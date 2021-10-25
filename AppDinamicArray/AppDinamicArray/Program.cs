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
            string userInput=" ";
            int sum=0;

            ShowMessage();

            while (userInput != "Exit")
            {
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "Sum":
                        Console.Clear();
                        ShowMessage();
                        Console.WriteLine($"Сумма = {ShowList(numbers,sum)}");                       
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

        static int ShowList(List<int> list,int resul)
        {
            for (int i = 0; i < list.Count; i++)
            {
                resul += list[i];
            }
            return resul;
        }

        static void ShowMessage()
        {
            Console.WriteLine("Введите числа. Когда надоест введите Sum и получите их сумму. \nЧто бы выйти введите Exit ");
        }
    }
}
