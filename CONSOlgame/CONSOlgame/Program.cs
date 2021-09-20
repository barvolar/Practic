using System;

namespace CONSOlgame
{
    class Program
    {
        static void Main(string[] args)
        {
            //Дан двумерный массив.
            //Вычислить сумму второй строки и произведение первого столбца. Вывести исходную матрицу и результаты вычислений.
            int[,] arrays = {{1,2,3,4,5 },{1,3,5,7,9 },{2,4,6,8,2 },{5,6,7,8,9 }};
            int sum = 0;
            int multiply = 1;

            for (int i = 0; i < arrays.GetLength(0); i++)
            {
                for (int j = 0; j < arrays.GetLength(1); j++)
                {
                    Console.Write(arrays[i, j] + " ");
                }
                Console.WriteLine();

            }

            for (int i = 0; i < arrays.GetLength(1); i++)
            {
                sum += arrays[1, i];
                Console.WriteLine();
            }

            for (int i = 0; i < arrays.GetLength(0); i++)
            {
                multiply *= arrays[i, 0];
            }

            Console.WriteLine("Сумма второй строки = " + sum);
            Console.WriteLine("Произведение первого столбца = " + multiply);
        }
    }
}
