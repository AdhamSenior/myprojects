using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace VehicleLicenseIssueApp.Logic
{
    using Common;
    using Common.Database;

    public partial class VehicleLicense
    {
        static string _lastError = String.Empty;
        public static string LastError
        {
            get { return _lastError; }
        }

        public static readonly DateTime MinDate = new DateTime(1900, 1, 1);
        public VehicleLicense()
        {
            IsPersonal = true;
            Person = new PersonalInfo();
            Organization = new OrganizationInfo();
            Vehicle = new VehicleInfo();
        }

        public bool Save()
        {
            _lastError = String.Empty;

            //if (IsIndividual)
            //    CompanyName = String.Format("{0} {1} {2}", LastName, FirstName, MiddleName);
            //else
            //{
            //    LastName = CompanyName;
            //    FirstName = CompanyName;
            //    MiddleName = CompanyName;
            //}

            var db = new DbHelper(Setting.VlDbPath);
            var prm = GetParameters();
            var id = db.Insert("VehicleLicenses", prm);
            if (id <= 0)
                _lastError = db.LastError;
            return (id > 0);
        }

        public bool Update()
        {
            _lastError = String.Empty;

            var db = new DbHelper(Setting.VlDbPath);
            var prm = GetParameters();
            var suc = db.Update("VehicleLicenses", prm, String.Format("Id = {0}", Id));
            if (suc != 0)
                _lastError = db.LastError;
            return (suc == 0);
        }

        ParametersCollection GetParameters()
        {
            var prm = new ParametersCollection
            {
                //{"StateNumberPlate", StateNumberPlate, DbType.String},
                //{"Make", Make, DbType.String},
                //{"Model", Model, DbType.String},
                //{"Color", Color, DbType.String},
                //{"LastName", LastName, DbType.String},
                //{"FirstName", FirstName, DbType.String},
                //{"MiddleName", MiddleName, DbType.String},
                //{"Region", Region, DbType.String},
                //{"City", City, DbType.String},
                //{"Address", Address, DbType.String},
                //{"PlaceOfIssue", PlaceOfIssue, DbType.String},
                //{"PersonalNumber", PersonalNumber, DbType.String},
                //{"YearOfManufacture", YearOfManufacture, DbType.Int32},
                //{"Type", Type, DbType.String},
                //{"VehicleIdentificationNumber", VehicleIdentificationNumber, DbType.String},
                //{"GrossWeight", GrossWeight, DbType.Decimal},
                //{"CurbWeight", CurbWeight, DbType.Decimal},
                //{"EngineNumber", EngineNumber, DbType.String},
                //{"EnginePower", EnginePower, DbType.Int32},
                //{"FuelType", FuelType, DbType.String},
                //{"NumberOfSeats", NumberOfSeats, DbType.Int32},
                //{"NumberOfStandees", NumberOfStandees, DbType.Int32},
                //{"SpecialMarks", SpecialMarks, DbType.String},
                //{"DateOfIssue", DateOfIssue, DbType.DateTime},
                //{"IsIndividual", IsIndividual, DbType.Boolean},
                //{"CompanyName", CompanyName, DbType.String}
            };
            return prm;
        }

        public string Validate()
        {
            var sb = new StringBuilder();
            if (IsPersonal)
            {
                var rs = Person.Validate();
                if (!String.IsNullOrEmpty(rs))
                    sb.AppendLine(rs);
            }
            else
            {
                var rs = Organization.Validate();
                if (!String.IsNullOrEmpty(rs))
                    sb.AppendLine(rs);
            }

            var r = Vehicle.Validate();
            if (!String.IsNullOrEmpty(r))
                sb.AppendLine(r);

            if (DateOfIssue == MinDate)
                sb.AppendLine(String.Format(ErrorTexts.FieldIsEmpty, Texts.DateOfIssue));


            if (ExpireDate.Value.Date == DateTime.Today.Date)
                ExpireDate = null;

            PlaceOfIssue = PlaceOfIssue.ToSafeTrimmedString();
            if (String.IsNullOrEmpty(PlaceOfIssue))
                sb.AppendLine(String.Format(ErrorTexts.FieldIsEmpty, Texts.PlaceOfIssue));

            return sb.ToString();
        }

        public static List<VehicleLicense> GetItems(int isInd, int skip)
        {
            var etc = "ORDER BY Id DESC LIMIT 50";
            if (skip > 0)
                etc = String.Format("ORDER BY Id DESC LIMIT 50 OFFSET {0}", skip);

            var db = new DbHelper(Setting.VlDbPath);
            var table = db.FetchAll("VehicleLicenses", String.Format("WHERE IsIndividual = {0}", isInd), etc);
            if (ReferenceEquals(table, null))
            {
                _lastError = db.LastError;
                return null;
            }

            var rs = new List<VehicleLicense>();
            for (var i = 0; i < table.Rows.Count; i++)
            {
                var row = table.Rows[i];
                var id = row["Id"].ConvertTo<long>();
                var stateNumberPlate = row["StateNumberPlate"].ConvertTo<string>();
                var make = row["Make"].ConvertTo<string>();
                var model = row["Model"].ConvertTo<string>();
                var color = row["Color"].ConvertTo<string>();
                var region = row["Region"].ConvertTo<string>();
                var city = row["City"].ConvertTo<string>();
                var address = row["Address"].ConvertTo<string>();
                var placeOfIssue = row["PlaceOfIssue"].ConvertTo<string>();
                var personalNumber = row["PersonalNumber"].ConvertTo<string>();
                var lastName = row["LastName"].ConvertTo<string>();
                var firstName = row["FirstName"].ConvertTo<string>();
                var middleName = row["MiddleName"].ConvertTo<string>();
                var type = row["Type"].ConvertTo<string>();
                var vehicleIdentificationNumber = row["VehicleIdentificationNumber"].ConvertTo<string>();
                var engineNumber = row["EngineNumber"].ConvertTo<string>();
                var fuelType = row["FuelType"].ConvertTo<string>();
                var specialMarks = row["SpecialMarks"].ConvertTo<string>();
                var companyName = row["CompanyName"].ConvertTo<string>();

                var yearOfManufacture = row["YearOfManufacture"].ConvertTo<int>();
                var enginePower = row["EnginePower"].ConvertTo<int>();
                var numberOfSeats = row["NumberOfSeats"].ConvertTo<int>();
                var numberOfStandees = row["NumberOfStandees"].ConvertTo<int>();

                var grossWeight = row["GrossWeight"].ConvertTo<decimal>();
                var curbWeight = row["CurbWeight"].ConvertTo<decimal>();

                var dateOfIssue = row["DateOfIssue"].ConvertTo<DateTime>();
                var isSentToPrint = row["IsSentToPrint"].ConvertTo<bool>();
                var isIndividual = row["IsIndividual"].ConvertTo<bool>();

                var item = new VehicleLicense
                {
                    Id = id,
                    //StateNumberPlate = stateNumberPlate,
                    //Make = make,
                    //Model = model,
                    //MakeModel = String.Format("{0} / {1}", make, model),
                    //Color = color,
                    //Region = region,
                    //City = city,
                    //Address = address,
                    //LastName = lastName,
                    //FirstName = firstName,
                    //MiddleName = middleName,
                    //Type = type,
                    //PlaceOfIssue = placeOfIssue,
                    //PersonalNumber = personalNumber,
                    //Inn = personalNumber,
                    //VehicleIdentificationNumber = vehicleIdentificationNumber,
                    //EngineNumber = engineNumber,
                    //FuelType = fuelType,
                    //SpecialMarks = specialMarks,
                    //YearOfManufacture = yearOfManufacture,
                    //EnginePower = enginePower,
                    //NumberOfSeats = numberOfSeats,
                    //NumberOfStandees = numberOfStandees,
                    //GrossWeight = grossWeight,
                    //CurbWeight = curbWeight,
                    //DateOfIssue = dateOfIssue,
                    //IsSentToPrint = isSentToPrint,
                    //EnginePowerStr = enginePower.ToSafeString(),
                    //YearOfManufactureStr = yearOfManufacture.ToSafeString(),
                    //CompanyName = companyName,
                    //IsIndividual = isIndividual
                };
                rs.Add(item);
            }
            return rs;
        }

        public bool SetIsSentToPrint()
        {
            _lastError = String.Empty;

            var db = new DbHelper(Setting.VlDbPath);
            var prm = new ParametersCollection
            {
                {"IsSentToPrint", true, DbType.Boolean}
            };
            var suc = db.Update("VehicleLicenses", prm, String.Format("Id = {0}", Id));
            if (suc != 0)
                _lastError = db.LastError;

            return (suc == 0);
        }
    }
}
