﻿using System;
using System.IO;

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
            char[,] map=ReadMap("map1.txt",out playerPositinX,out playerPositionY);
            char box = '.';

            Console.CursorVisible = false;

            ShowMap(map);

            Console.SetCursorPosition(2, 21);
            Console.WriteLine("A - оставить после себя $\n  S - оставить после себя %\n  W - оставить после себя .\n  D - ластик");

            while (isPlaying)
            {               
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            playerDirectionX = -1;
                            playerDirectionY = 0;
                            break;
                        case ConsoleKey.DownArrow:
                            playerDirectionX = 1;
                            playerDirectionY = 0;
                            break;
                        case ConsoleKey.LeftArrow:
                            playerDirectionX = 0;
                            playerDirectionY = -1;
                            break;
                        case ConsoleKey.RightArrow:
                            playerDirectionX = 0;
                            playerDirectionY = 1;
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
                        case ConsoleKey.W:
                            box = '.';
                            break;
                    }
                    if (map[playerPositinX + playerDirectionX, playerPositionY + playerDirectionY] != '#')
                    {
                        Move(ref playerPositinX, ref playerPositionY, playerDirectionX, playerDirectionY,box);
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
