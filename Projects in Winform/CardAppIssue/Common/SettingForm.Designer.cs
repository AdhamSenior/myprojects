namespace Common
{
    partial class SettingForm
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
            this.klblApiUrl = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.klblPrinterName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.klblProductionLine = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kcbProductionLine = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kcbPrinterName = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.ktbApiUrl = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kbtnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kcbProductionLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcbPrinterName)).BeginInit();
            this.SuspendLayout();
            // 
            // klblApiUrl
            // 
            this.klblApiUrl.Location = new System.Drawing.Point(12, 12);
            this.klblApiUrl.Name = "klblApiUrl";
            this.klblApiUrl.Size = new System.Drawing.Size(46, 20);
            this.klblApiUrl.TabIndex = 0;
            this.klblApiUrl.Values.Text = "Api url";
            // 
            // klblPrinterName
            // 
            this.klblPrinterName.Location = new System.Drawing.Point(12, 40);
            this.klblPrinterName.Name = "klblPrinterName";
            this.klblPrinterName.Size = new System.Drawing.Size(80, 20);
            this.klblPrinterName.TabIndex = 2;
            this.klblPrinterName.Values.Text = "Printer name";
            // 
            // klblProductionLine
            // 
            this.klblProductionLine.Location = new System.Drawing.Point(12, 68);
            this.klblProductionLine.Name = "klblProductionLine";
            this.klblProductionLine.Size = new System.Drawing.Size(93, 20);
            this.klblProductionLine.TabIndex = 4;
            this.klblProductionLine.Values.Text = "Production line";
            // 
            // kcbProductionLine
            // 
            this.kcbProductionLine.DropDownWidth = 278;
            this.kcbProductionLine.Location = new System.Drawing.Point(153, 68);
            this.kcbProductionLine.Name = "kcbProductionLine";
            this.kcbProductionLine.Size = new System.Drawing.Size(278, 21);
            this.kcbProductionLine.TabIndex = 5;
            // 
            // kcbPrinterName
            // 
            this.kcbPrinterName.DropDownWidth = 278;
            this.kcbPrinterName.Location = new System.Drawing.Point(153, 38);
            this.kcbPrinterName.Name = "kcbPrinterName";
            this.kcbPrinterName.Size = new System.Drawing.Size(278, 21);
            this.kcbPrinterName.TabIndex = 3;
            // 
            // ktbApiUrl
            // 
            this.ktbApiUrl.Location = new System.Drawing.Point(153, 12);
            this.ktbApiUrl.Name = "ktbApiUrl";
            this.ktbApiUrl.Size = new System.Drawing.Size(278, 20);
            this.ktbApiUrl.TabIndex = 1;
            // 
            // kbtnSave
            // 
            this.kbtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnSave.Location = new System.Drawing.Point(341, 107);
            this.kbtnSave.Name = "kbtnSave";
            this.kbtnSave.Size = new System.Drawing.Size(90, 25);
            this.kbtnSave.TabIndex = 6;
            this.kbtnSave.Values.Text = "Save";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 144);
            this.Controls.Add(this.kbtnSave);
            this.Controls.Add(this.ktbApiUrl);
            this.Controls.Add(this.kcbPrinterName);
            this.Controls.Add(this.kcbProductionLine);
            this.Controls.Add(this.klblProductionLine);
            this.Controls.Add(this.klblPrinterName);
            this.Controls.Add(this.klblApiUrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingForm";
            this.Text = "SettingForm";
            ((System.ComponentModel.ISupportInitialize)(this.kcbProductionLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcbPrinterName)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonLabel klblApiUrl;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel klblPrinterName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel klblProductionLine;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox kcbProductionLine;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox kcbPrinterName;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktbApiUrl;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kbtnSave;
    }
}