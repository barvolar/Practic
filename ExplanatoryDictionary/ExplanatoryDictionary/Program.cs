using System;
using System.Collections.Generic;

namespace ExplanatoryDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> items = new Dictionary<string, string>();

            AddItem(items, "Меч", "Оружие Ближнего боя");
            AddItem(items, "Лук", "Оружие Дальнего боя");
            AddItem(items, "Яблоко", "Еда");
            AddItem(items, "Бутылка", "Предмет для набора воды ");
            AddItem(items, "Факел", "Источник света в темноте");

            ShowMenu(items);

            ShowItemInfo(items);
          
        }

        static void ShowMenu(Dictionary<string, string> dictionary)
        {
            Console.WriteLine("У вас имеется:");

            foreach (var item in dictionary)
            {
                Console.WriteLine(item.Key);
            }

            Console.WriteLine("О чём хотите узнать больше ?\nP.S. Exit - Выход");
        }

        static void ShowItemInfo(Dictionary<string, string> dictionary)
        {
            bool isPlay = true;

            while (isPlay)
            {
                string userInput = Console.ReadLine();

                if (userInput == "Exit")
                {
                    isPlay = false;
                }

                else if (dictionary.ContainsKey(userInput))
                {
                    Console.WriteLine(dictionary[userInput]);
                }

                else
                {
                    Console.WriteLine("Такой вещи у вас нет");
                }
            }
        }

        static void AddItem(Dictionary<string, string> items, string item, string itemInfo)
        {
            if (!items.ContainsKey(item))
            {
                items.Add(item, itemInfo); 
            }
        }
    }
}
