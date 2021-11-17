using System;
using System.Collections.Generic;

namespace Shoper
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isPlay = true;
            string userInput;
            Bag bag = new Bag();
            Vendor vendor = new Vendor();
            Byuer byuer = new Byuer(3000);

            while (isPlay)
            {
                byuer.ShowMoney();
                vendor.ShowItemsVendor();
                ShowMenu();

                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        //byuer.Tester();
                        Console.WriteLine("Введите номер предмета");
                        userInput = Console.ReadLine();
                        if (Int32.TryParse(userInput, out int value))
                        {
                            bag.BuyItems(value);
                        }
                        else
                        {
                            Console.WriteLine("Ошибка");
                        }

                        break;
                    case "2":
                        Console.Clear();
                        byuer.ShowItemsByuer();
                        break;
                    case "3":
                        break;
                    default:
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("1: Купить предмет\n2: Моя сумка\n3: Выход");
        }
    }

    class Bag
    {
        protected int moneyVendor;
        protected int moneyByuer;
        protected List<Product> bagVendor;
        protected List<Product> bagBuyer;

        public Bag()
        {
            //bagBuyer = new List<Product>() ;
           // bagVendor = new List<Product>() { new Product("Apple", 13), new Product("Sword", 1000), new Product("Bow", 520), new Product("Water", 20), new Product("Torch", 75) };
        }

        public void Test()
        {
            moneyByuer -= 19;
        }

        protected void showItems(List<Product> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"{i+1} - ");
                list[i].ShowInfo();
            }
        }

        public void BuyItems(int number)
        {
            for (int i = 0; i < bagVendor.Count; i++)
            {
                if (moneyByuer >= bagVendor[i].ReturnPrice() && bagVendor[i ] == bagVendor[number])
                {
                    bagBuyer.Add(bagVendor[i]);
                    bagVendor.RemoveAt(i);
                    moneyByuer -= bagVendor[i].ReturnPrice();
                    moneyVendor += bagVendor[i].ReturnPrice();
                }
                Console.WriteLine("Покупка завершена");
            }
           
        }
    }

    class Vendor : Bag
    {
               
        public Vendor()
        {
            moneyVendor = 10000;
            bagVendor = new List<Product> { new Product("Apple",13), new Product("Sword", 1000), new Product("Bow", 520), new Product("Water", 20), new Product("Torch", 75) };           
        }

        public void ShowItemsVendor()
        {
            showItems(bagVendor);
        }

       
    }

    class Byuer : Bag
    {
        public Byuer(int value)
        {
            moneyByuer = value;
            bagBuyer = new List<Product>();
        }

        public void ShowItemsByuer()
        {
            showItems(bagBuyer);
        }

        public void ShowMoney()
        {
            Console.WriteLine($"Мои деньги: {moneyByuer}");
        }

        public void Tester()
        {
            
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

        public string ReturnName() //Удалить
        {
            return _name;
        }

        public int ReturnPrice()
        {
            return _price;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Название: {_name}\nЦена: {_price}");
        }
    }
}
