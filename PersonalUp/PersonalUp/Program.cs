using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalUp
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> personal = new Dictionary<string, string>();
            string input = " ";

            while (input != "4")
            {
                ShowMenu();
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddWorker(personal);
                        break;
                    case "2":
                        ShowWorker(personal);
                        break;
                    case "3":
                        ClearPersonal(personal);
                        break;
                    case "4":
                       break;
                    default:
                        Console.Clear();
                        //ShowMenu();
                        break;
                }
            }       
        }

        static void AddWorker( Dictionary<string, string> dictionary)
        {
            Console.WriteLine("Введите имя работника");
            string name = Console.ReadLine();

            while(dictionary.ContainsKey(name))
            {
                Console.WriteLine("Такие сотрудники у нас уже есть . Дайте ему другое имя, ибо нехуй");
                name = Console.ReadLine();
            }
           
            Console.WriteLine("Введите должность работника");
            string post = Console.ReadLine();
            dictionary.Add(name, post);
            Console.WriteLine("Сотрудник успешно добавлен, нажмите любую кнопку для продолжения");
            Console.ReadKey();
            Console.Clear();
        }

        static void ShowWorker(Dictionary<string, string> dictuionary)
        {
            Console.WriteLine("Ваши сотрудники:");

            foreach (var item in dictuionary)
            {
                Console.Write($" -{item.Key} на должности  {item.Value}");
            }
            Console.WriteLine("\nДля продолжения нажмите любую кнопку");
            Console.ReadKey();
            Console.Clear();
        }

        static void ShowMenu()
        {
            Console.WriteLine("1) добавить досье\n2) вывести все досье\n3) уволить сотрудника\n4) выход");
        }
        static void ClearPersonal(Dictionary<string,string> dictionary)
        {
            Console.WriteLine("Введите имя сотрудника которого хотите уволить");
            string name = Console.ReadLine();

            if (dictionary.ContainsKey(name))
            {
                dictionary.Remove(name);
                Console.WriteLine("\nСотрудник уволен!!");
            }
            else
            {
                Console.WriteLine("Таких у нас нет");
            }                     
            Console.ReadKey();
            Console.Clear();
        }
    }
}
