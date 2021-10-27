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
            string userInput = " ";
            bool isPlay = true;

            ShowMeny();

            while (isPlay)
            {
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "Sum":
                        Console.Clear();
                        ShowMeny();
                        Console.WriteLine($"Сумма = {ShowSum(numbers)}");
                        break;
                    case "Exit":
                        isPlay = false;
                        break;
                    default:
                        if (Int32.TryParse(userInput, out int i))
                        {
                            numbers.Add(i);
                        }
                        else
                        {
                            Console.WriteLine("Ну разве это число ?");
                        }
                        break;
                }
            }
        }

        static int ShowSum(List<int> list)
        {
            int resul = 0;
            for (int i = 0; i < list.Count; i++)
            {
                resul += list[i];
            }
            return resul;
        }

        static void ShowMeny()
        {
            Console.WriteLine("Введите числа. Когда надоест введите Sum и получите их сумму. \nЧто бы выйти введите Exit ");
        }
    }
}
