using System;
using System.Collections.Generic;

namespace Shop_01
{// Создать класс инвентарей
    class Program
    {
        static void Main(string[] args)
        {
            bool isOpen = true;
            string userInput;
            Buyer byuer = new Buyer();
            Vendor vendor = new Vendor();

            while (vendor.IsOpen() && isOpen)
            {
                ShowMenu();
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        vendor.ShowItems();
                        break;
                    case "2":
                        Console.WriteLine("Введите номер товара");
                        vendor.ShowItems();
                        userInput = Console.ReadLine();
                        byuer.AddItem(vendor)
                        break;
                    case "3":
                        byuer.ShowItems();
                        break;
                    case "4":
                        isOpen = false;
                        Console.WriteLine("Лавочка закрыта");
                        break;
                    default:
                        Console.WriteLine("ОШИБКА!!!!");
                        break;

                }
                Console.WriteLine("Готово для продолжения нажмите кнопку");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("Добро Пожаловать!!!\n1: Показать товар\n2: Купить товар\n3: Мой товар\n4: Выход");
        }
    }

    class Human
    {
        protected List<Product> Bag;

        public void ShowItems()
        {
            for (int i = 0; i < Bag.Count; i++)
            {
                Console.Write(i + 1 + "_");
                Bag[i].ShowInfo();
            }
        }
    }

    class Buyer : Human
    {
        
        public Buyer()
        {
            Bag = new List<Product>();
        }

        public void AddItem(Product item,string input)
        {
            Bag.Add(item);
            if (Int32.TryParse(input, out int number) && (number <=Bag.Count))
            {
                Bag.Add(item);
            }
        }

       
    }

    class Vendor : Human
    {
        public Vendor()
        {
            Bag = new List<Product>() { new Product("Яблоко"), new Product("Сыр"), new Product("Фанта"), new Product("Меч"), new Product("Лук"), };
        }

        public bool IsOpen()
        {
            bool isOpen;

            if (Bag.Count > 0)
            {
                isOpen = true;
                return isOpen;
            }
            else
            {
                Console.WriteLine("Товар кончился");
                isOpen = false;
                return isOpen;
            }
        }

        public Bag asdasd(int number)
        {
            for (int i = 0; i < Bag.Count; i++)
            {
                if (Bag[i] == Bag[number])
                {
                    return Bag[i];
                }
            }
        }

        public void RemoveItem(int number)
        {

            for (int i = 0; i < Bag.Count; i++)
            {

                if (number > Bag.Count || number < 0)
                {
                    i = Bag.Count;
                    Console.WriteLine("ОШИБКА!!!!!!!");
                }

                else
                {

                    if (Bag[i] == Bag[number - 1])
                    {
                        Bag.RemoveAt(i);
                    }
                }
            }
        }
    }

    class Bag
    {

    }

    class Product
    {
        private string _name;

        public Product(string name)
        {
            _name = name;
        }

        public void ShowInfo()
        {
            Console.WriteLine(_name);
        }
    }
}
