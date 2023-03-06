using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Lab1
{
    internal class TopHatFilter : Filters
    {

        private bool[,] kernel;
        private int centerX;
        private int centerY;
        private Bitmap imageAfterDilation;
        private bool dilationCompleted = false;
        public TopHatFilter(bool[,] _kernel, int _centerX, int _centerY)
        {
            kernel = _kernel;
            centerX = _centerX;
            centerY = _centerY;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int i, int j)
        {
            bool colorNew = colorToBool(closingColor(sourceImage, i, j));
            bool colorOld = colorToBool(sourceImage.GetPixel(i, j));
            if (colorOld && !colorNew) return Color.White;
            else return Color.Black;


        }

        private Color closingColor(Bitmap sourceImage, int i, int j)
        {
            if (!dilationCompleted)
            {
                imageAfterDilation = new Bitmap(sourceImage.Width, sourceImage.Height);
                var g = Graphics.FromImage(imageAfterDilation);
                g.Clear(Color.White);
                for (int a = 0; a < sourceImage.Width; a++)
                {
                    for (int b = 0; b < sourceImage.Height; b++)
                        imageAfterDilation.SetPixel(a, b, dilationColor(sourceImage, a, b));
                }
                dilationCompleted = true;
            }


            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;

            for (int l = -radiusY; l <= radiusY; l++)
                for (int k = -radiusX; k <= radiusX; k++)
                {

                    int idX = Clamp(i + k, 0, imageAfterDilation.Width - 1);
                    int idY = Clamp(j + l, 0, imageAfterDilation.Height - 1);
                    bool pixelColor = colorToBool(imageAfterDilation.GetPixel(idX, idY));
                    if (pixelColor != kernel[k + radiusX, l + radiusY])
                    {
                        return Color.White;
                    }
                }
            return Color.Black;
        }

        private Color dilationColor(Bitmap sourceImage, int i, int j)
        {

            bool pixelColor = colorToBool(sourceImage.GetPixel(i, j));
            if (kernel[centerX, centerY] == pixelColor)
            {
                int radiusX = kernel.GetLength(0) / 2;
                int radiusY = kernel.GetLength(1) / 2;
                for (int l = -radiusY; l <= radiusY; l++)
                    for (int k = -radiusX; k <= radiusX; k++)
                    {
                        int idX = Clamp(i + k, 0, sourceImage.Width - 1);
                        int idY = Clamp(j + l, 0, sourceImage.Height - 1);
                        if (!kernel[k + radiusX, l + radiusY]) imageAfterDilation.SetPixel(idX, idY, Color.Black);
                    }
            }
            return imageAfterDilation.GetPixel(i, j);
        }

        private bool colorToBool(Color color)
        {
            if (color.R >= 250 && color.G >= 250 && color.B >= 250) return true;
            return false;
        }


    }
}
