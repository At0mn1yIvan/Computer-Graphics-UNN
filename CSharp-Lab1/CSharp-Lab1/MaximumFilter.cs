using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Lab1
{
    internal class MaximumFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int size = 3;
            int radiusX = size / 2;
            int radiusY = size / 2;
            int index = 0;
            int[] colR = new int[9];
            int[] colG = new int[9];
            int[] colB = new int[9];
            for (int l = -radiusY; l <= radiusY; l++)
            {
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + k, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    colR[index] = neighborColor.R;
                    colG[index] = neighborColor.G;
                    colB[index] = neighborColor.B;
                    index++;
                }

            }

            return Color.FromArgb(colR.Max(), colG.Max(), colB.Max());
        }

    }
}
