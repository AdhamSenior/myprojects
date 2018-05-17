namespace DrivingLicenseIssueApp
{
    partial class EditSignatureForm
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
            this.spContent = new Topaz.SigPlusNET();
            this.kbtnClear = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kbtnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kgbContent = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.kgbContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kgbContent.Panel)).BeginInit();
            this.kgbContent.Panel.SuspendLayout();
            this.kgbContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // spContent
            // 
            this.spContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spContent.BackColor = System.Drawing.Color.White;
            this.spContent.ForeColor = System.Drawing.Color.Black;
            this.spContent.Location = new System.Drawing.Point(7, 8);
            this.spContent.Name = "spContent";
            this.spContent.Size = new System.Drawing.Size(417, 236);
            this.spContent.TabIndex = 0;
            // 
            // kbtnClear
            // 
            this.kbtnClear.Location = new System.Drawing.Point(12, 275);
            this.kbtnClear.Name = "kbtnClear";
            this.kbtnClear.Size = new System.Drawing.Size(90, 25);
            this.kbtnClear.TabIndex = 1;
            this.kbtnClear.Values.Text = "Clear";
            // 
            // kbtnSave
            // 
            this.kbtnSave.Location = new System.Drawing.Point(357, 275);
            this.kbtnSave.Name = "kbtnSave";
            this.kbtnSave.Size = new System.Drawing.Size(90, 25);
            this.kbtnSave.TabIndex = 1;
            this.kbtnSave.Values.Text = "Save";
            // 
            // kgbContent
            // 
            this.kgbContent.Location = new System.Drawing.Point(12, 12);
            this.kgbContent.Name = "kgbContent";
            // 
            // kgbContent.Panel
            // 
            this.kgbContent.Panel.Controls.Add(this.spContent);
            this.kgbContent.Size = new System.Drawing.Size(435, 257);
            this.kgbContent.TabIndex = 2;
            this.kgbContent.Values.Heading = "";
            // 
            // EditSignatureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 316);
            this.Controls.Add(this.kgbContent);
            this.Controls.Add(this.kbtnClear);
            this.Controls.Add(this.kbtnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(465, 340);
            this.Name = "EditSignatureForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EditSignatureForm";
            ((System.ComponentModel.ISupportInitialize)(this.kgbContent.Panel)).EndInit();
            this.kgbContent.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kgbContent)).EndInit();
            this.kgbContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Topaz.SigPlusNET spContent;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kbtnClear;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kbtnSave;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kgbContent;
    }
}