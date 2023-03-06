using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Lab1
{
    internal class MotionBlurFilter : MatrixFilter
    {
        public MotionBlurFilter()
        {
            int n = 5;
            _kernel = new float[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    _kernel[i, j] = 1f / (n * n);
                }
            }
        }
    }
}
