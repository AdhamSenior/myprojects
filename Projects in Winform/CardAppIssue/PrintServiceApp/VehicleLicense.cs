using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingLicenseIssueApp.Logic;
using Newtonsoft.Json;
using Npgsql;

namespace PrintServiceApp
{
    public partial class VehicleLicense : ITask
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public Image Background { get; set; }

        public VehicleLicense()
        {
            GraphicsHelper.FontSize = 7;
            GraphicsHelper.DefaultMainTextMargin = 288;
            GraphicsHelper.DefaultTextBlockWidth = 500;
            GraphicsHelper.DefaultTextBlockHeight = 28;
        }

        public string UpdateStatus(NpgsqlConnectionStringBuilder csb, string state)
        {
            var db = new DbHelper(csb);
            var query = String.Format("update private_vehicle_licenses set \"status\" = '{0}' where id = {1}", state, Id);
            if (!IsIndividual)
                query = String.Format("update legal_vehicle_licenses set \"status\" = '{0}' where id = {1}", state, Id);
            var suc = db.ExecuteNonQuery(query);
            return !suc ? db.LastError : String.Format(TextUI.JobStateChanged, state);
        }
        public Bitmap CreateFrontCard()
        {
            // 85.60 x 54.00 mm or 2.127 in x 3.37 in
            var canvasWidthInPixel = (int)Math.Round(GraphicsHelper.Dpi * GraphicsHelper.CanvasWidth);
            var canvasHeightInPixel = (int)Math.Round(GraphicsHelper.Dpi * GraphicsHelper.CanvasHeight);
            var cardBitmap = new Bitmap(canvasWidthInPixel, canvasHeightInPixel, PixelFormat.Format32bppArgb);
            cardBitmap.SetResolution(GraphicsHelper.Dpi, GraphicsHelper.Dpi);

            //var background = Background;
            using (var gr = Graphics.FromImage(cardBitmap))
            {
                gr.SmoothingMode = SmoothingMode.HighQuality;
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gr.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                gr.PageUnit = GraphicsUnit.Pixel;
                gr.CompositingQuality = CompositingQuality.HighQuality;
                gr.Clear(System.Drawing.Color.Transparent);
                //gr.DrawImage(background, 0, 0, canvasWidthInPixel, canvasHeightInPixel);
                //gr.DrawRectangle(Pens.Green, 0, 0, canvasWidthInPixel, canvasHeightInPixel);

                FillFrontSideTextByDrawText(gr);
            }

            return cardBitmap;
        }
        public Bitmap CreateBackCard()
        {
            var canvasWidthInPixel = (int)Math.Round(GraphicsHelper.Dpi * GraphicsHelper.CanvasWidth);
            var canvasHeightInPixel = (int)Math.Round(GraphicsHelper.Dpi * GraphicsHelper.CanvasHeight);
            var cardBitmap = new Bitmap(canvasWidthInPixel, canvasHeightInPixel, PixelFormat.Format32bppArgb);
            cardBitmap.SetResolution(GraphicsHelper.Dpi, GraphicsHelper.Dpi);

            //var background = Background;
            using (var gr = Graphics.FromImage(cardBitmap))
            {
                gr.SmoothingMode = SmoothingMode.HighQuality;
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gr.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                gr.PageUnit = GraphicsUnit.Pixel;
                gr.CompositingQuality = CompositingQuality.HighQuality;

                gr.Clear(System.Drawing.Color.Transparent);
                //gr.DrawImage(background, 0, 0, canvasWidthInPixel, canvasHeightInPixel);

                FillBackSideTextByDrawText(gr);
            }

            return cardBitmap;
        }

        void FillFrontSideTextByDrawText(Graphics gr)
        {
            var textMargin = GraphicsHelper.DefaultMainTextMargin + 26;
            GraphicsHelper.DrawMainText(gr, "1.", 146);
            GraphicsHelper.DrawText(gr, RegNumber.ToUpper(), textMargin, 146);
            GraphicsHelper.DrawMainText(gr, "2.", 183);
            GraphicsHelper.DrawText(gr, Model.ToUpper(), textMargin, 183);
            GraphicsHelper.DrawMainText(gr, "3.", 220);
            GraphicsHelper.DrawText(gr, Color.ToUpper(), textMargin, 220);
            GraphicsHelper.DrawMainText(gr, "4.", 257);
            GraphicsHelper.DrawText(gr, Owner.ToUpper(), textMargin, 257, GraphicsHelper.DefaultTextBlockWidth, 65);
            GraphicsHelper.DrawMainText(gr, "5.", 330);
            GraphicsHelper.DrawText(gr, Address, textMargin, 330, GraphicsHelper.DefaultTextBlockWidth, 85);
            GraphicsHelper.DrawMainText(gr, "6.", 425);
            var dt = DateOfIssue.ToShortDateString();
            GraphicsHelper.DrawText(gr, dt.ToUpper(), textMargin, 425);
            GraphicsHelper.DrawMainText(gr, "7.", 466);
            GraphicsHelper.DrawText(gr, PlaceOfIssue.ToUpper(), textMargin, 466);
            GraphicsHelper.DrawMainText(gr, "8.", 510);
            GraphicsHelper.DrawText(gr, PersonalNumber.ToUpper(), textMargin, 510);
        }

        void FillBackSideTextByDrawText(Graphics gr)
        {
            const int textMainMargin = 468;
            const int textMargin = textMainMargin + 41;
            const int textWidth = 450;

            GraphicsHelper.DrawText(gr, "9.", textMainMargin, 38);
            GraphicsHelper.DrawText(gr, YearOfManufacture.ToUpper(), textMargin, 38, textWidth);
            GraphicsHelper.DrawText(gr, "10.", textMainMargin, 88);
            GraphicsHelper.DrawText(gr, Type.ToUpper(), textMargin, 88, textWidth);
            GraphicsHelper.DrawText(gr, "11.", textMainMargin, 138);
            GraphicsHelper.DrawText(gr, VehicleIdentificationNumber.ToUpper(), textMargin, 138, textWidth);
            GraphicsHelper.DrawText(gr, "12.", textMainMargin, 190);
            GraphicsHelper.DrawText(gr, GrossWeight.ToString("n2"), textMargin, 190, textWidth);
            GraphicsHelper.DrawText(gr, "13.", textMainMargin, 242);
            GraphicsHelper.DrawText(gr, CurbWeight.ToString("n2"), textMargin, 242, textWidth);
            GraphicsHelper.DrawText(gr, "14.", textMainMargin, 293);
            GraphicsHelper.DrawText(gr, EngineNumber.ToUpper(), textMargin, 293, textWidth);
            GraphicsHelper.DrawText(gr, "15.", textMainMargin, 345);
            GraphicsHelper.DrawText(gr, EnginePower.ToUpper(), textMargin, 345, textWidth);
            GraphicsHelper.DrawText(gr, "16.", textMainMargin, 395);
            GraphicsHelper.DrawText(gr, FuelType.ToUpper(), textMargin, 395, textWidth);
            GraphicsHelper.DrawText(gr, "17.", textMainMargin, 448);
            GraphicsHelper.DrawText(gr, NumberOfSeats.ToSafeString(), textMargin, 448, textWidth);
            GraphicsHelper.DrawText(gr, "18.", textMainMargin, 499);
            GraphicsHelper.DrawText(gr, NumberOfStandees.ToSafeString(), textMargin, 499, textWidth);
            GraphicsHelper.DrawText(gr, "19.", textMainMargin, 549);
            GraphicsHelper.DrawText(gr, SpecialMarks.ToUpper(), textMargin, 549, textWidth);
        }
    }
}