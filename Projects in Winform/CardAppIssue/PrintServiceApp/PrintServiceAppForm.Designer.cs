namespace PrintServiceApp
{
    partial class PrintServiceAppForm
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
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.tiService = new System.Windows.Forms.Timer(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPrintTemplate = new System.Windows.Forms.Button();
            this.lblProductionLine = new System.Windows.Forms.Label();
            this.lblPrinter = new System.Windows.Forms.Label();
            this.rbDrivingLicense = new System.Windows.Forms.RadioButton();
            this.rbVehicleLicense = new System.Windows.Forms.RadioButton();
            this.cbPrinter = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.cbProductionLine = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cbPrinter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbProductionLine)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbLog
            // 
            this.rtbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbLog.Location = new System.Drawing.Point(12, 92);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(710, 279);
            this.rtbLog.TabIndex = 6;
            this.rtbLog.Text = "";
            // 
            // tiService
            // 
            this.tiService.Interval = 5000;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.Location = new System.Drawing.Point(12, 377);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(83, 23);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "Start service";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStop.Location = new System.Drawing.Point(101, 377);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(83, 23);
            this.btnStop.TabIndex = 8;
            this.btnStop.Text = "Stop service";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // btnPrintTemplate
            // 
            this.btnPrintTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintTemplate.Location = new System.Drawing.Point(607, 377);
            this.btnPrintTemplate.Name = "btnPrintTemplate";
            this.btnPrintTemplate.Size = new System.Drawing.Size(115, 23);
            this.btnPrintTemplate.TabIndex = 9;
            this.btnPrintTemplate.Text = "Print template";
            this.btnPrintTemplate.UseVisualStyleBackColor = true;
            // 
            // lblProductionLine
            // 
            this.lblProductionLine.AutoSize = true;
            this.lblProductionLine.Location = new System.Drawing.Point(14, 16);
            this.lblProductionLine.Name = "lblProductionLine";
            this.lblProductionLine.Size = new System.Drawing.Size(80, 13);
            this.lblProductionLine.TabIndex = 0;
            this.lblProductionLine.Text = "Production line:";
            // 
            // lblPrinter
            // 
            this.lblPrinter.AutoSize = true;
            this.lblPrinter.Location = new System.Drawing.Point(14, 43);
            this.lblPrinter.Name = "lblPrinter";
            this.lblPrinter.Size = new System.Drawing.Size(40, 13);
            this.lblPrinter.TabIndex = 2;
            this.lblPrinter.Text = "Printer:";
            // 
            // rbDrivingLicense
            // 
            this.rbDrivingLicense.AutoSize = true;
            this.rbDrivingLicense.Location = new System.Drawing.Point(100, 69);
            this.rbDrivingLicense.Name = "rbDrivingLicense";
            this.rbDrivingLicense.Size = new System.Drawing.Size(98, 17);
            this.rbDrivingLicense.TabIndex = 4;
            this.rbDrivingLicense.TabStop = true;
            this.rbDrivingLicense.Text = "Driving License";
            this.rbDrivingLicense.UseVisualStyleBackColor = true;
            // 
            // rbVehicleLicense
            // 
            this.rbVehicleLicense.AutoSize = true;
            this.rbVehicleLicense.Location = new System.Drawing.Point(204, 69);
            this.rbVehicleLicense.Name = "rbVehicleLicense";
            this.rbVehicleLicense.Size = new System.Drawing.Size(100, 17);
            this.rbVehicleLicense.TabIndex = 5;
            this.rbVehicleLicense.TabStop = true;
            this.rbVehicleLicense.Text = "Vehicle License";
            this.rbVehicleLicense.UseVisualStyleBackColor = true;
            // 
            // cbPrinter
            // 
            this.cbPrinter.DropDownWidth = 622;
            this.cbPrinter.Location = new System.Drawing.Point(100, 39);
            this.cbPrinter.Name = "cbPrinter";
            this.cbPrinter.Size = new System.Drawing.Size(622, 21);
            this.cbPrinter.TabIndex = 3;
            // 
            // cbProductionLine
            // 
            this.cbProductionLine.DropDownWidth = 622;
            this.cbProductionLine.Location = new System.Drawing.Point(100, 12);
            this.cbProductionLine.Name = "cbProductionLine";
            this.cbProductionLine.Size = new System.Drawing.Size(622, 21);
            this.cbProductionLine.TabIndex = 1;
            // 
            // btnClearLog
            // 
            this.btnClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearLog.Location = new System.Drawing.Point(486, 377);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(115, 23);
            this.btnClearLog.TabIndex = 10;
            this.btnClearLog.Text = "Clear log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            // 
            // PrintServiceAppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 412);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.cbProductionLine);
            this.Controls.Add(this.cbPrinter);
            this.Controls.Add(this.rbVehicleLicense);
            this.Controls.Add(this.rbDrivingLicense);
            this.Controls.Add(this.lblPrinter);
            this.Controls.Add(this.lblProductionLine);
            this.Controls.Add(this.btnPrintTemplate);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.rtbLog);
            this.MinimumSize = new System.Drawing.Size(750, 450);
            this.Name = "PrintServiceAppForm";
            this.Text = "PrintServiceAppForm";
            ((System.ComponentModel.ISupportInitialize)(this.cbPrinter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbProductionLine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Timer tiService;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPrintTemplate;
        private System.Windows.Forms.Label lblProductionLine;
        private System.Windows.Forms.Label lblPrinter;
        private System.Windows.Forms.RadioButton rbDrivingLicense;
        private System.Windows.Forms.RadioButton rbVehicleLicense;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbPrinter;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbProductionLine;
        private System.Windows.Forms.Button btnClearLog;
    }
}

