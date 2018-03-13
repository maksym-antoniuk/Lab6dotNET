using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class Part2
    {
        public static void MainFunction()
        {
            Matrix vector = new Matrix(1, 2);
            Matrix matrix = new Matrix(2, 2);
            Console.WriteLine("Ввод вектора");
            vector.Read();
            Console.WriteLine("\nВвод матрицы");
            matrix.Read();
            Matrix result = vector.Multiple(matrix);
            Console.WriteLine("Вектор");
            vector.Print();
            Console.WriteLine("\nМатрица");
            matrix.Print();
            Console.WriteLine("\nРезультат умножения матрицы на вектор");
            result.Print();
        }
    }
}
