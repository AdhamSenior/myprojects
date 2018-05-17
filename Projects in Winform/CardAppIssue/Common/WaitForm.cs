using System;
using System.Drawing;
using System.Windows.Forms;

namespace Common
{
    public partial class WaitForm : Form
    {
        public Form OwnerForm { get; set; }
        public string Status { get; set; }

        public WaitForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Closing += WaitForm_Closing;
        }

        void WaitForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            OwnerForm.Enabled = true;
            OwnerForm.Activate();
            OwnerForm.BringToFront();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode)
                return;

            OwnerForm.Enabled = false;
            Location = new Point(OwnerForm.Location.X + (OwnerForm.Width - Width) / 2, OwnerForm.Location.Y + (OwnerForm.Height - Height) / 2);
            lblStatus.Text = Status;
        }
    }
}
