using System;
using System.Collections.Generic;

namespace ShopTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Vendor vendor = new Vendor();
            Player player = new Player(100);

            vendor.ShowItems();
            vendor.BuyItem();
            player.BuyItem();
            player.ShowItems();
            Console.ReadKey();
            Console.WriteLine("sdasd");
            vendor.ShowItems();
        }
    }

    class Human
    {
        protected Product item;

        public  void ShowItems(List<Product> list)
        {
            foreach (var item in list)
            {
                item.ShowInfo();
            }
        }

    }

    class Vendor : Human
    {
        private List<Product> _bag;

        public Vendor()
        {
            _bag = new List<Product>() { new Product("Apple", 16), new Product("Water", 10), new Product("Sword", 100), new Product("SuperUberMegaSWORD", 100000) };
        }

        public void ShowItems()
        {
            ShowItems(_bag);
        }
 

        public void BuyItem()
        {
            string input = Console.ReadLine();

            if (Int32.TryParse(input, out int number))
            {
                for (int i = 0; i < _bag.Count; i++)
                {
                    if (_bag[i] == _bag[number-1])
                    {
                        item = _bag[i];
                    }
                }
            }
        }
    }

    class Player : Human
    {
        private List<Product> _bag;
        private int _money;

        public Player(int money)
        {
            _bag = new List<Product>();
            _money = money;
        }

        public void BuyItem()
        {
            _bag.Add(item);
        }

        public void ShowItems()
        {
            ShowItems(_bag);
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
            Console.WriteLine($"{_name} цена:{_price}");
        }
    }
}
