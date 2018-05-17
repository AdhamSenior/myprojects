using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicleLicenseIssueApp
{
    public partial class VLLegalSearchFrom : Form
    {
        public Dictionary<String, string> SearchParams;
        public VLSearch Object;
        public VLLegalSearchFrom()
        {
            InitializeComponent();
            this.Text = TextUI.VLLegalSearchFrom; 
            lblPassport.Text = TextUI.Passport;
            label1.Text = TextUI.Inn;
            label2.Text = TextUI.StateNumber;
            kbtnSearch.Text = TextUI.Search;
            kbtnSearch.Click += KbtnSearch_Click;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            bsSearch.DataSource = Object;
        }

        private void KbtnSearch_Click(object sender, EventArgs e)
        {
            var obj = (VLSearch)bsSearch.DataSource;
            if (SearchParams.Count > 0)
            {
                SearchParams["seria"] = Object.PassportSeries;
                SearchParams["number"] = Object.PassportNumber;
                SearchParams["inn"] = Object.INN;
                SearchParams["reg_number"] = Object.StateNumber;
            }
            else
            {
                SearchParams.Add("seria", Object.PassportSeries);
                SearchParams.Add("number", Object.PassportNumber);
                SearchParams.Add("inn", Object.INN);
                SearchParams.Add("reg_number", Object.StateNumber);
            }

            DialogResult = DialogResult.OK;
        }
    }
}
