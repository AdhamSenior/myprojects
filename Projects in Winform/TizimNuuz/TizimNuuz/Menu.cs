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
    public partial class Menu : Form
    {
        //    private TizimEntities db = new TizimEntities();
        string pname = ""; int iid = 0;
        public Menu(string personname,string PersonName, int id)
        {
            InitializeComponent();
//            var person = db.RegistrationClientsUZMUs.FirstOrDefault(x => x.Id ==id);
            lblWelcome.Text += personname;
            pname = personname; iid = id;
        }

        private void Menu_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.newUser, "Create new User");
        }

        private void newUser_Click(object sender, EventArgs e)
        {
            CreateNew cn = new CreateNew();
            cn.ShowDialog();
        }

        private void RemoveUser_Click(object sender, EventArgs e)
        {
            SelectUser su = new SelectUser("Remove",1);
            su.ShowDialog();
        }

        private void UpdateUser_Click(object sender, EventArgs e)
        {
            SelectUser su = new SelectUser("Update", 2);
            su.ShowDialog();
        }

        private void UserGroup_Click(object sender, EventArgs e)
        {
            UsersGroup ug = new UsersGroup();
            ug.ShowDialog();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            Search s = new TizimNuuz.Search();
            s.ShowDialog();
        }

        private void CoursesList_Click(object sender, EventArgs e)
        {
            @int PCL = new @int(pname, iid);
          
            PCL.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
