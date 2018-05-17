using System;
using System.Windows.Forms;

namespace PrintServiceApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(params string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var frm = new PrintServiceAppForm();
            if (args.Length != 0)
            {
                if (args[0] == "dl")
                    frm.IsDrivingLicense = true;
                else if (args[0] == "vl")
                    frm.IsDrivingLicense = false;
                frm.IsAutoStart = true;
            }
            Application.Run(frm);
        }
    }
}
