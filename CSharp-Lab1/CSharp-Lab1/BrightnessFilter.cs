using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Lab1
{
    internal class BrightnessFilter: Filters
    {
        private int _ratio;

        public BrightnessFilter(int ratio = 10)
        {
            this._ratio = ratio;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(Clamp(sourceColor.R + _ratio, 0, 255),
                                               Clamp(sourceColor.G + _ratio, 0, 255),
                                               Clamp(sourceColor.B + _ratio, 0, 255));
            return resultColor;
        }
    }
}
