using System;
using System.Collections.Generic;

namespace Train0._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Menegment menegment = new Menegment();


            menegment.ShowHumanCount();
            menegment.ShowWagonPlace();
        }
    }

    class Menegment
    {
        private List<Human> _humans;
        private Ticket _ticket;
        private Wagon _wagon;
        public Menegment()
        {
            _ticket = new Ticket(45);
            _humans = new List<Human>();
            _wagon = new Wagon();
            _wagon.SetMaxPlace(_ticket.HumanCount);
        }

        public void ShowHumanCount()
        {
            Console.WriteLine($"прибыло пассажиров -- {_ticket.HumanCount}");
        }

        public void ShowWagonPlace()
        {
            Console.WriteLine($"так как прибыло {_ticket.HumanCount} пассажиров предоставлены вагоны на {_wagon.PlaceCount} пасадочных мест");
        }

        public void FillWagons()
        {

        }
    }

    class Human
    {      
        public int Money { get; private set; }
        private Random _random;
        private Wagon _wagon;
        
        public Human(int value)
        {
            _random = new Random();
            
            Money = _random.Next(100);
        }
    }

    class Ticket
    {
        private Random _random;
        public int Price;
        public int HumanCount;


        public Ticket(int price)
        {
            _random = new Random();
            HumanCount = _random.Next(1000);
            Price = price;
        }

        

    }

    class Wagon
    {
        public int PlaceCount { get; private set; }
        private List<Human> _passengers;
        private Random _random;


        public Wagon()
        {
            _passengers = new List<Human>();
            _random = new Random();
        }

        public void SetMaxPlace(int value)
        {
            if (value < 300)
            {
                PlaceCount = 25;
            }
            else if (value >= 300 && value < 600)
            {
                PlaceCount = 40;
            }
            else if (value >= 600)
            {
                PlaceCount = 55;
            }
        }
        
        


        
    }
}
