using System;

namespace ClassWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Player enemyPlayer = new Player();
            enemyPlayer.ShowStats();

            Player hero = new Player("Димон","Паладин",10000);
            hero.ShowStats();
        }
    }

    class Player
    {
        private string _name;
        private string _profession;
        private int _health;

        public Player(string name, string profession, int health)
        {
            _name = name;
            _profession = profession;
            _health = health;
        }

        public Player()
        {
            _name = "Новый игрок";
            _profession = "Тунеядец";
            _health = 20;
        }

        public void ShowStats()
        {
            Console.WriteLine($" Имя - {_name}\n Профессия - {_profession}\n Жизни - {_health}");
        }
    }
}
