using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Lab1
{
    internal class MatrixFilter : Filters
    {
        protected float[,] _kernel = null; 
        protected MatrixFilter() { }

        public MatrixFilter(float[,] kernel)
        {
            this._kernel = kernel;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = _kernel.GetLength(0) / 2;
            int radiusY = _kernel.GetLength(1) / 2;

            float ResultR = 0;
            float ResultG = 0;
            float ResultB = 0;

            for (int l = -radiusY; l <= radiusY; l++) {
                for (int k = -radiusX; k <= radiusX; k++) {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    ResultR += neighborColor.R * _kernel[k + radiusX, l + radiusY];
                    ResultG += neighborColor.G * _kernel[k + radiusX, l + radiusY];
                    ResultB += neighborColor.B * _kernel[k + radiusX, l + radiusY];
                
                }
            }

            return Color.FromArgb(
                Clamp((int)ResultR, 0, 255),
                Clamp((int)ResultG, 0, 255),
                Clamp((int)ResultB, 0, 255)
                );
        }

    }
}
