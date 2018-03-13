using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab6
{
    public class Matrix
    {
        double[,] matrix;
        private static object _syncRoot = new object();

        public int Row { get; protected set; }
        public int Column { get; protected set; }

        public Matrix(int row, int column)
        {
            Row = row;
            Column = column;
            matrix = new double[row, column];
        }

        public Matrix Multiple(Matrix value)
        {
            List<Thread> list = new List<Thread>();
            Matrix result = new Matrix(Row, value.Column);
            for (int i = 0; i < Row; i++)
                for (int j = 0; j < value.Column; j++)
                {
                    Thread t = new Thread(new ParameterizedThreadStart(Func));
                    list.Add(t);
                    t.Start(new Part2Param(result, value, matrix, i, j));
                }
            foreach(Thread t in list)
            {
                t.Join();
            }
            return result;
        }

        public static void Func(object obj)
        {
            Part2Param p = (Part2Param)obj;
            for (int k = 0; k < p.value.Row; k++)
            {
                lock (_syncRoot)
                {
                    p.result.matrix[p.i, p.j] += p.matrix[p.i, k] * p.value.matrix[k, p.j];
                }
            }
        }

        public void Read()
        {
            for (int i = 0; i < Row; i++)
                for (int j = 0; j < Column; j++)
                {
                    Console.Write("Введите элемент [{0},{1}]: ", i + 1, j + 1);
                    matrix[i, j] = System.Convert.ToDouble(Console.ReadLine());
                }
        }

        public void Print()
        {
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                    Console.Write("{0:f2} ", matrix[i, j]);
                Console.WriteLine();
            }
        }
    }

    public class Part2Param
    {
        public Matrix result;
        public Matrix value;
        public double[,] matrix;
        public int i;
        public int j;

        public Part2Param(Matrix result, Matrix value, double[,] matrix, int i, int j)
        {
            this.result = result;
            this.value = value;
            this.matrix = matrix;
            this.i = i;
            this.j = j;
        }
    }
}
