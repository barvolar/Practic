using System;

namespace Shuffle
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];
            bool isPlay = true;

            Console.WriteLine("1 - Добавить в массив случайные значения от 0 до 99\n2 - Показать массив\n3 - Перемешать массив");

            while (isPlay)
            {
                string input = Console.ReadLine();


                switch (input)
                {
                    case "1":
                        AddValue(array, 0, 100);
                        break;
                    case "2":
                        ShowArray(array);
                        break;
                    case "3":
                        ShaffleArray(array);
                        break;
                    default:
                        isPlay = false;
                        break;
                }
                Console.WriteLine();
            }
        }

        static void AddValue(int[] array, int minValue, int maxValue)
        {
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minValue, maxValue);
            }
        }
        
        static void ShowArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }

        static void ShaffleArray(int[] array)
        {
            Random random = new Random();

            for (int i = array.Length-1; i>=1;i--)
            {
                int j = random.Next(i + 1);
                int tempVariable = array[j];
                array[j] = array[i];
                array[i] = tempVariable;

            }
        }
    }
}
