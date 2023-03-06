using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Lab1
{
    internal class GlassFilter: Filters
    {
        private Random rand = new Random();
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int resX = (int)(x + (rand.Next(0, 5) - 2) * 5);
            int resY = (int)(y + (rand.Next(0, 5) - 2) * 5);
            return sourceImage.GetPixel(Clamp(resX, 0, sourceImage.Width - 1), Clamp(resY, 0, sourceImage.Height - 1));
        }
    }
}
