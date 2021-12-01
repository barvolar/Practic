using System;
using System.Collections.Generic;

namespace Train_Plan
{
    class Program
    {
        static void Main(string[] args)
        {
            Ticket ticket = new Ticket();
            Managment managment = new Managment();
            Path path = new Path();
            bool isPlay = true;

           
                

                
                while (isPlay)
                {
                    path.ShowDirection();
                    Console.WriteLine("готовность маршрута"+path.Readiness+"  готовность поезда "+managment._readinessTrine+" люди  "+ticket.HumanCount);

                    managment.ShowMenu();
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            managment.SetDirection();
                            break;
                        case "2":
                            Console.WriteLine($"Продано {ticket.HumanCount} билетов");
                            break;
                        case "3":
                            managment.CreateTrine();
                            break;
                        case "4":
                            if (managment._readinessTrine == true && path.Readiness == true)
                            {
                                managment.SendTrine();
                            }
                            else
                            {
                                Console.WriteLine("Ошибка");
                            }
                            break;
                        case "5":
                            isPlay = false;
                            break;

                        default:
                            Console.WriteLine("Ошибка");
                            break;
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
                
            
            
            
            
        }

      
    }



    

    class Managment
    {
        private Ticket _ticket;
        private Wagon _wagon;
        private Path _path;
        public bool _readinessTrine;
        private List<Wagon> _trine;

        public Managment()
        {
            _ticket = new Ticket();
            _wagon = new Wagon(_ticket.HumanCount);
            _readinessTrine = false;
            _path = new Path();
        }

        public void ShowMenu()
        {
            Console.WriteLine("1:Создать направление\n2:Продать билеты\n3:Сформировать поезд\n4:Отправить поезд\n5:Выход");
           
           
        }

        public void SetDirection()
        {
            _path.SetDirection();
        }

        public void ShowHumamCount()
        {
            Console.WriteLine($"Сегодня к нам прибыло {_ticket.HumanCount} человек(а).");
        }

        public void ShowPlaceCount()
        {
            Console.WriteLine($"Так как к нам прибыло {_ticket.HumanCount} человек, количество посадочных мест в вагоне равно {_wagon.PlaceCount}");
        }
        public void CreateTrine()
        {
            int wagonCount = _ticket.HumanCount / _wagon.PlaceCount;
            _trine = new List<Wagon>(wagonCount);
            for (int i = 0; i < _trine.Count; i++)
            {
                _trine.Add(new Wagon());
            }
            _readinessTrine = true;
            Console.WriteLine($"Поезд успешно создан, количество вагонов{_trine.Count}");
        }

        public void SendTrine()
        {
            //if (_readinessTrine == true && _path.Readiness == true)
            //{
                Console.Write($"поезд убыл:\nКоличество вагонов: {_wagon.PlaceCount}" +
                              $"\nКоличество уехавших: {_ticket.HumanCount}" +
                              $"\n Состав поезда: {_trine.Count} вагонов вместимостью {_wagon.PlaceCount}");
                Console.Write("Маршрут движения: ");
                _path.ShowDirection();
            //}
            //else
            //{
            //    Console.Write("Поезд не готов");
            //}
        }
    }
    class Path
    {
        private string _start;
        private string _finish;
        public bool Readiness { get; private set; }

        public Path()
        {
            Readiness = false;
        }

        public void SetDirection()
        {
            Console.WriteLine("Откуда?");
            _start = Console.ReadLine();
            Console.WriteLine("Куда?");
            _finish = Console.ReadLine();
            Readiness = true;
        }

        public void ShowDirection()
        {
            Console.WriteLine($"маршрут движения : {_start} - {_finish}");
        }
    }

    class Ticket
    {
        private Random random;
        public int HumanCount { get; private set; }

        public Ticket()
        {
            random = new Random();
            HumanCount = random.Next(1000);
        }

        
    }

    class Wagon
    {        
        public int PlaceCount { get; private set; }
        public Wagon(int value)
        {
            if(value<=300)
            {
                PlaceCount = 15;
            }
            if (value > 300 && value <= 600)
            {
                PlaceCount = 30;
            }
            if (value > 600)
            {
                PlaceCount = 45;
            }
        }

        public Wagon()
        {
         
        }
       
    }
}
