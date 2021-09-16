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
            int indexUpString=0;
            int indexDownString = 0;

            Console.WriteLine("Введите имя");
            nameUser = Console.ReadLine();
            longName = nameUser.Length + 1;

            Console.WriteLine("Выберите символ для декора");
            decor =Convert.ToChar( Console.ReadLine());
            
            while (indexUpString<=longName)
            {
                Console.Write(decor);
                indexUpString++;
            }
            Console.WriteLine(("\n"+decor)+nameUser+decor);
            while (indexDownString <= longName)
            {
                Console.Write(decor);
                indexDownString++;
            }

        }
    }
}
