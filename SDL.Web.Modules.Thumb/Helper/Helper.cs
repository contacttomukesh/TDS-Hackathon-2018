using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDL.Web.Modules.Thumb.Helper
{
    static class Helper
    {
        public static void GetThumb(Image originalImage, int width, int height)
        {
            Bitmap newImage = new Bitmap(width, height);
            using (Graphics gr = Graphics.FromImage(newImage))
            {
                gr.SmoothingMode = SmoothingMode.HighQuality;
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gr.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, width, height));
                newImage.Save("c:/temp/result.png", ImageFormat.Png);
            }
            
        }

        static void GenerateThumb(string input, string output, int width)
        {

            // Load image.
            Image image = Image.FromFile(input);

            // Compute thumbnail size.
            Size thumbnailSize = GetThumbnailSize(image, width);

            // Get thumbnail.
            Image thumbnail = image.GetThumbnailImage(thumbnailSize.Width,
                thumbnailSize.Height, null, IntPtr.Zero);

            // Save thumbnail.
            thumbnail.Save(output);
        }

        static Size GetThumbnailSize(Image original, int maxPixels)
        {
            // Width and height.
            int originalWidth = original.Width;
            int originalHeight = original.Height;

            // Compute best factor to scale entire image based on larger dimension.
            double factor;
            if (originalWidth > originalHeight)
            {
                factor = (double)maxPixels / originalWidth;
            }
            else
            {
                factor = (double)maxPixels / originalHeight;
            }

            // Return thumbnail size.
            return new Size((int)(originalWidth * factor), (int)(originalHeight * factor));
        }
    }
}
