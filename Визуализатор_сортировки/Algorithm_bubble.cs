using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Визуализатор_сортировки
{
    public class Algorithm_bubble : ISort
    {

        public List<(int, int, double, double)>/*void*/ Sort(double[] Numbers)
        {
            List<(int, int, double, double)> To_Return = new List<(int, int, double, double)>();
            double temp;
            double[] Numbers_ = new double[Numbers.Length];
            for (int i = 0; i < Numbers_.Length; i++)
            {
                Numbers_[i] = Numbers[i];
            }


            for (int i = 0; i < Numbers_.Length + 1; i++)
            {
                for (int j = i + 1; j < Numbers_.Length; j++)
                {
                    if (Numbers_[i] > Numbers_[j])
                    {
                        temp = Numbers_[i];
                        Numbers_[i] = Numbers_[j];
                        Numbers_[j] = temp;
                        var To_Write = (i,j, Numbers_[i], Numbers_[j]);
                        To_Return.Add(To_Write);
                        //Task.Delay(100).GetAwaiter().GetResult();
                    }
                }
            }
            return To_Return;
        }



        //public (int, int, double, double)[] Sort(double[] Numbers)
        //{
        //    (int, int, double, double)[] To_Return = new (int, int, double, double)[0];
        //    int Index = 0;
        //    double temp;
        //    for (int i = 0; i < Numbers.Length + 1; i++)
        //    {
        //        for (int j = i + 1; j < Numbers.Length; j++)
        //        {
        //            if (Numbers[i] > Numbers[j])
        //            {
        //                temp = Numbers[i];
        //                Numbers[i] = Numbers[j];
        //                Numbers[j] = temp;
        //                Array.Resize(ref To_Return, To_Return.Length + 1);
        //                To_Return[Index] = (i, j, Numbers[i], Numbers[j]);
        //                Index++;
        //                //To_Return.Add((i, j, Array[i], Array[j]));//break;
        //            }
        //        }
        //    }
        //    return To_Return;
        //}


    }
}
