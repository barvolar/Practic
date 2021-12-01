using System;
using System.Collections.Generic;

namespace Kartinki
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isPlay = true;
            Menagment menagment = new Menagment();
            Direction direction = new Direction();

            while (isPlay)
            {
                direction.ShowPath();
                menagment.ShowMenu();
                switch (Console.ReadLine())
                {
                    case "1":
                        direction.CreatePath();
                        break;
                    case "2":
                        menagment.CreateHumans();
                        break;
                    case "3":
                        menagment.CreateTrine();
                        break;
                    case "4":
                        if (direction.ReadinessPath == false)
                        {
                            Console.WriteLine("Ошибка не задан маршрут");
                        }
                        else if (menagment.ReadinessHuman == false)
                        {
                            Console.WriteLine("Ошибка в поезде нету пассажиров");
                        }
                        else if (menagment.ReadinessTrine == false)
                        {
                            Console.WriteLine("Ошибка поезд не готов");
                        }
                        else
                        {
                            menagment.SendTrine();
                            menagment = new Menagment();
                            direction = new Direction();
                        }
                        break;
                    case "5":
                        Console.WriteLine("ВЫХОД!!!!!");
                        isPlay = false;
                        break;
                    default:

                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Menagment
    {
        private List<Human> _humans;
        private Random _random;
        private List<Wagon> _trine;

        public bool ReadinessTrine { get; private set; }
        public bool ReadinessHuman { get; private set; }

        public Menagment()
        {
            _random = new Random();
            _humans = new List<Human>();
            _trine = new List<Wagon>();
            ReadinessHuman = false;
            ReadinessTrine = false;
        }

        public void CreateHumans()
        {
            int maxPeopleCount = _random.Next(100);

            for (int i = 0; i < maxPeopleCount; i++)
            {
                _humans.Add(new Human());
            }

            ReadinessHuman = true;
            Console.WriteLine("Билетов продано " + maxPeopleCount);
        }

        public void CreateTrine()
        {
            for (int i = 0; i < _humans.Count; i++)
            {
                _trine.Add(new Wagon());
                _trine[i].AddPassengers(_humans);
            }
            ReadinessTrine = true;
        }

        public void SendTrine()
        {
            Console.WriteLine($"Убыл поезд : Количество вагонов = {_trine.Count}");
            for (int i = 0; i < _trine.Count; i++)
            {
                Console.WriteLine($"\nВагон номер : {i + 1}");
                _trine[i].ShowInfo();
            }
        }

        public void ShowMenu()
        {
            Console.WriteLine($"Ожидающих убытия пассажиров - {_humans.Count}");
            Console.WriteLine("\n1: Задать направление\n2: Создать пассажиров\n3: Создать поезд\n4: Отправить поезд\n5: Выход");
        }
    }

    class Direction
    {
        private string _start;
        private string _finish;
        private string _path;

        public bool ReadinessPath { get; private set; }

        public Direction()
        {
            _path = "направлене не задано";
            ReadinessPath = false;
        }

        public void CreatePath()
        {
            Console.WriteLine("Введите место отправления");
            _start = Console.ReadLine();
            Console.WriteLine("Введите место прибытия");
            _finish = Console.ReadLine();
            _path = _start + " - " + _finish;
            ReadinessPath = true;
        }

        public void ShowPath()
        {
            Console.WriteLine(_path);
        }
    }

    class Wagon
    {
        private int _maxPlace;

        private List<Human> _passengers;

        public Wagon()
        {
            Console.WriteLine("Создание вагона , укажите максимальное количество мест");
            string input = Console.ReadLine();

            if (Int32.TryParse(input, out int value) && value > 0)
            {
                _maxPlace = value;

            }
            else
            {
                Console.WriteLine("Ошибка ввода создан вагон с 1 местом");
                _maxPlace = 1;

            }

            _passengers = new List<Human>();
        }

        public void AddPassengers(List<Human> list)
        {
            for (int i = 0; i < _maxPlace; i++)
            {
                if (list.Count > 0)
                {
                    _passengers.Add(list[0]);
                    list.RemoveAt(0);
                }
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Количество мест в вагоне ---- {_maxPlace}");

            for (int i = 0; i < _passengers.Count; i++)
            {
                Console.WriteLine("пассажир № " + (i + 1) + ". Имя " + _passengers[i].Name);
            }
        }
    }


    class Human
    {
        private Random _random;
        public string Name { get; private set; }

        public Human()
        {
            _random = new Random();
            CreateName();
        }

        private void CreateName()
        {
            int number = _random.Next(0, 11);

            switch (number)
            {
                case 0:
                    Name = "Дима";
                    break;
                case 1:
                    Name = "Гоша";
                    break;
                case 3:
                    Name = "Катя";
                    break;
                case 4:
                    Name = "Саша";
                    break;
                case 5:
                    Name = "Яна";
                    break;
                case 6:
                    Name = "Вова";
                    break;
                case 7:
                    Name = "Женя";
                    break;
                case 8:
                    Name = "Вика";
                    break;
                case 9:
                    Name = "Хасбик";
                    break;
                case 10:
                    Name = "Абдуросик";
                    break;
                default:
                    Name = "Пикачу";
                    break;
            }
        }
    }
}
