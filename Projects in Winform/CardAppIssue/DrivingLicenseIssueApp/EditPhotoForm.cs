using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DrivingLicenseIssueApp
{
    using Common;

    public sealed partial class EditPhotoForm : Form
    {
        public Bitmap Photo { get; set; }
        public Bitmap CropPhoto { get; set; }

        int _cropX;
        int _cropY;
        float _scaleFactor;
        readonly Pen _cropPen;
        Rectangle _cropArea = new Rectangle(0, 0, 260, 325);
        bool _canDraw;
        bool _isCroped;

        public EditPhotoForm()
        {
            InitializeComponent();

            Load += EditPhotoForm_Load;
            kbtnCrop.Text = TextUI.Crop;
            kbtnRefresh.Text = TextUI.Refresh;
            kbtnReady.Text = TextUI.Ready;

            Cursor = Cursors.Cross;
            _cropPen = new Pen(Color.Red, 2) { DashStyle = DashStyle.Dash };

            pbPhoto.MouseClick += pbPhoto_MouseClick;
            pbPhoto.MouseMove += pbPhoto_MouseMove;
            pbPhoto.MouseDown += pbPhoto_MouseDown;
            pbPhoto.MouseUp += pbPhoto_MouseUp;

            kbtnCrop.Click += kbtnCrop_Click;
            kbtnRefresh.Click += kbtnRefresh_Click;
            kbtnReady.Click += kbtnReady_Click;
        }

        void pbPhoto_MouseUp(object sender, MouseEventArgs e)
        {
            _canDraw = false;
        }

        void pbPhoto_MouseDown(object sender, MouseEventArgs e)
        {
            if (_cropX == 0 && _cropY == 0)
                return;

            if (e.Button == MouseButtons.Left)
                _canDraw = true;
        }

        void pbPhoto_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_canDraw || e.Button != MouseButtons.Left)
                return;

            pbPhoto.Refresh();

            var diffX = _cropArea.Width / 2;
            var maxX = pbPhoto.Width - _cropArea.Width - 5;
            _cropArea.X = e.X > diffX ? Math.Min(e.X - diffX, maxX) : 1;

            var diffY = _cropArea.Height / 2;
            var maxY = pbPhoto.Height - _cropArea.Height - 5;
            _cropArea.Y = e.Y > diffY ? Math.Min(e.Y - diffY, maxY) : 1;

            pbPhoto.CreateGraphics().DrawRectangle(_cropPen, _cropArea);
        }
        void kbtnRefresh_Click(object sender, EventArgs e)
        {
            _isCroped = false;
            LoadPhoto(Photo);
            DrawCropArea();
        }
        void kbtnReady_Click(object sender, EventArgs e)
        {
            if (!_isCroped)
                Crop();

            if (ReferenceEquals(CropPhoto, null))
            {
                MessageBox.Show(ErrorTexts.PhotoProcessingNotCompleted);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
        void kbtnCrop_Click(object sender, EventArgs e)
        {
            Crop();
        }
        void pbPhoto_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            _cropX = e.X;
            _cropY = e.Y;

            var diffX = _cropArea.Width / 2;
            var maxCropX = pbPhoto.Width - _cropArea.Width - 5;
            _cropX = _cropX > diffX ? Math.Min(_cropX - diffX, maxCropX) : 1;

            var diffY = _cropArea.Height / 2;
            var maxCropY = pbPhoto.Height - _cropArea.Height - 5;
            _cropY = _cropY > diffY ? Math.Min(_cropY - diffY, maxCropY) : 1;

            DrawCropArea();
        }
        void DrawCropArea()
        {
            pbPhoto.Refresh();

            _cropArea.X = _cropX;
            _cropArea.Y = _cropY;
            pbPhoto.CreateGraphics().DrawRectangle(_cropPen, _cropArea);
        }
        void EditPhotoForm_Load(object sender, EventArgs e)
        {
            _isCroped = false;
            pbPhoto.Paint += pbPhoto_Paint;
            LoadPhoto(Photo);
        }
        void pbPhoto_Paint(object sender, PaintEventArgs e)
        {
            var photo = pbPhoto.Image;
            if (ReferenceEquals(photo, null))
                return;

            _scaleFactor = 1;
            if (pbPhoto.Width < photo.Width)
            {
                _scaleFactor = (float)Math.Round(pbPhoto.Width / (float)photo.Width, 2);
                e.Graphics.ScaleTransform(_scaleFactor, _scaleFactor, MatrixOrder.Append);
                e.Graphics.DrawImage(photo, new Point(0, 0));
            }
        }
        void LoadPhoto(Image photo)
        {
            pbPhoto.Refresh();
            pbPhoto.Image = photo;
            //pbPhoto.Image = GraphicsHelper.GetStretchedImage(photo, pbPhoto.Height, pbPhoto.Width);
        }
        void Crop()
        {
            if (_cropX == 0 && _cropY == 0)
            {
                MessageBox.Show(ErrorTexts.PhotoCroppingAreaIsNotSpecified);
                return;
            }

            var x = (int)(_cropArea.X / _scaleFactor);
            var y = (int)(_cropArea.Y / _scaleFactor);
            var width = (int)(_cropArea.Width / _scaleFactor);
            var height = (int)(_cropArea.Height / _scaleFactor);

            //var originalImage = new Bitmap(pbPhoto.Image, pbPhoto.Width, pbPhoto.Height);
            var originalImage = new Bitmap(Photo, Photo.Width, Photo.Height);
            //var cropPhoto = new Bitmap(_cropArea.Width, _cropArea.Height);
            var cropPhoto = new Bitmap(width, height);
            var gr = Graphics.FromImage(cropPhoto);
            gr.SmoothingMode = SmoothingMode.HighQuality;
            gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
            gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
            gr.PageUnit = GraphicsUnit.Pixel;
            gr.CompositingQuality = CompositingQuality.HighQuality;
            //gr.DrawImage(originalImage, 0, 0, _cropArea, GraphicsUnit.Pixel);

            var rect = new Rectangle(x, y, width, height);
            gr.DrawImage(originalImage, 0, 0, rect, GraphicsUnit.Pixel);

            CropPhoto = cropPhoto;
            pbPhoto.Image = GraphicsHelper.GetStretchedImage(cropPhoto, 236, 295);

            _isCroped = true;
        }
    }
}
