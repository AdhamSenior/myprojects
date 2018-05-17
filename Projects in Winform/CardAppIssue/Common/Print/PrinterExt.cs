using System;
using System.Management;
using ComponentFactory.Krypton.Toolkit;

namespace Common.Print
{
    public static class PrinterExt
    {
        public static void LoadPrinters(KryptonComboBox cb)
        {
            if (cb.Items.Count != 0)
                cb.Items.Clear();

            var query = String.Format("select * from Win32_Printer");
            var printers = new ManagementObjectSearcher(query);
            foreach (var o in printers.Get())
            {
                var printer = (ManagementObject)o;
                var name = (string)printer.GetPropertyValue("Name");
                cb.Items.Add(name);
            }
        }
        public static void LoadProductionLines(KryptonComboBox cb)
        {
            if (cb.Items.Count != 0)
                cb.Items.Clear();

            var items = Printer.GetPrinters();
            items.ForEach(fe => cb.Items.Add(fe));
        }
    }
}
