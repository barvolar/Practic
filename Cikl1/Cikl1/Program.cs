using System;

namespace Cikl1
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxBurningTime = 3;
            int myBurningTime=0;

            while (myBurningTime < maxBurningTime)
            {
                Console.WriteLine("Вы горите");
                myBurningTime++;
            }
        }
    }
}
