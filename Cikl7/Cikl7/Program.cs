using System;

namespace Cikl7
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = "113";
            string userInput;
            int tryCount = 3;
            int tryInput = 0;
            Console.WriteLine("Введите пароль");
            while (tryInput != tryCount)
            {
                userInput = Console.ReadLine();
                if (userInput == password)
                {
                    Console.WriteLine("TikTok zlo");
                    break;
                }
                else
                {
                    tryInput++;
                    Console.WriteLine("Неверно , осталось "+(tryCount-tryInput)+" попыток");
                }
            }


        }
    }
}
