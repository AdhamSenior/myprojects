namespace DrivingLicenseIssueApp
{
    sealed partial class EditPhotoForm
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
            this.pbPhoto = new System.Windows.Forms.PictureBox();
            this.kbtnCrop = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kbtnRefresh = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kbtnReady = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPhoto
            // 
            this.pbPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPhoto.Location = new System.Drawing.Point(12, 12);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(675, 450);
            this.pbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbPhoto.TabIndex = 0;
            this.pbPhoto.TabStop = false;
            // 
            // kbtnCrop
            // 
            this.kbtnCrop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCrop.Location = new System.Drawing.Point(501, 471);
            this.kbtnCrop.Name = "kbtnCrop";
            this.kbtnCrop.Size = new System.Drawing.Size(90, 25);
            this.kbtnCrop.TabIndex = 2;
            this.kbtnCrop.Values.Text = "Crop";
            // 
            // kbtnRefresh
            // 
            this.kbtnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kbtnRefresh.Location = new System.Drawing.Point(12, 471);
            this.kbtnRefresh.Name = "kbtnRefresh";
            this.kbtnRefresh.Size = new System.Drawing.Size(90, 25);
            this.kbtnRefresh.TabIndex = 3;
            this.kbtnRefresh.Values.Text = "Refresh";
            // 
            // kbtnReady
            // 
            this.kbtnReady.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnReady.Location = new System.Drawing.Point(597, 471);
            this.kbtnReady.Name = "kbtnReady";
            this.kbtnReady.Size = new System.Drawing.Size(90, 25);
            this.kbtnReady.TabIndex = 4;
            this.kbtnReady.Values.Text = "Ready";
            // 
            // EditPhotoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 506);
            this.Controls.Add(this.kbtnReady);
            this.Controls.Add(this.kbtnRefresh);
            this.Controls.Add(this.kbtnCrop);
            this.Controls.Add(this.pbPhoto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(705, 530);
            this.Name = "EditPhotoForm";
            this.Text = "EditPhotoForm";
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPhoto;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kbtnCrop;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kbtnRefresh;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kbtnReady;
    }
}