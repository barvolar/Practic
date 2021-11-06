using System;

namespace Working_with_properties
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player(13, 1);

            Renderer playerPosition = new Renderer();

            playerPosition.DrowPlayer(player1.PositionX, player1.PositionY);
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
        private int _positionX;

        public int PositionX

        {
            get
            {
                return _positionX;
            }
            private set
            {
                _positionX = value;
            }
        }

        public int PositionY { get; private set; }

        public Player(int x, int y)
        {
            _positionX = x;
            PositionY = y;
        }
    }
}
