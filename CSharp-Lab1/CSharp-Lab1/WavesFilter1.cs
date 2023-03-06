using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Lab1
{
    internal class WavesFilter1 : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int resX = (int)(x + 20 * Math.Sin(2 * y * Math.PI / 60));
            Color resultColor;
            resultColor = sourceImage.GetPixel(Clamp(resX, 0, sourceImage.Width - 1),
                Clamp(y, 0, sourceImage.Height - 1));
            return resultColor;

        }
    }
}
