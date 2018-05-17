namespace TizimNuuz
{
    partial class @int
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgw = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teachersNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentsNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.worksListDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.worksNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.worksTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ballDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eduCoursesListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblPerson = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eduCoursesListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // dgw
            // 
            this.dgw.AllowUserToAddRows = false;
            this.dgw.AllowUserToDeleteRows = false;
            this.dgw.AutoGenerateColumns = false;
            this.dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.teachersNameDataGridViewTextBoxColumn,
            this.studentsNameDataGridViewTextBoxColumn,
            this.worksListDataGridViewTextBoxColumn,
            this.worksNumberDataGridViewTextBoxColumn,
            this.worksTypeDataGridViewTextBoxColumn,
            this.ballDataGridViewTextBoxColumn});
            this.dgw.DataSource = this.eduCoursesListBindingSource;
            this.dgw.Location = new System.Drawing.Point(18, 55);
            this.dgw.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgw.Name = "dgw";
            this.dgw.ReadOnly = true;
            this.dgw.RowTemplate.Height = 23;
            this.dgw.Size = new System.Drawing.Size(1358, 577);
            this.dgw.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 110;
            // 
            // teachersNameDataGridViewTextBoxColumn
            // 
            this.teachersNameDataGridViewTextBoxColumn.DataPropertyName = "Teachers_Name";
            this.teachersNameDataGridViewTextBoxColumn.HeaderText = "Teachers_Name";
            this.teachersNameDataGridViewTextBoxColumn.Name = "teachersNameDataGridViewTextBoxColumn";
            this.teachersNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.teachersNameDataGridViewTextBoxColumn.Width = 140;
            // 
            // studentsNameDataGridViewTextBoxColumn
            // 
            this.studentsNameDataGridViewTextBoxColumn.DataPropertyName = "Students_Name";
            this.studentsNameDataGridViewTextBoxColumn.HeaderText = "Students_Name";
            this.studentsNameDataGridViewTextBoxColumn.Name = "studentsNameDataGridViewTextBoxColumn";
            this.studentsNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.studentsNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // worksListDataGridViewTextBoxColumn
            // 
            this.worksListDataGridViewTextBoxColumn.DataPropertyName = "WorksList";
            this.worksListDataGridViewTextBoxColumn.HeaderText = "WorksList";
            this.worksListDataGridViewTextBoxColumn.Name = "worksListDataGridViewTextBoxColumn";
            this.worksListDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // worksNumberDataGridViewTextBoxColumn
            // 
            this.worksNumberDataGridViewTextBoxColumn.DataPropertyName = "WorksNumber";
            this.worksNumberDataGridViewTextBoxColumn.HeaderText = "WorksNumber";
            this.worksNumberDataGridViewTextBoxColumn.Name = "worksNumberDataGridViewTextBoxColumn";
            this.worksNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // worksTypeDataGridViewTextBoxColumn
            // 
            this.worksTypeDataGridViewTextBoxColumn.DataPropertyName = "WorksType";
            this.worksTypeDataGridViewTextBoxColumn.HeaderText = "WorksType";
            this.worksTypeDataGridViewTextBoxColumn.Name = "worksTypeDataGridViewTextBoxColumn";
            this.worksTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ballDataGridViewTextBoxColumn
            // 
            this.ballDataGridViewTextBoxColumn.DataPropertyName = "Ball";
            this.ballDataGridViewTextBoxColumn.HeaderText = "Ball";
            this.ballDataGridViewTextBoxColumn.Name = "ballDataGridViewTextBoxColumn";
            this.ballDataGridViewTextBoxColumn.ReadOnly = true;
            this.ballDataGridViewTextBoxColumn.Width = 50;
            // 
            // eduCoursesListBindingSource
            // 
            this.eduCoursesListBindingSource.DataSource = typeof(TizimNuuz.EduCoursesList);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(56, 11);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(112, 35);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(178, 11);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(112, 35);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(299, 11);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(112, 35);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(420, 11);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(112, 35);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(542, 11);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 35);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // lblPerson
            // 
            this.lblPerson.AutoSize = true;
            this.lblPerson.Location = new System.Drawing.Point(975, 11);
            this.lblPerson.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPerson.Name = "lblPerson";
            this.lblPerson.Size = new System.Drawing.Size(37, 20);
            this.lblPerson.TabIndex = 2;
            this.lblPerson.Text = "Info";
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackgroundImage = global::TizimNuuz.Properties.Resources.back;
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox6.Location = new System.Drawing.Point(1, -2);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(34, 33);
            this.pictureBox6.TabIndex = 28;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = global::TizimNuuz.Properties.Resources.cancel_cross_delete_letter_x_remove_3c90434ffe690e93_512x512;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Location = new System.Drawing.Point(1355, -2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(38, 33);
            this.pictureBox5.TabIndex = 29;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // @int
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1394, 651);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.lblPerson);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.dgw);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "@int";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PassedCoursesList";
            this.Load += new System.EventHandler(this.int_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eduCoursesListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgw;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.BindingSource eduCoursesListBindingSource;
        private System.Windows.Forms.Label lblPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn teachersNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentsNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn worksListDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn worksNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn worksTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ballDataGridViewTextBoxColumn;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}