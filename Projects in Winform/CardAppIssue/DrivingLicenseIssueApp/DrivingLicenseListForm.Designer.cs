using Common;

namespace DrivingLicenseIssueApp
{
    partial class DrivingLicenseListForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.kscMain = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.khgLeftSide = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.pcPage = new Common.PagingControl();
            this.kbtnPrint = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kbtnCaptureSignature = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kdgvData = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.colID = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colLastName = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colFirstName = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colMiddleName = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colPlaceOfBirth = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colDateOfBirth = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewDateTimePickerColumn();
            this.colCardNumber = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colStatus = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.kbtnTakePhoto = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kbtnNew = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.khgRightSide = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnRightSideHeader = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.lblOwnerName = new System.Windows.Forms.Label();
            this.pbSignature = new System.Windows.Forms.PictureBox();
            this.pbPhoto = new System.Windows.Forms.PictureBox();
            this.bsDL = new System.Windows.Forms.BindingSource(this.components);
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.tsmSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStartPrintService = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.kscMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kscMain.Panel1)).BeginInit();
            this.kscMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kscMain.Panel2)).BeginInit();
            this.kscMain.Panel2.SuspendLayout();
            this.kscMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.khgLeftSide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.khgLeftSide.Panel)).BeginInit();
            this.khgLeftSide.Panel.SuspendLayout();
            this.khgLeftSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kdgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.khgRightSide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.khgRightSide.Panel)).BeginInit();
            this.khgRightSide.Panel.SuspendLayout();
            this.khgRightSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSignature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDL)).BeginInit();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // kscMain
            // 
            this.kscMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.kscMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kscMain.IsSplitterFixed = true;
            this.kscMain.Location = new System.Drawing.Point(0, 24);
            this.kscMain.Name = "kscMain";
            // 
            // kscMain.Panel1
            // 
            this.kscMain.Panel1.Controls.Add(this.khgLeftSide);
            this.kscMain.Panel1MinSize = 0;
            // 
            // kscMain.Panel2
            // 
            this.kscMain.Panel2.Controls.Add(this.khgRightSide);
            this.kscMain.Panel2MinSize = 0;
            this.kscMain.Size = new System.Drawing.Size(964, 448);
            this.kscMain.SplitterDistance = 730;
            this.kscMain.TabIndex = 0;
            // 
            // khgLeftSide
            // 
            this.khgLeftSide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.khgLeftSide.HeaderVisibleSecondary = false;
            this.khgLeftSide.Location = new System.Drawing.Point(0, 0);
            this.khgLeftSide.Name = "khgLeftSide";
            // 
            // khgLeftSide.Panel
            // 
            this.khgLeftSide.Panel.Controls.Add(this.pcPage);
            this.khgLeftSide.Panel.Controls.Add(this.kbtnPrint);
            this.khgLeftSide.Panel.Controls.Add(this.kbtnCaptureSignature);
            this.khgLeftSide.Panel.Controls.Add(this.kdgvData);
            this.khgLeftSide.Panel.Controls.Add(this.kbtnTakePhoto);
            this.khgLeftSide.Panel.Controls.Add(this.kbtnNew);
            this.khgLeftSide.Size = new System.Drawing.Size(730, 448);
            this.khgLeftSide.TabIndex = 0;
            this.khgLeftSide.ValuesPrimary.Heading = "ListDL";
            this.khgLeftSide.ValuesPrimary.Image = null;
            // 
            // pcPage
            // 
            this.pcPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pcPage.CurrentPage = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.pcPage.Location = new System.Drawing.Point(489, 42);
            this.pcPage.MaximumSize = new System.Drawing.Size(230, 25);
            this.pcPage.Name = "pcPage";
            this.pcPage.PageSize = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.pcPage.Size = new System.Drawing.Size(230, 25);
            this.pcPage.TabIndex = 6;
            this.pcPage.TotalRecords = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // kbtnPrint
            // 
            this.kbtnPrint.Location = new System.Drawing.Point(289, 42);
            this.kbtnPrint.Name = "kbtnPrint";
            this.kbtnPrint.Size = new System.Drawing.Size(133, 25);
            this.kbtnPrint.TabIndex = 3;
            this.kbtnPrint.Values.Text = "Print";
            // 
            // kbtnCaptureSignature
            // 
            this.kbtnCaptureSignature.Location = new System.Drawing.Point(150, 42);
            this.kbtnCaptureSignature.Name = "kbtnCaptureSignature";
            this.kbtnCaptureSignature.Size = new System.Drawing.Size(133, 25);
            this.kbtnCaptureSignature.TabIndex = 2;
            this.kbtnCaptureSignature.Values.Text = "Capture signature";
            // 
            // kdgvData
            // 
            this.kdgvData.AllowUserToAddRows = false;
            this.kdgvData.AllowUserToDeleteRows = false;
            this.kdgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kdgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kdgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colLastName,
            this.colFirstName,
            this.colMiddleName,
            this.colPlaceOfBirth,
            this.colDateOfBirth,
            this.colCardNumber,
            this.colStatus});
            this.kdgvData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.kdgvData.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Sheet;
            this.kdgvData.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
            this.kdgvData.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.kdgvData.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.kdgvData.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.kdgvData.Location = new System.Drawing.Point(11, 73);
            this.kdgvData.MultiSelect = false;
            this.kdgvData.Name = "kdgvData";
            this.kdgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.kdgvData.Size = new System.Drawing.Size(708, 331);
            this.kdgvData.StandardTab = true;
            this.kdgvData.TabIndex = 4;
            // 
            // colID
            // 
            this.colID.DataPropertyName = "Id";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colID.DefaultCellStyle = dataGridViewCellStyle17;
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Width = 50;
            // 
            // colLastName
            // 
            this.colLastName.DataPropertyName = "LastName";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colLastName.DefaultCellStyle = dataGridViewCellStyle18;
            this.colLastName.HeaderText = "Last name";
            this.colLastName.MinimumWidth = 125;
            this.colLastName.Name = "colLastName";
            this.colLastName.ReadOnly = true;
            this.colLastName.Width = 125;
            // 
            // colFirstName
            // 
            this.colFirstName.DataPropertyName = "FirstName";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colFirstName.DefaultCellStyle = dataGridViewCellStyle19;
            this.colFirstName.HeaderText = "First name";
            this.colFirstName.MinimumWidth = 125;
            this.colFirstName.Name = "colFirstName";
            this.colFirstName.ReadOnly = true;
            this.colFirstName.Width = 125;
            // 
            // colMiddleName
            // 
            this.colMiddleName.DataPropertyName = "MiddleName";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colMiddleName.DefaultCellStyle = dataGridViewCellStyle20;
            this.colMiddleName.HeaderText = "Middle name";
            this.colMiddleName.MinimumWidth = 125;
            this.colMiddleName.Name = "colMiddleName";
            this.colMiddleName.ReadOnly = true;
            this.colMiddleName.Width = 125;
            // 
            // colPlaceOfBirth
            // 
            this.colPlaceOfBirth.DataPropertyName = "PlaceOfBirth";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colPlaceOfBirth.DefaultCellStyle = dataGridViewCellStyle21;
            this.colPlaceOfBirth.HeaderText = "Place of birth";
            this.colPlaceOfBirth.MinimumWidth = 125;
            this.colPlaceOfBirth.Name = "colPlaceOfBirth";
            this.colPlaceOfBirth.ReadOnly = true;
            this.colPlaceOfBirth.Width = 125;
            // 
            // colDateOfBirth
            // 
            this.colDateOfBirth.CalendarTodayDate = new System.DateTime(2017, 8, 7, 0, 0, 0, 0);
            this.colDateOfBirth.Checked = false;
            this.colDateOfBirth.DataPropertyName = "DateOfBirth";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colDateOfBirth.DefaultCellStyle = dataGridViewCellStyle22;
            this.colDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.colDateOfBirth.HeaderText = "Date of birth";
            this.colDateOfBirth.Name = "colDateOfBirth";
            this.colDateOfBirth.ReadOnly = true;
            this.colDateOfBirth.Width = 100;
            // 
            // colCardNumber
            // 
            this.colCardNumber.DataPropertyName = "CardNumber";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCardNumber.DefaultCellStyle = dataGridViewCellStyle23;
            this.colCardNumber.HeaderText = "Card number";
            this.colCardNumber.MinimumWidth = 125;
            this.colCardNumber.Name = "colCardNumber";
            this.colCardNumber.ReadOnly = true;
            this.colCardNumber.Width = 125;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colStatus.DefaultCellStyle = dataGridViewCellStyle24;
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 100;
            // 
            // kbtnTakePhoto
            // 
            this.kbtnTakePhoto.Location = new System.Drawing.Point(11, 42);
            this.kbtnTakePhoto.Name = "kbtnTakePhoto";
            this.kbtnTakePhoto.Size = new System.Drawing.Size(133, 25);
            this.kbtnTakePhoto.TabIndex = 1;
            this.kbtnTakePhoto.Values.Text = "Take photo";
            // 
            // kbtnNew
            // 
            this.kbtnNew.Location = new System.Drawing.Point(11, 11);
            this.kbtnNew.Name = "kbtnNew";
            this.kbtnNew.Size = new System.Drawing.Size(133, 25);
            this.kbtnNew.TabIndex = 0;
            this.kbtnNew.Values.Text = "New";
            // 
            // khgRightSide
            // 
            this.khgRightSide.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnRightSideHeader});
            this.khgRightSide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.khgRightSide.HeaderVisibleSecondary = false;
            this.khgRightSide.Location = new System.Drawing.Point(0, 0);
            this.khgRightSide.Name = "khgRightSide";
            // 
            // khgRightSide.Panel
            // 
            this.khgRightSide.Panel.Controls.Add(this.lblOwnerName);
            this.khgRightSide.Panel.Controls.Add(this.pbSignature);
            this.khgRightSide.Panel.Controls.Add(this.pbPhoto);
            this.khgRightSide.Size = new System.Drawing.Size(229, 448);
            this.khgRightSide.TabIndex = 0;
            this.khgRightSide.ValuesPrimary.Heading = "View";
            this.khgRightSide.ValuesPrimary.Image = null;
            // 
            // btnRightSideHeader
            // 
            this.btnRightSideHeader.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.ArrowRight;
            this.btnRightSideHeader.UniqueName = "btnRightSideHeader";
            // 
            // lblOwnerName
            // 
            this.lblOwnerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOwnerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblOwnerName.Location = new System.Drawing.Point(6, 9);
            this.lblOwnerName.Name = "lblOwnerName";
            this.lblOwnerName.Size = new System.Drawing.Size(215, 67);
            this.lblOwnerName.TabIndex = 0;
            this.lblOwnerName.Text = "Owner name";
            this.lblOwnerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbSignature
            // 
            this.pbSignature.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbSignature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSignature.Location = new System.Drawing.Point(13, 351);
            this.pbSignature.Name = "pbSignature";
            this.pbSignature.Size = new System.Drawing.Size(200, 120);
            this.pbSignature.TabIndex = 1;
            this.pbSignature.TabStop = false;
            // 
            // pbPhoto
            // 
            this.pbPhoto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPhoto.Location = new System.Drawing.Point(13, 85);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(200, 250);
            this.pbPhoto.TabIndex = 0;
            this.pbPhoto.TabStop = false;
            // 
            // msMain
            // 
            this.msMain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSettings,
            this.tsmStartPrintService});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(964, 24);
            this.msMain.TabIndex = 1;
            this.msMain.Text = "menuStrip1";
            // 
            // tsmSettings
            // 
            this.tsmSettings.Name = "tsmSettings";
            this.tsmSettings.Size = new System.Drawing.Size(61, 20);
            this.tsmSettings.Text = "Settings";
            // 
            // tsmStartPrintService
            // 
            this.tsmStartPrintService.Name = "tsmStartPrintService";
            this.tsmStartPrintService.Size = new System.Drawing.Size(110, 20);
            this.tsmStartPrintService.Text = "Start print service";
            // 
            // DrivingLicenseListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 472);
            this.Controls.Add(this.kscMain);
            this.Controls.Add(this.msMain);
            this.MainMenuStrip = this.msMain;
            this.MinimumSize = new System.Drawing.Size(980, 460);
            this.Name = "DrivingLicenseListForm";
            this.Text = "DrivingLicenseListForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.kscMain.Panel1)).EndInit();
            this.kscMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kscMain.Panel2)).EndInit();
            this.kscMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kscMain)).EndInit();
            this.kscMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.khgLeftSide.Panel)).EndInit();
            this.khgLeftSide.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.khgLeftSide)).EndInit();
            this.khgLeftSide.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kdgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.khgRightSide.Panel)).EndInit();
            this.khgRightSide.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.khgRightSide)).EndInit();
            this.khgRightSide.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSignature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDL)).EndInit();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kscMain;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup khgLeftSide;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup khgRightSide;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnRightSideHeader;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kdgvData;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kbtnNew;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kbtnPrint;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kbtnTakePhoto;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kbtnCaptureSignature;
        private System.Windows.Forms.PictureBox pbPhoto;
        private System.Windows.Forms.PictureBox pbSignature;
        private System.Windows.Forms.BindingSource bsDL;
        private System.Windows.Forms.Label lblOwnerName;
        private PagingControl pcPage;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmStartPrintService;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colID;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colLastName;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colFirstName;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colMiddleName;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colPlaceOfBirth;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewDateTimePickerColumn colDateOfBirth;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colCardNumber;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colStatus;


    }
}

