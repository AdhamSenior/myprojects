using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TizimNuuz
{
    public partial class SelectUser : Form
    {
        private TizimEntities db = new TizimEntities();
        private int log=0;
        public SelectUser(string mess,int pass)
        {
            InitializeComponent();
            select.Text += mess;
            comboBox1.DataSource = db.Admins.ToList();
            comboBox1.DisplayMember = "FIO";
            comboBox1.ValueMember = "id";
            log = pass;
        }

        private void creataccount_Click(object sender, EventArgs e)
        {
            // CreateNew.selectedUser  =  comboBox1.SelectedValue.ToString();
            int selectedindex = (int)comboBox1.SelectedValue;
            Admin select = db.Admins.FirstOrDefault(x => x.id == selectedindex);

            if (log == 1)
            {
                db.Admins.Remove(select);
                db.SaveChanges();
                MessageBox.Show(select.FIO + " removed from database...");
            }

            else if (log == 2)
            {
                UpdateUser uu = new UpdateUser(select);
                uu.ShowDialog();
            }
            this.Close();
        }
    }
}
