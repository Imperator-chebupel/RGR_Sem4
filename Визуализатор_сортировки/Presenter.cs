using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Визуализатор_сортировки
{
    public class Presenter
    {
        public ISort Algorithm;
        private Random r = new Random();

        public double[] Numbers;
        public double[] Start_work(int Lenght)
        {
            Numbers = new double[Lenght];
            for (int i = 0; i < Lenght; i++)
            {
                Numbers[i] = r.NextDouble();
            }
            return Numbers;
        }

        public string Return_String()
        {
            return (String.Join("\n", Numbers)); 
        }

        public void Sort_numbers()
        {
            for (int i = 0; i < Numbers.Length; i++)
            {
                Algorithm.Sort(Numbers);
            }
        }
    }
}
