using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Lab1
{
    abstract class Morphology : Filters
    {
        protected abstract bool calculateColorMorphology(bool a, bool b);
        protected bool[,] _kernal = null;
        protected bool _result = false;
        public Morphology() { }
        public Morphology(bool[,] kernal)
        {
            this._kernal = kernal;
        }

        protected override Color calculateNewPixelColor(Bitmap sourse, int x, int y)
        {
            int radX = _kernal.GetLength(0) / 2;
            int radY = _kernal.GetLength(1) / 2;
            int resCol = 0;
            bool resC = _result;
            for (int i = 0; i < _kernal.GetLength(1); i++)
            {
                for (int j = 0; j < _kernal.GetLength(0); j++)
                {
                    int idx = Clamp(x + j - radY, 0, sourse.Width - 1);
                    int idy = Clamp(y + i - radX, 0, sourse.Height - 1);
                    Color neigCol = sourse.GetPixel(idx, idy);
                    bool neig = false;
                    if (neigCol.R >= 250 && neigCol.G >= 250 && neigCol.B >= 250) neig = true;
                    if (_kernal[j, i]) resC = calculateColorMorphology(resC, neig);
                }
            }
            if (resC) resCol = 255;
            return Color.FromArgb(resCol, resCol, resCol);
        }
    }
}
