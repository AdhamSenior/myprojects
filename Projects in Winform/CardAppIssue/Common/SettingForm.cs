using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Common
{
    using Print;

    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();

            Text = Texts.Settings;

            klblApiUrl.Text = Texts.ApiUrl;
            klblPrinterName.Text = Texts.PrinterName;
            klblProductionLine.Text = Texts.ProductionLine;
            kbtnSave.Text = Texts.Save;

            kbtnSave.Click += kbtnSave_Click;
        }

        void kbtnSave_Click(object sender, EventArgs e)
        {
            var prop = new Dictionary<string, string>
            {
                {"ApiUrl", ktbApiUrl.Text.ToSafeTrimmedString()},
                {"PrinterName", kcbPrinterName.SelectedItem.ToSafeTrimmedString()},
                {"ProductionLine", kcbProductionLine.SelectedItem.ToSafeTrimmedString()}
            };

            UserSettings.Instance.Save(prop);
            MessageBox.Show(Texts.DataSuccessfullySaved);
            UserSettings.Instance.Load();
            Close();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode)
                return;

            var set = UserSettings.Instance.Items;
            ktbApiUrl.Text = set["ApiUrl"];

            PrinterExt.LoadPrinters(kcbPrinterName);
            if (kcbPrinterName.Items.Count != 0)
                kcbPrinterName.SelectedIndex = kcbPrinterName.FindStringExact(set["PrinterName"]);

            PrinterExt.LoadProductionLines(kcbProductionLine);
            if (kcbProductionLine.Items.Count != 0)
                kcbProductionLine.SelectedIndex = kcbProductionLine.FindStringExact(set["ProductionLine"]);
        }
    }
}
