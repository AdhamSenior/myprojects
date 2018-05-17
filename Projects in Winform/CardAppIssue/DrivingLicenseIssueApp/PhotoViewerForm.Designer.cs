namespace DrivingLicenseIssueApp
{
    partial class PhotoViewerForm
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
            this.scPanel = new System.Windows.Forms.SplitContainer();
            this.pbLiveView = new System.Windows.Forms.PictureBox();
            this.kbtnFocusNear = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kbtnFocusFar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kcbTv = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kcbAv = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kcbIso = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kbtnCapturePhoto = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kbtnSession = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kbtnGetCameras = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblTv = new System.Windows.Forms.Label();
            this.lblAv = new System.Windows.Forms.Label();
            this.lblIso = new System.Windows.Forms.Label();
            this.lblCamera = new System.Windows.Forms.Label();
            this.lvCamera = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.scPanel)).BeginInit();
            this.scPanel.Panel1.SuspendLayout();
            this.scPanel.Panel2.SuspendLayout();
            this.scPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLiveView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcbTv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcbAv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcbIso)).BeginInit();
            this.SuspendLayout();
            // 
            // scPanel
            // 
            this.scPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scPanel.Location = new System.Drawing.Point(0, 0);
            this.scPanel.Name = "scPanel";
            // 
            // scPanel.Panel1
            // 
            this.scPanel.Panel1.Controls.Add(this.pbLiveView);
            this.scPanel.Panel1.Margin = new System.Windows.Forms.Padding(5);
            // 
            // scPanel.Panel2
            // 
            this.scPanel.Panel2.Controls.Add(this.kbtnFocusNear);
            this.scPanel.Panel2.Controls.Add(this.kbtnFocusFar);
            this.scPanel.Panel2.Controls.Add(this.kcbTv);
            this.scPanel.Panel2.Controls.Add(this.kcbAv);
            this.scPanel.Panel2.Controls.Add(this.kcbIso);
            this.scPanel.Panel2.Controls.Add(this.kbtnCapturePhoto);
            this.scPanel.Panel2.Controls.Add(this.kbtnSession);
            this.scPanel.Panel2.Controls.Add(this.kbtnGetCameras);
            this.scPanel.Panel2.Controls.Add(this.lblTv);
            this.scPanel.Panel2.Controls.Add(this.lblAv);
            this.scPanel.Panel2.Controls.Add(this.lblIso);
            this.scPanel.Panel2.Controls.Add(this.lblCamera);
            this.scPanel.Panel2.Controls.Add(this.lvCamera);
            this.scPanel.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.scPanel.Size = new System.Drawing.Size(849, 436);
            this.scPanel.SplitterDistance = 589;
            this.scPanel.TabIndex = 0;
            // 
            // pbLiveView
            // 
            this.pbLiveView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLiveView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLiveView.Location = new System.Drawing.Point(10, 26);
            this.pbLiveView.Name = "pbLiveView";
            this.pbLiveView.Size = new System.Drawing.Size(570, 380);
            this.pbLiveView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbLiveView.TabIndex = 0;
            this.pbLiveView.TabStop = false;
            // 
            // kbtnFocusNear
            // 
            this.kbtnFocusNear.Location = new System.Drawing.Point(124, 291);
            this.kbtnFocusNear.Name = "kbtnFocusNear";
            this.kbtnFocusNear.Size = new System.Drawing.Size(104, 25);
            this.kbtnFocusNear.TabIndex = 12;
            this.kbtnFocusNear.Values.Text = "Focus -";
            // 
            // kbtnFocusFar
            // 
            this.kbtnFocusFar.Location = new System.Drawing.Point(11, 291);
            this.kbtnFocusFar.Name = "kbtnFocusFar";
            this.kbtnFocusFar.Size = new System.Drawing.Size(104, 25);
            this.kbtnFocusFar.TabIndex = 12;
            this.kbtnFocusFar.Values.Text = "Focus +";
            // 
            // kcbTv
            // 
            this.kcbTv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kcbTv.DropDownHeight = 106;
            this.kcbTv.DropDownWidth = 226;
            this.kcbTv.Location = new System.Drawing.Point(11, 264);
            this.kcbTv.Name = "kcbTv";
            this.kcbTv.Size = new System.Drawing.Size(231, 21);
            this.kcbTv.TabIndex = 11;
            // 
            // kcbAv
            // 
            this.kcbAv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kcbAv.DropDownHeight = 106;
            this.kcbAv.DropDownWidth = 226;
            this.kcbAv.Location = new System.Drawing.Point(11, 224);
            this.kcbAv.Name = "kcbAv";
            this.kcbAv.Size = new System.Drawing.Size(231, 21);
            this.kcbAv.TabIndex = 11;
            // 
            // kcbIso
            // 
            this.kcbIso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kcbIso.DropDownHeight = 106;
            this.kcbIso.DropDownWidth = 226;
            this.kcbIso.Location = new System.Drawing.Point(11, 184);
            this.kcbIso.Name = "kcbIso";
            this.kcbIso.Size = new System.Drawing.Size(231, 21);
            this.kcbIso.TabIndex = 11;
            // 
            // kbtnCapturePhoto
            // 
            this.kbtnCapturePhoto.Location = new System.Drawing.Point(11, 340);
            this.kbtnCapturePhoto.Name = "kbtnCapturePhoto";
            this.kbtnCapturePhoto.Size = new System.Drawing.Size(217, 69);
            this.kbtnCapturePhoto.TabIndex = 10;
            this.kbtnCapturePhoto.Values.Text = "Capture photo";
            // 
            // kbtnSession
            // 
            this.kbtnSession.Location = new System.Drawing.Point(11, 129);
            this.kbtnSession.Name = "kbtnSession";
            this.kbtnSession.Size = new System.Drawing.Size(104, 25);
            this.kbtnSession.TabIndex = 3;
            this.kbtnSession.Values.Text = "Start session";
            // 
            // kbtnGetCameras
            // 
            this.kbtnGetCameras.Location = new System.Drawing.Point(124, 129);
            this.kbtnGetCameras.Name = "kbtnGetCameras";
            this.kbtnGetCameras.Size = new System.Drawing.Size(104, 25);
            this.kbtnGetCameras.TabIndex = 2;
            this.kbtnGetCameras.Values.Text = "Get cameras";
            // 
            // lblTv
            // 
            this.lblTv.AutoSize = true;
            this.lblTv.Location = new System.Drawing.Point(8, 248);
            this.lblTv.Name = "lblTv";
            this.lblTv.Size = new System.Drawing.Size(24, 13);
            this.lblTv.TabIndex = 8;
            this.lblTv.Text = "TV:";
            // 
            // lblAv
            // 
            this.lblAv.AutoSize = true;
            this.lblAv.Location = new System.Drawing.Point(8, 208);
            this.lblAv.Name = "lblAv";
            this.lblAv.Size = new System.Drawing.Size(24, 13);
            this.lblAv.TabIndex = 6;
            this.lblAv.Text = "AV:";
            // 
            // lblIso
            // 
            this.lblIso.AutoSize = true;
            this.lblIso.Location = new System.Drawing.Point(8, 168);
            this.lblIso.Name = "lblIso";
            this.lblIso.Size = new System.Drawing.Size(28, 13);
            this.lblIso.TabIndex = 4;
            this.lblIso.Text = "ISO:";
            // 
            // lblCamera
            // 
            this.lblCamera.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCamera.Location = new System.Drawing.Point(8, 9);
            this.lblCamera.Name = "lblCamera";
            this.lblCamera.Size = new System.Drawing.Size(240, 13);
            this.lblCamera.TabIndex = 0;
            this.lblCamera.Text = "Available cameras";
            this.lblCamera.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvCamera
            // 
            this.lvCamera.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvCamera.FormattingEnabled = true;
            this.lvCamera.Location = new System.Drawing.Point(11, 28);
            this.lvCamera.Name = "lvCamera";
            this.lvCamera.Size = new System.Drawing.Size(231, 95);
            this.lvCamera.TabIndex = 1;
            // 
            // PhotoViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 436);
            this.Controls.Add(this.scPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(865, 470);
            this.Name = "PhotoViewerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PhotoViewerForm";
            this.scPanel.Panel1.ResumeLayout(false);
            this.scPanel.Panel2.ResumeLayout(false);
            this.scPanel.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scPanel)).EndInit();
            this.scPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLiveView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcbTv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcbAv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcbIso)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scPanel;
        private System.Windows.Forms.PictureBox pbLiveView;
        private System.Windows.Forms.ListBox lvCamera;
        private System.Windows.Forms.Label lblCamera;
        private System.Windows.Forms.Label lblIso;
        private System.Windows.Forms.Label lblAv;
        private System.Windows.Forms.Label lblTv;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kbtnGetCameras;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kbtnSession;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kbtnCapturePhoto;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox kcbIso;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox kcbAv;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox kcbTv;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kbtnFocusNear;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kbtnFocusFar;
    }
}