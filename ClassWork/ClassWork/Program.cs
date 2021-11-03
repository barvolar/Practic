using System;

namespace ClassWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Player enemyPlayer = new Player();
            enemyPlayer.ShowStats();
        }
    }

    class Player
    {
        private string _name = "Убицца328";
        private string _profession = "Пекарь";
        private int _health = 100;

        public void ShowStats()
        {
            Console.Write($" Имя - {_name}\n Профессия - {_profession}\n Жизни - {_health}");
        }
    }
}
