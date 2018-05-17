namespace DrivingLicenseIssueApp
{
    partial class DrivingLicenseObjectForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblLastName = new System.Windows.Forms.Label();
            this.ktbLastName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.bsHolder = new System.Windows.Forms.BindingSource(this.components);
            this.lblFirstName = new System.Windows.Forms.Label();
            this.ktbFirstName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblMiddleName = new System.Windows.Forms.Label();
            this.ktbMiddleName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblPlaceOfBirth = new System.Windows.Forms.Label();
            this.lblPlaceOfIssue = new System.Windows.Forms.Label();
            this.ktbPlaceOfIssue = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.bsDL = new System.Windows.Forms.BindingSource(this.components);
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.kdtpDateOfBirth = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.lblDateOfIssue = new System.Windows.Forms.Label();
            this.kdtpDateOfIssue = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.lblDateOfExpiry = new System.Windows.Forms.Label();
            this.kdtpDateOfExpiry = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.lblPersonalNumber = new System.Windows.Forms.Label();
            this.ktbPersonalNumber = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblCardNumber = new System.Windows.Forms.Label();
            this.ktbCardNumber = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.ktbPlaceOfResidence = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.bsAddress = new System.Windows.Forms.BindingSource(this.components);
            this.kdgvCategory = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.colChecked = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewCheckBoxColumn();
            this.colCategory = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colDateOfIssue = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewDateTimePickerColumn();
            this.colDateOfExpiry = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewDateTimePickerColumn();
            this.colAddInfo = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.lblCategory = new System.Windows.Forms.Label();
            this.kbtnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.bsCategory = new System.Windows.Forms.BindingSource(this.components);
            this.lblRegion = new System.Windows.Forms.Label();
            this.kcbRegion = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.lblDistrict = new System.Windows.Forms.Label();
            this.ktbDistrict = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.gbPlaceOfResidence = new System.Windows.Forms.GroupBox();
            this.ktbRegionId = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kbtnSelectDistrict = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kbtnPlaceOfIssue = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.ktbPlaceOfBirth = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblPassport = new System.Windows.Forms.Label();
            this.ktbPassportSn = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.bsPassport = new System.Windows.Forms.BindingSource(this.components);
            this.ktbPassportNumber = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblSex = new System.Windows.Forms.Label();
            this.kcbSex = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kcbCitizenship = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.bsHolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kdgvCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcbRegion)).BeginInit();
            this.gbPlaceOfResidence.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPassport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcbSex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcbCitizenship)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLastName
            // 
            this.lblLastName.Location = new System.Drawing.Point(12, 42);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(114, 13);
            this.lblLastName.TabIndex = 4;
            this.lblLastName.Text = "Last name";
            // 
            // ktbLastName
            // 
            this.ktbLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ktbLastName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHolder, "LastName", true));
            this.ktbLastName.Location = new System.Drawing.Point(132, 38);
            this.ktbLastName.MaxLength = 37;
            this.ktbLastName.Name = "ktbLastName";
            this.ktbLastName.Size = new System.Drawing.Size(510, 20);
            this.ktbLastName.TabIndex = 5;
            // 
            // bsHolder
            // 
            this.bsHolder.DataSource = typeof(DrivingLicenseIssueApp.Logic.HolderInfo);
            // 
            // lblFirstName
            // 
            this.lblFirstName.Location = new System.Drawing.Point(12, 68);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(114, 13);
            this.lblFirstName.TabIndex = 6;
            this.lblFirstName.Text = "First name";
            // 
            // ktbFirstName
            // 
            this.ktbFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ktbFirstName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHolder, "FirstName", true));
            this.ktbFirstName.Location = new System.Drawing.Point(132, 64);
            this.ktbFirstName.MaxLength = 37;
            this.ktbFirstName.Name = "ktbFirstName";
            this.ktbFirstName.Size = new System.Drawing.Size(510, 20);
            this.ktbFirstName.TabIndex = 7;
            // 
            // lblMiddleName
            // 
            this.lblMiddleName.Location = new System.Drawing.Point(12, 94);
            this.lblMiddleName.Name = "lblMiddleName";
            this.lblMiddleName.Size = new System.Drawing.Size(114, 13);
            this.lblMiddleName.TabIndex = 8;
            this.lblMiddleName.Text = "Middle name";
            // 
            // ktbMiddleName
            // 
            this.ktbMiddleName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ktbMiddleName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHolder, "MiddleName", true));
            this.ktbMiddleName.Location = new System.Drawing.Point(132, 90);
            this.ktbMiddleName.MaxLength = 37;
            this.ktbMiddleName.Name = "ktbMiddleName";
            this.ktbMiddleName.Size = new System.Drawing.Size(510, 20);
            this.ktbMiddleName.TabIndex = 9;
            // 
            // lblPlaceOfBirth
            // 
            this.lblPlaceOfBirth.Location = new System.Drawing.Point(12, 120);
            this.lblPlaceOfBirth.Name = "lblPlaceOfBirth";
            this.lblPlaceOfBirth.Size = new System.Drawing.Size(114, 13);
            this.lblPlaceOfBirth.TabIndex = 10;
            this.lblPlaceOfBirth.Text = "Place of birth";
            // 
            // lblPlaceOfIssue
            // 
            this.lblPlaceOfIssue.Location = new System.Drawing.Point(12, 232);
            this.lblPlaceOfIssue.Name = "lblPlaceOfIssue";
            this.lblPlaceOfIssue.Size = new System.Drawing.Size(114, 13);
            this.lblPlaceOfIssue.TabIndex = 22;
            this.lblPlaceOfIssue.Text = "Place of issue";
            // 
            // ktbPlaceOfIssue
            // 
            this.ktbPlaceOfIssue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ktbPlaceOfIssue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDL, "PlaceOfIssue", true));
            this.ktbPlaceOfIssue.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.bsDL, "PlaceOfIssueId", true));
            this.ktbPlaceOfIssue.Enabled = false;
            this.ktbPlaceOfIssue.Location = new System.Drawing.Point(132, 229);
            this.ktbPlaceOfIssue.MaxLength = 33;
            this.ktbPlaceOfIssue.Name = "ktbPlaceOfIssue";
            this.ktbPlaceOfIssue.Size = new System.Drawing.Size(472, 20);
            this.ktbPlaceOfIssue.TabIndex = 23;
            this.ktbPlaceOfIssue.TabStop = false;
            // 
            // bsDL
            // 
            this.bsDL.DataSource = typeof(DrivingLicenseIssueApp.Logic.DrivingLicense);
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.Location = new System.Drawing.Point(12, 147);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(114, 13);
            this.lblDateOfBirth.TabIndex = 12;
            this.lblDateOfBirth.Text = "Date of birth";
            // 
            // kdtpDateOfBirth
            // 
            this.kdtpDateOfBirth.AutoShift = true;
            this.kdtpDateOfBirth.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsHolder, "DateOfBirth", true));
            this.kdtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.kdtpDateOfBirth.Location = new System.Drawing.Point(132, 143);
            this.kdtpDateOfBirth.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.kdtpDateOfBirth.Name = "kdtpDateOfBirth";
            this.kdtpDateOfBirth.Size = new System.Drawing.Size(103, 21);
            this.kdtpDateOfBirth.TabIndex = 13;
            this.kdtpDateOfBirth.ValueNullable = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // lblDateOfIssue
            // 
            this.lblDateOfIssue.Location = new System.Drawing.Point(12, 206);
            this.lblDateOfIssue.Name = "lblDateOfIssue";
            this.lblDateOfIssue.Size = new System.Drawing.Size(114, 13);
            this.lblDateOfIssue.TabIndex = 18;
            this.lblDateOfIssue.Text = "Date of issue";
            // 
            // kdtpDateOfIssue
            // 
            this.kdtpDateOfIssue.AutoShift = true;
            this.kdtpDateOfIssue.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsDL, "DateOfIssue", true));
            this.kdtpDateOfIssue.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.kdtpDateOfIssue.Location = new System.Drawing.Point(132, 202);
            this.kdtpDateOfIssue.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.kdtpDateOfIssue.Name = "kdtpDateOfIssue";
            this.kdtpDateOfIssue.Size = new System.Drawing.Size(103, 21);
            this.kdtpDateOfIssue.TabIndex = 19;
            this.kdtpDateOfIssue.TabStop = false;
            this.kdtpDateOfIssue.ValueNullable = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // lblDateOfExpiry
            // 
            this.lblDateOfExpiry.Location = new System.Drawing.Point(250, 206);
            this.lblDateOfExpiry.Name = "lblDateOfExpiry";
            this.lblDateOfExpiry.Size = new System.Drawing.Size(104, 13);
            this.lblDateOfExpiry.TabIndex = 20;
            this.lblDateOfExpiry.Text = "Date of expiry";
            // 
            // kdtpDateOfExpiry
            // 
            this.kdtpDateOfExpiry.AutoShift = true;
            this.kdtpDateOfExpiry.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsDL, "DateOfExpiry", true));
            this.kdtpDateOfExpiry.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.kdtpDateOfExpiry.Location = new System.Drawing.Point(361, 202);
            this.kdtpDateOfExpiry.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.kdtpDateOfExpiry.Name = "kdtpDateOfExpiry";
            this.kdtpDateOfExpiry.Size = new System.Drawing.Size(103, 21);
            this.kdtpDateOfExpiry.TabIndex = 21;
            this.kdtpDateOfExpiry.TabStop = false;
            this.kdtpDateOfExpiry.ValueNullable = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // lblPersonalNumber
            // 
            this.lblPersonalNumber.Location = new System.Drawing.Point(250, 147);
            this.lblPersonalNumber.Name = "lblPersonalNumber";
            this.lblPersonalNumber.Size = new System.Drawing.Size(114, 13);
            this.lblPersonalNumber.TabIndex = 14;
            this.lblPersonalNumber.Text = "Personal number";
            // 
            // ktbPersonalNumber
            // 
            this.ktbPersonalNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ktbPersonalNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHolder, "PersonalNumber", true));
            this.ktbPersonalNumber.Location = new System.Drawing.Point(361, 144);
            this.ktbPersonalNumber.MaxLength = 14;
            this.ktbPersonalNumber.Name = "ktbPersonalNumber";
            this.ktbPersonalNumber.Size = new System.Drawing.Size(196, 20);
            this.ktbPersonalNumber.TabIndex = 15;
            // 
            // lblCardNumber
            // 
            this.lblCardNumber.Location = new System.Drawing.Point(12, 258);
            this.lblCardNumber.Name = "lblCardNumber";
            this.lblCardNumber.Size = new System.Drawing.Size(114, 13);
            this.lblCardNumber.TabIndex = 25;
            this.lblCardNumber.Text = "Card number";
            // 
            // ktbCardNumber
            // 
            this.ktbCardNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ktbCardNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDL, "CardNumber", true));
            this.ktbCardNumber.Enabled = false;
            this.ktbCardNumber.Location = new System.Drawing.Point(132, 255);
            this.ktbCardNumber.MaxLength = 9;
            this.ktbCardNumber.Name = "ktbCardNumber";
            this.ktbCardNumber.Size = new System.Drawing.Size(196, 20);
            this.ktbCardNumber.TabIndex = 26;
            this.ktbCardNumber.TabStop = false;
            // 
            // lblAddress
            // 
            this.lblAddress.Location = new System.Drawing.Point(7, 77);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(104, 13);
            this.lblAddress.TabIndex = 6;
            this.lblAddress.Text = "Address";
            // 
            // ktbPlaceOfResidence
            // 
            this.ktbPlaceOfResidence.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ktbPlaceOfResidence.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAddress, "Address", true));
            this.ktbPlaceOfResidence.Location = new System.Drawing.Point(117, 74);
            this.ktbPlaceOfResidence.MaxLength = 75;
            this.ktbPlaceOfResidence.Name = "ktbPlaceOfResidence";
            this.ktbPlaceOfResidence.Size = new System.Drawing.Size(504, 20);
            this.ktbPlaceOfResidence.TabIndex = 7;
            // 
            // bsAddress
            // 
            this.bsAddress.DataSource = typeof(Common.Location);
            // 
            // kdgvCategory
            // 
            this.kdgvCategory.AllowUserToAddRows = false;
            this.kdgvCategory.AllowUserToDeleteRows = false;
            this.kdgvCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kdgvCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kdgvCategory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChecked,
            this.colCategory,
            this.colDateOfIssue,
            this.colDateOfExpiry,
            this.colAddInfo});
            this.kdgvCategory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.kdgvCategory.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Sheet;
            this.kdgvCategory.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
            this.kdgvCategory.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.kdgvCategory.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.kdgvCategory.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.kdgvCategory.Location = new System.Drawing.Point(132, 397);
            this.kdgvCategory.MultiSelect = false;
            this.kdgvCategory.Name = "kdgvCategory";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.kdgvCategory.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.kdgvCategory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.kdgvCategory.Size = new System.Drawing.Size(510, 206);
            this.kdgvCategory.TabIndex = 29;
            // 
            // colChecked
            // 
            this.colChecked.DataPropertyName = "IsChecked";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = false;
            this.colChecked.DefaultCellStyle = dataGridViewCellStyle1;
            this.colChecked.FalseValue = null;
            this.colChecked.HeaderText = "";
            this.colChecked.IndeterminateValue = null;
            this.colChecked.Name = "colChecked";
            this.colChecked.TrueValue = null;
            this.colChecked.Width = 25;
            // 
            // colCategory
            // 
            this.colCategory.DataPropertyName = "Name";
            this.colCategory.HeaderText = "Category";
            this.colCategory.MinimumWidth = 75;
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            this.colCategory.Width = 75;
            // 
            // colDateOfIssue
            // 
            this.colDateOfIssue.Checked = false;
            this.colDateOfIssue.CustomNullText = " -";
            this.colDateOfIssue.DataPropertyName = "DateOfIssue";
            this.colDateOfIssue.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.colDateOfIssue.HeaderText = "Date of issue";
            this.colDateOfIssue.MinimumWidth = 125;
            this.colDateOfIssue.Name = "colDateOfIssue";
            this.colDateOfIssue.Width = 125;
            // 
            // colDateOfExpiry
            // 
            this.colDateOfExpiry.Checked = false;
            this.colDateOfExpiry.CustomNullText = " -";
            this.colDateOfExpiry.DataPropertyName = "DateOfExpiry";
            this.colDateOfExpiry.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.colDateOfExpiry.HeaderText = "Date of expiry";
            this.colDateOfExpiry.MinimumWidth = 125;
            this.colDateOfExpiry.Name = "colDateOfExpiry";
            this.colDateOfExpiry.Width = 125;
            // 
            // colAddInfo
            // 
            this.colAddInfo.DataPropertyName = "AdditionalInformation";
            this.colAddInfo.HeaderText = "Add. info";
            this.colAddInfo.MinimumWidth = 100;
            this.colAddInfo.Name = "colAddInfo";
            this.colAddInfo.Width = 100;
            // 
            // lblCategory
            // 
            this.lblCategory.Location = new System.Drawing.Point(23, 402);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(103, 13);
            this.lblCategory.TabIndex = 28;
            this.lblCategory.Text = "Category";
            // 
            // kbtnSave
            // 
            this.kbtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnSave.Location = new System.Drawing.Point(552, 609);
            this.kbtnSave.Name = "kbtnSave";
            this.kbtnSave.Size = new System.Drawing.Size(90, 25);
            this.kbtnSave.TabIndex = 30;
            this.kbtnSave.Values.Text = "Save";
            // 
            // lblRegion
            // 
            this.lblRegion.Location = new System.Drawing.Point(7, 24);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(104, 13);
            this.lblRegion.TabIndex = 0;
            this.lblRegion.Text = "Region";
            // 
            // kcbRegion
            // 
            this.kcbRegion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kcbRegion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.kcbRegion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.kcbRegion.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsAddress, "RegionId", true));
            this.kcbRegion.DropDownWidth = 506;
            this.kcbRegion.Location = new System.Drawing.Point(226, 20);
            this.kcbRegion.Name = "kcbRegion";
            this.kcbRegion.Size = new System.Drawing.Size(395, 21);
            this.kcbRegion.TabIndex = 2;
            // 
            // lblDistrict
            // 
            this.lblDistrict.Location = new System.Drawing.Point(7, 52);
            this.lblDistrict.Name = "lblDistrict";
            this.lblDistrict.Size = new System.Drawing.Size(104, 13);
            this.lblDistrict.TabIndex = 3;
            this.lblDistrict.Text = "District";
            // 
            // ktbDistrict
            // 
            this.ktbDistrict.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ktbDistrict.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAddress, "District", true));
            this.ktbDistrict.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.bsAddress, "DistrictId", true));
            this.ktbDistrict.Enabled = false;
            this.ktbDistrict.Location = new System.Drawing.Point(117, 48);
            this.ktbDistrict.MaxLength = 33;
            this.ktbDistrict.Name = "ktbDistrict";
            this.ktbDistrict.Size = new System.Drawing.Size(467, 20);
            this.ktbDistrict.TabIndex = 4;
            this.ktbDistrict.TabStop = false;
            // 
            // gbPlaceOfResidence
            // 
            this.gbPlaceOfResidence.Controls.Add(this.ktbRegionId);
            this.gbPlaceOfResidence.Controls.Add(this.kbtnSelectDistrict);
            this.gbPlaceOfResidence.Controls.Add(this.lblDistrict);
            this.gbPlaceOfResidence.Controls.Add(this.kcbRegion);
            this.gbPlaceOfResidence.Controls.Add(this.lblAddress);
            this.gbPlaceOfResidence.Controls.Add(this.lblRegion);
            this.gbPlaceOfResidence.Controls.Add(this.ktbPlaceOfResidence);
            this.gbPlaceOfResidence.Controls.Add(this.ktbDistrict);
            this.gbPlaceOfResidence.Location = new System.Drawing.Point(15, 288);
            this.gbPlaceOfResidence.Name = "gbPlaceOfResidence";
            this.gbPlaceOfResidence.Size = new System.Drawing.Size(627, 103);
            this.gbPlaceOfResidence.TabIndex = 27;
            this.gbPlaceOfResidence.TabStop = false;
            this.gbPlaceOfResidence.Text = "Place of residence";
            // 
            // ktbRegionId
            // 
            this.ktbRegionId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAddress, "RegionId", true));
            this.ktbRegionId.Location = new System.Drawing.Point(117, 21);
            this.ktbRegionId.MaxLength = 10;
            this.ktbRegionId.Name = "ktbRegionId";
            this.ktbRegionId.Size = new System.Drawing.Size(103, 20);
            this.ktbRegionId.TabIndex = 1;
            this.ktbRegionId.TabStop = false;
            // 
            // kbtnSelectDistrict
            // 
            this.kbtnSelectDistrict.Location = new System.Drawing.Point(589, 46);
            this.kbtnSelectDistrict.Name = "kbtnSelectDistrict";
            this.kbtnSelectDistrict.Size = new System.Drawing.Size(32, 25);
            this.kbtnSelectDistrict.TabIndex = 5;
            this.kbtnSelectDistrict.Values.Text = "...";
            // 
            // kbtnPlaceOfIssue
            // 
            this.kbtnPlaceOfIssue.Enabled = false;
            this.kbtnPlaceOfIssue.Location = new System.Drawing.Point(610, 226);
            this.kbtnPlaceOfIssue.Name = "kbtnPlaceOfIssue";
            this.kbtnPlaceOfIssue.Size = new System.Drawing.Size(32, 25);
            this.kbtnPlaceOfIssue.TabIndex = 24;
            this.kbtnPlaceOfIssue.Values.Text = "...";
            // 
            // ktbPlaceOfBirth
            // 
            this.ktbPlaceOfBirth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ktbPlaceOfBirth.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHolder, "PlaceOfBirth", true));
            this.ktbPlaceOfBirth.Location = new System.Drawing.Point(132, 117);
            this.ktbPlaceOfBirth.MaxLength = 37;
            this.ktbPlaceOfBirth.Name = "ktbPlaceOfBirth";
            this.ktbPlaceOfBirth.Size = new System.Drawing.Size(510, 20);
            this.ktbPlaceOfBirth.TabIndex = 11;
            this.ktbPlaceOfBirth.TabStop = false;
            // 
            // lblPassport
            // 
            this.lblPassport.Location = new System.Drawing.Point(12, 15);
            this.lblPassport.Name = "lblPassport";
            this.lblPassport.Size = new System.Drawing.Size(114, 13);
            this.lblPassport.TabIndex = 0;
            this.lblPassport.Text = "Passport";
            // 
            // ktbPassportSn
            // 
            this.ktbPassportSn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ktbPassportSn.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPassport, "Seria", true));
            this.ktbPassportSn.Location = new System.Drawing.Point(132, 12);
            this.ktbPassportSn.MaxLength = 2;
            this.ktbPassportSn.Name = "ktbPassportSn";
            this.ktbPassportSn.Size = new System.Drawing.Size(53, 20);
            this.ktbPassportSn.TabIndex = 1;
            // 
            // bsPassport
            // 
            this.bsPassport.DataSource = typeof(Common.Passport);
            // 
            // ktbPassportNumber
            // 
            this.ktbPassportNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ktbPassportNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPassport, "Number", true));
            this.ktbPassportNumber.Location = new System.Drawing.Point(191, 12);
            this.ktbPassportNumber.MaxLength = 6;
            this.ktbPassportNumber.Name = "ktbPassportNumber";
            this.ktbPassportNumber.Size = new System.Drawing.Size(127, 20);
            this.ktbPassportNumber.TabIndex = 2;
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(12, 174);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(114, 13);
            this.lblSex.TabIndex = 16;
            this.lblSex.Text = "Sex";
            // 
            // kcbSex
            // 
            this.kcbSex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kcbSex.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.kcbSex.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.kcbSex.DropDownWidth = 506;
            this.kcbSex.Location = new System.Drawing.Point(132, 170);
            this.kcbSex.Name = "kcbSex";
            this.kcbSex.Size = new System.Drawing.Size(103, 21);
            this.kcbSex.TabIndex = 17;
            // 
            // kcbCitizenship
            // 
            this.kcbCitizenship.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kcbCitizenship.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.kcbCitizenship.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.kcbCitizenship.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsHolder, "Citizenship", true));
            this.kcbCitizenship.DropDownWidth = 506;
            this.kcbCitizenship.Location = new System.Drawing.Point(361, 11);
            this.kcbCitizenship.Name = "kcbCitizenship";
            this.kcbCitizenship.Size = new System.Drawing.Size(281, 21);
            this.kcbCitizenship.TabIndex = 3;
            // 
            // DrivingLicenseObjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 646);
            this.Controls.Add(this.ktbPlaceOfBirth);
            this.Controls.Add(this.kbtnPlaceOfIssue);
            this.Controls.Add(this.gbPlaceOfResidence);
            this.Controls.Add(this.kcbSex);
            this.Controls.Add(this.kcbCitizenship);
            this.Controls.Add(this.kbtnSave);
            this.Controls.Add(this.kdgvCategory);
            this.Controls.Add(this.kdtpDateOfExpiry);
            this.Controls.Add(this.kdtpDateOfIssue);
            this.Controls.Add(this.kdtpDateOfBirth);
            this.Controls.Add(this.lblDateOfExpiry);
            this.Controls.Add(this.ktbCardNumber);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.ktbPersonalNumber);
            this.Controls.Add(this.lblCardNumber);
            this.Controls.Add(this.ktbPlaceOfIssue);
            this.Controls.Add(this.lblPersonalNumber);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.lblDateOfIssue);
            this.Controls.Add(this.lblPlaceOfIssue);
            this.Controls.Add(this.lblDateOfBirth);
            this.Controls.Add(this.lblPlaceOfBirth);
            this.Controls.Add(this.ktbMiddleName);
            this.Controls.Add(this.lblMiddleName);
            this.Controls.Add(this.ktbFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.ktbPassportNumber);
            this.Controls.Add(this.ktbPassportSn);
            this.Controls.Add(this.ktbLastName);
            this.Controls.Add(this.lblPassport);
            this.Controls.Add(this.lblLastName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(670, 615);
            this.Name = "DrivingLicenseObjectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DrivingLicenseObjectForm";
            ((System.ComponentModel.ISupportInitialize)(this.bsHolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kdgvCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcbRegion)).EndInit();
            this.gbPlaceOfResidence.ResumeLayout(false);
            this.gbPlaceOfResidence.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPassport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcbSex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcbCitizenship)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLastName;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktbLastName;
        private System.Windows.Forms.Label lblFirstName;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktbFirstName;
        private System.Windows.Forms.Label lblMiddleName;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktbMiddleName;
        private System.Windows.Forms.Label lblPlaceOfBirth;
        private System.Windows.Forms.Label lblPlaceOfIssue;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktbPlaceOfIssue;
        private System.Windows.Forms.Label lblDateOfBirth;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker kdtpDateOfBirth;
        private System.Windows.Forms.Label lblDateOfIssue;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker kdtpDateOfIssue;
        private System.Windows.Forms.Label lblDateOfExpiry;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker kdtpDateOfExpiry;
        private System.Windows.Forms.Label lblPersonalNumber;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktbPersonalNumber;
        private System.Windows.Forms.Label lblCardNumber;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktbCardNumber;
        private System.Windows.Forms.Label lblAddress;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktbPlaceOfResidence;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kdgvCategory;
        private System.Windows.Forms.Label lblCategory;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kbtnSave;
        private System.Windows.Forms.BindingSource bsCategory;
        private System.Windows.Forms.BindingSource bsDL;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewCheckBoxColumn colChecked;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colCategory;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewDateTimePickerColumn colDateOfIssue;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewDateTimePickerColumn colDateOfExpiry;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colAddInfo;
        private System.Windows.Forms.Label lblRegion;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox kcbRegion;
        private System.Windows.Forms.Label lblDistrict;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktbDistrict;
        private System.Windows.Forms.GroupBox gbPlaceOfResidence;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kbtnPlaceOfIssue;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kbtnSelectDistrict;
        private System.Windows.Forms.BindingSource bsHolder;
        private System.Windows.Forms.BindingSource bsAddress;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktbPlaceOfBirth;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktbRegionId;
        private System.Windows.Forms.Label lblPassport;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktbPassportSn;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ktbPassportNumber;
        private System.Windows.Forms.Label lblSex;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox kcbSex;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox kcbCitizenship;
        private System.Windows.Forms.BindingSource bsPassport;
    }
}