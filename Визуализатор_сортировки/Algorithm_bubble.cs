using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Визуализатор_сортировки
{
    internal class Algorithm_bubble : ISort
    {

        public void Sort(double[] Array)
        {
            double temp;
            for (int i = 0; i < Array.Length; i++)
            {
                for (int j = 0; j < Array.Length - 1 - i; j++)
                {   
                    if (Array[j] > Array[j + 1])
                    {
                        temp = Array[j];
                        Array[j] = Array[j + 1];
                        Array[j + 1] = temp;
                    }
                }
            }
        }
    }
}
