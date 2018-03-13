using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab6
{
    public class Part7
    {

        public void MainFunction()
        {
            new Thread(Count).Start();
        }

        private void Count()
        {
            double w = 1.0;
            int x = new Random().Next(30, 210);
            int j = 1;
            int k = 1;
            while (true)
            {
                w += k * Math.Pow(Math.Sin(x), j);
                k *= 2;
                Console.Clear();
                Console.Write("W = " + w);
                Thread.Sleep(500);
                w -= k * Math.Pow(Math.Cos(x), j);
                j++;
                Console.Clear();
                Console.Write("W = " + w);
                Thread.Sleep(500);
            }
        }
    }
}
