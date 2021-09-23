using System;

namespace CONSOlga
{
    class Program
    {
        static void Main(string[] args)
        {
            int myHealth=40;
            int maxHealth=100;
            ShowHealthBar(myHealth, maxHealth, ConsoleColor.Green);
        }

        static void ShowHealthBar(int value, int maxValue, ConsoleColor color)
        {
            string bar = "";
            ConsoleColor defoultColor = Console.BackgroundColor;

            Console.SetCursorPosition(2, 10);            
            Console.Write("HP\n|");
            Console.BackgroundColor = color;

            for (int i = 0; i < value; i++)
            {
                bar += " ";
            }
           
            Console.Write(bar);

            bar = "";

            Console.BackgroundColor = ConsoleColor.White;

            for (int i = value; i < maxValue; i++)
            {
                bar += " ";
            }

            Console.Write(bar);
            Console.BackgroundColor = defoultColor;
            Console.Write("|");
        }
    }
}
