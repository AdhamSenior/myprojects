using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintServiceApp
{
    using Common;
    using Common.Ext;
    using Common.Print;
    using DrivingLicenseIssueApp.Logic;
    using GID_CardApi;
    using ImageMagick;
    using Newtonsoft.Json;
    using PrinterQueueWatch;
    using Properties;

    public partial class PrintServiceAppForm : Form
    {
        NotifyIcon _trayIcon;
        MenuItem _miOpen;
        MenuItem _miExit;

        readonly List<ITask> _printTasks = new List<ITask>();
        Image _backgroundFront;
        Image _backgroundBack;
        ITask _currentJob;

        public string CurrentPrinter;
        public Printer CurrentProdLine;
        public bool IsDrivingLicense;
        public bool IsAutoStart;

        int _isPrinting;
        int _isPrinted;
        int _isDeleting;

        readonly PrinterMonitorComponent _printerMonitor;

        public delegate void InvokeDelegate();
        public delegate void InvokeStatusDelegate(string msg);

        public PrintServiceAppForm()
        {
            InitializeComponent();
            Text = Texts.PrintService;

            btnStart.Click += btnStart_Click;
            btnStop.Click += btnStop_Click;
            btnPrintTemplate.Click += btnPrintTemplate_Click;
            btnClearLog.Click += btnClearLog_Click;

            tiService.Tick += tiService_Tick;
            tiService.Interval = 10000;

            rtbLog.ReadOnly = true;
            cbProductionLine.DropDown += cbProductionLine_DropDown;
            cbProductionLine.SelectedIndexChanged += cbProductionLine_SelectedIndexChanged;

            cbPrinter.DropDown += cbPrinter_DropDown;
            cbPrinter.SelectedIndexChanged += cbPrinter_SelectedIndexChanged;

            _printerMonitor = new PrinterMonitorComponent();
            _printerMonitor.JobSet += PrinterMonitor_JobSet;
            _printerMonitor.JobDeleted += PrinterMonitor_JobDeleted;

            Closing += PrintServiceAppForm_Closing;

            CreateTrayIcon();
            ShowInTaskbar = false;
            WindowState = FormWindowState.Minimized;
        }
        void btnClearLog_Click(object sender, EventArgs e)
        {
            rtbLog.Clear();
        }
        void PrintServiceAppForm_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            WindowState = FormWindowState.Minimized;
        }
        void cbPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentPrinter = String.Empty;
            if (cbPrinter.SelectedIndex == -1)
                return;

            CurrentPrinter = cbPrinter.SelectedItem.ToString();
        }
        void cbPrinter_DropDown(object sender, EventArgs e)
        {
            if (cbPrinter.Items.Count != 0)
                cbPrinter.Items.Clear();

            PrinterExt.LoadPrinters(cbPrinter);
        }
        void cbProductionLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentProdLine = null;
            if (cbProductionLine.SelectedIndex == -1)
                return;

            CurrentProdLine = cbProductionLine.SelectedItem as Printer;
        }
        void cbProductionLine_DropDown(object sender, EventArgs e)
        {
            if (cbProductionLine.Items.Count != 0)
                cbProductionLine.Items.Clear();

            PrinterExt.LoadProductionLines(cbProductionLine);
        }
        void btnStart_Click(object sender, EventArgs e)
        {
            if (ReferenceEquals(CurrentProdLine, null) || String.IsNullOrEmpty(CurrentPrinter))
            {
                MessageBox.Show(Texts.NoPrinterSelected);
                return;
            }

            UserSettings.Instance.IsDrivingLicense = rbDrivingLicense.Checked;
            UserSettings.Instance.Load();
            Setting.ApiUrl = UserSettings.Instance.Items["ApiUrl"];
            Login();

            _printerMonitor.AddPrinter(CurrentPrinter);
            tiService.Enabled = true;
            rtbLog.AppendText(String.Format(Texts.PrintServiceStarted, DateTime.Now.ToString("G")));
            rtbLog.AppendText(Environment.NewLine);

            DisableUi();
        }
        void btnStop_Click(object sender, EventArgs e)
        {
            _printerMonitor.Disconnect();
            _printTasks.Clear();

            tiService.Enabled = false;
            rtbLog.AppendText(String.Format(Texts.PrintServiceStoped, DateTime.Now.ToString("G")));
            rtbLog.AppendText(Environment.NewLine);

            SaveLog();
            DisableUi();
        }

        void InvokeJobEnd()
        {
            var dt = DateTime.Now.ToString("G");
            rtbLog.AppendText(String.Format(Texts.JobStateChanged, dt, _currentJob.Id, Texts.Printed));
            rtbLog.AppendText(Environment.NewLine);
            tiService.Enabled = true;

            _printTasks.Remove(_currentJob);
            _currentJob = null;
        }
        void InvokeJobPrinting()
        {
            var dt = DateTime.Now.ToString("G");
            rtbLog.AppendText(String.Format(Texts.JobStateChanged, dt, _currentJob.Id, Texts.InPrint));
            rtbLog.AppendText(Environment.NewLine);
        }
        void InvokeJobCancel()
        {
            var dt = DateTime.Now.ToString("G");
            rtbLog.AppendText(String.Format(Texts.JobStateChanged, dt, _currentJob.Id, Texts.Cancel));
            rtbLog.AppendText(Environment.NewLine);
            tiService.Enabled = true;

            _currentJob = null;
        }
        void InvokePatchStatus(string msg)
        {
            var dt = DateTime.Now.ToString("G");
            rtbLog.AppendText(String.Format("{0} - {1}", dt, msg));
            rtbLog.AppendText(Environment.NewLine);
        }

        async void PrinterMonitor_JobDeleted(object sender, PrintJobEventArgs args)
        {
            if (args.PrintJob.StatusDescription == "Printed")
            {
                if (_isPrinted++ == 0 && args.PrintJob.Printed)
                {
                    UpdateStatus(_currentJob, Texts.Printed);
                    rtbLog.BeginInvoke(new InvokeDelegate(InvokeJobEnd));
                    var rs = await PatchStatus(_currentJob, Texts.Printed);
                    if (!String.IsNullOrEmpty(rs))
                        rtbLog.BeginInvoke(new InvokeStatusDelegate(InvokePatchStatus), new object[] { rs });
                }
            }
        }

        void PrinterMonitor_JobSet(object sender, PrintJobEventArgs args)
        {
            if (args.PrintJob.StatusDescription == "Printing")
            {
                if (_isPrinting++ == 0 && args.PrintJob.Printing)
                {
                    UpdateStatus(_currentJob, Texts.InPrint);
                    rtbLog.BeginInvoke(new InvokeDelegate(InvokeJobPrinting));
                }
            }

            if (String.IsNullOrEmpty(args.PrintJob.StatusDescription))
            {
                if (_isDeleting++ == 0 && args.PrintJob.Deleting && args.PrintJob.Deleted)
                {
                    UpdateStatus(_currentJob, Texts.Published);
                    rtbLog.BeginInvoke(new InvokeDelegate(InvokeJobCancel));
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode)
                return;

            if (!IsAutoStart)
                IsDrivingLicense = true;

            if (IsDrivingLicense)
                rbDrivingLicense.Checked = true;
            else
                rbVehicleLicense.Checked = true;
            DisableUi();

            UserSettings.Instance.IsDrivingLicense = rbDrivingLicense.Checked;
            UserSettings.Instance.Load();
            Setting.ApiUrl = UserSettings.Instance.Items["ApiUrl"];

            PrinterExt.LoadPrinters(cbPrinter);
            if (cbPrinter.Items.Count != 0)
                cbPrinter.SelectedIndex = cbPrinter.FindStringExact(UserSettings.Instance.Items["PrinterName"]);

            PrinterExt.LoadProductionLines(cbProductionLine);
            cbProductionLine.SelectedIndex = cbProductionLine.FindStringExact(UserSettings.Instance.Items["ProductionLine"]);
            if (IsAutoStart)
                btnStart_Click(btnStart, e);
        }
        void btnPrintTemplate_Click(object sender, EventArgs e)
        {
            if (ReferenceEquals(CurrentProdLine, null) || String.IsNullOrEmpty(CurrentPrinter))
            {
                MessageBox.Show(Texts.NoPrinterSelected);
                return;
            }

            var rs = CurrentProdLine.GetPrinterStatus();
            if (rs != "ready")
            {
                MessageBox.Show(String.Format(Texts.PrinterState, DateTime.Now.ToString("G"), rs));
                return;
            }

            if (rbDrivingLicense.Checked)
            {
                _backgroundFront = Image.FromFile("background\\DL_Front_V3-01.png");
                _backgroundBack = Image.FromFile("background\\DL_Back_V3-01.png");
            }
            else
            {
                _backgroundFront = Image.FromFile("background\\VL_Front_V3-01.png");
                _backgroundBack = Image.FromFile("background\\VL_Back_V3-01.png");
            }

            var frontImage = DriverLicenseGraphics.CreateCardTemplate(_backgroundFront);
            var backImage = DriverLicenseGraphics.CreateCardTemplate(_backgroundBack);
            IEnumerable<Image> pages = new[] { frontImage, backImage };
            try
            {
                Print(pages);
            }
            catch (Exception ex)
            {
                rtbLog.AppendText(ex.Message);
                rtbLog.AppendText(Environment.NewLine);
            }
        }
        void tiService_Tick(object sender, EventArgs e)
        {
            if (rtbLog.Lines.Count() > 50)
                SaveLog();

            var dt = DateTime.Now.ToString("G");
            rtbLog.AppendText(String.Format("{0} - {1}", dt, Texts.Line));
            rtbLog.AppendText(Environment.NewLine);

            var rs = CurrentProdLine.GetPrinterStatus();
            if (rs != "ready")
            {
                var pos = CurrentProdLine.GetPrinterPosition();
                if (!String.IsNullOrEmpty(pos))
                {
                    rtbLog.AppendText(String.Format(Texts.PrinterState, dt, pos));
                    rtbLog.AppendText(Environment.NewLine);
                    return;
                }

                rtbLog.AppendText(String.Format(Texts.PrinterState, dt, rs));
                rtbLog.AppendText(Environment.NewLine);
                return;
            }

            if (!ReferenceEquals(_currentJob, null))
                return;

            if (_printTasks.Count == 0)
            {
                LoadPrintTasks();
                rtbLog.AppendText(String.Format(Texts.LoadPrintJobs, dt, _printTasks.Count));
                rtbLog.AppendText(Environment.NewLine);
            }
            if (_printTasks.Count == 0)
                return;

            _currentJob = _printTasks[0];
            try
            {
                _isPrinting = 0;
                _isPrinted = 0;
                _isDeleting = 0;
                Print(_currentJob);
            }
            catch (Exception ex)
            {
                rtbLog.AppendText(ex.Message);
                rtbLog.AppendText(Environment.NewLine);
            }
        }

        void SaveLog()
        {
            var dt = DateTime.Now;
            var txt = rtbLog.Lines.ToString(Environment.NewLine);
            var fileName = String.Format("Log_{0}.txt", dt.ToString("yyyyMMdd"));
            var log = new StreamWriter(Path.Combine(Setting.AppDirectoryPath, fileName), true);
            log.WriteLine(txt);
            log.Flush();
            log.Close();

            rtbLog.Clear();
        }
        void LoadPrintTasks()
        {
            _printTasks.Clear();
            if (rbDrivingLicense.Checked)
                PrintQueue.FillByDriverLicense(_printTasks);
            //else
            //    DbHelper.FillByVehicleLicense(_csb, _printTasks);
        }
        void UpdateStatus(ITask obj, string state)
        {
            var suc = obj.UpdateStatus(state);
            if (!suc)
            {
                rtbLog.AppendText(obj.Error);
                rtbLog.AppendText(Environment.NewLine);
            }
        }
        void Print(IEnumerable<Image> pages)
        {
            var pr = new PrinterResolution
            {
                Kind = PrinterResolutionKind.Custom,
                X = 300,
                Y = 300
            };

            var ps = new PaperSize
            {
                PaperName = "SC",
                Width = 221,
                Height = 345,
                RawKind = 120
            };

            var pd = new PrintDocument
            {
                PrinterSettings = { PrinterName = CurrentPrinter, Duplex = Duplex.Vertical },
                DefaultPageSettings =
                {
                    PaperSize = ps,
                    PrinterResolution = pr,
                    Landscape = true,
                    Margins = new Margins(0, 0, 0, 0)
                }
            };

            var jobId = String.Empty;
            if (!ReferenceEquals(_currentJob, null))
                jobId = _currentJob.Id.ToSafeTrimmedString();
            if (!String.IsNullOrEmpty(jobId))
                pd.DocumentName = jobId;

            var pageNumber = 1;
            var enumerator = pages.GetEnumerator();
            enumerator.MoveNext();

            pd.PrintPage += (s, a) =>
            {
                var i = enumerator.Current;
                var rect = new Rectangle(10, 0, 1014, 639);
                if (pageNumber % 2 == 0)
                    rect = new Rectangle(10, 10, 1014, 639);

                a.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                a.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                a.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                a.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                a.Graphics.PageUnit = GraphicsUnit.Pixel;
                a.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                a.Graphics.Clear(Color.Transparent);
                a.Graphics.DrawImage(i, rect);

                pageNumber++;
                var moveNext = enumerator.MoveNext();
                a.HasMorePages = moveNext;
                if (!moveNext)
                    enumerator.Dispose();
            };

            pd.BeginPrint += pd_BeginPrint;
            pd.Print();
        }
        void pd_BeginPrint(object sender, PrintEventArgs e)
        {
            if (ReferenceEquals(_currentJob, null))
                return;

            rtbLog.AppendText(String.Format(Texts.StartPrintJob, DateTime.Now.ToString("G"), _currentJob.Id));
            rtbLog.AppendText(Environment.NewLine);
        }

        void DisableUi()
        {
            cbPrinter.Enabled = !tiService.Enabled;
            cbProductionLine.Enabled = !tiService.Enabled;
            rbDrivingLicense.Enabled = !tiService.Enabled;
            rbVehicleLicense.Enabled = !tiService.Enabled;

            btnStart.Enabled = !tiService.Enabled;
            btnStop.Enabled = tiService.Enabled;
            btnPrintTemplate.Enabled = !tiService.Enabled;
        }
        void CreateTrayIcon()
        {
            if (!ReferenceEquals(_trayIcon, null))
                return;

            _trayIcon = new NotifyIcon
            {
                Icon = Resources.Icon,
                Text = Texts.PrintService,
                ContextMenu = new ContextMenu()
            };

            _miOpen = new MenuItem(Texts.Open);
            _miOpen.Click += _miOpen_Click;
            _miExit = new MenuItem(Texts.Exit);
            _miExit.Click += _miExit_Click;
            _trayIcon.ContextMenu.MenuItems.Add(_miOpen);
            _trayIcon.ContextMenu.MenuItems.Add(_miExit);
            _trayIcon.Visible = true;
        }
        void _miExit_Click(object sender, EventArgs e)
        {
            _printerMonitor.Disconnect();
            _trayIcon.Visible = false;

            SaveLog();
            Close();
            Application.Exit();
        }
        void _miOpen_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                WindowState = FormWindowState.Normal;
            Activate();
        }

        async void Print(ITask obj)
        {
            tiService.Enabled = false;

            var rs = CurrentProdLine.GetPrinterStatus();
            if (rs != "ready")
                return;

            var msg = CurrentProdLine.SetPrinterPosition("ContactlessEncoderPosition");
            if (msg != "true")
            {
                rtbLog.AppendText(String.Format(Texts.SetPrinterPositionError, DateTime.Now.ToString("G"), msg));
                rtbLog.AppendText(Environment.NewLine);
                return;
            }

            if (rbDrivingLicense.Checked)
            {
                if (!await EncodeDrivingLicense(obj))
                    return;
            }
            CurrentProdLine.SetPrinterPosition("PrintPosition");

            var frontImage = obj.CreateFrontCard();
            var backImage = obj.CreateBackCard();
            IEnumerable<Bitmap> pages = new[] { frontImage, backImage };
            Print(pages);
        }
        async Task<bool> EncodeDrivingLicense(ITask obj)
        {
            var o = (DrivingLicense)obj;
            var holderPhoto = o.Holder.PhotoData;
            if (!String.IsNullOrEmpty(holderPhoto))
            {
                var photoData = Convert.FromBase64String(holderPhoto);
                using (var image = new MagickImage(photoData))
                {
                    image.Quality = 80;
                    image.Resize(275, 0);
                    o.Holder.PhotoData = image.ToBase64(MagickFormat.Jpeg);
                }
            }

            var holderSign = o.Holder.SignatureData;
            if (!String.IsNullOrEmpty(holderSign))
            {
                var signData = Convert.FromBase64String(holderSign);
                using (var image = new MagickImage(signData))
                {
                    image.Quality = 90;
                    image.Resize(165, 0);
                    image.BackgroundColor = MagickColors.White;
                    image.ColorAlpha(MagickColors.White);
                    o.Holder.SignatureData = image.ToBase64(MagickFormat.Jpeg);
                }
            }

            var jss = new JsonSerializerSettings
            {
                ContractResolver = new DlPostContractResolver("card"),
                DateTimeZoneHandling = DateTimeZoneHandling.Local,
                DateFormatString = "yyyyMMdd"
            };
            var json = JsonConvert.SerializeObject(o, Formatting.Indented, jss);

            int rsCode;
            string cardSn;
            try
            {
                rsCode = await CardApi.WriteDriverInfo(json);
                cardSn = await CardApi.ReadUUidAsync();
            }
            catch
            {
                CurrentProdLine.SetPrinterPosition("RejectPosition");
                rtbLog.AppendText(String.Format(Texts.CardEncodingError, DateTime.Now.ToString("G")));
                rtbLog.AppendText(Environment.NewLine);
                return false;
            }

            if (rsCode != 0)
            {
                CurrentProdLine.SetPrinterPosition("RejectPosition");
                rtbLog.AppendText(String.Format(Texts.CardEncodingError, DateTime.Now.ToString("G")));
                rtbLog.AppendText(Environment.NewLine);
                return false;
            }

            o.CardSn = cardSn;
            o.Holder.PhotoData = holderPhoto;
            o.Holder.SignatureData = holderSign;
            return true;
        }
        async void Login()
        {
            User.Instance.Login = "printer";
            User.Instance.Password = "printer";
            var rs = await User.Instance.PostLogin();
            if (rs.StatusCode != HttpStatusCode.OK)
            {
                var sb = new StringBuilder();
                sb.AppendLine(String.Format(ErrorTexts.ServerAuthenticationError, rs.StatusCode));
                var error = ApiResponse.ParseError(rs.Content);
                if (!String.IsNullOrEmpty(error))
                    sb.AppendLine(error);

                rtbLog.AppendText(sb.ToString());
                return;
            }

            var authData = ApiResponse.ParseAuth(rs.Content);
            if (authData.ContainsKey("token"))
                User.Instance.AuthToken = authData["token"].ToSafeTrimmedString();
        }
        async Task<string> PatchStatus(ITask task, string status)
        {
            var json = String.Empty;
            var cardSn = String.Empty;
            if (rbDrivingLicense.Checked)
            {
                var dl = (DrivingLicense)task;
                dl.Status = status;
                json = dl.GetStatusJson();
                cardSn = dl.CardSn;
            }

            var errors = String.Empty;
            var url = String.Format("{0}/api/v1/cards/" + cardSn + "/status", Setting.ApiUrl);
            var rs = await Server.PatchData(json, url);
            if (rs.StatusCode == HttpStatusCode.OK)
            {
                var error = ApiResponse.ParseError(rs.Content);
                if (!String.IsNullOrEmpty(error))
                    errors = error;
            }
            else
                errors = ErrorTexts.FailedToSendDataToServer;

            if (!String.IsNullOrEmpty(errors))
            {
                // add to cache
            }
            return errors;
        }
    }
}
