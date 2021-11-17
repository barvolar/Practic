using System;
using System.Collections.Generic;

namespace qqq
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            bool isPlay = true;
            string input;

            while (isPlay)
            {
                ShowMenu();
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        shop.ShowItems();
                        break;
                    case "2":
                        shop.ShowItems();
                        Console.WriteLine("Введите номер предмета");
                        input = Console.ReadLine();
                        if (Int32.TryParse(input, out int number))
                        {
                            shop.Buy(number);
                        }
                        break;
                    case "3":
                        shop.ShowMyBag();
                        break;
                    case "4":
                        isPlay = false;
                        break;
                    default:
                        Console.WriteLine("ОШИБКА!!!");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine($"1: Показать предметы\n2: Купить предмет\n3: Моя сумка\n4: Выход");
        }
    }

    class Shop
    {
        protected List<Product> vendorBag;
        protected List<Product> buyerBag;

        public Shop()
        {
            vendorBag = new List<Product>() { new Product("Яблоко", 11), new Product("хлеб", 23), new Product("сыр", 46) };
            buyerBag = new List<Product>();
        }

        public void Buy(int number)
        {
            buyerBag.Add(vendorBag[number - 1]);
            vendorBag.RemoveAt(number - 1);
        }

        public void ShowMyBag()
        {
            foreach (var item in buyerBag)
            {
                item.ShowInfo();
            }
        }

        public void ShowItems()
        {
            for (int i = 0; i < vendorBag.Count; i++)
            {
                Console.Write($"{i + 1} - ");
                vendorBag[i].ShowInfo();
            }
        }

    }

 

    class Product
    {
        private string _name;
        private int _price;

        public Product(string name, int price)
        {
            _name = name;
            _price = price;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{_name} цена : {_price}");
        }
    }


}
