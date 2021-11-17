using System;

namespace Train_Plan
{
    class Program
    {
        static void Main(string[] args)
        {

            bool isPlay = true;
            bool trainReadnis = false;
            bool wagonReadnis = false;
            bool directionReadnis = false;
            Direction direction;
            Passengers passengers;
            Wagon wagon;

            while (isPlay)
            {
                direction = new Direction();
                passengers = new Passengers();
                wagon = new Wagon();
                trainReadnis = false;
                directionReadnis = false;
                wagonReadnis = false;
                while (trainReadnis == false)
                {
                    
                    direction.ShowDirection();
                    Console.WriteLine($"Количество прибывших пасажиров - {passengers.CountPassenger}");
                    ShowMenu();


                    switch (Console.ReadLine())
                    {
                        case "1":
                            direction.SetDirection();
                            directionReadnis = true;
                            break;
                        case "2":
                            Console.WriteLine("Укажите количество мест в вагоне");
                            if (Int32.TryParse(Console.ReadLine(), out int value))
                            {
                                wagon.SetPlaceCount(value);
                                wagon.SetWagonCount(passengers.CountPassenger);
                            }
                            Console.WriteLine($"Необходимое количество вагонов - {wagon.WagonCount + 1}");
                            wagonReadnis = true;
                            break;
                        case "3":

                            if (directionReadnis == false)
                            {
                                Console.WriteLine("Не найден маршрут движения");
                            }
                            else if (wagonReadnis == false)
                            {
                                Console.WriteLine("Количество вагонов не известно");
                            }
                            else 
                            {
                                Console.WriteLine($"Поезд успешно отправлен:\nКоличество вагонов {wagon.WagonCount + 1}\nМаршрут движения: {direction.Directopn} ");
                                trainReadnis = true;
                            }
                            break;
                        case "4":
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

        static void ShowMenu()
        {
            Console.WriteLine("1: Ввести маршрут движения\n2: Подобрать количество вагонов\n3: Отправить поезд\n4: Выход");
        }
    }

    class Passengers
    {
        private Random _random;

        public int CountPassenger { get; private set; }


        public Passengers()
        {
            _random = new Random();
            CountPassenger = _random.Next(5000);
        }

    }

    class Wagon
    {
        private int _maxPlace = 1;
        private Passengers _passenger;

        public int WagonCount { get; private set; }


        public Wagon()
        {
            _passenger = new Passengers();   
        }

        public void SetPlaceCount(int value)
        {
            _maxPlace = value;
        }

        public void SetWagonCount(int passengersCount)
        {
            WagonCount = passengersCount / _maxPlace;
        }

    }

    class Direction
    {
        private string _departure;
        private string _arrival;
        public string Directopn;

        public Direction()
        {
            Directopn = "не задан";
        }

        public void SetDirection()
        {
            Console.WriteLine("Введите станцию отправления");
            _departure = Console.ReadLine();
            Console.WriteLine("Введите станцию прибытия");
            _arrival = Console.ReadLine();
            Directopn = _departure + " - " + _arrival;
        }

        public void ShowDirection()
        {
            Console.WriteLine("Маршрут движения :" + Directopn);
        }
    }
}
