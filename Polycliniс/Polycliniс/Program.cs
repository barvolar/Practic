using System;

namespace Polycliniс
{
    class Program
    {
        static void Main(string[] args)
        {
            int receptionTime = 10;
            int oneHour = 60;

            Console.WriteLine("Сколько в очереди людей ?");
            int countHuman=Convert.ToInt32(Console.ReadLine());

            int totalReceptionTime = receptionTime * countHuman;
            int hourReception = totalReceptionTime / oneHour;
            int minutReception = totalReceptionTime % oneHour;

            Console.WriteLine("Вам предстоит ожидать " + hourReception + " часов и " + minutReception + " минут ");
        }
    }
}
