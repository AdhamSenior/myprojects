using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace DrivingLicenseIssueApp
{
    using Common;
    using EOSDigital.API;
    using EOSDigital.SDK;

    public partial class PhotoViewerForm : Form
    {
        public Bitmap Photo { get; set; }

        bool _isInitCanonApi;
        CanonAPI _canonApi;
        Camera _currentCamera;
        List<Camera> _listOfCameras;

        int _lvWidth;
        int _lvHeight;

        Bitmap _bpFrame;

        public PhotoViewerForm()
        {
            InitializeComponent();

            _isInitCanonApi = false;
            _lvWidth = pbLiveView.Width;
            _lvHeight = pbLiveView.Height;

            lblCamera.Text = TextUI.AvailableCameras;
            kbtnGetCameras.Text = TextUI.Fill;
            kbtnSession.Text = TextUI.Start;
            kbtnCapturePhoto.Text = TextUI.CapturePhoto;
            kbtnFocusFar.Text = TextUI.FocusFar;
            kbtnFocusNear.Text = TextUI.FocusNear;

            Closing += PhotoViewerForm_Closing;

            kbtnGetCameras.Click += kbtnGetCameras_Click;
            kbtnSession.Click += kbtnSession_Click;
            kbtnCapturePhoto.Click += kbtnCapturePhoto_Click;
            kbtnFocusFar.Click += kbtnFocusFar_Click;
            kbtnFocusNear.Click += kbtnFocusNear_Click;

            lvCamera.SelectedIndexChanged += lvCamera_SelectedIndexChanged;
            pbLiveView.Paint += pbLiveView_Paint;
            pbLiveView.SizeChanged += pbLiveView_SizeChanged;

            kcbIso.SelectedIndexChanged += kcbIso_SelectedIndexChanged;
            kcbAv.SelectedIndexChanged += kcbAv_SelectedIndexChanged;
            kcbTv.SelectedIndexChanged += kcbTv_SelectedIndexChanged;
        }
        void kbtnFocusNear_Click(object sender, EventArgs e)
        {
            if (ReferenceEquals(_currentCamera, null))
                return;

            _currentCamera.SendCommand(CameraCommand.DriveLensEvf, (int)DriveLens.Near2);
        }
        void kbtnFocusFar_Click(object sender, EventArgs e)
        {
            if (ReferenceEquals(_currentCamera, null))
                return;

            _currentCamera.SendCommand(CameraCommand.DriveLensEvf, (int)DriveLens.Far2);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode)
                return;

            GetAvailableCameras();
        }
        void kcbTv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kcbTv.SelectedIndex == -1)
                return;

            var tv = kcbTv.SelectedItem as CameraValue;
            if (!ReferenceEquals(tv, null))
                _currentCamera.SetSetting(PropertyID.Tv, tv.IntValue);
        }
        void kcbAv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kcbAv.SelectedIndex == -1)
                return;

            var av = kcbAv.SelectedItem as CameraValue;
            if (!ReferenceEquals(av, null))
                _currentCamera.SetSetting(PropertyID.Av, av.IntValue);
        }
        void kcbIso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kcbIso.SelectedIndex == -1)
                return;

            var iso = kcbIso.SelectedItem as CameraValue;
            if (!ReferenceEquals(iso, null))
                _currentCamera.SetSetting(PropertyID.ISO, iso.IntValue);
        }
        void kbtnCapturePhoto_Click(object sender, EventArgs e)
        {
            if (ReferenceEquals(_currentCamera, null) || !_currentCamera.IsLiveViewOn)
            {
                MessageBox.Show(ErrorTexts.SelectCamera);
                return;
            }

            try
            {
                _currentCamera.TakePhoto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void pbLiveView_SizeChanged(object sender, EventArgs e)
        {
            _lvWidth = pbLiveView.Width;
            _lvHeight = pbLiveView.Height;
            pbLiveView.Invalidate();
        }
        void pbLiveView_Paint(object sender, PaintEventArgs e)
        {
            if (ReferenceEquals(_currentCamera, null) || !_currentCamera.SessionOpen)
                return;

            if (!_currentCamera.IsLiveViewOn)
            {
                e.Graphics.Clear(BackColor);
                return;
            }

            if (ReferenceEquals(_bpFrame, null))
                return;

            var viewRatio = _lvWidth / (float)_lvHeight;
            var frameRatio = _bpFrame.Width / (float)_bpFrame.Height;

            int width;
            int height;
            if (viewRatio < frameRatio)
            {
                width = _lvWidth;
                height = (int)(_lvWidth / frameRatio);
            }
            else
            {
                width = (int)(_lvHeight * frameRatio);
                height = _lvHeight;
            }

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImage(_bpFrame, 0, 0, width, height);
        }
        void kbtnGetCameras_Click(object sender, EventArgs e)
        {
            GetAvailableCameras();
        }
        void kbtnSession_Click(object sender, EventArgs e)
        {
            if (ReferenceEquals(_currentCamera, null))
            {
                MessageBox.Show(ErrorTexts.SelectCamera);
                return;
            }

            if (_currentCamera.SessionOpen)
                StopSession();
            else
            {
                StartSession();
                _currentCamera.SetSetting(PropertyID.SaveTo, (int)SaveTo.Host);
                _currentCamera.SetCapacity(4096, int.MaxValue);
            }
        }
        void lvCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentCamera = null;
            if (_listOfCameras.Count == 0 || lvCamera.SelectedIndex == -1)
                return;

            _currentCamera = _listOfCameras[lvCamera.SelectedIndex];
        }
        void PhotoViewerForm_Closing(object sender, CancelEventArgs e)
        {
            if (ReferenceEquals(_canonApi, null))
            {
                _isInitCanonApi = false;
                return;
            }

            try
            {
                if (!ReferenceEquals(_currentCamera, null))
                    _currentCamera.Dispose();
                _canonApi.Dispose();
                _isInitCanonApi = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void _currentCamera_LiveViewUpdated(Camera sender, Stream img)
        {
            _bpFrame = new Bitmap(img);
            pbLiveView.Invalidate();
        }
        void _currentCamera_StateChanged(Camera sender, StateEventID eventId, int parameter)
        {
            try
            {
                if (eventId == StateEventID.Shutdown && _isInitCanonApi)
                    Invoke((Action)StopSession);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void _currentCamera_DownloadReady(Camera sender, DownloadInfo info)
        {
            try
            {
                string dir = null;
                Invoke((Action)delegate { dir = Setting.PhotoFolderPath; });
                sender.DownloadFile(info, dir);

                var path = Path.Combine(dir, info.FileName);
                var img = Image.FromFile(path);
                Photo = new Bitmap(img);

                Invoke((Action)StopSession);
                Invoke((Action)CloseForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void GetAvailableCameras()
        {
            InitCanonApi();

            lvCamera.Items.Clear();
            _listOfCameras = _canonApi.GetCameraList();
            foreach (var cam in _listOfCameras)
                lvCamera.Items.Add(cam.DeviceName);

            if (lvCamera.Items.Count != 0)
            {
                var cameraName = Properties.Settings.Default.CameraName;
                var itemIndex = lvCamera.FindString(cameraName);
                if (itemIndex != -1)
                    lvCamera.SelectedIndex = itemIndex;
            }
        }
        void InitCanonApi()
        {
            if (_isInitCanonApi)
                return;

            try
            {
                _canonApi = new CanonAPI();
                _isInitCanonApi = true;
            }
            catch (DllNotFoundException)
            {
                MessageBox.Show(ErrorTexts.CanonSdkFilesNotFound);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void StartSession()
        {
            if (ReferenceEquals(_currentCamera, null))
                return;

            _currentCamera.OpenSession();
            _currentCamera.LiveViewUpdated += _currentCamera_LiveViewUpdated;
            _currentCamera.StateChanged += _currentCamera_StateChanged;
            _currentCamera.DownloadReady += _currentCamera_DownloadReady;
            //_currentCamera.ProgressChanged += _currentCamera_ProgressChanged;

            StartLiveView();
            kbtnSession.Text = TextUI.Stop;

            kcbIso.Items.Clear();
            var isoList = _currentCamera.GetSettingsList(PropertyID.ISO);
            foreach (var i in isoList)
                kcbIso.Items.Add(i);

            kcbAv.Items.Clear();
            var avList = _currentCamera.GetSettingsList(PropertyID.Av);
            foreach (var a in avList)
                kcbAv.Items.Add(a);

            kcbTv.Items.Clear();
            var tvList = _currentCamera.GetSettingsList(PropertyID.Tv);
            foreach (var t in tvList)
                kcbTv.Items.Add(t);

            SetDefaultSettings();
        }
        void StopSession()
        {
            if (ReferenceEquals(_currentCamera, null))
                return;

            _currentCamera.CloseSession();
            StopLiveView();

            kbtnSession.Text = TextUI.Start;
        }
        void CloseForm()
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        void StartLiveView()
        {
            if (ReferenceEquals(_currentCamera, null) || _currentCamera.IsLiveViewOn)
                return;

            try
            {
                _currentCamera.StartLiveView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void StopLiveView()
        {
            if (ReferenceEquals(_currentCamera, null) || !_currentCamera.IsLiveViewOn)
                return;

            try
            {
                _currentCamera.StopLiveView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void SetDefaultSettings()
        {
            if (kcbIso.Items.Count != 0)
                kcbIso.SelectedIndex = kcbIso.FindStringExact("ISO 800");

            if (kcbAv.Items.Count != 0)
                kcbAv.SelectedIndex = kcbAv.FindStringExact("5.6");

            if (kcbTv.Items.Count != 0)
                kcbTv.SelectedIndex = kcbTv.FindStringExact("1/160");
        }
    }
}
