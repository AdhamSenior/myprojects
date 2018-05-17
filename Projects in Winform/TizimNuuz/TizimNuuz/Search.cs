using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TizimNuuz
{
    public partial class Search : Form
    {
        private TizimEntities db = new TizimEntities();
        Dictionary<string, int> items = new Dictionary<string, int>();
        public Search()
        {
            InitializeComponent();
            adminBindingSource.DataSource = db.Admins.ToList();
            typePersonBindingSource.DataSource = db.TypePersons.ToList();

            items.Add("Admin", 1);
            items.Add("Teachers", 2);
            items.Add("Courses", 3);
            items.Add("TypePerson", 4);

            cmbsearch.Items.Add("Admin");
            cmbsearch.Items.Add("Teachers");
            cmbsearch.Items.Add("Courses");
            cmbsearch.Items.Add("TypePerson");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        async void button1_Click(object sender, EventArgs e)
        {
            var wait = new WaitForm { Status = Texts.Searching, OwnerForm = this };
            wait.Show();
            typePersonBindingSource.DataSource = db.TypePersons.ToList();          
           
            switch ((int)cmbsearch.SelectedIndex)
            {
                case 0:
                    {
                        BindingSource bs = new BindingSource();
                        List<Admin> admins = db.Admins.ToList();

                        bs.DataSource = admins;
                        dataGridView1.DataSource = bs.DataSource;


                        #region MyRegion


                        //foreach (var item in admins)
                        //{


                        //    item.TypePerson.Type = db.TypePersons.FirstOrDefault(x => x.Id == item.id).Type;
                        //    dataGridView1.Columns["TypePerson"].DataPropertyName = item.TypePerson.Type;



                        //}
                        // dataGridView1.Columns.Remove(dataGridView1.Columns["type"]);


                        //foreach (DataGridViewColumn item in dataGridView1.Columns)
                        //{

                        //    item.ValueType = typeof(string);



                        //}
                        //  DataColumn dv = new DataColumn("Type");

                        //dataGridView1.Columns["type"].Visible = false;
                        //dataGridView1.Columns["TypePerson"].Visible = false;
                        //DataGridViewComboBoxColumn cmbCol = new DataGridViewComboBoxColumn();
                        //cmbCol.HeaderText = "Type";
                        //cmbCol.Name = "typePerson";
                        //cmbCol.Items.Add("True");
                        //cmbCol.DataSource = db.TypePersons.ToList();
                        //cmbCol.ValueMember = "id";
                        //cmbCol.DisplayMember = "type";
                        //dataGridView1.Columns.Add(cmbCol);
                        //  dataGridView1.Columns["myComboColumn"].DisplayIndex = "at any index that you want";

                        //foreach (DataGridViewRow row in dataView.Rows)
                        //{
                        //    row.Cells["myComboColumn"].Value = row.Cells["yourColumn"].Value;
                        //}





                        //((DataGridViewComboBoxColumn)dataGridView1.Columns["type"]).DataSource = db.TypePersons.ToList();
                        //((DataGridViewComboBoxColumn)dataGridView1.Columns["type"]).DisplayMember = "id";
                        //((DataGridViewComboBoxColumn)dataGridView1.Columns["type"]).ValueMember = "type";
                        #endregion
                        break;
                    }
                case 1:
                    {
                        BindingSource bs = new BindingSource();
                        bs.DataSource = db.TeachersUZMUs.ToList();
                        dataGridView1.DataSource = bs.DataSource; break;
                    }
                case 2:
                    {
                        BindingSource bs = new BindingSource();
                        bs.DataSource = db.EduCoursesLists.ToList();
                        dataGridView1.DataSource = bs.DataSource; break;
                    }
                case 3:
                    {
                        BindingSource bs = new BindingSource();
                        bs.DataSource = db.TypePersons.ToList();

                        dataGridView1.DataSource = bs.DataSource; break;
                    }
                default:
                    break;
            }
            wait.Close();
            wait.Dispose();
        }

    }
}
