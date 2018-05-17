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
    public partial class UpdateUser : Form
    {
        private TizimEntities db = new TizimEntities();
        private int remID = -1;
        public UpdateUser(Admin selected)
        {
          
            InitializeComponent();
            cmbtype.DataSource = db.TypePersons.ToList();
            remID = selected.id;
            cmbtype.DisplayMember = "type";
            cmbtype.ValueMember = "id";
            txtboxFIO.Text = selected.FIO;
            txtboxInfo.Text = selected.Info;
            txtboxLogin.Text = selected.lg;
            txtboxpassword.Text = selected.pass;
            txtboxPhoneNumber.Text = selected.PhoneNumber;
            textBox5.Text = (string)db.TypePersons.FirstOrDefault(x =>x.Id==selected.type).Type;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin select = db.Admins.FirstOrDefault(x => x.id == remID);
                db.Admins.Remove(select);
                db.SaveChanges();
              
            db.Admins.Add(new Admin()
            {
                FIO = txtfio.Text,
                type = (int)cmbtype.SelectedValue,
                PhoneNumber = txtphone.Text,
                Info = txtinfo.Text,
                login = (txtlg.Text.GetHashCode() * txtpass.Text.Length.GetHashCode()).ToString(),
                password = (txtpass.Text.GetHashCode() * txtlg.Text.Length.GetHashCode()).ToString(),
                lg=txtlg.Text,
                pass=txtpass.Text

            });

            db.SaveChanges();
            MessageBox.Show(select.FIO + " updated to "+txtfio.Text);
            this.Close();

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            txtfio.Text = txtboxFIO.Text;
            txtphone.Text = txtboxPhoneNumber.Text;
            txtinfo.Text = txtboxInfo.Text;
            txtlg.Text = txtboxLogin.Text;
            txtpass.Text = txtboxpassword.Text;
            
        }
    }
}
