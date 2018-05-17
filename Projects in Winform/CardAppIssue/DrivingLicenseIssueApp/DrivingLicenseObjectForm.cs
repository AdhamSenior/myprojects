using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace DrivingLicenseIssueApp
{
    using Common;
    using Common.Ext;
    using ComponentFactory.Krypton.Toolkit;
    using Logic;
    using Newtonsoft.Json;

    public partial class DrivingLicenseObjectForm : Form
    {
        public DrivingLicense Object { get; set; }
        public DrivingLicenseObjectForm()
        {
            InitializeComponent();

            Text = TextUI.RegistrationNewDL;

            lblPassport.Text = TextUI.Passport;
            lblLastName.Text = TextUI.LastName;
            lblFirstName.Text = TextUI.FirstName;
            lblMiddleName.Text = TextUI.MiddleName;
            lblPlaceOfBirth.Text = TextUI.PlaceOfBirth;
            lblDateOfBirth.Text = TextUI.DateOfBirth;
            lblDateOfIssue.Text = TextUI.DateOfIssue;
            lblDateOfExpiry.Text = TextUI.DateOfExpiry;
            lblPlaceOfIssue.Text = TextUI.PlaceOfIssue;
            lblPersonalNumber.Text = TextUI.PersonalNumber;
            lblCardNumber.Text = TextUI.CardNumber;
            lblRegion.Text = TextUI.Region;
            lblDistrict.Text = TextUI.District;
            lblAddress.Text = TextUI.Address;
            lblCategory.Text = TextUI.Category;
            lblSex.Text = TextUI.Sex;
            gbPlaceOfResidence.Text = TextUI.PlaceOfResidence;

            colCategory.HeaderText = TextUI.Category;
            colDateOfIssue.HeaderText = TextUI.DateOfIssue;
            colDateOfExpiry.HeaderText = TextUI.DateOfExpiry;
            colAddInfo.HeaderText = TextUI.AddInfo;

            kbtnSave.Text = TextUI.Save;
            kbtnSave.Click += kbtnSave_Click;
            kbtnPlaceOfIssue.Click += kbtnPlaceOfIssue_Click;
            kbtnSelectDistrict.Click += kbtnSelectDistrict_Click;

            kdgvCategory.AutoGenerateColumns = false;
            kdgvCategory.DataSource = bsCategory;
            kdgvCategory.CellBeginEdit += kdgvCategory_CellBeginEdit;
            kdgvCategory.CellValueChanged += kdgvCategory_CellValueChanged;
            kdgvCategory.CurrentCellDirtyStateChanged += kdgvCategory_CurrentCellDirtyStateChanged;

            KeyDown += DrivingLicenseObjectForm_KeyDown;
            kdtpDateOfBirth.KeyDown += kdtpDateOfBirth_KeyDown;
            kdtpDateOfIssue.KeyDown += kdtpDateOfIssue_KeyDown;
            kdtpDateOfExpiry.KeyDown += kdtpDateOfExpiry_KeyDown;

            ktbRegionId.TextChanged += ktbRegionId_TextChanged;

            ktbRegionId.KeyPress += NumericTextBox_KeyPress;
            ktbPassportNumber.KeyPress += NumericTextBox_KeyPress;

            ktbLastName.KeyPress += StringTextBox_KeyPress;
            ktbFirstName.KeyPress += StringTextBox_KeyPress;
            ktbMiddleName.KeyPress += StringTextBox_KeyPress;
            ktbPlaceOfBirth.KeyPress += StringTextBox_KeyPress;
            ktbPlaceOfResidence.KeyPress += StringTextBox_KeyPress;
            ktbPassportSn.KeyPress += ktbPassportSn_KeyPress;
        }

        void ktbPassportSn_KeyPress(object sender, KeyPressEventArgs e)
        {
            var c = e.KeyChar;
            e.Handled = !c.IsLatinLetter();
        }
        void StringTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var c = e.KeyChar;
            e.Handled = char.IsLetter(c) && !c.IsLatinLetter();
        }
        void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var c = e.KeyChar;
            e.Handled = !(char.IsDigit(c) || c == (char)Keys.Back);
        }
        void ktbRegionId_TextChanged(object sender, EventArgs e)
        {
            var txt = ktbRegionId.Text;
            if (!String.IsNullOrEmpty(txt))
            {
                var id = int.Parse(txt);
                kcbRegion.SelectedValue = id;
                Object.Holder.PlaceOfResidence.Region = Soato.FindById(id);
            }
        }
        void kdtpDateOfExpiry_KeyDown(object sender, KeyEventArgs e)
        {
            PasteDateTimePickerValue(kdtpDateOfExpiry, e);
        }
        void kdtpDateOfIssue_KeyDown(object sender, KeyEventArgs e)
        {
            PasteDateTimePickerValue(kdtpDateOfIssue, e);
        }
        void kdtpDateOfBirth_KeyDown(object sender, KeyEventArgs e)
        {
            PasteDateTimePickerValue(kdtpDateOfBirth, e);
        }
        void PasteDateTimePickerValue(KryptonDateTimePicker kdtp, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
            {
                var txt = Clipboard.GetText();
                DateTime dt;
                var suc = DateTime.TryParse(txt.ToSafeTrimmedString(), out dt);
                if (suc)
                    kdtp.Value = dt;
                e.Handled = true;
            }
        }
        void DrivingLicenseObjectForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
        void kbtnSelectDistrict_Click(object sender, EventArgs e)
        {
            if (kcbRegion.SelectedIndex == -1)
            {
                MessageBox.Show(ErrorTexts.NoRegionSelected);
                return;
            }

            var item = (Soato)kcbRegion.SelectedItem;
            var districtId = Object.Holder.PlaceOfResidence.DistrictId.ToString();
            var frm = new SelectSoatoForm { CurrentItem = districtId, ParentId = item.Id, Level = "0,1,3" };
            var dr = frm.ShowDialog();
            if (dr != DialogResult.OK)
                return;

            var obj = (Location)bsAddress.DataSource;
            obj.DistrictId = frm.SelectedItemId;
            obj.District = frm.SelectedItem;
            bsAddress.ResetBindings(false);
        }
        void kbtnPlaceOfIssue_Click(object sender, EventArgs e)
        {
            var frm = new SelectSoatoForm { CurrentItem = Object.PlaceOfIssueId.ToString() };
            var dr = frm.ShowDialog();
            if (dr != DialogResult.OK)
                return;

            var obj = (DrivingLicense)bsDL.DataSource;
            obj.PlaceOfIssue = frm.SelectedItem;
            obj.PlaceOfIssueId = frm.SelectedItemId;
            bsDL.ResetBindings(false);
        }
        void kdgvCategory_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (ReferenceEquals(kdgvCategory.CurrentCell, null))
                return;

            if (kdgvCategory.CurrentCell.ColumnIndex == colChecked.Index && kdgvCategory.IsCurrentCellDirty)
                kdgvCategory.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        void kdgvCategory_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var cr = kdgvCategory.CurrentRow;
            if (e.RowIndex == -1 || ReferenceEquals(cr, null))
                return;

            if (e.ColumnIndex == colChecked.Index)
            {
                var obj = (Category)cr.DataBoundItem;
                if (!obj.IsChecked)
                {
                    obj.DateOfIssue = null;
                    obj.DateOfExpiry = null;
                    obj.AdditionalInformation = String.Empty;
                }
                else
                    obj.DateOfIssue = DateTime.Now;
            }

            kdgvCategory.Invalidate();
        }
        void kdgvCategory_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex != colChecked.Index)
            {
                if (ReferenceEquals(kdgvCategory.CurrentRow, null))
                    return;

                var cr = (Category)kdgvCategory.CurrentRow.DataBoundItem;
                e.Cancel = !cr.IsChecked;
            }
        }
        void kbtnSave_Click(object sender, EventArgs e)
        {
            var suc = ValidateFields();
            if (!suc)
                return;

            Object.Category = ConvertCategory();
            Object.CategoryList = Category.Deserialize(Object.Category).ToArray();
            Post();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode)
                return;

            FillRegions();
            FillCitizenship();
            //FillSex();

            bsDL.DataSource = Object;
            bsHolder.DataSource = Object.Holder;
            bsAddress.DataSource = Object.Holder.PlaceOfResidence;
            bsPassport.DataSource = Object.Holder.Passport;
            FillCategory();

            foreach (Control c in Controls)
            {
                //var prop = c.GetType().GetProperty("ReadOnly");
                //if (!ReferenceEquals(prop, null))
                //    prop.SetValue(c, Object.IsSentToPrint, null);
                c.Enabled = (Object.Status == TextUI.InWait);
            }
            ktbPlaceOfIssue.Enabled = false;
            kbtnPlaceOfIssue.Enabled = false;
            ktbDistrict.Enabled = false;
            ktbCardNumber.Enabled = false;

            lblSex.Visible = false;
            kcbSex.Visible = false;
        }
        void FillCategory()
        {
            if (!ReferenceEquals(Object.CategoryList, null) && Object.CategoryList.Length != 0)
            {
                var jss = new JsonSerializerSettings
                {
                    DateTimeZoneHandling = DateTimeZoneHandling.Local,
                    DateFormatString = "yyyyMMdd"
                };
                var json = JsonConvert.SerializeObject(Object.CategoryList, Formatting.Indented, jss);
                Object.Category = json;
            }

            var rs = Object.Id == 0 ? Category.GetItems() : Category.GetItems(Object.Category);
            bsCategory.DataSource = rs;
        }
        void FillRegions()
        {
            if (Object.Id == 0)
            {
                Object.PlaceOfIssue = User.Instance.Department;
                Object.PlaceOfIssueId = User.Instance.DepartmentId;
            }
            else
            {
                Object.PlaceOfIssue = Soato.FindById(Object.PlaceOfIssueId);
                Object.Holder.PlaceOfResidence.District = Soato.FindById(Object.Holder.PlaceOfResidence.DistrictId);
            }

            kcbRegion.DisplayMember = "NameUz";
            kcbRegion.ValueMember = "Id";
            kcbRegion.DataSource = Soato.GetRegions();
        }
        void FillSex()
        {
            kcbSex.DisplayMember = "Name";
            kcbSex.ValueMember = "Type";
            kcbSex.DataSource = Sex.GetItems();
        }
        void FillCitizenship()
        {
            kcbCitizenship.DisplayMember = "Name";
            kcbCitizenship.ValueMember = "Id";
            kcbCitizenship.DataSource = Citizenship.GetItems();
        }

        bool ValidateFields()
        {
            var err = Object.Validate();
            if (!String.IsNullOrEmpty(err))
            {
                MessageBox.Show(err);
                return false;
            }

            var src = (BindingSource)kdgvCategory.DataSource;
            var rs = (List<Category>)src.DataSource;
            rs = rs.Where(wh => wh.IsChecked).ToList();
            if (rs.Count == 0)
            {
                MessageBox.Show(String.Format(ErrorTexts.MissingField, TextUI.Category));
                return false;
            }

            var sb = new StringBuilder();
            foreach (var r in rs)
            {
                err = r.Validate();
                if (!String.IsNullOrEmpty(err))
                    sb.AppendLine(err);
            }

            if (sb.Length != 0)
            {
                MessageBox.Show(sb.ToString());
                return false;
            }

            return true;
        }
        string ConvertCategory()
        {
            var src = (BindingSource)kdgvCategory.DataSource;
            var rs = (List<Category>)src.DataSource;
            rs = rs.Where(wh => wh.IsChecked).ToList();

            foreach (var r in rs)
            {
                if (r.DateOfIssue.HasValue)
                    r.DateOfIssue = r.DateOfIssue.Value.Date;
                if (r.DateOfExpiry.HasValue)
                    r.DateOfExpiry = r.DateOfExpiry.Value.Date;

                if (ReferenceEquals(r.AdditionalInformation, null))
                    r.AdditionalInformation = String.Empty;
            }

            var jss = new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Local,
                DateFormatString = "yyyyMMdd"
            };
            var json = JsonConvert.SerializeObject(rs, Formatting.Indented, jss);
            return json;
        }

        async void Post()
        {
            var wait = new WaitForm { Status = TextUI.SavingData, OwnerForm = this };
            wait.Show();
            var rs = await Object.Post();
            wait.Close();
            wait.Dispose();

            if (rs.StatusCode == HttpStatusCode.OK)
            {
                var error = ApiResponse.ParseError(rs.Content);
                if (!String.IsNullOrEmpty(error))
                    MessageBox.Show(error);
                else
                {
                    MessageBox.Show(TextUI.DataSuccessfullySaved);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else
                MessageBox.Show(ErrorTexts.FailedToSendDataToServer);
        }
    }
}
