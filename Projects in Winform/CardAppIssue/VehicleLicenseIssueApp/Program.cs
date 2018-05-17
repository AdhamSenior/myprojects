using System;
using System.Windows.Forms;

namespace VehicleLicenseIssueApp
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
            UserSettings.Instance.IsDrivingLicense = false;
            UserSettings.Instance.Load();

            Setting.ApiUrl = UserSettings.Instance.Items["ApiUrl"];
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //var frmAuth = new AuthForm();
            //Application.Run(frmAuth);
            //if (User.Instance.IsAuthorized)
                Application.Run(new VehicleLicenseListForm());
        }
    }
}
