using System;
using System.Windows.Forms;

namespace VehicleLicenseIssueApp
{
    using Common;
    using Common.Entities;
    using Common.Ext;
    using Logic;
    using RestSharp;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using VehicleLicenseIssueApp.Logic.Helper;

    public partial class VehicleLicenseObjectForm : Form
    {
        public VehicleLicense Object { get; set; }
        List<Soato> _regions;

        public VehicleLicenseObjectForm()
        {
            InitializeComponent();

            Text = TextUI.RegistrationNewVL;

            lblStateNumberPlate.Text = TextUI.StateNumberPlate;
            lblMakeModel.Text = TextUI.MakeModel;
            lblColor.Text = TextUI.Color;
            lblYearOfManufacture.Text = TextUI.YearOfManufacture;
            lblType.Text = TextUI.Type;
            lblVehicleIdentificationNumberKuzov.Text = TextUI.VehicleIdentificationNumberKuzov;
            lblVehicleIdentificationNumberShassi.Text = TextUI.VehicleIdentificationNumberShassi;
            lblGrossWeight.Text = TextUI.GrossWeight;
            lblCurbWeight.Text = TextUI.CurbWeight;
            lblEngineNumber.Text = TextUI.EngineNumber;
            lblEnginePower.Text = TextUI.EnginePower;
            lblFuelType.Text = TextUI.FuelType;
            lblNumberOfSeats.Text = TextUI.NumberOfSeats;
            lblNumberOfStandees.Text = TextUI.NumberOfStandees;
            lblSpecialMarks.Text = TextUI.SpecialMarks;

            lblPassport.Text = TextUI.Passport;
            lblLastName.Text = TextUI.LastName;
            lblFirstName.Text = TextUI.FirstName;
            lblMiddleName.Text = TextUI.MiddleName;
            lblDateOfBirth.Text = TextUI.DateOfBirth;
            lblPlaceOfBirth.Text = TextUI.PlaceOfBirth;
            lblPersonalNumber.Text = TextUI.PersonalNumber;

            gbAddressPer.Text = TextUI.Address;
            lblRegionPer.Text = TextUI.Region;
            lblDistrictPer.Text = TextUI.District;
            lblAddressPer.Text = TextUI.Address;

            lblCompanyName.Text = TextUI.CompanyName;
            lblInn.Text = TextUI.Inn;
            gbAddressOrg.Text = TextUI.Address;
            lblRegionOrg.Text = TextUI.Region;
            lblDistrictOrg.Text = TextUI.District;
            lblAddressOrg.Text = TextUI.Address;

            tpPerson.Text = TextUI.Individual;
            tpOrganization.Text = TextUI.Organization;
            tpVehicle.Text = TextUI.Vehicle;
            lblDateOfIssue.Text = TextUI.DateOfIssue;
            lblDateOfExpire.Text = TextUI.DateOfExpire;
            lblPlaceOfIssue.Text = TextUI.PlaceOfIssue;

            kbtnSave.Text = TextUI.Save;
            kbtnSave.Click += kbtnSave_Click;
            ktbYearOfManufacture.KeyPress += NumericTextBox_KeyPress;
            ktbGrossWeight.KeyPress += NumericTextBox_KeyPress;
            ktbCurbWeight.KeyPress += NumericTextBox_KeyPress;
            ktbEngineNumber.KeyPress += NumericTextBox_KeyPress;
            ktbNumberOfSeats.KeyPress += NumericTextBox_KeyPress;
            ktbNumberOfStandees.KeyPress += NumericTextBox_KeyPress;
            kbtnSelectDistrictOrg.Click += KbtnSelectDistrictOrg_Click;
            kcbMake.SelectedIndexChanged += KcbMake_SelectedIndexChanged;
            kcbFuel.SelectedIndexChanged += KcbFuel_SelectedIndexChanged;
            kcbMeasurement.SelectedIndexChanged += KcbMeasurement_SelectedIndexChanged;
            kcbModel.SelectedIndexChanged += KcbModel_SelectedIndexChanged;
            kcbColor.SelectedIndexChanged += KcbColor_SelectedIndexChanged;
            kcbVehicalType.SelectedIndexChanged += KcbVehicalType_SelectedIndexChanged;
            kcbRegionOrg.SelectedIndexChanged += KcbRegionOrg_SelectedIndexChanged;
        }        

        private void KcbRegionOrg_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (Soato)kcbRegionOrg.SelectedItem;

            var obj = (Location)bsAddressOrg.DataSource;
            obj.Region = item.NameUz;
            obj.RegionId = item.Id;
            bsAddressOrg.ResetBindings(false);
        }

        private void KcbVehicalType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (VehicleTypes)kcbVehicalType.SelectedItem;

