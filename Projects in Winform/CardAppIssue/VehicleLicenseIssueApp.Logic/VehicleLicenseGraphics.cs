using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace VehicleLicenseIssueApp.Logic
{
    using Common;

    public class VehicleLicenseGraphics
    {
        public Image FrontSideBackground { get; set; }
        public Image BackSideBackground { get; set; }

        public VehicleLicenseGraphics()
        {
            GraphicsHelper.FontSize = 7;
            GraphicsHelper.DefaultMainTextMargin = 288;
            GraphicsHelper.DefaultTextBlockWidth = 500;
            GraphicsHelper.DefaultTextBlockHeight = 28;
        }

        public static Bitmap CreateCardTemplate(Image background)
        {
            var canvasWidthInPixel = (int)Math.Round(GraphicsHelper.Dpi * GraphicsHelper.CanvasWidth);
            var canvasHeightInPixel = (int)Math.Round(GraphicsHelper.Dpi * GraphicsHelper.CanvasHeight);
            var cardBitmap = new Bitmap(canvasWidthInPixel, canvasHeightInPixel, PixelFormat.Format32bppArgb);
            cardBitmap.SetResolution(GraphicsHelper.Dpi, GraphicsHelper.Dpi);

            using (var gr = Graphics.FromImage(cardBitmap))
            {
                gr.SmoothingMode = SmoothingMode.HighQuality;
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gr.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                gr.PageUnit = GraphicsUnit.Pixel;
                gr.CompositingQuality = CompositingQuality.HighQuality;

                gr.Clear(Color.Transparent);
                gr.DrawImage(background, 0, 0, canvasWidthInPixel, canvasHeightInPixel);
            }

            return cardBitmap;
        }
        public Bitmap CreateFrontCard(VehicleLicense obj)
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
                gr.Clear(Color.Transparent);
                //gr.DrawImage(background, 0, 0, canvasWidthInPixel, canvasHeightInPixel);
                //gr.DrawRectangle(Pens.Green, 0, 0, canvasWidthInPixel, canvasHeightInPixel);

                FillFrontSideTextByDrawText(gr, obj);
            }

            return cardBitmap;
        }
        public Bitmap CreateBackCard(VehicleLicense obj)
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

                gr.Clear(Color.Transparent);
                //gr.DrawImage(background, 0, 0, canvasWidthInPixel, canvasHeightInPixel);

                FillBackSideTextByDrawText(gr, obj);
            }

            return cardBitmap;
        }

        void FillFrontSideTextByDrawText(Graphics gr, VehicleLicense obj)
        {
            var textMargin = GraphicsHelper.DefaultMainTextMargin + 26;
            GraphicsHelper.DrawMainText(gr, "1.", 146);
            GraphicsHelper.DrawText(gr, obj.Vehicle.RegNumber.ToUpper(), textMargin, 146);
            GraphicsHelper.DrawMainText(gr, "2.", 183);
            GraphicsHelper.DrawText(gr, obj.ModelName.ToUpper(), textMargin, 183);
            GraphicsHelper.DrawMainText(gr, "3.", 220);
            GraphicsHelper.DrawText(gr, obj.Color.ToUpper(), textMargin, 220);
            GraphicsHelper.DrawMainText(gr, "4.", 257);
            //GraphicsHelper.DrawText(gr, obj.Owner.ToUpper(), textMargin, 257, GraphicsHelper.DefaultTextBlockWidth, 65);
            GraphicsHelper.DrawMainText(gr, "5.", 330);
            //GraphicsHelper.DrawText(gr, obj.Address, textMargin, 330, GraphicsHelper.DefaultTextBlockWidth, 85);
            GraphicsHelper.DrawMainText(gr, "6.", 425);
            var dt = obj.DateOfIssue.ToShortDateString();
            GraphicsHelper.DrawText(gr, dt.ToUpper(), textMargin, 425);
            GraphicsHelper.DrawMainText(gr, "7.", 466);
            GraphicsHelper.DrawText(gr, obj.PlaceOfIssue.ToUpper(), textMargin, 466);
            GraphicsHelper.DrawMainText(gr, "8.", 510);
            //GraphicsHelper.DrawText(gr, obj.PersonalNumber.ToUpper(), textMargin, 510);
        }

        void FillBackSideTextByDrawText(Graphics gr, VehicleLicense obj)
        {
            const int textMainMargin = 468;
            const int textMargin = textMainMargin + 41;
            const int textWidth = 450;

            GraphicsHelper.DrawText(gr, "9.", textMainMargin, 38);
            GraphicsHelper.DrawText(gr, obj.Vehicle.YearOfManufacture.ToString(), textMargin, 38, textWidth);
            GraphicsHelper.DrawText(gr, "10.", textMainMargin, 88);
            GraphicsHelper.DrawText(gr, obj.Vehicle.Type.ToUpper(), textMargin, 88, textWidth);
            GraphicsHelper.DrawText(gr, "11.", textMainMargin, 138);
            //GraphicsHelper.DrawText(gr, obj.Vehicle.RegNumber.ToUpper(), textMargin, 138, textWidth);
            GraphicsHelper.DrawText(gr, "12.", textMainMargin, 190);
            GraphicsHelper.DrawText(gr, obj.Vehicle.GrossWeight.ToString("n2"), textMargin, 190, textWidth);
            GraphicsHelper.DrawText(gr, "13.", textMainMargin, 242);
            GraphicsHelper.DrawText(gr, obj.Vehicle.CurbWeight.ToString("n2"), textMargin, 242, textWidth);
            GraphicsHelper.DrawText(gr, "14.", textMainMargin, 293);
            GraphicsHelper.DrawText(gr, obj.Vehicle.EngineNumber.ToUpper(), textMargin, 293, textWidth);
            GraphicsHelper.DrawText(gr, "15.", textMainMargin, 345);
            GraphicsHelper.DrawText(gr, obj.Vehicle.EnginePower.ToString(), textMargin, 345, textWidth);
            GraphicsHelper.DrawText(gr, "16.", textMainMargin, 395);
            GraphicsHelper.DrawText(gr, obj.Vehicle.FuelType.ToUpper(), textMargin, 395, textWidth);
            GraphicsHelper.DrawText(gr, "17.", textMainMargin, 448);
            GraphicsHelper.DrawText(gr, obj.Vehicle.NumberOfSeats.ToSafeString(), textMargin, 448, textWidth);
            GraphicsHelper.DrawText(gr, "18.", textMainMargin, 499);
            GraphicsHelper.DrawText(gr, obj.Vehicle.NumberOfStandees.ToSafeString(), textMargin, 499, textWidth);
            GraphicsHelper.DrawText(gr, "19.", textMainMargin, 549);
            GraphicsHelper.DrawText(gr, obj.Vehicle.SpecialMarks.ToUpper(), textMargin, 549, textWidth);
        }
    }
}
