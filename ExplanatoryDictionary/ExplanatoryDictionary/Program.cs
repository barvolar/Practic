using System;
using System.Collections.Generic;

namespace ExplanatoryDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> items = new Dictionary<string, string>();
            bool isPlay = true;

            Additem(items);

            Console.WriteLine("У вас имеется:");

            foreach (var item in items)
            {
                Console.WriteLine(item.Key);
            }

            Console.WriteLine("О чём хотите узнать больше ?");

            while (isPlay)
            {
                string userInput = Console.ReadLine();

                if (items.ContainsKey(userInput))
                {
                    Console.WriteLine(items[userInput]);
                }
                else if (userInput == "Exit")
                {
                    isPlay = false;
                }
                else
                {
                    Console.WriteLine("Такой вещи у вас нет");
                }
            }          
        }

        static void Additem(Dictionary<string,string> items)
        {
            items.Add("Меч", "Оружие ближнего боя");
            items.Add("Лук", "Оружие дальнего боя");
            items.Add("Яблоко", "Еда");
            items.Add("Бутылка", "Ёмкость для набора воды");
            items.Add("Зажигалка", "Позволяет развести огонь");
        }
      
    }
}
