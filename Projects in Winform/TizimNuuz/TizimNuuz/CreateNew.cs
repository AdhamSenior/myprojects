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
    public partial class CreateNew : Form
    {
        public static string selectedUser = "";
        private TizimEntities db = new TizimEntities();
        public CreateNew()
        {
            InitializeComponent();
            cmbox.DataSource = db.TypePersons.ToList();
            cmbox.DisplayMember = "type";
            cmbox.ValueMember = "id";
        }
        #region MyRegion
        private void CreateNew_Load(object sender, EventArgs e)
        {

            txtboxFIO.Text = "FIO...";
            txtboxInfo.Text = "Your address and your skills...";
     
            txtboxPhoneNumber.Text = "123456789...";
            txtboxLogin.Text = "Login...";
            txtboxpassword.Text = "Password...";
        }

        private void CreateNew_Enter(object sender, EventArgs e)
        {
            if (txtboxLogin.Text == "Login...")
            {
                txtboxLogin.Text = "";
            }
            if (txtboxpassword.Text == "Password...")
            {
                txtboxpassword.Text = "";
            }
            if (txtboxFIO.Text == "FIO...")
            {
                txtboxFIO.Text = "";
            }
            if (txtboxInfo.Text == "Your address and your skills...")
            {
                txtboxInfo.Text = "";
            }
          
            if (txtboxPhoneNumber.Text == "123456789...")
            {
                txtboxPhoneNumber.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {

            if (txtboxFIO.Text == "")
            {
                txtboxFIO.Text = "FIO...";

            }
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            if (txtboxFIO.Text == "FIO...")
            {
                txtboxFIO.Text = "";
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox6, "Back");
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox5, "Exit from Application");
        }

 
        private void txtboxPhoneNumber_MouseEnter(object sender, EventArgs e)
        {
            if (txtboxPhoneNumber.Text == "123456789...")
            {
                txtboxPhoneNumber.Text = "";
            }
        }

        private void txtboxPhoneNumber_Leave(object sender, EventArgs e)
        {

            if (txtboxPhoneNumber.Text == "")
            {
                txtboxPhoneNumber.Text = "123456789...";

            }
        }

        private void txtboxInfo_MouseEnter(object sender, EventArgs e)
        {

            if (txtboxInfo.Text == "Your address and your skills...")
            {
                txtboxInfo.Text = "";
            }
        }

        private void txtboxInfo_Leave(object sender, EventArgs e)
        {
            if (txtboxInfo.Text == "")
            {
                txtboxInfo.Text = "Your address and your skills...";

            }
        }

        private void creataccount_Click(object sender, EventArgs e)
        {

        }
      
        private void txtboxLogin_Leave(object sender, EventArgs e)
        {
            if (txtboxLogin.Text == "")
            {
                txtboxLogin.Text = "Login...";

            }
        }

        private void txtboxLogin_MouseEnter(object sender, EventArgs e)
        {
            if (txtboxLogin.Text == "Login...")
            {
                txtboxLogin.Text = "";
            }
        }

        private void txtboxpassword_MouseEnter(object sender, EventArgs e)
        {
            if (txtboxpassword.Text == "Password...")
            {
                txtboxpassword.Text = "";
            }
        }

        private void txtboxpassword_Leave(object sender, EventArgs e)
        {
            if (txtboxpassword.Text == "")
            {
                txtboxpassword.Text = "Password...";

            }
        }
     

        #endregion
        private void creataccount_Click_1(object sender, EventArgs e)
        {

            if (txtboxFIO.Text == "" || txtboxInfo.Text == "" || cmbox.SelectedItem.ToString() == ""
                || txtboxPhoneNumber.Text == "" || txtboxLogin.Text == "" || txtboxpassword.Text == ""||
                txtboxFIO.Text == "FIO..." || txtboxInfo.Text == "Your address and your skills..." || cmbox.SelectedItem.ToString() == ""
                || txtboxPhoneNumber.Text == "123456789..." || txtboxLogin.Text == "Login..." || txtboxpassword.Text == "Password...")
            {
                MessageBox.Show("You are missed field!!\nFill the all fields ....");
            }
            else {


                db.Admins.Add(new Admin()
                {
                    FIO = txtboxFIO.Text,
                    type = (int)cmbox.SelectedValue,
                    PhoneNumber = txtboxPhoneNumber.Text,
                    Info = txtboxInfo.Text,
                    login = (txtboxLogin.Text.GetHashCode() * txtboxpassword.Text.Length.GetHashCode()).ToString(),
                    password = (txtboxpassword.Text.GetHashCode() * txtboxLogin.Text.Length.GetHashCode()).ToString()
                   , lg = txtboxLogin.Text,
                    pass=txtboxpassword.Text
                });

                db.SaveChanges();
                this.Close();

            }

        }
    }
}