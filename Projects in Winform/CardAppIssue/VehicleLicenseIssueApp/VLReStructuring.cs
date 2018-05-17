using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VehicleLicenseIssueApp.Logic;

namespace VehicleLicenseIssueApp
{
    public partial class VLReStructuring : Form
    {
        public VLReStructuring(VehicleLicense obj)
        {
                  InitializeComponent();

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
            label20.Text = TextUI.CompanyName;
            label19.Text = TextUI.Inn;
            groupBox1.Text = TextUI.Address;
            label7.Text = TextUI.Region;
            label5.Text = TextUI.District;
            label6.Text = TextUI.Address;
            label8.Text = TextUI.StateNumberPlate;
            label9.Text = TextUI.MakeModel;
            label12.Text = TextUI.Color;
            label1.Text = TextUI.YearOfManufacture;
            label14.Text = TextUI.Type;
            label16.Text = TextUI.VehicleIdentificationNumberKuzov;
            label15.Text = TextUI.VehicleIdentificationNumberShassi;
            label2.Text = TextUI.GrossWeight;
            label10.Text = TextUI.CurbWeight;
            label17.Text = TextUI.EngineNumber;
            label11.Text = TextUI.EnginePower;
            label18.Text = TextUI.FuelType;
            label3.Text = TextUI.NumberOfSeats;
            label13.Text = TextUI.NumberOfStandees;
            label4.Text = TextUI.SpecialMarks;
            lblCurrent.Text = TextUI.CurrentVehicle;
            lblnew.Text = TextUI.NewVehicle;
            lblCompanyName.Text = TextUI.CompanyName;
            lblInn.Text = TextUI.Inn;
            gbAddressOrg.Text = TextUI.Address;
            lblRegionOrg.Text = TextUI.Region;
            lblDistrictOrg.Text = TextUI.District;
            lblAddressOrg.Text = TextUI.Address;            
            kbtnSave.Text = TextUI.Save;



            bsRestructing.DataSource = obj;
            kbtnSave.Click += kbtnSave_Click;
        }

        private void kbtnSave_Click(object sender, EventArgs e)
        {
            bsRestructing.EndEdit();
            DialogResult = DialogResult.OK;
          
            
        }

     
    }
}
