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
    public partial class UsersGroup : Form
    {
        private TizimEntities db = new TizimEntities();
        public UsersGroup()
        {
            InitializeComponent();
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LimeGreen;
            adminBindingSource.DataSource = db.Admins.ToList();
            typePersonBindingSource.DataSource = db.TypePersons.ToList();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UsersGroup_Load(object sender, EventArgs e)
        {
            
        }
    }
}
