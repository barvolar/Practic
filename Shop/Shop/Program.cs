using System;
using System.Collections.Generic;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Vendor vendor = new Vendor();
            Buyer buyer = new Buyer();
            vendor.TempBuyer = buyer;

            bool isPlay = true;

            while (isPlay)
            {
                Console.WriteLine("1: Просмотр товара\n2: Купить товар\n3: Мои вещи\n4: Выход");

                string userInput = Console.ReadLine();

                if (ChekItem(vendor) == true)
                {

                    switch (userInput)
                    {
                        case "1":
                            vendor.ShowBag();
                            ChekItem(vendor);
                            break;
                        case "2":
                            vendor.ShowBag();
                            Console.WriteLine("Выберите товар");
                            vendor.BuyItem();
                            break;
                        case "3":
                            buyer.ShowBag();
                            break;
                        case "4":
                            isPlay = false;
                            break;
                        default:
                            Console.WriteLine("Ошибка");
                            break;
                    }
                    ShowMessage();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Товар закончился , лавочка закрыта");
                }
            }
        }

        static void ShowMessage()
        {
            Console.WriteLine("Готово для продолжения нажмите любую клавишу");
            Console.ReadKey();
        }
        
        static bool ChekItem(Vendor vendor)
        {
            bool producAvailability;
            if (vendor.ReturnBagCount() == 0)
            {
                Console.WriteLine("Товар кончился");
                producAvailability = false;
                return producAvailability;
            }
            else
            {
                producAvailability = true;
                return producAvailability;
            }
        }
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

    class Vendor
    {
        protected List<Product> _bag = new List<Product> { new Product("яблоко"), new Product("сыр"), new Product("ананас"), new Product("молоко"), };

        public int ReturnBagCount()
        {
            int count = _bag.Count;
            return count;
        }
        public Buyer TempBuyer { set; private get; }

        public void BuyItem()
        {
            string userInput = Console.ReadLine();


            if (Int32.TryParse(userInput, out int Input))
            {
                if (Input > _bag.Count||Input<=0)
                {
                    Console.WriteLine("ОЩИБКА ТОВАР НЕ НАЙДЕН");
                }
                for (int i = 0; i < _bag.Count; i++)
                {
                    if ((Input - 1) == i)
                    {
                        TempBuyer.AddItem(_bag[i]);
                        _bag.RemoveAt(i);
                    }

                }         
            }
            else
            {
                Console.WriteLine("!!!ОШИБКА!!!");
            }
        }

        public void ShowBag()
        {
            for (int i = 0; i < _bag.Count; i++)
            {
                Console.Write((i + 1) + " :");
                _bag[i].ShowInfo();
            }
        }

    }

    class Buyer
    {
        private List<Product> _bag = new List<Product>();

        public void ShowBag()
        {
            for (int i = 0; i < _bag.Count; i++)
            {
                Console.Write((i + 1) + " :");
                _bag[i].ShowInfo();
            }
        }
        public void AddItem(Product item)
        {
            _bag.Add(item);
        }

    }
}
