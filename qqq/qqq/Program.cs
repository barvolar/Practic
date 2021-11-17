using System;
using System.Collections.Generic;

namespace qqq
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            Player player = new Player(70);
            bool isPlay = true;
            string input;

            while (isPlay && (player.ReturnMoney() >= 0))
            {
                player.ShowMoney();
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
                        if ((Int32.TryParse(input, out int number)) && number <= shop.ReturnBagCount()) 
                        {
                            shop.Buy(number, player);
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

    class Player
    {
        private int _money;

        public Player(int money)
        {
            _money = money;
        }

        public int ReturnMoney()
        {
            return _money;
        }

        public void SpendMoney(int value)
        {
            _money -= value;
        }

        public void ShowMoney()
        {
            Console.WriteLine($"Мои деньги : {_money}");
        }
    }

    class Shop
    {
        private List<Product> _vendorBag;
        private List<Product> _playerBag;

        public Shop()
        {
            _vendorBag = new List<Product>() { new Product("Яблоко", 11), new Product("хлеб", 23), new Product("сыр", 46) };
            _playerBag = new List<Product>();
        }

        public void Buy(int number, Player player)
        {
            if (_vendorBag[number - 1].ReturnPrice() <= player.ReturnMoney())
            {
                _playerBag.Add(_vendorBag[number - 1]);
                _vendorBag.RemoveAt(number - 1);
                player.SpendMoney(_vendorBag[number - 1].ReturnPrice());
            }
            else
            {
                Console.WriteLine("Ошибка");
            }
        }

        public void ShowMyBag()
        {
            foreach (var item in _playerBag)
            {
                item.ShowInfo();
            }
        }

        public void ShowItems()
        {
            for (int i = 0; i < _vendorBag.Count; i++)
            {
                Console.Write($"{i + 1} - ");
                _vendorBag[i].ShowInfo();

            }
        }

        public int ReturnBagCount()
        {
            return _vendorBag.Count;
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

        public int ReturnPrice()
        {
            return _price;
        }
    }


}
