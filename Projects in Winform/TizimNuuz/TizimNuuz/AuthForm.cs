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
    public partial class AuthForm : Form
    {
        private TizimEntities db = new TizimEntities();
        private string SecurityLogin = "";
        private string SecurityPassword = "";

        public AuthForm()
        {
            InitializeComponent();
            Text = Texts.LoginToSystem;

            kwlblTitle.Text = Texts.LoginToSystem;
            klblLogin.Text = Texts.Login;
            klblPass.Text = Texts.Password;
            kbtnEnter.Text = Texts.Enter;
            kbtnEnter.Click += kbtnEnter_Click;
        }

        void kbtnEnter_Click(object sender, EventArgs e)
        {
            var login = ktbLogin.Text;
          
            var pass = ktbPassword.Text;

            Menu men = new TizimNuuz.Menu("", "", 1);

            men.ShowDialog();

        }
        private void Anonym()
        {
            SecurityLogin = (ktbLogin.Text.GetHashCode() * ktbPassword.Text.Length.GetHashCode()).ToString();
            SecurityPassword = (ktbPassword.Text.GetHashCode() * ktbLogin.Text.Length.GetHashCode()).ToString();

        }
        async void Auth()
        {

            var wait = new WaitForm { Status = Texts.Authorization, OwnerForm = this };
            wait.Show();
            Anonym();
            foreach (var item in db.Admins)
            {
                if (item.login.Equals(SecurityLogin) && item.password.Equals(SecurityPassword))
                {
                    var person = db.TypePersons.FirstOrDefault(x => x.Id == item.type);
                    var personname = db.Admins.FirstOrDefault(x => x.id == item.id);

                    Menu men = new TizimNuuz.Menu(personname.FIO, person.Type, person.Id);

                    men.ShowDialog();


                }
                else if (ktbLogin.Text==null|| ktbLogin.Text==""||ktbPassword.Text==null||ktbPassword.Text=="") {
                    MessageBox.Show(Texts.FieldIsEmpty);
                }
                else { MessageBox.Show(Texts.FailedToAuthenticateToServer); }
            }
            wait.Close();
            wait.Dispose();

        }

        private void AuthForm_Load(object sender, EventArgs e)
        {

        }
    }
}
