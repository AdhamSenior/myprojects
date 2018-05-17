namespace TizimNuuz
{
    partial class SelectUser
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.select = new System.Windows.Forms.Label();
            this.creataccount = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(28, 50);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(500, 33);
            this.comboBox1.TabIndex = 0;
            // 
            // select
            // 
            this.select.AutoSize = true;
            this.select.Location = new System.Drawing.Point(145, 9);
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(160, 25);
            this.select.TabIndex = 1;
            this.select.Text = "Select User for ";
            // 
            // creataccount
            // 
            this.creataccount.BackColor = System.Drawing.Color.Gray;
            this.creataccount.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.creataccount.Location = new System.Drawing.Point(109, 113);
            this.creataccount.Name = "creataccount";
            this.creataccount.Size = new System.Drawing.Size(326, 46);
            this.creataccount.TabIndex = 17;
            this.creataccount.Text = "Select";
            this.creataccount.UseVisualStyleBackColor = false;
            this.creataccount.Click += new System.EventHandler(this.creataccount_Click);
            // 
            // SelectUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 171);
            this.Controls.Add(this.creataccount);
            this.Controls.Add(this.select);
            this.Controls.Add(this.comboBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "SelectUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SelectUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label select;
        private System.Windows.Forms.Button creataccount;
    }
}