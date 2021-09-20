using System;

namespace Cikl1
{
    class Program
    {
        //Найти наибольший элемент матрицы A(10,10) и записать ноль в ту ячейку, где он находится. Вывести наибольший элемент, исходную и полученную матрицу.
        //Массив под измененную версию не нужен.
        static void Main(string[] args)
        {
            int[,] a = new int[10, 10];
            int maxNumber = Int32.MinValue;
            Random rand = new Random();

            Console.WriteLine("Начальная матрица ");

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    a[i, j] = rand.Next(10,100);
                    Console.Write(a[i, j] + " ");
                    if (maxNumber < a[i, j])
                    {
                        maxNumber = a[i, j];
                    }
                    
                }
                Console.WriteLine();
            }
            

            Console.WriteLine("\nМаксимальное числов ней = "+maxNumber+"\nНовая матрица");
            for(int i = 0; i < a.GetLength(0); i++)
            {
                for(int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] == maxNumber) a[i, j] = 0;
                    Console.Write(a[i, j]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
