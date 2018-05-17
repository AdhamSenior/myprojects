using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;

namespace DrivingLicenseIssueApp.Logic
{
    using Common;

    public class DriverLicenseGraphics
    {
        public Image FrontSideBackground { get; set; }
        public Image BackSideBackground { get; set; }

        public DriverLicenseGraphics()
        {
            GraphicsHelper.DefaultMainTextMargin = 310;
            GraphicsHelper.DefaultTextBlockWidth = 550;
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
        public Bitmap CreateFrontCard(DrivingLicense obj)
        {
            byte[] photo = null;
            if (!String.IsNullOrEmpty(obj.Holder.PhotoData))
            {
                var photoData = Convert.FromBase64String(obj.Holder.PhotoData);
                photo = photoData;
            }

            byte[] sign = null;
            if (!String.IsNullOrEmpty(obj.Holder.SignatureData))
            {
                var signData = Convert.FromBase64String(obj.Holder.SignatureData);
                sign = signData;
            }

            // 85.60 x 54.00 mm or 2.127 in x 3.37 in
            var canvasWidthInPixel = (int)Math.Round(GraphicsHelper.Dpi * GraphicsHelper.CanvasWidth);
            var canvasHeightInPixel = (int)Math.Round(GraphicsHelper.Dpi * GraphicsHelper.CanvasHeight);
            var cardBitmap = new Bitmap(canvasWidthInPixel, canvasHeightInPixel, PixelFormat.Format32bppArgb);
            cardBitmap.SetResolution(GraphicsHelper.Dpi, GraphicsHelper.Dpi);

            //var background = FrontSideBackground;
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

                FillFrontSideTextByDrawText(gr, obj);
                //FillFrontSideTextByTextRenderer(gr);

                GraphicsHelper.DrawPhoto(gr, photo, 43, 166);
                GraphicsHelper.DrawSign(gr, sign, 70, 485);
            }

            return cardBitmap;
        }
        public Bitmap CreateBackCard(DrivingLicense obj)
        {
            var canvasWidthInPixel = (int)Math.Round(GraphicsHelper.Dpi * GraphicsHelper.CanvasWidth);
            var canvasHeightInPixel = (int)Math.Round(GraphicsHelper.Dpi * GraphicsHelper.CanvasHeight);
            var cardBitmap = new Bitmap(canvasWidthInPixel, canvasHeightInPixel, PixelFormat.Format32bppArgb);
            cardBitmap.SetResolution(GraphicsHelper.Dpi, GraphicsHelper.Dpi);

            //var background = BackSideBackground;
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

                const int textMarginX = 593;
                const int diffMarginX = 55;
                foreach (var c in obj.CategoryList)
                {
                    var textMarginY = 116;
                    switch (c.Name)
                    {
                        case "B":
                            textMarginY = textMarginY + diffMarginX;
                            break;
                        case "C":
                            textMarginY = textMarginY + diffMarginX * 2;
                            break;
                        case "D":
                            textMarginY = textMarginY + diffMarginX * 3 + 5;
                            break;
                        case "BE":
                            textMarginY = textMarginY + diffMarginX * 4 + 5;
                            break;
                        case "CE":
                            textMarginY = textMarginY + diffMarginX * 5 + 5;
                            break;
                        case "DE":
                            textMarginY = textMarginY + diffMarginX * 6 + 5;
                            break;
                    }

                    if (c.DateOfIssue.HasValue && c.DateOfIssue.Value != DateTime.MinValue)
                        GraphicsHelper.DrawText(gr, c.DateOfIssue.Value.ToShortDateString(), textMarginX, textMarginY, 115, 50);
                    if (c.DateOfExpiry.HasValue && c.DateOfExpiry.Value != DateTime.MinValue)
                        GraphicsHelper.DrawText(gr, c.DateOfExpiry.Value.ToShortDateString(), textMarginX + 120, textMarginY, 115, 50);
                }
            }

