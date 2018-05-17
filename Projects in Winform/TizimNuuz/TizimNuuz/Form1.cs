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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private TizimEntities db = new TizimEntities();
        private string SecurityLogin = "";
        private string SecurityPassword = "";
        

        private void Form1_Load(object sender, EventArgs e)
        {
            tbPassword.PasswordChar = '*';
        }

        private void tbLogin_Validating(object sender, CancelEventArgs e)
        {
            if (tbLogin.Text.Length < 4)
            {
                e.Cancel = true;
                vlInfo.Text = "Login must be minimum 4 characters... ";
            }
            if (isAlfa(tbLogin.Text))
            {
                e.Cancel = true;
                vlInfo.Text = "Don't use {#$@?&^%*()_-+!`~}";

            }

        }
        private bool isAlfa(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '@') { return true; }
            }
            return false;
        }

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            if (tbPassword.Text.Length < 8)
            {
                e.Cancel = true;
                vlInfo.Text = "Password must be minimum 8 characters... ";
            }
            if (isAlfa(tbPassword.Text))
            {
                e.Cancel = true;
                vlInfo.Text = "Don't use {#$@?&^%*()_-+!`~}";

            }
        }
        
        private void btnEnter_Click(object sender, EventArgs e)
        {
               Anonym();
            foreach (var item in db.Admins)
            {
                if(item.login.Equals(SecurityLogin) && item.password.Equals(SecurityPassword))
                {
                    var person = db.TypePersons.FirstOrDefault(x => x.Id ==item.type);
                  @int PCL = new @int(person.Type,person.Id);
                   
                    PCL.ShowDialog();


                }
            }
            
            
        }
        
        private void Anonym()
        {
            SecurityLogin = (tbLogin.Text.GetHashCode() * tbPassword.Text.Length.GetHashCode()).ToString();
            SecurityPassword = (tbPassword.Text.GetHashCode() * tbLogin.Text.Length.GetHashCode()).ToString();
            
        }
    }
}
