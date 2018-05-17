using System;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace VehicleLicenseIssueApp
{
    using Common;
    using Common.Entities;
    using ComponentFactory.Krypton.Toolkit;
    using Equin.ApplicationFramework;
    using Logic;
    using Newtonsoft.Json;
    using RestSharp;
    using System.Collections.Generic;
    using System.Linq;
    using VehicleLicenseIssueApp.Logic.Helper;

    public partial class VehicleLicenseListForm : Form
    {
        const double LeftSideRatio = 0.75;
        private  Dictionary<string, string> SearchParametrs = new Dictionary<string, string>();
        private VLSearch SearchObj = new VLSearch();
        
        int _currentPage;
        

        public VehicleLicenseListForm()
        {
            InitializeComponent();

            Text = TextUI.VLP;
            kbtnRestructuring.Text = TextUI.Restructuring;
            kbtnSearch.Text = TextUI.Search;
            btnClear.Text = TextUI.Clear;
            khgLeftSide.ValuesPrimary.Heading = TextUI.ListVL;
            khgRightSide.ValuesPrimary.Heading = TextUI.View;

            colStateNumberPlateInd.HeaderText = TextUI.StateNumberPlate;
            colMakeInd.HeaderText = TextUI.Make;
            colModelInd.HeaderText = TextUI.Model;
            colColorInd.HeaderText = TextUI.Color;
            colLastNameInd.HeaderText = TextUI.LastName;
            colFirstNameInd.HeaderText = TextUI.FirstName;
            colMiddleNameInd.HeaderText = TextUI.MiddleName;
            colIsSentToPrintInd.HeaderText = TextUI.IsSentToPrint;

            colStateNumberPlateOrg.HeaderText = TextUI.StateNumberPlate;
            colMakeOrg.HeaderText = TextUI.Make;
            colModelOrg.HeaderText = TextUI.Model;
            colColorOrg.HeaderText = TextUI.Color;
            colCompanyNameOrg.HeaderText = TextUI.OrgName;
            colIsSentToPrintOrg.HeaderText = TextUI.IsSentToPrint;

            kpIndividual.Text = TextUI.Individual;
            kpIndividual.ToolTipTitle = TextUI.Individual;
            kpOrganization.Text = TextUI.Organization;
            kpOrganization.ToolTipTitle = TextUI.Organization;

            kbtnNew.Text = TextUI.New;
            kbtnPrint.Text = TextUI.Print;

            kdgvDataInd.AutoGenerateColumns = false;
            kdgvDataInd.DataSource = bsIndVL;

            kdgvDataOrg.AutoGenerateColumns = false;
            kdgvDataOrg.DataSource = bsOrgVL;

            Resize += VehicleLicenseListForm_Resize;
            btnRightSideHeader.Click += btnRightSideHeader_Click;
            kbtnNew.Click += kbtnNew_Click;
            kbtnPrint.Click += kbtnPrint_Click;

            kdgvDataInd.CellDoubleClick += kdgvDataInd_CellDoubleClick;
            kdgvDataInd.SelectionChanged += kdgvDataInd_SelectionChanged;
            kbtnRestructuring.Click += kbtnRestructuring_Click;
            kdgvDataOrg.SelectionChanged += kdgvDataOrg_SelectionChanged;
            kdgvDataOrg.CellDoubleClick += kdgvDataOrg_CellDoubleClick;
            knTabs.SelectedPageChanged += knTabs_SelectedPageChanged;
            kbtnSearch.Click += KbtnSearch_Click;
        }

        private void kbtnRestructuring_Click(object sender, EventArgs e)
        {
            var cr = kdgvDataOrg.CurrentRow; 
            VehicleLicense obj = ((ObjectView<VehicleLicense>)cr.DataBoundItem).Object; 


            if (obj != null)
            {
                var RestructForm = new VLReStructuring(obj);
                if (RestructForm.ShowDialog() == DialogResult.OK)
                {
                    FillDataGrid();
                    RestructForm.Close();
                    RestructForm.Dispose();
                }
                               
            }
            
        }

        private async void KbtnSearch_Click(object sender, EventArgs e)
        {
            var wait = new VLLegalSearchFrom { SearchParams = SearchParametrs, Object = SearchObj };
            wait.ShowDialog();
            if (wait.DialogResult == DialogResult.OK)
            {
               
                //SearchParametrs = wait.ParamsDictionary;

                // var data = await ApiHelper.LegalLicenses((int)pcPageOrg.CurrentPage, (int)pcPageOrg.PageSize, SearchParametrs);
                FillDataGrid();

             
            }            
            wait.Close();
            wait.Dispose();
        }

        void kdgvDataOrg_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var cr = kdgvDataOrg.CurrentRow;
            if (ReferenceEquals(cr, null))
                return;

            var vl = ((ObjectView<VehicleLicense>)cr.DataBoundItem).Object;
            vl.IsPersonal = false;
            var frm = new VehicleLicenseObjectForm { Object = vl };
            var dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
                FillDataGrid();
        }

        void kdgvDataOrg_SelectionChanged(object sender, EventArgs e)
        {
            UpdateView();
        }

        void knTabs_SelectedPageChanged(object sender, EventArgs e)
        {
            FillDataGrid();
            UpdateView();
        }

        void kbtnPrint_Click(object sender, EventArgs e)
        {
            var isIndividual = (knTabs.SelectedPage == kpIndividual);
            var cr = isIndividual ? kdgvDataInd.CurrentRow : kdgvDataOrg.CurrentRow;
            if (ReferenceEquals(cr, null))
                return;

            var obj = (VehicleLicense)cr.DataBoundItem;
            kbtnPrint.Enabled = false;

            var jss = new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Local
            };
            var json = JsonConvert.SerializeObject(obj, Formatting.Indented, jss);

            var query = String.Format("http://{0}/api/private_vehicle_license", Properties.Settings.Default.ServerName);
            if (!obj.IsPersonal)
                query = String.Format("http://{0}/api/legal_vehicle_license", Properties.Settings.Default.ServerName);

            var client = new RestClient(query);
            var request = new RestRequest(Method.POST);
            request.AddHeader("postman-token", "e9170b5d-9b0e-abb7-113f-bcacebe47678");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var suc = obj.SetIsSentToPrint();
                if (!suc)
                    MessageBox.Show(VehicleLicense.LastError);
                MessageBox.Show(TextUI.DataTransferredToPrint);
            }
            else
            {
                //obj.IsSentToPrint = false;
                var sb = new StringBuilder();
                if (!string.IsNullOrEmpty(response.StatusDescription))
                    sb.AppendLine(response.StatusDescription);
                if (!string.IsNullOrEmpty(response.ErrorMessage))
                    sb.AppendLine(response.ErrorMessage);
                MessageBox.Show(sb.ToString());
            }

            FillDataGrid();
            //kbtnPrint.Enabled = obj.IsSentToPrint;
        }

        void kdgvDataInd_SelectionChanged(object sender, EventArgs e)
        {
            UpdateView();
        }

        void kdgvDataInd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var cr = kdgvDataInd.CurrentRow;
            if (ReferenceEquals(cr, null))
                return;

            var vl = (VehicleLicense)cr.DataBoundItem;
            var frm = new VehicleLicenseObjectForm { Object = vl };
            var dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
                FillDataGrid();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode)
                return;

            _currentPage = 0;
            knTabs.SelectedPage = kpIndividual;

            FillDataGrid();
            UpdateView();
            FillColors();
            FillModels();
            FillMarks();
            FillMeasurements();
            FillRegions();
            FillFuels();
            FillUbdds();
            FillVehicleTypes();
        }

        private async void FillMarks()
        {
            var data = await ApiHelper.GetMarks();
            if (!ReferenceEquals(data, null))
                EntitiesCollections.Instance.Marks = data;
            else
                MessageBox.Show(ErrorTexts.FailedToGetDataFromServer);
        }

        

        private async void FillVehicleTypes()
        {
            var data = await ApiHelper.GetVehicleTypes();
            if (!ReferenceEquals(data, null))
                EntitiesCollections.Instance.VehicleTypes = data;
            else
                MessageBox.Show(ErrorTexts.FailedToGetDataFromServer);
        }

        private async void FillUbdds()
        {
            var data = await ApiHelper.GetUbdds();
            if (!ReferenceEquals(data, null))
                EntitiesCollections.Instance.Ubdd = data;
            else
                MessageBox.Show(ErrorTexts.FailedToGetDataFromServer);
        }

        private async void FillFuels()
        {
            var data = await ApiHelper.GetFuels();
            if (!ReferenceEquals(data, null))
                EntitiesCollections.Instance.Fuels = data;
            else
                MessageBox.Show(ErrorTexts.FailedToGetDataFromServer);
        }

        private async void FillRegions()
        {
            var data = await ApiHelper.GetRegions();
            if (!ReferenceEquals(data, null))
                EntitiesCollections.Instance.Regions = data;
            else
                MessageBox.Show(ErrorTexts.FailedToGetDataFromServer);
        }

        private async void FillMeasurements()
        {
            var data = await ApiHelper.GetMeasurements();
            if (!ReferenceEquals(data, null))
                EntitiesCollections.Instance.Measurements = data;
            else
                MessageBox.Show(ErrorTexts.FailedToGetDataFromServer);
        }
        private async void FillModels()
        {
            var data = await ApiHelper.GetModels();
            if (!ReferenceEquals(data, null))
                EntitiesCollections.Instance.Models = data;
            else
                MessageBox.Show(ErrorTexts.FailedToGetDataFromServer);
        }

        private async void FillColors()
        {
            var data = await ApiHelper.GetColors();
            if (!ReferenceEquals(data, null))
                EntitiesCollections.Instance.Colors = data;
            else
                MessageBox.Show(ErrorTexts.FailedToGetDataFromServer);
        }

        void kbtnNew_Click(object sender, EventArgs e)
        {
            var isIndividual = (knTabs.SelectedPage == kpIndividual);
            var vl = new VehicleLicense
            {
                Id = 0,
                IsPersonal = isIndividual,
                DateOfIssue = DateTime.Now,
                ExpireDate = DateTime.Now
                
            };

            var frm = new VehicleLicenseObjectForm { Object = vl };
            var dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
                FillDataGrid();
        }

        void VehicleLicenseListForm_Resize(object sender, EventArgs e)
        {
            int widthLeftSide;
            if (kscMain.FixedPanel == FixedPanel.None)
                widthLeftSide = (int)(kscMain.Width * LeftSideRatio);
            else
            {
                var newWidth = khgRightSide.PreferredSize.Width;
                widthLeftSide = kscMain.Width - newWidth - kscMain.SplitterWidth;
            }

            kscMain.SuspendLayout();
            kscMain.Panel1MinSize = widthLeftSide;
            kscMain.SplitterDistance = widthLeftSide - kscMain.SplitterWidth;
            kscMain.ResumeLayout();
        }

        void btnRightSideHeader_Click(object sender, EventArgs e)
        {
            UpdateRightSideSize();
        }

        void UpdateRightSideSize()
        {
            kscMain.SuspendLayout();
            if (kscMain.FixedPanel == FixedPanel.None)
            {
                var newWidth = khgRightSide.PreferredSize.Height;
                kscMain.FixedPanel = FixedPanel.Panel2;
                kscMain.Panel2MinSize = 0;
                kscMain.SplitterDistance = kscMain.Width - newWidth - kscMain.SplitterWidth;

                khgRightSide.Panel.Width = newWidth;
                khgRightSide.HeaderPositionPrimary = VisualOrientation.Right;
                btnRightSideHeader.Edge = PaletteRelativeEdgeAlign.Near;
            }
            else
            {
                var widthLeftSide = (int)(kscMain.Width * LeftSideRatio);
                kscMain.FixedPanel = FixedPanel.None;
                kscMain.Panel1MinSize = widthLeftSide;
                kscMain.SplitterDistance = widthLeftSide - kscMain.SplitterWidth;

                khgRightSide.HeaderPositionPrimary = VisualOrientation.Top;
                btnRightSideHeader.Edge = PaletteRelativeEdgeAlign.Far;
            }
            kscMain.ResumeLayout();
        }

        async void FillDataGrid()
        {
            var isIndividual = (knTabs.SelectedPage == kpIndividual);
            if (isIndividual)
            {
                kdgvDataInd.EndEdit();
                var newSrc = new BindingSource();
                var curSrc = (BindingSource)kdgvDataInd.DataSource;
                kdgvDataInd.DataSource = newSrc;
                

                var wait = new WaitForm { Status = TextUI.RetrievingData, OwnerForm = this };
                wait.Show();
                var data = await ApiHelper.PrivateLicenses((int)pcPage.CurrentPage, (int)pcPage.PageSize, SearchParametrs);
                wait.Close();
                wait.Dispose();
                if (ReferenceEquals(data, null))
                    MessageBox.Show(ErrorTexts.FailedToGetDataFromServer);
                else
                {
                    pcPage.TotalRecords = data.TotalNumber;
                    var view = new BindingListView<VehicleLicense>(data.Items);
                    curSrc.DataSource = view; //data.Items;
                }
                
                kdgvDataInd.DataSource = curSrc;
                newSrc.Dispose();
                kdgvDataInd.Invalidate();
            }
            else
            {
                kdgvDataOrg.EndEdit();
                var newSrc = new BindingSource();
                var curSrc = (BindingSource)kdgvDataOrg.DataSource;
                kdgvDataOrg.DataSource = newSrc;
                //curSrc.Clear();

                //curSrc.DataSource = await ApiHelper.LegalLicenses(_currentPage, 25); //VehicleLicense.GetItems(0, _currentPage);

                var wait = new WaitForm { Status = TextUI.RetrievingData, OwnerForm = this };
                wait.Show();
                var data = await ApiHelper.LegalLicenses((int)pcPageOrg.CurrentPage, (int)pcPageOrg.PageSize, SearchParametrs);
                wait.Close();
                wait.Dispose();
                if (ReferenceEquals(data, null))
                    MessageBox.Show(ErrorTexts.FailedToGetDataFromServer);
                else
                {
                    pcPage.TotalRecords = data.TotalNumber;
                    var view = new BindingListView<VehicleLicense>(data.Items);
                    curSrc.DataSource = view; //data.Items;
                }
                
                var col = EntitiesCollections.Instance;

                foreach (var item in data.Items)
                {
                    
                    item.Vehicle.ModelName = col.Models.FirstOrDefault(w => w.Key == item.Vehicle.ModelId).Value;
                    item.Vehicle.MarkName = col.Marks.FirstOrDefault(w => w.Key == item.Vehicle.MarkId).Value;
                    item.Vehicle.ColorName = col.Colors.FirstOrDefault(w => w.Key == item.Vehicle.ColorId).Value;
                    item.Organization.Address.Region = col.Regions.FirstOrDefault(w => w.Key == item.Organization.Address.RegionId).Value;
                    item.Organization.Address.District = col.Regions.FirstOrDefault(w => w.Key == item.Organization.Address.DistrictId).Value;
                    item.Vehicle.Type = col.VehicleTypes.FirstOrDefault(w => w.Key == item.Vehicle.TypeId).Value;
                    item.Vehicle.FuelType = col.Fuels.FirstOrDefault(w => w.Key == item.Vehicle.FuelTypeId).Value;
                    
                  //item.Vehicle.Me = col.Regions.FirstOrDefault(w => w.Key == item.Vehicle.EngineMasurementId).Value;
                }


                kdgvDataOrg.DataSource = curSrc;
                newSrc.Dispose();
                kdgvDataOrg.Invalidate();
            }
        }

        void UpdateView()
        {
            ktvView.Nodes.Clear();
            lblOwnerName.Text = String.Empty;

            var isIndividual = (knTabs.SelectedPage == kpIndividual);
            if (isIndividual)
            {
                var cr = kdgvDataInd.CurrentRow;
                if (!ReferenceEquals(cr, null))
                {
                    var objView = (ObjectView<VehicleLicense>)cr.DataBoundItem;
                    var obj = objView.Object;
                    //lblOwnerName.Text = String.Format("{0} {1} {2}", obj.LastName, obj.FirstName, obj.MiddleName);
                    //kbtnPrint.Enabled = !obj.IsSentToPrint;

                    FillView(obj);
                }
            }
            else
            {
                var cr = kdgvDataOrg.CurrentRow;
                if (!ReferenceEquals(cr, null))
                {
                    var objView = (ObjectView<VehicleLicense>)cr.DataBoundItem;
                    var obj = objView.Object;
                    //lblOwnerName.Text = obj.CompanyName;
                    //kbtnPrint.Enabled = !obj.IsSentToPrint;

                    FillView(obj);
                }
            }
        }

        void FillView(VehicleLicense vl)
        {
            var rootPersonalNumber = new KryptonTreeNode(TextUI.PersonalNumber);
            //rootPersonalNumber.Nodes.Add(vl.PersonalNumber);
            rootPersonalNumber.Expand();

            var rootDateOfIssue = new KryptonTreeNode(TextUI.DateOfIssue);
            rootDateOfIssue.Nodes.Add(vl.DateOfIssue.ToShortDateString());
            rootDateOfIssue.Expand();
            var rootDateOfExpire = new KryptonTreeNode(TextUI.DateOfExpire);
            rootDateOfExpire.Nodes.Add(vl.ExpireDate<DateTime.Today&& vl.ExpireDate !=null? vl.ExpireDate.Value.ToString("dd/MM/yyyy"):string.Empty);
            rootDateOfExpire.Expand();

            var rootPlaceOfIssue = new KryptonTreeNode(TextUI.PlaceOfIssue);
            rootPlaceOfIssue.Nodes.Add(vl.UbddName);
            rootPlaceOfIssue.Expand();

            var rootAddress = new KryptonTreeNode(TextUI.Address);            
            rootAddress.Nodes.Add(vl.Organization.Address.Region);
            rootAddress.Nodes.Add(vl.Organization.Address.District);
            rootAddress.Nodes.Add(vl.Organization.Address.Address);
            rootAddress.Expand();

            var rootMakeModel = new KryptonTreeNode(TextUI.MakeModel);
            rootMakeModel.Nodes.Add(vl.Vehicle.ModelName);
            rootMakeModel.Expand();

            var rootYearOfManufacture = new KryptonTreeNode(TextUI.YearOfManufacture);
            rootYearOfManufacture.Nodes.Add(vl.Vehicle.YearOfManufacture.ToSafeString());
            rootYearOfManufacture.Expand();

            var rootType = new KryptonTreeNode(TextUI.Type);
            rootType.Nodes.Add(vl.Vehicle.Type);
            rootType.Expand();

            var rootVehicleIdentificationNumber = new KryptonTreeNode(TextUI.VehicleIdentificationNumberKuzov);
            rootVehicleIdentificationNumber.Nodes.Add(vl.Vehicle.VehicleIdentificationNumberKuzov);
            rootVehicleIdentificationNumber.Expand();

            var rootEngineNumber = new KryptonTreeNode(TextUI.EngineNumber);
            rootEngineNumber.Nodes.Add(vl.Vehicle.EngineNumber);
            rootEngineNumber.Expand();

            var rootEnginePower = new KryptonTreeNode(TextUI.EnginePower);
            rootEnginePower.Nodes.Add(vl.Vehicle.EnginePower.ToSafeString());
            rootEnginePower.Expand();

            var rootFuelType = new KryptonTreeNode(TextUI.FuelType);
            rootFuelType.Nodes.Add(vl.Vehicle.FuelType);
            rootFuelType.Expand();

            var rootGrossWeight = new KryptonTreeNode(TextUI.GrossWeight);
            rootGrossWeight.Nodes.Add(vl.Vehicle.GrossWeight.ToSafeString("n2"));
            rootGrossWeight.Expand();

            var rootCurbWeight = new KryptonTreeNode(TextUI.CurbWeight);
            rootCurbWeight.Nodes.Add(vl.Vehicle.CurbWeight.ToSafeString("n2"));
            rootCurbWeight.Expand();

            var rootNumberOfSeats = new KryptonTreeNode(TextUI.NumberOfSeats);
            rootNumberOfSeats.Nodes.Add(vl.Vehicle.NumberOfSeats.ToSafeString());
            rootNumberOfSeats.Expand();

            var rootNumberOfStandees = new KryptonTreeNode(TextUI.NumberOfStandees);
            rootNumberOfStandees.Nodes.Add(vl.Vehicle.NumberOfStandees.ToSafeString());
            rootNumberOfStandees.Expand();

            var rootSpecialMarks = new KryptonTreeNode(TextUI.SpecialMarks);
            rootSpecialMarks.Nodes.Add(vl.Vehicle.SpecialMarks);
            rootSpecialMarks.Expand();

            ktvView.Nodes.Add(rootPersonalNumber);
            ktvView.Nodes.Add(rootDateOfIssue);
            ktvView.Nodes.Add(rootPlaceOfIssue);
            ktvView.Nodes.Add(rootAddress);
            ktvView.Nodes.Add(rootMakeModel);
            ktvView.Nodes.Add(rootYearOfManufacture);
            ktvView.Nodes.Add(rootType);
            ktvView.Nodes.Add(rootVehicleIdentificationNumber);
            ktvView.Nodes.Add(rootEngineNumber);
            ktvView.Nodes.Add(rootEnginePower);
            ktvView.Nodes.Add(rootFuelType);
            ktvView.Nodes.Add(rootGrossWeight);
            ktvView.Nodes.Add(rootCurbWeight);
            ktvView.Nodes.Add(rootNumberOfSeats);
            ktvView.Nodes.Add(rootNumberOfStandees);
            ktvView.Nodes.Add(rootSpecialMarks);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            SearchParametrs = null;
            SearchObj = null;
            SearchParametrs = new Dictionary<string, string>();
            SearchObj = new VLSearch();
        }
    }
}
