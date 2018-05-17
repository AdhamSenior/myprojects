using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DrivingLicenseIssueApp.Logic
{
    using Common;
    using Common.Database;
    using Newtonsoft.Json;
    using RestSharp;

    public partial class DrivingLicense : ITask
    {
        static string _lastError = String.Empty;
        public static string LastError
        {
            get { return _lastError; }
        }

        public static readonly DateTime MinDate = new DateTime(1900, 1, 1);

        public DrivingLicense()
        {
            Holder = new HolderInfo();
        }
        public string Validate()
        {
            var sb = new StringBuilder();
            var rs = Holder.Validate();
            if (!String.IsNullOrEmpty(rs))
                sb.AppendLine(rs);

            if (DateOfIssue == MinDate)
                sb.AppendLine(String.Format(ErrorTexts.FieldIsEmpty, Texts.DateOfIssue));

            if (DateOfExpiry == MinDate)
                sb.AppendLine(String.Format(ErrorTexts.FieldIsEmpty, Texts.DateOfExpiry));

            PlaceOfIssue = PlaceOfIssue.ToSafeTrimmedString();
            if (String.IsNullOrEmpty(PlaceOfIssue))
                sb.AppendLine(String.Format(ErrorTexts.FieldIsEmpty, Texts.PlaceOfIssue));

            //CardNumber = CardNumber.ToSafeTrimmedString();
            //if (String.IsNullOrEmpty(CardNumber))
            //    sb.AppendLine(String.Format(ErrorTexts.FieldIsEmpty, Texts.CardNumber));

            return sb.ToString();
        }
        ParametersCollection GetParameters()
        {
            if (String.IsNullOrEmpty(Holder.PlaceOfResidence.Region))
                Holder.PlaceOfResidence.Region = Soato.FindById(Holder.PlaceOfResidence.RegionId);

            if (String.IsNullOrEmpty(Holder.PlaceOfResidence.District))
                Holder.PlaceOfResidence.District = Soato.FindById(Holder.PlaceOfResidence.DistrictId);

            if (String.IsNullOrEmpty(PlaceOfIssue))
                PlaceOfIssue = Soato.FindById(PlaceOfIssueId);

            var prm = new ParametersCollection
            {
                {"LastName", Holder.LastName, DbType.String},
                {"FirstName", Holder.FirstName, DbType.String},
                {"MiddleName", Holder.MiddleName, DbType.String},
                {"PlaceOfBirth", Holder.PlaceOfBirth, DbType.String},
                {"DateOfBirth", Holder.DateOfBirth, DbType.DateTime},
                {"PersonalNumber", Holder.PersonalNumber, DbType.String},
                {"PlaceOfResidence", Holder.PlaceOfResidence.Address, DbType.String},
                {"Region", Holder.PlaceOfResidence.Region, DbType.String},
                {"District", Holder.PlaceOfResidence.District, DbType.String},
                {"PlaceOfIssue", PlaceOfIssue, DbType.String},
                {"CardNumber", CardNumber, DbType.String},
                {"Category", Category, DbType.String},
                {"DateOfIssue", DateOfIssue, DbType.DateTime},
                {"DateOfExpiry", DateOfExpiry, DbType.DateTime},
                {"PassportSeries", Holder.Passport.Seria, DbType.String},
                {"PassportNumber", Holder.Passport.Number, DbType.Int32},
                {"LicenseId", Id, DbType.Int64},
                {"Status", Status, DbType.String}
            };
            return prm;
        }
        public bool SendToPrint()
        {
            _lastError = String.Empty;
            var db = new DbHelper(Setting.DlDbPath);
            var prm = GetParameters();
            prm.Add(new Common.Database.Parameter { ColumnName = "Photo", DbType = DbType.String, Value = Holder.PhotoData });
            prm.Add(new Common.Database.Parameter { ColumnName = "Signature", DbType = DbType.String, Value = Holder.SignatureData });
            var id = db.Insert("PrintQueue", prm);
            if (id <= 0)
                _lastError = db.LastError;
            return (id > 0);
        }
        public bool UpdateStatus(string state)
        {
            _lastError = String.Empty;

            var db = new DbHelper(Setting.DlDbPath);
            var prm = new ParametersCollection
            {
                {"Status", state, DbType.String}
            };
            var suc = db.Update("PrintQueue", prm, String.Format("LicenseId = {0}", Id));
            if (suc != 0)
                _lastError = db.LastError;

            return (suc == 0);
        }

        public Bitmap CreateFrontCard()
        {
            var dr = new DriverLicenseGraphics();
            return dr.CreateFrontCard(this);
        }
        public Bitmap CreateBackCard()
        {
            var dr = new DriverLicenseGraphics();
            return dr.CreateBackCard(this);
        }

        public static async Task<DlData> GetDrivingLicenses(int page, int pageSize)
        {
            DlData rs;
            var url = String.Format("{0}/api/v1/dl", Setting.ApiUrl);
            var response = await Server.GetDataList(url, page, pageSize);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = response.Content;
                var obj = DlDataResponse.Deserialize(content);
                rs = obj.Data;
            }
            else
                rs = null;

            return rs;
        }

        public async Task<IRestResponse> Post()
        {
            var jss = new JsonSerializerSettings
            {
                ContractResolver = Id == 0 ? new DlPostContractResolver("new") : new DlPostContractResolver("edit"),
                DateTimeZoneHandling = DateTimeZoneHandling.Local,
                DateFormatString = "yyyyMMdd"
            };
            var json = JsonConvert.SerializeObject(this, Formatting.Indented, jss);

            if (Id > 0)
                return await PatchDriverLicence(json);
            return await PostDriverLicence(json);
        }

        public async Task<IRestResponse> PostPhoto()
        {
            var json = GetPostImageJson(Photo, ImageFormat.Jpeg);
            var url = String.Format("{0}/api/v1/dl/photo", Setting.ApiUrl);
            return await Server.PatchData(json, url);
        }

        public async Task<IRestResponse> PostSignature()
        {
            var json = GetPostImageJson(Signature, ImageFormat.Png);
            var url = String.Format("{0}/api/v1/dl/signature", Setting.ApiUrl);
            return await Server.PatchData(json, url);
        }

        public async Task<IRestResponse> PostPublishedStatus()
        {
            var json = GetPublishedStatusJson();
            var url = String.Format("{0}/api/v1/cards/status", Setting.ApiUrl);
            return await Server.PatchData(json, url);
        }

        async Task<IRestResponse> PostDriverLicence(string json)
        {
            var url = String.Format("{0}/api/v1/dl", Setting.ApiUrl);
            return await Server.PostData(json, url);
        }

        async Task<IRestResponse> PatchDriverLicence(string json)
        {
            var url = String.Format("{0}/api/v1/dl/" + Id, Setting.ApiUrl);
            return await Server.PatchData(json, url);
        }

        string GetPostImageJson(Image img, ImageFormat imgFormat)
        {
            byte[] imgData;
            using (var ms = new MemoryStream())
            {
                img.Save(ms, imgFormat);
                imgData = ms.ToArray();
            }

            var base64Data = Convert.ToBase64String(imgData);
            var sb = new StringBuilder();
            var sw = new StringWriter(sb);
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartObject();
                writer.WritePropertyName("id");
                writer.WriteValue(Id);
                writer.WritePropertyName("base64");
                writer.WriteValue(base64Data);
                writer.WriteEndObject();
            }
            return sb.ToString();
        }
        string GetPublishedStatusJson()
        {
            var sb = new StringBuilder();
            var sw = new StringWriter(sb);
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartObject();
                writer.WritePropertyName("license_id");
                writer.WriteValue(Id);
                writer.WritePropertyName("status");
                writer.WriteValue(Status);
                writer.WriteEndObject();
            }
            return sb.ToString();
        }
        public string GetStatusJson(string revokeReason = "")
        {
            var sb = new StringBuilder();
            var sw = new StringWriter(sb);
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartObject();
                writer.WritePropertyName("status");
                writer.WriteValue(Status);

                if (!String.IsNullOrEmpty(CardSn))
                {
                    writer.WritePropertyName("license_id");
                    writer.WriteValue(Id);
                }

                if (!String.IsNullOrEmpty(revokeReason))
                {
                    writer.WritePropertyName("revoke_reason");
                    writer.WriteValue(revokeReason);
                }
                writer.WriteEndObject();
            }
            return sb.ToString();
        }
    }
}