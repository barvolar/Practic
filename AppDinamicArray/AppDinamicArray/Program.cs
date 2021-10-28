using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDinamicArray
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            string userInput;
            bool isPlay = true;

            ShowMenu();

            while (isPlay)
            {
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "Sum":
                        Console.Clear();
                        ShowMenu();
                        Console.WriteLine($"Сумма = {ReturnSum(numbers)}");
                        break;
                    case "Exit":
                        isPlay = false;
                        break;
                    default:
                        if (Int32.TryParse(userInput, out int InputNumber))
                        {
                            numbers.Add(InputNumber);
                        }
                        else
                        {
                            Console.WriteLine("Ну разве это число ?");
                        }
                        break;
                }

            }
        }

        static int ReturnSum(List<int> list)
        {
            int sum = 0;

            for (int i = 0; i < list.Count; i++)
            {
                sum += list[i];
            }
            return sum;
        }

        static void ShowMenu()
        {
            Console.WriteLine("Введите числа. Когда надоест введите Sum и получите их сумму. \nЧто бы выйти введите Exit ");
        }
    }
}
