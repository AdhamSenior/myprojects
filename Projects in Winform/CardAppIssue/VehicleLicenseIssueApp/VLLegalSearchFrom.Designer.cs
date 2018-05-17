namespace VehicleLicenseIssueApp
{
    partial class VLLegalSearchFrom
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
            this.ktbPassportSeries = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.bsSearch = new System.Windows.Forms.BindingSource(this.components);
            this.lblPassport = new System.Windows.Forms.Label();
            this.ktbPassportNumber = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.ktbINN = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ktbStateNumber = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.kbtnSearch = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.bsSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // ktbPassportSeries
            // 
            this.ktbPassportSeries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ktbPassportSeries.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSearch, "PassportSeries", true));
            this.ktbPassportSeries.Location = new System.Drawing.Point(158, 12);
            this.ktbPassportSeries.MaxLength = 37;
            this.ktbPassportSeries.Name = "ktbPassportSeries";
            this.ktbPassportSeries.Size = new System.Drawing.Size(66, 20);
            this.ktbPassportSeries.TabIndex = 8;
            // 
            // bsSearch
            // 
            this.bsSearch.DataSource = typeof(VehicleLicenseIssueApp.VLSearch);
            // 
            // lblPassport
            // 
            this.lblPassport.Location = new System.Drawing.Point(22, 12);
            this.lblPassport.Name = "lblPassport";
            this.lblPassport.Size = new System.Drawing.Size(121, 13);
            this.lblPassport.TabIndex = 9;
            this.lblPassport.Text = "Passport";
            // 
            // ktbPassportNumber
            // 
            this.ktbPassportNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ktbPassportNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSearch, "PassportNumber", true));
            this.ktbPassportNumber.Location = new System.Drawing.Point(230, 12);
            this.ktbPassportNumber.MaxLength = 37;
            this.ktbPassportNumber.Name = "ktbPassportNumber";
            this.ktbPassportNumber.Size = new System.Drawing.Size(233, 20);
            this.ktbPassportNumber.TabIndex = 8;
            // 
            // ktbINN
            // 
            this.ktbINN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ktbINN.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSearch, "INN", true));
            this.ktbINN.Location = new System.Drawing.Point(158, 41);
            this.ktbINN.MaxLength = 37;
            this.ktbINN.Name = "ktbINN";
            this.ktbINN.Size = new System.Drawing.Size(305, 20);
            this.ktbINN.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(22, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Inn";
            // 
            // ktbStateNumber
            // 
            this.ktbStateNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ktbStateNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSearch, "StateNumber", true));
            this.ktbStateNumber.Location = new System.Drawing.Point(158, 70);
            this.ktbStateNumber.MaxLength = 37;
            this.ktbStateNumber.Name = "ktbStateNumber";
            this.ktbStateNumber.Size = new System.Drawing.Size(305, 20);
            this.ktbStateNumber.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(22, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "StateNumber";
            // 
            // kbtnSearch
            // 
            this.kbtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnSearch.Location = new System.Drawing.Point(373, 116);
            this.kbtnSearch.Name = "kbtnSearch";
            this.kbtnSearch.Size = new System.Drawing.Size(90, 25);
            this.kbtnSearch.TabIndex = 10;
            this.kbtnSearch.Values.Text = "Search";
            // 
            // VLLegalSearchFrom
            // 
            this.AcceptButton = this.kbtnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 153);
            this.Controls.Add(this.kbtnSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPassport);
            this.Controls.Add(this.ktbStateNumber);
            this.Controls.Add(this.ktbINN);
            this.Controls.Add(this.ktbPassportNumber);
            this.Controls.Add(this.ktbPassportSeries);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "VLLegalSearchFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "VLLegalSearchFrom";
            ((System.ComponentModel.ISupportInitialize)(this.bsSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktbPassportSeries;
        private System.Windows.Forms.Label lblPassport;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktbPassportNumber;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktbINN;
        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktbStateNumber;
        private System.Windows.Forms.Label label2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kbtnSearch;
        private System.Windows.Forms.BindingSource bsSearch;
    }
}