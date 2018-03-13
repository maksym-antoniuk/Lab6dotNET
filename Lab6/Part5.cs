using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab6
{
    public class Part5
    {
        long counterFibonacci;
        long counterNumber = 1;
        bool isAlive = true;

        private void Fibonacci()
        {
            new Thread(() =>
            {
                
                using (var sw = new StreamWriter("D://fibonacciLab6.txt"))
                {
                    long a = 0;
                    long b = 1;
                    while (isAlive)
                    {
                        long temp = a;
                        a = b;
                        b = temp + b;
                        sw.WriteLine(b);
                        counterFibonacci++;
                        Thread.Sleep(500);
                    }
                }
            }).Start();
        }

        private void Numbers()
        {
            new Thread(() =>
            {
                using (var sw = new StreamWriter("D://numbersLab6.txt"))
                {
                    while (isAlive)
                    {
                        sw.WriteLine(counterNumber++);
                        Thread.Sleep(500);
                    }
                }
            }).Start();
        }
        public void Start()
        {
            Numbers();
            Fibonacci();
        }

        public void Stop()
        {
            Console.WriteLine("Закончить подсчеты?");
            Console.ReadKey();
            isAlive = false;
            Thread.Sleep(1000);
        }

        public void Stat()
        {
            counterNumber = 1;
            counterFibonacci = 1;
            var sr1 = new StreamReader("D://numbersLab6.txt");
            var sr2 = new StreamReader("D://fibonacciLab6.txt");
            while(!sr1.EndOfStream && !sr2.EndOfStream)
            {
                Console.WriteLine((!sr1.EndOfStream ? sr1.ReadLine() : "") + "\t" + (!sr2.EndOfStream ? sr2.ReadLine() : ""));
                if (!sr1.EndOfStream)
                    counterNumber++;
                if (!sr2.EndOfStream)
                    counterFibonacci++;
            }
            Console.WriteLine("Числа :" + counterNumber + " Фиббоначи :" + counterFibonacci);
        }
    }
}
