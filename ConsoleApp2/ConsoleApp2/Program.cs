using System;
using System.Collections.Generic;
//Готовность сделать

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Management management = new Management();
           // management.CreateHumans();
            //management.CreateTrain();
            //management.ShowInfo();
        }
    }
    class Management
    {
        private Random _random;
        private List<Human> _humans;
        private List<Train> _trains;
        private int _ticketCount;

        private bool ReadinessTrine;

        public Management()
        {
            _random = new Random();
            _humans = new List<Human>();
            _trains = new List<Train>();
        }

        public void CreateHumans()
        {
            int maxHumanCount = _random.Next(100);
            for (int i = 0; i < maxHumanCount; i++)
            {
                _humans.Add(new Human());
            }
            _ticketCount = _humans.Count;
        }

        public void CreateTrain()
        {
            _trains.Add(new Train(_humans));
            ReadinessTrine = true;
        }

        public void ShowInfo()
        {
            Console.Clear();

            Console.WriteLine("Продано билетов " + _ticketCount);
            for (int i = 0; i < _trains.Count; i++)
            {
                _trains[i].ShowInfo();
            }
        }
    }

    class Train
    {
        private List<Wagon> _wagons;
        private string _name;
        private string _path;
        private int _wagonsCount;//удалить

        public bool ReadinessPath { get; private set; }
        public bool ReadinessTrain { get; private set; }
        public bool ReadinessPeople { get; private set; }

        public Train(List<Human> humans)
        {
            ReadinessPath = false;
            ReadinessPeople = false;
            ReadinessTrain = false;
            _path = "не задано";
            _wagons = new List<Wagon>();
            Console.WriteLine("Введите название поезда");
            _name = Console.ReadLine();

            for (int i = 0; i < humans.Count; i++)
            {
                _wagons.Add(new Wagon());
                _wagons[i].AddPassengers(humans);
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine("Название поезда " + _name);
            Console.WriteLine("Маршрут: " + _path);
            for (int i = 0; i < _wagons.Count; i++)
            {
                Console.WriteLine("\nНомер вагона  " + (i + 1));
                _wagons[i].ShowInfo();
            }
        }

        public void CreatePath()
        {
            Console.WriteLine("Введите точку отправления");
            string start = Console.ReadLine();
            Console.WriteLine("Введите точку прибытия");
            string finish = Console.ReadLine();
            _path = start +" - "+ finish;
            ReadinessPath = true;
        }
    }

    class Wagon
    {
        private List<Human> _passengers;
        private int _maxPlace;

        public Wagon()
        {
            Console.WriteLine("Введите количество мест");
            Create();
            _passengers = new List<Human>();
        }

        public void AddPassengers(List<Human> humans)
        {
            
            for (int i = 0; i < _maxPlace; i++)
            {
                if (humans.Count > 0)
                {
                    _passengers.Add(humans[0]);
                    humans.RemoveAt(0);
                }
            }
        }

        private void Create()
        {
            if (Int32.TryParse(Console.ReadLine(), out int value) && value > 0)
            {
                _maxPlace = value;
            }
            else
            {
                Console.WriteLine("Создан вагон с 1 местом");
                _maxPlace = 1;
            }
        }

        public void ShowInfo()
        {
            for (int i = 0; i < _passengers.Count; i++)
            {
                Console.Write("Пассажир №" + (i + 1));
                _passengers[i].ShowName();
            }
        }
    }

    class Human
    {
        private string _name;
        private List<string> _names;
        private Random _random;

        public Human()
        {
            _names = new List<string>() { "Дима", "Гоша", "Вика", "Яна", "Витя", "Максим", "Кирилл", "Саша", "Катя", "Юля", "Миша", "Настя" };
            _random = new Random();
            _name = _names[_random.Next(12)];
        }

        public void ShowName()
        {
            Console.WriteLine(" " + _name + " ");
        }
    }
}
