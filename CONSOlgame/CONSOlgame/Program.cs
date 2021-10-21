using System;

namespace CONSOlgame
{
    class Program
    {
        static void Main(string[] args)
        {
            string number=Console.ReadLine();
            int numb;

            bool success = int.TryParse(number, out numb);
            if (success)
            {
                Console.WriteLine(number);
            }
            else
            {
                Console.WriteLine("qweq");
            }
        }
    }
}
