using System;
using System.IO;
using System.Collections.Generic;

namespace Map
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isPlaying = true;
            int playerPositinX;
            int playerPositionY;
            int playerDirectionX = 0;
            int playerDirectionY = 0;
            char[,] map = ReadMap("map1.txt", out playerPositinX, out playerPositionY);
            char mapElement = '.';

            Console.CursorVisible = false;

            ShowMap(map);

            Console.SetCursorPosition(2, 21);
            Console.WriteLine("A - оставить после себя $\n  S - оставить после себя %\n  W - оставить после себя .\n  D - ластик");

            while (isPlaying)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                Сontroller(key,ref playerDirectionX, ref playerDirectionY);
                SwitchElement(key,ref mapElement);
               
                if (map[playerPositinX + playerDirectionX, playerPositionY + playerDirectionY] != '#')
                {
                    Move(ref playerPositinX, ref playerPositionY, playerDirectionX, playerDirectionY, mapElement);
                }

            }
        }

        static void SwitchElement(ConsoleKeyInfo key,ref char mapElement)
        {

            switch (key.Key)
            {
                case ConsoleKey.A:
                    mapElement = '$';
                    break;
                case ConsoleKey.S:
                    mapElement = '%';
                    break;
                case ConsoleKey.D:
                    mapElement = ' ';
                    break;
                case ConsoleKey.W:
                    mapElement = '.';
                    break;
            }

        }
        static void Сontroller(ConsoleKeyInfo key,ref int directionX, ref int directionY)
        {

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    directionX = -1;
                    directionY = 0;
                    break;
                case ConsoleKey.DownArrow:
                    directionX = 1;
                    directionY = 0;
                    break;
                case ConsoleKey.LeftArrow:
                    directionX = 0;
                    directionY = -1;
                    break;
                case ConsoleKey.RightArrow:
                    directionX = 0;
                    directionY = 1;
                    break;
                default:
                    directionX = 0;
                    directionY = 0;
                    break;
            }

        }


        static void Move(ref int x, ref int y, int directionX, int directionY, char mapElement)
        {
            Console.SetCursorPosition(y, x);
            Console.Write(mapElement);

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
                for (int j = 0; j < map.GetLength(1); j++)
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
        static void ShowMap(char[,] array)
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
