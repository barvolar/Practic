using System;
using System.Collections.Generic;

namespace DataBase
{
    class Program
    {
        static void ShowMenu()
        {
            Console.WriteLine($"1: Показать всех персонажей\n2: Добавить персонажа\n3: Забанить или разбанить персонажа\n4: Выход");
        }

        static void ShowPlayers(List<Player> players)
        {
            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine($"Number {i + 1}");
                players[i].ShowInfo();
            }
        }

        static void AddPlayer(List<Player> players)
        {
            Console.WriteLine("Введите имя персонажа");
            players.Add(new Player(Console.ReadLine()));
        }

        static void SwitchBan(List<Player> players)
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
        static void Main(string[] args)
        {
            bool isPlay = true;
            string inputUser;

            List<Player> players = new List<Player>();

            while (isPlay)
            {
                Console.Clear();
                ShowMenu();

                inputUser = Console.ReadLine();

                switch (inputUser)
                {
                    case "1":
                        ShowPlayers(players);
                        break;
                    case "2":
                        AddPlayer(players);
                        break;
                    case "3":
                        ShowPlayers(players);
                        SwitchBan(players);
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
    }

    class Player
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Number { get; private set; }
        private bool _isBan;

        Random random = new Random();

        public Player(string name)
        {
            Name = name;
            Level = random.Next(81);
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
