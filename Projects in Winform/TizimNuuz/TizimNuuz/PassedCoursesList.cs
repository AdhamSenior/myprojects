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
    public partial class @int : Form
    {
        public @int(string PersonName,int id)
        {
            InitializeComponent();
            Check(id);
            lblPerson.Text ="Hush Kelibsiz "+ (PersonName.ToUpper());
        }

        private void Check(int id)
        {
            switch (id)
            {
                case 13:
                    {
                        btnEdit.Enabled = false;
                        btnAdd.Enabled = false;
                        btnRemove.Enabled = false;
                        btnSave.Enabled = false;
                        break;
                    }
                case 12: { break; }
                case 11: {

                       
                        btnSave.Enabled = false;

                        break; }

                
                default:
                    break;
            }
        }

        private TizimEntities db = new TizimEntities();

        private void btnLoad_Click(object sender, EventArgs e)
        {
           
            eduCoursesListBindingSource.DataSource = db.EduCoursesLists.ToList();

        }

        private void int_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
