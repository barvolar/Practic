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

            AddItems(items, "Меч", "Оружие Ближнего боя");
            AddItems(items, "Лук", "Оружие Дальнего боя");
            AddItems(items, "Яблоко", "Еда");
            AddItems(items, "Бутылка", "Предмет для набора воды ");
            AddItems(items, "Факел", "Источник света в темноте");

            Console.WriteLine("У вас имеется:");

            foreach (var item in items)
            {
                Console.WriteLine(item.Key);
            }

            Console.WriteLine("О чём хотите узнать больше ?\nP.S. Exit - Выход");

            while (isPlay)
            {
                string userInput = Console.ReadLine();

                if (userInput == "Exit")
                {
                    isPlay = false;
                }
                else if (items.ContainsKey(userInput))
                {
                    Console.WriteLine(items[userInput]);
                }

                else
                {
                    Console.WriteLine("Такой вещи у вас нет");
                }
            }
        }

        static void AddItems(Dictionary<string, string> items,string item, string itemInfo)
        {        
            items.Add(item, itemInfo);
        }
    }
}
