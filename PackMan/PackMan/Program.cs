using System;
using System.IO;

namespace PackMan
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isPlaing = true;
            int packmanX, packmanY;
            int packmanDX = 0, packmanDY = 0;
            char[,] map = ReadMap("map1", out packmanX, out packmanY);

            Console.CursorVisible=false;

            DrowMap(map);

            while (isPlaing)
            {

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            packmanDX = -1;
                            packmanDY = 0;
                            break;
                        case ConsoleKey.DownArrow:
                            packmanDX = 1;
                            packmanDY = 0;
                            break;
                        case ConsoleKey.LeftArrow:
                            packmanDX = 0;
                            packmanDY = -1;
                            break;
                        case ConsoleKey.RightArrow:
                            packmanDX = 0;
                            packmanDY = 1;
                            break;
                    }
                    
                }
                if (map[packmanX + packmanDX, packmanY + packmanDY] != '#')
                {
                    Console.SetCursorPosition(packmanY, packmanX);
                    Console.Write(" ");

                    packmanY += packmanDY;
                    packmanX += packmanDX;

                    Console.SetCursorPosition(packmanY, packmanX);
                    Console.Write("G");
                }
            }
        }
        static void DrowMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        static char[,] ReadMap(string mapName, out int packmanX, out int packmanY)
        {
            packmanX = 0;
            packmanY = 0;
            string[] newFile = File.ReadAllLines($"maps/{mapName}.txt");
            char[,] map = new char[newFile.Length, newFile[0].Length];
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = newFile[i][j];
                    if (map[i, j] == '&')
                    {
                        packmanX = i;
                        packmanY = j;
                    }
                }
            }
            return map;
        }
    }
}
