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

            Database dataBase = new Database();

            while (isPlay)
            {
                Console.Clear();
                ShowMenu();

                inputUser = Console.ReadLine();

                switch (inputUser)
                {
                    case "1":
                        dataBase.ShowPlayers();
                        break;
                    case "2":
                        dataBase.AddPlayer();
                        break;
                    case "3":
                        dataBase.ShowPlayers();
                        dataBase.SwitchBan();
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

    class Database
    {
        private List<Player> _players;

        public Database()
        {
            _players = new List<Player>();
        }
        public void ShowPlayers()
        {

            for (int i = 0; i < _players.Count; i++)
            {
                Console.WriteLine($"Number {i + 1}");
                _players[i].ShowInfo();
            }
        }

        public void AddPlayer()
        {
            Console.WriteLine("Введите имя персонажа");
            _players.Add(new Player(Console.ReadLine()));
        }

        public void SwitchBan()
        {
            Console.WriteLine("Введите номер персонажа");
            int input = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < _players.Count; i++)
            {
                if (input == i + 1)
                {
                    Console.WriteLine("1: Забанить\n2: Разбанить");
                    input = Convert.ToInt32(Console.ReadLine());
                    if (input == 1)
                    {
                        _players[i].Ban();
                    }
                    else if (input == 2)
                    {
                        _players[i].Unban();
                    }
                    else
                    {
                        Console.WriteLine("Ошибка");
                    }

                }
            }
        }
    }

    class Player
    {
        private bool _isBanned;
        public string Name { get; private set; }
        public int Level { get; private set; }

        private Random _random = new Random();

        public Player(string name)
        {
            Name = name;
            Level = _random.Next(81);
            _isBanned = false;
        }

        public void Ban()
        {
            if (_isBanned == true)
            {
                Console.WriteLine("Персонаж уже забанен");
            }
            else
            {
                _isBanned = true;
            }
        }

        public void Unban()
        {
            if (_isBanned == true)
            {
                _isBanned = false;
            }
            else
            {
                Console.WriteLine("Персанаж не забанен");
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Name = {Name}\nLevel = {Level}\nBan = {_isBanned}");
            Console.WriteLine("_______");
        }
    }
}
