using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Lab1
{
    internal class SepiaFilter: Filters
    {
        private float _ratio;

        public SepiaFilter(float ratio = 25){
            this._ratio = ratio;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y) {
            Color sourceColor = sourceImage.GetPixel(x, y);
            double intensity = 0.36 * sourceColor.R + 0.53 * sourceColor.G + 0.11 * sourceColor.B;
            Color resultColor = Color.FromArgb(
                Clamp((int)(intensity + 2 * _ratio), 0, 255),
                Clamp((int)(intensity + 0.5 * _ratio), 0, 255),
                Clamp((int)(intensity - 1 * _ratio), 0, 255));
            return resultColor;
        }
    }
}