            return cardBitmap;
        }
        void FillFrontSideTextByDrawText(Graphics gr, DrivingLicense obj)
        {
            var textMargin = GraphicsHelper.DefaultMainTextMargin + 35;
            GraphicsHelper.DrawMainText(gr, "1.", 160);
            GraphicsHelper.DrawText(gr, obj.Holder.LastName.ToUpper(), textMargin, 160);
            GraphicsHelper.DrawMainText(gr, "2.", 194);
            GraphicsHelper.DrawText(gr, obj.Holder.FirstName.ToUpper(), textMargin, 194);
            GraphicsHelper.DrawText(gr, obj.Holder.MiddleName.ToUpper(), textMargin, 228);
            GraphicsHelper.DrawMainText(gr, "3.", 262);

            var placeOfBirth = obj.Holder.PlaceOfBirth;
            var placeAndDate = String.Format("{0}   {1}", placeOfBirth, obj.Holder.DateOfBirth.ToShortDateString());
            GraphicsHelper.DrawText(gr, placeAndDate.ToUpper(), textMargin, 262);
            GraphicsHelper.DrawMainText(gr, "4c.", 330);
            var placeOfIssue = obj.PlaceOfIssue;
            GraphicsHelper.DrawText(gr, placeOfIssue.ToUpper(), textMargin, 330);
            GraphicsHelper.DrawMainText(gr, "4d.", 364);
            GraphicsHelper.DrawText(gr, obj.Holder.PersonalNumber, textMargin, 364);
            GraphicsHelper.DrawMainText(gr, "5.", 398);
            GraphicsHelper.DrawText(gr, obj.CardNumber.ToUpper(), textMargin, 398);

            GraphicsHelper.DrawText(gr, "4a.", GraphicsHelper.DefaultMainTextMargin, 296, 200);
            GraphicsHelper.DrawText(gr, obj.DateOfIssue.ToShortDateString(), textMargin, 296, 200);
            GraphicsHelper.DrawText(gr, "4b.", 554, 296, 245);
            GraphicsHelper.DrawText(gr, obj.DateOfExpiry.ToShortDateString(), 590, 296, 245);
            GraphicsHelper.DrawText(gr, "8.", GraphicsHelper.DefaultMainTextMargin, 432, GraphicsHelper.DefaultTextBlockWidth, 85);

            var placeOfResidence = obj.Holder.PlaceOfResidence.ToString();
            GraphicsHelper.DrawText(gr, placeOfResidence.ToUpper(), 344, 432, 425, 85);
            GraphicsHelper.DrawText(gr, "6.", 38, 459, GraphicsHelper.DefaultTextBlockWidth, 85);
            GraphicsHelper.DrawText(gr, "7.", 38, 524, GraphicsHelper.DefaultTextBlockWidth, 85);

            GraphicsHelper.DrawMainText(gr, "9.", 534);
            if (obj.CategoryList.Length != 0)
            {
                var category = obj.CategoryList.Select(se => se.Name).ToString(" \\ ");
                GraphicsHelper.DrawText(gr, category, textMargin, 534);
            }
        }
        void FillFrontSideTextByTextRenderer(Graphics gr, DrivingLicense obj)
        {
            var textMargin = GraphicsHelper.DefaultMainTextMargin + 35;
            GraphicsHelper.RenderMainText(gr, "1.", 160);
            GraphicsHelper.RenderMainText(gr, "2.", 194);
            GraphicsHelper.RenderMainText(gr, "3.", 262);
            GraphicsHelper.RenderMainText(gr, "4c.", 330);
            GraphicsHelper.RenderMainText(gr, "4d.", 364);
            GraphicsHelper.RenderMainText(gr, "5.", 398);
            GraphicsHelper.RenderText(gr, "4a.", GraphicsHelper.DefaultMainTextMargin, 296, 200, GraphicsHelper.DefaultTextBlockHeight);
            GraphicsHelper.RenderText(gr, "4b.", 554, 296, 245, GraphicsHelper.DefaultTextBlockHeight);
            GraphicsHelper.RenderText(gr, "8.", GraphicsHelper.DefaultMainTextMargin, 432, GraphicsHelper.DefaultTextBlockWidth, 85);
            GraphicsHelper.RenderText(gr, "6.", 38, 459, GraphicsHelper.DefaultTextBlockWidth, 85);
            GraphicsHelper.RenderText(gr, "7.", 38, 524, GraphicsHelper.DefaultTextBlockWidth, 85);
            GraphicsHelper.RenderMainText(gr, "9.", 534);
            var placeOfResidence = obj.Holder.PlaceOfResidence.ToString();
            GraphicsHelper.RenderText(gr, placeOfResidence.ToUpper(), 344, 432, 425, 85);

            //var hdc = gr.GetHdc();
            //SetTextCharacterExtra(hdc.ToInt32(), 1);
            //gr.ReleaseHdc(hdc);

            GraphicsHelper.RenderText(gr, obj.Holder.LastName.ToUpper(), textMargin, 160);
            GraphicsHelper.RenderText(gr, obj.Holder.FirstName.ToUpper(), textMargin, 194);
            GraphicsHelper.RenderText(gr, obj.Holder.MiddleName.ToUpper(), textMargin, 228);
            var placeAndDate = String.Format("{0}   {1}", obj.Holder.PlaceOfBirth, obj.Holder.DateOfBirth.ToShortDateString());
            GraphicsHelper.RenderText(gr, placeAndDate.ToUpper(), textMargin, 262);
            GraphicsHelper.RenderText(gr, obj.PlaceOfIssue.ToUpper(), textMargin, 330);
            GraphicsHelper.RenderText(gr, obj.Holder.PersonalNumber, textMargin, 364);
            GraphicsHelper.RenderText(gr, obj.CardNumber.ToUpper(), textMargin, 398);
            GraphicsHelper.RenderText(gr, obj.DateOfIssue.ToShortDateString(), textMargin, 296, 200, GraphicsHelper.DefaultTextBlockHeight);
            GraphicsHelper.RenderText(gr, obj.DateOfExpiry.ToShortDateString(), 590, 296, 245, GraphicsHelper.DefaultTextBlockHeight);

            if (obj.CategoryList.Length != 0)
            {
                var category = obj.CategoryList.Select(se => se.Name).ToString(" \\ ");
                GraphicsHelper.RenderText(gr, category, textMargin, 534);
            }
        }
    }
}
