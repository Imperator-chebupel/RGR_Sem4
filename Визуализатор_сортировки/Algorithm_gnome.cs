using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Визуализатор_сортировки
{
    internal class Algorithm_gnome : ISort
    {
        public void Sort(double[] Array)
        {
            int index = 0;

            while (index < Array.Length)
            {
                if (index == 0) 
                {
                    index++;
                }

                if (Array[index] >= Array[index - 1])
                {
                    index++;
                }
                else
                {
                    double temp = 0;
                    temp = Array[index];
                    Array[index] = Array[index - 1];
                    Array[index - 1] = temp;
                    index--;
                }
            }
        }
    }
}
