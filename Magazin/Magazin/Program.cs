using System;

namespace Magazin
{
    class Program
    {
        static void Main(string[] args)
        {
            int crystalPrice = 5;

            Console.WriteLine("Сколько у вас золота ?");
            int myGold = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Сколько кристалов хотите купить ? Один кристал стоит "+crystalPrice+" золотых");
            int crystalCount = Convert.ToInt32(Console.ReadLine());

            int totalPrice = crystalPrice * crystalCount;
            myGold -= totalPrice;
            
            Console.WriteLine("вы купили "+crystalCount+" кристалов и у вас осталось "+myGold+" золота");
        }
    }
}
