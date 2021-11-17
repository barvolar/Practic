using System;
using System.Collections.Generic;

namespace qqq
{
    class Program
    {
        static void Main(string[] args)
        {        
            Player player = new Player(70);
            Vendor vendor = new Vendor();
            bool isPlay = true;
            string input;

            while (isPlay && (player.ReturnMoney >= 0))
            {
                player.ShowMoney();
                ShowMenu();
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        vendor.ShowItems();
                        break;
                    case "2":
                        vendor.ShowItems();
                        Console.WriteLine("Введите номер предмета");
                        input = Console.ReadLine();
                        if ((Int32.TryParse(input, out int number)) && (number <= vendor.ReturnBagCount))
                        {
                            vendor.Buy(number, player);
                        }
                        break;
                    case "3":
                        player.ShowBag();
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


    class Vendor 
    {
        private List<Product> _vendorBag;

        public int ReturnBagCount
        {
            get
            {
                return _vendorBag.Count;
            }
        }

        public Vendor()
        {
            _vendorBag = new List<Product>() { new Product("Яблоко", 11), new Product("хлеб", 23), new Product("сыр", 46) };
        }

        public void ShowItems()
        {
            for (int i = 0; i < _vendorBag.Count; i++)
            {
                Console.Write($"{i + 1} - ");
                _vendorBag[i].ShowInfo();

            }
        }

        public void Buy(int number, Player player)
        {
            if (_vendorBag[number - 1].ReturnPrice <= player.ReturnMoney)
            {
                player.SpendMoney(_vendorBag[number - 1].ReturnPrice);
                player.AddItem(_vendorBag[number-1]);
                _vendorBag.RemoveAt(number - 1);             
            }
            else
            {
                Console.WriteLine("Ошибка");
            }
        }
    }

    class Player 
    {
        private int _money;
        private List<Product> _playerBag;

        public int ReturnMoney
        {
            get
            {
                return _money;
            }
        }

        public Player(int money)
        {
            _money = money;
            _playerBag = new List<Product>();
        }

        public void AddItem(Product item)
        {
            _playerBag.Add(item);
        }

        public void SpendMoney(int value)
        {
            _money -= value;
        }

        public void ShowMoney()
        {
            Console.WriteLine($"Мои деньги : {_money}");
        }

        public void ShowBag()
        {
            foreach (var item in _playerBag)
            {
                item.ShowInfo();
            }
        }
    }

    class Product
    {
        private string _name;
        private int _price;

        public int ReturnPrice
        {
            get
            {
                return _price;
            }
        }

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
