using System;

namespace Cikl3
{
    class Program
    {
        static void Main(string[] args)
        {
            float dolar = 22f;
            float byn = 34f;
            float rus = 1800f;
            float sum;
            string transferFrom;
            string transferIn;
            string myChoice;
            float transferIndexDolarInByn = 2.4f;
            float transferIndexDolarInRus = 72.7f;
            float transferIndexBynInRus = 0.03f;


            Console.WriteLine("Если вы хотите конвертировать валюту напишите всё что угодно ,если хотите завершить работу напишите Exit");
            myChoice = Console.ReadLine();
            while (myChoice != "Exit")
            {
                Console.WriteLine("ваши счета dolar, byn ,rus");
                Console.WriteLine("у вас осталось " + dolar + " долоров " + byn + " белоруских рублей " + rus + " российских рублей");
                Console.WriteLine("из какого счёта вы хотите конвертировать?");
                transferFrom = Console.ReadLine();
                if (transferFrom == "dolar")
                {
                    Console.WriteLine("в какой счёт вы хотите конвертировать?");
                    transferIn = Console.ReadLine();
                    if (transferIn == "byn")
                    {
                        Console.WriteLine("Укажите сумму");
                        sum = Convert.ToInt32(Console.ReadLine());
                        dolar -= sum;
                        byn += transferIndexDolarInByn * sum;
                        Console.WriteLine("у вас осталось " + dolar + " долоров " + byn + " белоруских рублей " + rus + " российских рублей");
                    }
                    else if (transferIn == "rus")
                    {
                        Console.WriteLine("Укажите сумму");
                        sum = Convert.ToInt32(Console.ReadLine());
                        dolar -= sum;
                        rus += transferIndexDolarInRus * sum;
                        Console.WriteLine("у вас осталось " + dolar + " долоров " + byn + " белоруских рублей " + rus + " российских рублей");
                    }
                    else Console.WriteLine("такой счёт не найден");
                }
                if (transferFrom == "byn")
                {
                    Console.WriteLine("в какой счёт вы хотите конвертировать?");
                    transferIn = Console.ReadLine();
                    if (transferIn == "dolar")
                    {
                        Console.WriteLine("Укажите сумму");
                        sum = Convert.ToInt32(Console.ReadLine());
                        byn -= sum;
                        dolar += transferIndexDolarInByn * sum;
                        Console.WriteLine("у вас осталось " + dolar + " долоров " + byn + " белоруских рублей " + rus + " российских рублей");
                    }
                    else if (transferIn == "rus")
                    {
                        Console.WriteLine("Укажите сумму");
                        sum = Convert.ToInt32(Console.ReadLine());
                        byn -= sum;
                        rus += transferIndexBynInRus * sum;
                        Console.WriteLine("у вас осталось " + dolar + " долоров " + byn + " белоруских рублей " + rus + " российских рублей");
                    }
                    else Console.WriteLine("такой счёт не найден");
                }
                if (transferFrom == "rus")
                {
                    Console.WriteLine("в какой счёт вы хотите конвертировать?");
                    transferIn = Console.ReadLine();
                    if (transferIn == "byn")
                    {
                        Console.WriteLine("Укажите сумму");
                        sum = Convert.ToInt32(Console.ReadLine());
                        rus -= sum;
                        byn += transferIndexBynInRus * sum;
                        Console.WriteLine("у вас осталось " + dolar + " долоров " + byn + " белоруских рублей " + rus + " российских рублей");
                    }
                    else if (transferIn == "dolar")
                    {
                        Console.WriteLine("Укажите сумму");
                        sum = Convert.ToInt32(Console.ReadLine());
                        rus -= sum;
                        dolar += transferIndexDolarInRus * sum;
                        Console.WriteLine("у вас осталось " + dolar + " долоров " + byn + " белоруских рублей " + rus + " российских рублей");
                    }
                    else Console.WriteLine("такой счёт не найден");
                }
                Console.WriteLine("Если вы хотите конвертировать валюту напишите Yes ,если хотите завершить работу напишите no");
                myChoice = Console.ReadLine();
            }

             





        }
    }
}
