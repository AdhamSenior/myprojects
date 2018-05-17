using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace DrivingLicenseIssueApp
{
    using Common;
    using Common.Ext;
    using ComponentFactory.Krypton.Toolkit;
    using Equin.ApplicationFramework;
    using Logic;
    using Newtonsoft.Json;

    public partial class DrivingLicenseListForm : Form
    {
        const double LeftSideRatio = 0.8;
        const int ValidityPeriod = 10;

        public DrivingLicenseListForm()
        {
            InitializeComponent();

            Text = TextUI.DLP;
            khgLeftSide.ValuesPrimary.Heading = TextUI.ListDL;
            khgRightSide.ValuesPrimary.Heading = TextUI.View;
            tsmSettings.Text = TextUI.Settings;
            tsmStartPrintService.Text = TextUI.StartPrintService;

            colCardNumber.HeaderText = TextUI.CardNumber;
            colLastName.HeaderText = TextUI.LastName;
            colFirstName.HeaderText = TextUI.FirstName;
            colMiddleName.HeaderText = TextUI.MiddleName;
            colDateOfBirth.HeaderText = TextUI.DateOfBirth;
            colPlaceOfBirth.HeaderText = TextUI.PlaceOfBirth;
            colStatus.HeaderText = TextUI.Status;

            kbtnNew.Text = TextUI.New;
            kbtnPrint.Text = TextUI.Print;
            kbtnTakePhoto.Text = TextUI.TakePhoto;
            kbtnCaptureSignature.Text = TextUI.CaptureSignature;

            kdgvData.AutoGenerateColumns = false;
            kdgvData.DataSource = bsDL;

            Resize += DrivingLicenseListForm_Resize;
            btnRightSideHeader.Click += btnRightSideHeader_Click;
            kbtnNew.Click += kbtnNew_Click;
            kbtnTakePhoto.Click += kbtnTakePhoto_Click;
            kbtnCaptureSignature.Click += kbtnCaptureSignature_Click;
            kbtnPrint.Click += kbtnPrint_Click;

            kdgvData.SelectionChanged += kdgvData_SelectionChanged;
            kdgvData.CellDoubleClick += kdgvData_CellDoubleClick;

            pcPage.CurrentPageChanged += pcPage_CurrentPageChanged;
            tsmSettings.Click += tsmSettings_Click;
            tsmStartPrintService.Click += tsmStartPrintService_Click;
        }

        void tsmStartPrintService_Click(object sender, EventArgs e)
        {
            var set = UserSettings.Instance.Items;
            if (String.IsNullOrEmpty(set["PrinterName"]) || String.IsNullOrEmpty(set["ProductionLine"]))
            {
                MessageBox.Show(ErrorTexts.PrintSettingsNotSpecified);
                return;
            }

            var path = Path.Combine(Setting.AppDirectoryPath, "PrintServiceApp.exe");
            if (!File.Exists(path))
            {
                MessageBox.Show(ErrorTexts.FailedInitializePrintApp);
                return;
            }

            var proc = Process.GetProcessesByName("PrintServiceApp");
            if (proc.Length != 0 && !ReferenceEquals(proc[0], null))
            {
                MessageBox.Show(TextUI.PrintServiceIsStarted);
                return;
            }

            using (var p = new Process())
            {
                p.StartInfo.FileName = path;
                p.StartInfo.Arguments = "dl";
                var suc = p.Start();
                if (suc)
                    MessageBox.Show(TextUI.PrintServiceSuccessfullyStarted);
            }
        }
        void tsmSettings_Click(object sender, EventArgs e)
        {
            var frm = new SettingForm();
            frm.ShowDialog();
        }
        void pcPage_CurrentPageChanged(object sender, EventArgs e)
        {
            FillDataGrid();
            UpdateView();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode)
                return;

            pcPage.PageSize = 25;
            pcPage.CurrentPage = 0;
            FillDataGrid();
            UpdateView();
        }
        void kbtnPrint_Click(object sender, EventArgs e)
        {
            var cr = kdgvData.CurrentRow;
            if (ReferenceEquals(cr, null))
                return;

            var objView = (ObjectView<DrivingLicense>)cr.DataBoundItem;
            var obj = objView.Object;
            if (String.IsNullOrEmpty(obj.Holder.PhotoData))
            {
                MessageBox.Show(String.Format(ErrorTexts.FieldIsEmpty, TextUI.Photo));
                return;
            }

            if (String.IsNullOrEmpty(obj.Holder.SignatureData))
            {
                MessageBox.Show(String.Format(ErrorTexts.FieldIsEmpty, TextUI.Signature));
                return;
            }

            if (obj.Status != TextUI.InWait)
                return;

            if (!ReferenceEquals(obj.CategoryList, null) && obj.CategoryList.Length != 0)
            {
                var jss = new JsonSerializerSettings
                {
                    DateTimeZoneHandling = DateTimeZoneHandling.Local,
                    DateFormatString = "yyyyMMdd"
                };
                var json = JsonConvert.SerializeObject(obj.CategoryList, Formatting.Indented, jss);
                obj.Category = json;
            }

            PostPublishedStatus(obj);
        }
        void kbtnCaptureSignature_Click(object sender, EventArgs e)
        {
            //pbSignature.Image = null;

            var cr = kdgvData.CurrentRow;
            if (ReferenceEquals(cr, null))
                return;

            var frmName = String.Format("{0}: {1}", TextUI.Signature, lblOwnerName.Text);
            var signFrm = new EditSignatureForm { Text = frmName, ShowInTaskbar = false };
            var dr = signFrm.ShowDialog();
            if (dr != DialogResult.OK)
                return;

            var objView = (ObjectView<DrivingLicense>)cr.DataBoundItem;
            var obj = objView.Object;
            obj.Signature = signFrm.SignImage;
            PostSignature(obj);
        }
        void kbtnTakePhoto_Click(object sender, EventArgs e)
        {
            //pbPhoto.Image = null;

            var cr = kdgvData.CurrentRow;
            if (ReferenceEquals(cr, null))
                return;

            var frmName = String.Format("{0}: {1}", TextUI.Photo, lblOwnerName.Text);
            var photoFrm = new PhotoViewerForm { Text = frmName, ShowInTaskbar = false };
            var dr = photoFrm.ShowDialog();
            if (dr != DialogResult.OK)
                return;

            var editFrm = new EditPhotoForm { Text = frmName, Photo = photoFrm.Photo, ShowInTaskbar = false };
            dr = editFrm.ShowDialog();
            if (dr != DialogResult.OK)
                return;

            var objView = (ObjectView<DrivingLicense>)cr.DataBoundItem;
            var obj = objView.Object;
            obj.Photo = editFrm.CropPhoto;
            PostPhoto(obj);
        }
        void kdgvData_SelectionChanged(object sender, EventArgs e)
        {
            UpdateView();
        }
        void kdgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var cr = kdgvData.CurrentRow;
            if (ReferenceEquals(cr, null))
                return;

            var objView = (ObjectView<DrivingLicense>)cr.DataBoundItem;
            var dl = objView.Object;
            var frm = new DrivingLicenseObjectForm { Object = dl, ShowInTaskbar = false };
            var dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
                FillDataGrid();
        }
        void kbtnNew_Click(object sender, EventArgs e)
        {
            var holder = new HolderInfo
            {
                DateOfBirth = DrivingLicense.MinDate
            };

            var dl = new DrivingLicense
            {
                Id = 0,
                Holder = holder,
                DateOfIssue = DateTime.Now,
                DateOfExpiry = DateTime.Now.AddYears(ValidityPeriod),
                Status = TextUI.InWait
            };

            var frm = new DrivingLicenseObjectForm { Object = dl, ShowInTaskbar = false };
            var dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
                FillDataGrid();
        }
        void DrivingLicenseListForm_Resize(object sender, EventArgs e)
        {
            int widthLeftSide;
            if (kscMain.FixedPanel == FixedPanel.None)
                widthLeftSide = (int)(kscMain.Width * LeftSideRatio);
            else
            {
                var newWidth = khgRightSide.PreferredSize.Width;
                widthLeftSide = kscMain.Width - newWidth - kscMain.SplitterWidth;
            }

            kscMain.SuspendLayout();
            kscMain.Panel1MinSize = widthLeftSide;
            kscMain.SplitterDistance = widthLeftSide - kscMain.SplitterWidth;
            kscMain.ResumeLayout();
        }
        void btnRightSideHeader_Click(object sender, EventArgs e)
        {
            UpdateRightSideSize();
        }
        void UpdateRightSideSize()
        {
            kscMain.SuspendLayout();
            if (kscMain.FixedPanel == FixedPanel.None)
            {
                var newWidth = khgRightSide.PreferredSize.Height;
                kscMain.FixedPanel = FixedPanel.Panel2;
                kscMain.Panel2MinSize = 0;
                kscMain.SplitterDistance = kscMain.Width - newWidth - kscMain.SplitterWidth;

                khgRightSide.Panel.Width = newWidth;
                khgRightSide.HeaderPositionPrimary = VisualOrientation.Right;
                btnRightSideHeader.Edge = PaletteRelativeEdgeAlign.Near;
            }
            else
            {
                var widthLeftSide = (int)(kscMain.Width * LeftSideRatio);
                kscMain.FixedPanel = FixedPanel.None;
                kscMain.Panel1MinSize = widthLeftSide;
                kscMain.SplitterDistance = widthLeftSide - kscMain.SplitterWidth;

                khgRightSide.HeaderPositionPrimary = VisualOrientation.Top;
                btnRightSideHeader.Edge = PaletteRelativeEdgeAlign.Far;
            }
            kscMain.ResumeLayout();
        }
        void UpdateView()
        {
            lblOwnerName.Text = String.Empty;
            pbPhoto.Image = null;
            pbSignature.Image = null;

            var cr = kdgvData.CurrentRow;
            if (!ReferenceEquals(cr, null))
            {
                var objView = (ObjectView<DrivingLicense>)cr.DataBoundItem;
                var obj = objView.Object;
                lblOwnerName.Text = obj.Holder.GetFullName();

                if (ReferenceEquals(obj.Photo, null))
                    obj.Photo = GraphicsHelper.GetImageFromBase64String(obj.Holder.PhotoData);
                if (!ReferenceEquals(obj.Photo, null))
                    pbPhoto.Image = GraphicsHelper.GetStretchedImage(obj.Photo, pbPhoto.Height, pbPhoto.Width);

                if (ReferenceEquals(obj.Signature, null))
                    obj.Signature = GraphicsHelper.GetImageFromBase64String(obj.Holder.SignatureData);
                if (!ReferenceEquals(obj.Signature, null))
                    pbSignature.Image = GraphicsHelper.GetStretchedImage(obj.Signature, pbSignature.Height, pbSignature.Width);

                var isEnabled = (obj.Status == TextUI.InWait);
                kbtnTakePhoto.Enabled = isEnabled;
                kbtnCaptureSignature.Enabled = isEnabled;
                kbtnPrint.Enabled = isEnabled;
            }

            pbPhoto.Refresh();
            pbSignature.Refresh();
        }
        async void FillDataGrid()
        {
            kdgvData.EndEdit();
            var newSrc = new BindingSource();
            var curSrc = (BindingSource)kdgvData.DataSource;
            kdgvData.DataSource = newSrc;
            if (!ReferenceEquals(curSrc.DataSource, null))
            {
                var v = (BindingListView<DrivingLicense>)curSrc.DataSource;
                v.DataSource = new List<DrivingLicense>();
            }
            //curSrc.Clear();

            var wait = new WaitForm { Status = TextUI.RetrievingData, OwnerForm = this };
            wait.Show();
            var data = await DrivingLicense.GetDrivingLicenses((int)pcPage.CurrentPage, (int)pcPage.PageSize);
            wait.Close();
            wait.Dispose();
            if (ReferenceEquals(data, null))
                MessageBox.Show(ErrorTexts.FailedToGetDataFromServer);
            else
            {
                pcPage.TotalRecords = data.TotalNumber;
                var view = new BindingListView<DrivingLicense>(data.Items);
                curSrc.DataSource = view; //data.Items;
            }

            kdgvData.DataSource = curSrc;
            newSrc.Dispose();
            kdgvData.Invalidate();
        }
        async void PostPhoto(DrivingLicense obj)
        {
            var wait = new WaitForm { Status = TextUI.SavingData, OwnerForm = this };
            wait.Show();
            var rs = await obj.PostPhoto();
            wait.Close();
            wait.Dispose();

            if (rs.StatusCode == HttpStatusCode.OK)
            {
                var error = ApiResponse.ParseError(rs.Content);
                if (!String.IsNullOrEmpty(error))
                    MessageBox.Show(error);
                else
                {
                    pbPhoto.Image = GraphicsHelper.GetStretchedImage(obj.Photo, pbPhoto.Height, pbPhoto.Width);
                    pbPhoto.Refresh();
                }
            }
            else
                MessageBox.Show(ErrorTexts.FailedToSendDataToServer);
            FillDataGrid();
        }
        async void PostSignature(DrivingLicense obj)
        {
            var wait = new WaitForm { Status = TextUI.SavingData, OwnerForm = this };
            wait.Show();
            var rs = await obj.PostSignature();
            wait.Close();
            wait.Dispose();

            if (rs.StatusCode == HttpStatusCode.OK)
            {
                var error = ApiResponse.ParseError(rs.Content);
                if (!String.IsNullOrEmpty(error))
                    MessageBox.Show(error);
                else
                {
                    pbSignature.Image = GraphicsHelper.GetStretchedImage(obj.Signature, pbSignature.Height, pbSignature.Width);
                    pbSignature.Refresh();
                }
            }
            else
                MessageBox.Show(ErrorTexts.FailedToSendDataToServer);
            FillDataGrid();
        }
        async void PostPublishedStatus(DrivingLicense obj)
        {
            kbtnPrint.Enabled = false;

            obj.Status = TextUI.Published;
            var wait = new WaitForm { Status = TextUI.SavingData, OwnerForm = this };
            wait.Show();
            var rs = await obj.PostPublishedStatus();
            wait.Close();
            wait.Dispose();

            if (rs.StatusCode == HttpStatusCode.OK)
            {
                var error = ApiResponse.ParseError(rs.Content);
                if (!String.IsNullOrEmpty(error))
                    MessageBox.Show(error);
                else
                {
                    var suc = obj.SendToPrint();
                    MessageBox.Show(!suc ? DrivingLicense.LastError : TextUI.DataTransferredToPrint);
                }
            }
            else
                MessageBox.Show(ErrorTexts.FailedToSendDataToServer);
            FillDataGrid();
        }
    }
}