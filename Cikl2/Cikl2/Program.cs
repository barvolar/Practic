using System;

namespace Cikl2
{
    class Program
    {
        static void Main(string[] args)
        {
            string exitKey = "Exit";
            string myKey;
            Console.WriteLine("напишите выход");
            do
            {
                Console.WriteLine("неверное!!!");
                myKey = Console.ReadLine();               
            } 
            while (myKey!=exitKey);
        }
    }
}