            var obj = (VehicleInfo)bsVehicle.DataSource;
            obj.TypeId = item.Key;
            bsVehicle.ResetBindings(false);
        }

        private void KcbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (Colors)kcbColor.SelectedItem;

            var obj = (VehicleInfo)bsVehicle.DataSource;
            obj.ColorId = item.Key;
            bsVehicle.ResetBindings(false);
        }

        private void KcbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (Models)kcbModel.SelectedItem;

            var obj = (VehicleInfo)bsVehicle.DataSource;
            obj.ModelId = item.Key;
            bsVehicle.ResetBindings(false);
        }

        private void KcbMeasurement_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (Measurements)kcbMeasurement.SelectedItem;

            var obj = (VehicleInfo)bsVehicle.DataSource;
            obj.EngineMasurementId = item.Key;
            bsVehicle.ResetBindings(false);
        }

        private void KcbFuel_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (Fuels)kcbFuel.SelectedItem;

            var obj = (VehicleInfo)bsVehicle.DataSource;
            obj.FuelTypeId = item.Key;
            bsVehicle.ResetBindings(false);
        }
        

        private void KcbMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (Marks)kcbMake.SelectedItem;

            var models = EntitiesCollections.Instance.Models.Where(w=>w.ParentKey == item.Key).ToList();

            kcbModel.ValueMember = "Key";
            kcbModel.DisplayMember = "Value";
            kcbModel.DataSource = models;

            var obj = (VehicleInfo)bsVehicle.DataSource;
            obj.MarkId = item.Key;
            bsVehicle.ResetBindings(false);
        }

        private void KbtnSelectDistrictOrg_Click(object sender, EventArgs e)
        {
            if (kcbRegionOrg.SelectedIndex == -1)
            {
                MessageBox.Show(ErrorTexts.NoRegionSelected);
                return;
            }

            var item = (Soato)kcbRegionOrg.SelectedItem;
            var frm = new SelectSoatoForm { CurrentItem = Object.Person.Address.District, ParentId = item.Id, Level = "0,1,3" };
            var dr = frm.ShowDialog();
            if (dr != DialogResult.OK)
                return;

            var obj = (Location)bsAddressOrg.DataSource;
            //obj.Region = item.NameUz;
            obj.District = frm.SelectedItem;
            obj.DistrictId = frm.SelectedItemId;
            bsAddressOrg.ResetBindings(false);
        }

        void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var c = e.KeyChar;
            e.Handled = !(char.IsDigit(c) || c == (char)Keys.Back);
        }

        async void kbtnSave_Click(object sender, EventArgs e)
        {
            var suc = ValidateFields();
            if (!suc)
                return;

            //suc = Object.Id == 0 ? Object.Save() : Object.Update();
            //var response = Object.Id == 0 ? await ApiHelper.CreateLegalLicense(Object) : await ApiHelper.CreateLegalLicense(Object);
            IRestResponse response;
            if (Object.IsPersonal)
                response = await ApiHelper.CreatePrivateLicense(Object);
            else
                response = await ApiHelper.CreateLegalLicense(Object);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                var error = ApiResponse.ParseError(response.Content);
                if (!String.IsNullOrEmpty(error))
                    MessageBox.Show(error);
                else
                {
                    MessageBox.Show(TextUI.DataSuccessfullySaved);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }

            MessageBox.Show(TextUI.DataSuccessfullySaved);
            DialogResult = DialogResult.OK;
            Close();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode)
                return;

            bsVL.DataSource = Object;
            bsAddressOrg.DataSource = Object.Organization.Address;
            bsVehicle.DataSource = Object.Vehicle;
            bsOrganization.DataSource = Object.Organization;

            kcbColor.ValueMember = "Key";
            kcbColor.DisplayMember = "Value";
            kcbColor.DataSource = EntitiesCollections.Instance.Colors;

            //kcbModel.ValueMember = "Key";
            //kcbModel.DisplayMember = "Value";
            //kcbModel.DataSource = EntitiesCollections.Instance.Models;

            kcbMake.ValueMember = "Key";
            kcbMake.DisplayMember = "Value";
            kcbMake.DataSource = EntitiesCollections.Instance.Marks;

            kcbVehicalType.ValueMember = "Key";
            kcbVehicalType.DisplayMember = "Value";
            kcbVehicalType.DataSource = EntitiesCollections.Instance.VehicleTypes;

            kcbMeasurement.ValueMember = "Key";
            kcbMeasurement.DisplayMember = "Value";
            kcbMeasurement.DataSource = EntitiesCollections.Instance.Measurements;

            kcbFuel.ValueMember = "Key";
            kcbFuel.DisplayMember = "Value";
            kcbFuel.DataSource = EntitiesCollections.Instance.Fuels;


            if (Object.IsPersonal)
            {
                tcMain.TabPages.RemoveAt(1);
            }
            else
            {
                tcMain.TabPages.RemoveAt(0);
            }
            ktbPlaceOfIssue.Text = User.Instance.Department;
            Object.PlaceOfIssueId = User.Instance.DepartmentId;

            foreach (Control c in Controls)
            {
                //var prop = c.GetType().GetProperty("ReadOnly");
                //if (!ReferenceEquals(prop, null))
                //    prop.SetValue(c, Object.IsSentToPrint, null);
                //c.Enabled = !Object.IsSentToPrint;
            }
            FillRegions();
        }

        void FillRegions()
        {
            _regions = Soato.GetRegions();
            if (Object.Id == 0)
                Object.PlaceOfIssue = User.Instance.Department;

            //var placeOfBirth = Object.Holder.PlaceOfBirth;
            //if (!String.IsNullOrEmpty(placeOfBirth))
            //{
            //    var i = placeOfBirth.IndexOf(':');
            //    if (i != -1)
            //        ktbPlaceOfBirthId.Text = placeOfBirth.Substring(0, i).ToSafeTrimmedString();
            //}

            //var region = Object.Holder.PlaceOfResidence.Region;
            //if (!String.IsNullOrEmpty(region))
            //{
            //    var i = region.IndexOf(':');
            //    if (i != -1)
            //        ktbRegionId.Text = region.Substring(0, i).ToSafeTrimmedString();
            //}


            kcbRegionOrg.DisplayMember = "NameUz";
            kcbRegionOrg.ValueMember = "FullName";
            kcbRegionOrg.DataSource = Soato.GetRegions();
        }
        bool ValidateFields()
        {
            var err = Object.Validate();
            if (!String.IsNullOrEmpty(err))
            {
                MessageBox.Show(err);
                return false;
            }

            return true;
        }
    }
}
