using System;
using System.Collections.Generic;

namespace Train0._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Menagement menagement = new Menagement();
            menagement.ShowMenu();
        }
    }

    class Menagement
    {
        private List<Train> _trains;
        private List<Human> _humans;
        private bool _isPlay;
        private bool _isReadiness;

        public Menagement()
        {
            _trains = new List<Train>();
            _humans = new List<Human>();
            _isPlay = true;
            _isReadiness = false;
        }

        public void ShowMenu()
        {
            while (_isPlay)
            {
                Console.WriteLine("1: Создать поезд\n2: Отправить поезд\n3: Cправка\n4: Выход");

                switch (Console.ReadLine())
                {
                    case "1":
                        if (_isReadiness == true)
                        {
                            Console.WriteLine("Поезд уже создан , отправьте его");
                        }

                        else
                        {
                            _trains.Add(new Train());
                            bool isReadinessPath = false;
                            bool isReadinessPeople = false;
                            bool isReadinessTrain = false;
                            while (_isReadiness == false)
                            {
                                Console.WriteLine("1: Задать маршрут\n2: Добавить пассажиров\n3: Создать вагоны");

                                switch (Console.ReadLine())
                                {
                                    case "1":

                                        _trains[_trains.Count - 1].AddPath();
                                        isReadinessPath = true;

                                        break;
                                    case "2":
                                        CreateHumans();
                                        Console.WriteLine("Людей готовых уехать  " + _humans.Count);
                                        isReadinessPeople = true;
                                        break;
                                    case "3":
                                        if (_humans.Count > 0)
                                        {
                                            _trains[_trains.Count - 1].Create(_humans);
                                            isReadinessTrain = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("нету пассажиров");
                                        }
                                        break;
                                }

                                if (isReadinessTrain && isReadinessPeople && isReadinessPath == true)
                                {
                                    _isReadiness = true;
                                }
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                        break;
                    case "2":
                        if (_isReadiness == false)
                        {
                            Console.WriteLine("Поезд не готов");
                        }
                        else
                        {
                            _trains[_trains.Count-1].ShowInfo();
                            _isReadiness = false;
                        }
                        break;
                    case "3":
                        Console.WriteLine("С вашей станции уехало " + _trains.Count+" поездов\n Введите номер для получения информации о поезде");

                        for (int i = 0; i < _trains.Count; i++)
                        {
                            Console.WriteLine((i + 1) + ": "+_trains[i].Name);
                        }

                        if(Int32.TryParse(Console.ReadLine(),out int value) && value <=_trains.Count && value >0)
                        {
                            _trains[value - 1].ShowInfo();
                        }
                        else
                        {
                            Console.WriteLine("Ошибка");
                        }
                        break;
                    case "4":
                        _isPlay = false;
                        break;
                }
                Console.ReadKey();
                Console.Clear();
               
            }
        }

        public void CreateHumans()
        {
            Random random = new Random();
            int maxHuman = random.Next(100);
            
            for (int i = 0; i < maxHuman; i++)
            {
                _humans.Add(new Human());
            }
            
        }

    }

    class Train
    {
        private List<Wagon> _wagons;      
        private Direction _directon;

        public string Name { get; private set; }
        public Train()
        {
            _wagons = new List<Wagon>();
            Console.WriteLine("Введите название поезда");
            Name = Console.ReadLine();
            _directon = new Direction();
        }

        public void Create(List<Human> humans)
        {
            for (int i = 0; humans.Count>0; i++)
            {
                _wagons.Add(new Wagon());
                _wagons[i].AddPasengers(humans);
            }
        }

        public void AddPath()
        {
            _directon.AddPath();
        }

        public void ShowInfo()
        {
            Console.WriteLine("Поезд - "+Name);
            Console.WriteLine("Маршрут : "+ _directon.Path);
            for (int i = 0; i < _wagons.Count; i++)
            {
                Console.WriteLine("\nВагон номер "+(i+1)+"");
                _wagons[i].ShowInfo();
            }
        }
    }

    class Direction
    {
        
        private string _start;
        private string _finish;

        public string Path { get; private set; }
        public bool Readiness { get; private set; }

        public Direction()
        {
            Path = " не задано ";
            Readiness = false;
        }

        public void AddPath()
        {
            Console.WriteLine("Введите место отправления");
            _start = Console.ReadLine();
            Console.WriteLine("Введите место прибытия");
            _finish = Console.ReadLine();
            Path = _start +" - "+ _finish;
            Readiness = true;
        }

       
    }

    class Wagon
    {
        private List<Human> _passengers;
        private int _maxPlace;

        public Wagon()
        {
            _passengers = new List<Human>();
            Console.WriteLine("Введите количество мест");
            Create();
        }

        public void AddPasengers(List<Human> humans)
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

        public void ShowInfo()
        {           
            Console.WriteLine("Количество посадочных мест " + _maxPlace+"\n");
            for (int i = 0; i < _passengers.Count; i++)
            {
                Console.WriteLine($"Пассажир №{i+1} {_passengers[i].Name}");
            }
        }

        private void Create()
        {
            if(Int32.TryParse(Console.ReadLine(),out int value)&&value>0)
            {
                _maxPlace = value;
            }
            else
            {
                _maxPlace = 1;
                Console.WriteLine("Ошибка ввода создан вагон с 1 местом");
            }
        }
    }

    class Human
    {
        private Random _random;
        private List<string> _names;       
        public string Name { get; private set; }

        public Human()
        {
            _random = new Random();
            _names = new List<string>() { "Виктор", "Хасбик", "Абдурозик", "Константин", "Алексанлр", "Яна", "Ольга","Виктория", "Екатерина" };
            Name = _names[_random.Next(0, 9)];
        }
    }

        
    
}
