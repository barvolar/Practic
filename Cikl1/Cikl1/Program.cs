using System;

namespace Cikl1
{
    class Program
    {
        //Найти наибольший элемент матрицы A(10,10) и записать ноль в ту ячейку, где он находится. Вывести наибольший элемент, исходную и полученную матрицу.
        //Массив под измененную версию не нужен.
        static void Main(string[] args)
        {
            int[,] matrix = new int[10, 10];
            int maxNumber = Int32.MinValue;
            Random random = new Random();

            Console.WriteLine("Начальная матрица ");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(10,100);
                    Console.Write(matrix[i, j] + " ");
                    if (maxNumber < matrix[i, j])
                    {
                        maxNumber = matrix[i, j];
                    }                   
                }
                Console.WriteLine();
            }           

            Console.WriteLine("\nМаксимальное числов ней = "+maxNumber+"\nНовая матрица");

            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == maxNumber) 
                        matrix[i, j] = 0;
                    Console.Write(matrix[i, j]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
