using System;
using System.Collections.Generic;

namespace Kartinki
{
    class Program
    {
        static void Main(string[] args)
        {

            bool isPlay = true;
            Management management = new Management();
            Direction direction = new Direction();

            while (isPlay)
            {
                //direction.ShowPath();
                management.ShowMenu();
                switch (Console.ReadLine())
                {
                    case "1":
                        direction.CreatePath();
                        break;
                    case "2":
                        management.CreateHumans();
                        break;
                    case "3":
                        management.CreateTrain();
                        break;
                    case "4":
                        if (direction.ReadinessPath == false)
                        {
                            Console.WriteLine("Ошибка не задан маршрут");
                        }
                        else if (management.ReadinessHuman == false)
                        {
                            Console.WriteLine("Ошибка в поезде нету пассажиров");
                        }
                        else if (management.ReadinessTrine == false)
                        {
                            Console.WriteLine("Ошибка поезд не готов");
                        }
                        else
                        {
                            management.SendTrain();
                            management = new Management();
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

    class Management
    {
        private List<Human> _humans;
        private Random _random;
        private List<Train> _trains;
        private Train train;
        private string _path;

        public bool ReadinessTrine { get; private set; }
        public bool ReadinessHuman { get; private set; }


        public Management()
        {
            _random = new Random();
            _humans = new List<Human>();
            _trains = new List<Train>();
            ReadinessHuman = false;
            ReadinessTrine = false;
            train = new Train();
            _path = "не задано";
        }


        public void CreateTrain()
        {
            _trains.Add(new Train());
            _trains[_trains.Count].Create(_humans);
        }

        public void SendTrain()
        {
            train.Send();

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

        //public void CreateTrain()
        //{
        //    for (int i = 0; i < _humans.Count; i++)
        //    {
        //        _train.Add(new Wagon());
        //        _train[i].AddPassengers(_humans);
        //    }
        //    ReadinessTrine = true;
        //}

        //public void SendTrine()
        //{
        //    Console.WriteLine($"Убыл поезд : Количество вагонов = {_train.Count}");
        //    for (int i = 0; i < _train.Count; i++)
        //    {
        //        Console.WriteLine($"\nВагон номер : {i + 1}");
        //        _train[i].ShowInfo();
        //    }
        //}

        public void ShowMenu()
        {
            Console.WriteLine($"Маршрут движения {_path}\nОжидающих убытия пассажиров - {_humans.Count}");
            Console.WriteLine("\n1: Задать направление\n2: Создать пассажиров\n3: Создать поезд\n4: Отправить поезд\n5: Выход");
        }
    }

    //Создайте класс поезда, который содержит всю информацию, о пути, вагонах, пассажирах.
    //    А в управлении есть список всех поездов.И тогда после отправки поезда, создается этот поезд и добавляется в список.
    class Train
    {
        private string _direction;
        private string _name;
        private List<Wagon> _wagons;

        public bool Readiness;
        public bool ReadinessPath;
        public Train()
        {
            _wagons = new List<Wagon>();
            Console.WriteLine("Введите название поезда");
            _name = Console.ReadLine();
            Readiness = false;
            ReadinessPath = false;
        }

        public void AddDirection(string path)
        {
            Console.WriteLine("Введите место отправления");
            string start = Console.ReadLine();
            Console.WriteLine("Введите место прибытия");
            string finish = Console.ReadLine();
            path = start + finish;
            _direction = path;
        }

        public void Create(List<Human> humans)
        {

            for (int i = 0; i <= humans.Count; i++)
            {
                _wagons.Add(new Wagon());
                _wagons[i].AddPassengers(humans);
            }
            Readiness = true;
        }

        public void Send()
        {

            Console.WriteLine($"Убыл поезд {_name}: Количество вагонов = {_wagons.Count}");
            for (int i = 0; i < _wagons.Count; i++)
            {
                Console.WriteLine($"\nВагон номер : {i + 1}");
                _wagons[i].ShowInfo();
            }


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
