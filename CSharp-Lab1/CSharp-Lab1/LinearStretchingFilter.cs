using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Lab1
{
    internal class LinearStretchingFilter : Filters
    {
        private int maxR = 0;
        private int maxG = 0;
        private int maxB = 0;
        private int minR = 255;
        private int minG = 255;
        private int minB = 255;

        public LinearStretchingFilter(Bitmap image)
        {
            FindMinMax(image);
        }

        private void FindMinMax(Bitmap image)
        {
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color col = image.GetPixel(i, j);
                    if (col.R > maxR) maxR = col.R;
                    if (col.G > maxG) maxG = col.G;
                    if (col.B > maxB) maxB = col.B;
                    if (col.R < minR) minR = col.R;
                    if (col.G < minG) minG = col.G;
                    if (col.B < minB) minB = col.B;
                }
            }
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int i, int j)
        {
            Color col = sourceImage.GetPixel(i, j);
            return Color.FromArgb((col.R - minR) * 255 / (maxR - minR),
                                  (col.G - minG) * 255 / (maxG - minG),
                                  (col.B - minB) * 255 / (maxB - minB));
        }
    }
}

