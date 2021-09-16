using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameUser;
            char decor;
            int longName;
            int longUpString=0;
            int longDownString = 0;

            Console.WriteLine("Введите имя");
            nameUser = Console.ReadLine();
            longName = nameUser.Length + 1;

            Console.WriteLine("Выберите символ для декора");
            decor =Convert.ToChar( Console.ReadLine());
            
            while (longUpString<=longName)
            {
                Console.Write(decor);
                longUpString++;
            }
            Console.WriteLine(("\n"+decor)+nameUser+decor);
            while (longDownString <= longName)
            {
                Console.Write(decor);
                longDownString++;
            }

        }
    }
}
