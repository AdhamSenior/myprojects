using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DrivingLicenseIssueApp
{
    public partial class EditSignatureForm : Form
    {
        const int ImagePenWidth = 15;
        const int DisplayPenWidth = 10;

        public Image SignImage { get; set; }
        public EditSignatureForm()
        {
            InitializeComponent();

            kbtnSave.Text = TextUI.Save;
            kbtnClear.Text = TextUI.Clear;

            kbtnSave.Click += kbtnSave_Click;
            kbtnClear.Click += kbtnClear_Click;

            spContent.SetImagePenWidth(ImagePenWidth);
            spContent.SetDisplayPenWidth(DisplayPenWidth);

            Closing += EditSignatureForm_Closing;
        }
        void kbtnSave_Click(object sender, EventArgs e)
        {
            var signImage = spContent.GetSigImage();
            var bmp = MakeTransparent(signImage);
            SignImage = bmp;

            spContent.SetTabletState(0);
            DialogResult = DialogResult.OK;
            Close();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode)
                return;

            spContent.SetTabletState(1);
            spContent.SetImageXSize(495);
            spContent.SetImageYSize(285);
            spContent.SetJustifyMode(5);
        }
        void EditSignatureForm_Closing(object sender, CancelEventArgs e)
        {
            spContent.SetTabletState(0);
        }
        void kbtnClear_Click(object sender, EventArgs e)
        {
            spContent.ClearTablet();
        }
        Bitmap MakeTransparent(Image img)
        {
            var bmp = new Bitmap(img);
            bmp.MakeTransparent(Color.White);
            return bmp;
        }
    }
}
