using System;
using System.Windows.Forms;

namespace DrivingLicenseIssueApp
{
    using Common;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            UserSettings.Instance.IsDrivingLicense = true;
            UserSettings.Instance.Load();

            Setting.ApiUrl = UserSettings.Instance.Items["ApiUrl"];
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //var frmAuth = new AuthForm();
            //Application.Run(frmAuth);
            //if (true)
                Application.Run(new DrivingLicenseListForm());
        }
    }
}