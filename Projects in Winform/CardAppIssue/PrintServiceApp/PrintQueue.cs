using System;
using System.Collections.Generic;

namespace PrintServiceApp
{
    using Common;
    using Common.Database;
    using DrivingLicenseIssueApp.Logic;

    public class PrintQueue
    {
        public static void FillByDriverLicense(List<ITask> rs)
        {
            var db = new DbHelper(Setting.DlDbPath);
            var table = db.FetchAll("PrintQueue", String.Format("WHERE Status = '{0}'", Texts.Published));
            if (ReferenceEquals(table, null))
                return;

            for (var i = 0; i < table.Rows.Count; i++)
            {
                var row = table.Rows[i];
                var lastName = row["LastName"].ConvertTo<string>();
                var firstName = row["FirstName"].ConvertTo<string>();
                var middleName = row["MiddleName"].ConvertTo<string>();
                var personalNumber = row["PersonalNumber"].ConvertTo<string>();
                var cardNumber = row["CardNumber"].ConvertTo<string>();
                var placeOfResidence = row["PlaceOfResidence"].ConvertTo<string>();
                var category = row["Category"].ConvertTo<string>();
                var status = row["Status"].ConvertTo<string>();

                var dateOfBirth = row["DateOfBirth"].ConvertTo<DateTime>();
                var dateOfIssue = row["DateOfIssue"].ConvertTo<DateTime>();
                var dateOfExpiry = row["DateOfExpiry"].ConvertTo<DateTime>();

                var photo = row["Photo"].ConvertTo<string>();
                var sign = row["Signature"].ConvertTo<string>();

                var region = row["Region"].ConvertTo<string>();
                var district = row["District"].ConvertTo<string>();
                var placeOfBirth = row["PlaceOfBirth"].ConvertTo<string>();
                var placeOfIssue = row["PlaceOfIssue"].ConvertTo<string>();
                var passportSeries = row["PassportSeries"].ConvertTo<string>();
                var passportNumber = row["PassportNumber"].ConvertTo<int>();
                var licenseId = row["LicenseId"].ConvertTo<long>();

                var location = new Location
                {
                    Region = region,
                    District = district,
                    Address = placeOfResidence
                };

                var holder = new HolderInfo
                {
                    LastName = lastName,
                    FirstName = firstName,
                    MiddleName = middleName,
                    PlaceOfBirth = placeOfBirth,
                    PersonalNumber = personalNumber,
                    DateOfBirth = dateOfBirth,
                    PlaceOfResidence = location,
                    PhotoData = photo,
                    SignatureData = sign,
                    Passport = new Passport { Seria = passportSeries, Number = passportNumber }
                };

                var item = new DrivingLicense
                {
                    Id = licenseId,
                    Holder = holder,
                    CardNumber = cardNumber,
                    PlaceOfIssue = placeOfIssue,
                    DateOfIssue = dateOfIssue,
                    DateOfExpiry = dateOfExpiry,
                    Category = category,
                    CategoryList = Category.Deserialize(category).ToArray(),
                    Status = status
                };
                rs.Add(item);
            }
        }
    }
}