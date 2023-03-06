using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Lab1
{
    internal class GaussianFilter: MatrixFilter
    {
         public GaussianFilter() {
            createGaussianKernel(3, 2);
        }

        public void createGaussianKernel(int radius, float sigma)
        {
            int size = 2 * radius + 1; // размер ядра
            _kernel = new float[size, size]; // ядро фильтра
            float norm = 0; // коэффициент нормировки ядра 
            for (int i = -radius; i <= radius; i++) {
                for (int j = -radius; j <= radius; j++)
                {
                    _kernel[i + radius, j + radius] = (float)(Math.Exp(-(i * i + j * j) / (sigma * sigma)));
                    norm += _kernel[i + radius, j + radius];
                }
            }
            // нормирование ядра
            for (int i = 0; i < size; i++){
               for (int j = 0; j < size; j++)
                {
                    _kernel[i, j] /= norm;
                }
            }
        }
    }
}
