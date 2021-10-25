using System;
using System.Collections.Generic;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int myBalance = 0;
            int valueShopper = random.Next(15);
            Queue<int> shopper = new Queue<int>();

            AddShoppers(valueShopper, shopper);

            while (shopper.Count > 0)
            {
                Console.WriteLine($"В очереди {shopper.Count} клиентов, ваш баланс = {myBalance}");

                myBalance += shopper.Dequeue();

                Console.ReadKey();
                Console.Clear();
            }

            if (shopper.Count == 0)
            {
                Console.WriteLine("Ваш рабочий день окончен , вы заработали " + myBalance);
                Console.ReadKey();
            }
        }

        static void AddShoppers(int value, Queue<int> queue)
        {
            Random random = new Random();

            for (int i = 0; i < value; i++)
            {
                queue.Enqueue(random.Next(200));
            }
        }
    }
}
