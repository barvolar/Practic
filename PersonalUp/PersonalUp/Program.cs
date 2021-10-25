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
            string name;
            string post;
            string input = " ";

            ShowMassage();

            while (input != "4")
            {
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddWorker(out name, out post, personal);
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
                        ShowMassage();
                        break;
                }
            }       
        }

        static void AddWorker(out string name, out string post, Dictionary<string, string> dictionary)
        {
            Console.WriteLine("Введите имя работника");
            name = Console.ReadLine();
            foreach (var item in dictionary)
            {
                while (item.Key == name)
                {
                    Console.WriteLine("Такие сотрудники у нас уже есть . Дайте ему другое имя, ибо нехуй");
                    name = Console.ReadLine();
                }
            }
            Console.WriteLine("Введите должность работника");
            post = Console.ReadLine();
            dictionary.Add(name, post);
            Console.WriteLine("Сотрудник успешно добавлен, нажмите любую кнопку для продолжения");
            Console.ReadKey();
            Console.Clear();
            ShowMassage();
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
            ShowMassage();
        }

        static void ShowMassage()
        {
            Console.WriteLine("1) добавить досье\n2) вывести все досье\n3) удалить досье\n4) выход");
        }
        static void ClearPersonal(Dictionary<string,string> dictionary)
        {
            dictionary.Clear();        
            Console.WriteLine("\nДосье Очищено.Для продолжения нажмите любую кнопку");
            Console.ReadKey();
            Console.Clear();
            ShowMassage();
        }
    }
}
