using System;

namespace Working_with_properties
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player(13, 1);

            Renderer showPlayer = new Renderer();

            showPlayer.DrowPlayer(player1.X, player1.Y);
        }
    }

    class Renderer
    {
        public void DrowPlayer(int x, int y, char player = '@')
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(player);
        }
    }

    class Player
    {
        private int _x;
        public int X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }
        public int Y { get; private set; }

        public Player(int x, int y)
        {
            _x = x;
            Y = y;
        }
    }
}
