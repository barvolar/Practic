using System;

namespace String
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Как вас зовут ?");
            string name = Console.ReadLine();

            Console.WriteLine("Сколько вам лет ?");
            string age = Console.ReadLine();

            Console.WriteLine("Кем вы работаете ?");
            string profession = Console.ReadLine();

            Console.WriteLine("Где вы живёте ?");
            string placeLive = Console.ReadLine();

            Console.WriteLine("Кто вы по знаку задиака?");
            string zodiak = Console.ReadLine();

            Console.WriteLine("Вас зовут "+name+". Вам "+age+" лет, по знаку задиака вы "+zodiak+", живёте в "+placeLive+" и профессия ваша "+profession);
        }
    }
}
