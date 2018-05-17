using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;

namespace Common
{
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public static class Setting
    {
        public const string DlFileName = "dl_database.db";
        public readonly static string DlDbPath;

        public const string VlFileName = "vl_database.db";
        public readonly static string VlDbPath;

        public readonly static string AppDirectoryPath;
        public readonly static string PhotoFolderPath;

        public static string ApiUrl;

        public static string Token;
        static Setting()
        {
            AppDirectoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            PhotoFolderPath = AppDirectoryPath + "\\PhotoTemp";
            DlDbPath = String.Format("{0}\\Data\\{1}", AppDirectoryPath, DlFileName);
            VlDbPath = String.Format("{0}\\Data\\{1}", AppDirectoryPath, VlFileName);
        }
    }
}