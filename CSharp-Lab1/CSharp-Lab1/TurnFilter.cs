using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Lab1
{
    internal class TurnFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            double corner = Math.PI / 4;
            int x0 = (int)sourceImage.Width / 2;
            int y0 = (int)sourceImage.Height / 2;
            int resX = (int)((x - x0) * Math.Cos(corner) - (y - y0) * Math.Sin(corner) + x0);
            int resY = (int)((x - x0) * Math.Sin(corner) + (y - y0) * Math.Cos(corner) + y0);
            Color resultColor;
            if (resY > sourceImage.Height - 1 || resX > sourceImage.Width - 1) return Color.White;
            resultColor = sourceImage.GetPixel(Clamp(resX, 0, sourceImage.Width - 1),
                Clamp(resY, 0, sourceImage.Height - 1));
            return resultColor;



        }
    }
}
