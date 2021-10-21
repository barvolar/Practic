using System;
using System.IO;

namespace Map
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isPlaying = true;
            int playerX, playerY;
            int playerDX = 0, playerDY = 0;
            char[,] map=ReadMap("map1.txt",out playerX,out playerY);
            char box = '.';

            Console.CursorVisible = false;

            ShowMap(map);

            Console.SetCursorPosition(2, 21);
            Console.WriteLine("A - оставить после себя $\n  S - оставить после себя %\n  D - ластик");

            while (isPlaying)
            {               
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            playerDX = -1;
                            playerDY = 0;
                            break;
                        case ConsoleKey.DownArrow:
                            playerDX = 1;
                            playerDY = 0;
                            break;
                        case ConsoleKey.LeftArrow:
                            playerDX = 0;
                            playerDY = -1;
                            break;
                        case ConsoleKey.RightArrow:
                            playerDX = 0;
                            playerDY = 1;
                            break;
                        case ConsoleKey.A:
                            box = '$';
                            break;
                        case ConsoleKey.S:
                            box = '%';
                            break;
                        case ConsoleKey.D:
                            box = ' ';
                            break;
                    }
                    if (map[playerX + playerDX, playerY + playerDY] != '#')
                    {
                        Move(ref playerX, ref playerY, playerDX, playerDY,box);
                    }
                    
                }
            }

        }
        static void Move(ref int x,ref int y, int directionX,  int directionY,char box)
        {
            Console.SetCursorPosition(y, x);
            Console.Write(box);

            x += directionX;
            y += directionY;

            Console.SetCursorPosition(y, x);
            Console.Write("@");
        }
        static char[,] ReadMap(string nameMap, out int playerX, out int playerY)
        {
            playerX = 0;
            playerY = 0;

            string[] fileMap = File.ReadAllLines($"Maps/{nameMap}");
            char[,] map = new char[fileMap.Length, fileMap[0].Length];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j <map.GetLength(1) ; j++)
                {
                    map[i, j] = fileMap[i][j];

                    if (map[i, j] == '@')
                    {
                        playerX = i;
                        playerY = j;
                    }
                }
            }

            return map;
        }
        static void ShowMap(char[,]array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j]);
                }
                Console.WriteLine();
            }
        }
        
    }
}
