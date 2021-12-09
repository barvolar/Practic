using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Management management = new Management();
            management.CreateHumans();
            management.CreateTrain();
        }

    }

    class Management
    {
        private Random _random;
        private List<Human> _humans;
        private List<Train> _trains;

        public Management()
        {
            _random = new Random();
            _humans = new List<Human>();
            _trains = new List<Train>();
        }

        public void CreateHumans()
        {
            int maxHumanCount = _random.Next(1000);
            for (int i = 0; i < maxHumanCount; i++)
            {
                _humans.Add(new Human());
            }
        }

        public void CreateTrain()
        {
            _trains.Add(new Train(_humans));
        }
    }

    class Train 
    {
        private List<Wagon> _wagons;
        private string _name;
        private int _wagonsCount;

        public Train(List<Human> humans)
        {
            _wagons = new List<Wagon>();
            Console.WriteLine("Введите название поезда");
            _name = Console.ReadLine();

            for (int i = 0; i < humans.Count; i++)
            {
                _wagons.Add(new Wagon());
                _wagons[i].AddPassengers(humans);
            }
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
        }

        public void AddPassengers(List<Human> humans)
        {
            for (int i = 0; i < _maxPlace; i++)
            {
                _passengers.Add(humans[0]);
                humans.RemoveAt(0);
            }
        }

        private void Create()
        {
            if (Int32.TryParse(Console.ReadLine(), out int value))
            {
                if (value > 0)
                {
                    _maxPlace = value;
                }
            }
            else
            {
                Console.WriteLine("Создан вагон с 1 местом");
                _maxPlace = 1;
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
            Console.WriteLine(_name);
        }
    }
}
