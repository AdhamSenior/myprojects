using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Common
{
    public class GraphicsHelper
    {
        [DllImport("Gdi32.dll", CharSet = CharSet.Auto)]
        public static extern int SetTextCharacterExtra(int hdc, int nCharExtra);

        public const int Dpi = 300; //300
        public const double CanvasWidth = 3.38; //3.37
        public const double CanvasHeight = 2.13; //2.126

        static GraphicsHelper()
        {
            FontSize = 6;
            FontFamily = "Arial Narrow";
        }
        public static int FontSize { get; set; }
        public static int DefaultTextBlockWidth { get; set; }
        public static int DefaultTextBlockHeight { get; set; }
        public static int DefaultMainTextMargin { get; set; }
        public static string FontFamily { get; set; }

        public static void DrawMainText(Graphics gr, string text, int y)
        {
            DrawText(gr, text, DefaultMainTextMargin, y);
        }
        public static void DrawText(Graphics gr, string text, int x, int y)
        {
            DrawText(gr, text, x, y, DefaultTextBlockWidth, DefaultTextBlockHeight);
        }
        public static void DrawText(Graphics gr, string text, int x, int y, int width)
        {
            DrawText(gr, text, x, y, width, DefaultTextBlockHeight);
        }
        public static void DrawText(Graphics gr, string text, int x, int y, int width, int height)
        {
            var textRect = new RectangleF(x, y, width, height);
            var textFormat = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Near
            };

            var sb = new SolidBrush(Color.FromArgb(255, 0, 0, 0));
            gr.DrawString(text, new Font(FontFamily, FontSize), sb, textRect, textFormat);
        }
        public static void RenderMainText(Graphics gr, string text, int y)
        {
            RenderText(gr, text, DefaultMainTextMargin, y, DefaultTextBlockWidth, DefaultTextBlockHeight);
        }
        public static void RenderText(Graphics gr, string text, int x, int y)
        {
            RenderText(gr, text, x, y, DefaultTextBlockWidth, DefaultTextBlockHeight);
        }
        public static void RenderText(Graphics gr, string text, int x, int y, int width, int height)
        {
            var textRect = new Rectangle(x, y, width, height);
            TextRenderer.DrawText(gr, text, new Font(FontFamily, 18), textRect, Color.Black, TextFormatFlags.Left | TextFormatFlags.WordBreak);
        }
        public static void DrawPhoto(Graphics gr, byte[] photoData, int x, int y)
        {
            if (ReferenceEquals(photoData, null))
                return;

            const double photoWidth = 0.787;
            const double photoHeight = 0.984;
            var photoWidthInPixel = (int)Math.Round(Dpi * photoWidth);
            var photoHeightInPixel = (int)Math.Round(Dpi * photoHeight);

            Image photo;
            using (var ms = new MemoryStream(photoData))
            {
                photo = Image.FromStream(ms);
            }
            var p = GetStretchedImage(photo, photoHeightInPixel, photoWidthInPixel);
            //var colorMatrix = new ColorMatrix { Matrix33 = 0.8f };
            var colorMatrix = new ColorMatrix(new[]
            {
                            new float[]{1, 0, 0, 0, 0},
                            new float[]{0, 1, 0, 0, 0},
                            new float[]{0, 0, 1, 0, 0},
                            new[]{0, 0, 0, 0.8f, 0},
                            new float[]{0, 0, 0, 0, 1}
            });

            var imgAttribute = new ImageAttributes();
            imgAttribute.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            gr.DrawImage(p, new Rectangle(x, y, p.Width, p.Height), 0, 0, p.Width, p.Height, GraphicsUnit.Pixel, imgAttribute);
        }
        public static void DrawSign(Graphics gr, byte[] signData, int x, int y)
        {
            if (ReferenceEquals(signData, null))
                return;

            const double photoWidth = 0.551;
            const double photoHeight = 0.317;
            var photoWidthInPixel = (int)Math.Round(Dpi * photoWidth);
            var photoHeightInPixel = (int)Math.Round(Dpi * photoHeight);

            Image photo;
            using (var ms = new MemoryStream(signData))
            {
                photo = Image.FromStream(ms);
            }

            var p = GetStretchedImage(photo, photoHeightInPixel, photoWidthInPixel);
            gr.DrawImage(p, x, y, p.Width, p.Height);
        }
        public static Image GetStretchedImage(Image b, int height, int width)
        {
            int h, w;
            double proportion;
            if (b.Height > b.Width)
            {
                proportion = (b.Height) / ((double)b.Width);
                h = height;
                w = (int)(height / proportion);
            }
            else if (b.Height < b.Width)
            {
                proportion = (b.Width) / ((double)b.Height);
                h = (int)(width / proportion);
                w = width;
            }
            else
            {
                if (height > width)
                    h = w = width;
                else
                    h = w = height;
            }

            var res = new Bitmap(w, h);
            using (var g = Graphics.FromImage(res))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(b, 0, 0, w, h);
            }
            return res;
        }
        public static Image GetImageFromBase64String(string base64Data)
        {
            if (String.IsNullOrEmpty(base64Data.ToSafeTrimmedString()))
                return null;

            Image photo;
            try
            {
                var photoData = Convert.FromBase64String(base64Data);
                using (var ms = new MemoryStream(photoData))
                {
                    photo = Image.FromStream(ms);
                }
            }
            catch
            {
                return null;
            }
            return photo;
        }
    }
}
