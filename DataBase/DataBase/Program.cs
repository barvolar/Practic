using System;
using System.Collections.Generic;

namespace DataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isPlay = true;
            string inputUser;

            List<Player> players = new List<Player>();
            DataBase dataBase = new DataBase();

            while (isPlay)
            {
                Console.Clear();
                ShowMenu();

                inputUser = Console.ReadLine();

                switch (inputUser)
                {
                    case "1":
                        dataBase.ShowPlayers(players);
                        break;
                    case "2":
                        dataBase.AddPlayer(players);
                        break;
                    case "3":
                        dataBase.ShowPlayers(players);
                        dataBase.SwitchBan(players);
                        break;
                    case "4":
                        isPlay = false;
                        break;
                    default:
                        Console.WriteLine("!!!ОШИБКА!!!");
                        break;
                }

                Console.WriteLine("Готово. Для продолжения нажмите любую кнопку");
                Console.ReadKey();
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine($"1: Показать всех персонажей\n2: Добавить персонажа\n3: Забанить или разбанить персонажа\n4: Выход");
        }
    }

    class DataBase
    {
        public void ShowPlayers(List<Player> players)
        {
            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine($"Number {i + 1}");
                players[i].ShowInfo();
            }
        }

        public void AddPlayer(List<Player> players)
        {
            Console.WriteLine("Введите имя персонажа");
            players.Add(new Player(Console.ReadLine()));
        }

        public void SwitchBan(List<Player> players)
        {
            Console.WriteLine("Введите номер персонажа");
            int input = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < players.Count; i++)
            {
                if (input == i + 1)
                {
                    players[i].SwitchBan();
                }
            }
        }
    }

    class Player
    {
        private bool _isBan;
        public string Name { get; private set; }
        public int Level { get; private set; }

        private Random _random = new Random();

        public Player(string name)
        {
            Name = name;
            Level = _random.Next(81);
            _isBan = false;
        }

        public void SwitchBan()
        {
            if (_isBan == true)
            {
                _isBan = false;
            }
            else
            {
                _isBan = true;
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Name = {Name}\nLevel = {Level}\nBan = {_isBan}");
            Console.WriteLine("_______");
        }
    }
}
