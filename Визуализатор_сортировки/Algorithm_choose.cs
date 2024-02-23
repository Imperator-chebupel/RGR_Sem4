using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Визуализатор_сортировки
{
    internal class Algorithm_choose : ISort
    {/*
        double[] Numbers;

        public Algorithm_choose(int lenght)
        {
            Numbers = (lenght > 0) ? new double[lenght] : new double[100];
        }

        public Algorithm_choose()
        {
            Numbers = new double[100];
        }
        */
        public void Sort(double[] Array)
        {
            double temp;
            int Min;
            for (int i = 0; i < Array.Length; i++)
            {
                Min = i;
                for (int j = i + 1; j < Array.Length; j++)
                {
                    if (Array[j] < Array[Min])
                        Min = j;
                }
                temp = Array[Min];
                Array[Min] = Array[i];
                Array[i] = temp;

            }
        }
    }
}
