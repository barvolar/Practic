using System;

namespace Polycliniс
{
    class Program
    {
        static void Main(string[] args)
        {
            int receptionTime = 10;

            Console.WriteLine("Сколько в очереди людей ?");
            int countHuman=Convert.ToInt32(Console.ReadLine());

            int totalReceptionTime = receptionTime * countHuman;
            int hourReception = totalReceptionTime / 60;
            int minutReception = totalReceptionTime % 60;

            Console.WriteLine("Вам предстоит ожидать " + hourReception + " часов и " + minutReception + " минут ");
        }
    }
}
