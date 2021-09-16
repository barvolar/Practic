using System;

namespace Cikl4
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Не известно";
            string age = "Не известно";
            string password = "Не известно";
            string userInput;

            Console.WriteLine("Добро пожаловать в онлайн анкету. С чего начнём заполнение ? \n 1 = Set Name \n 2 = Set Age \n 3 = Set Password \n 4 = Check Information \n 0 = Exit");
            userInput = Console.ReadLine();
            while (userInput != "Exit")
            {
                switch (userInput)
                {
                    case "0":
                        Console.WriteLine("Finalo4ka");
                        userInput = "Exit";
                        break;
                    case "1":
                        Console.WriteLine("Введите ваше имя");
                        name = Console.ReadLine();
                        Console.WriteLine("\n 1 = Set Name \n 2 = Set Age \n 3 = Set Password \n 4 = Check Information");
                        userInput = Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine("Введите ваш возраст");
                        age = Console.ReadLine();
                        Console.WriteLine("\n 1 = Set Name \n 2 = Set Age \n 3 = Set Password \n 4 = Check Information");
                        userInput = Console.ReadLine();
                        break;
                    case "3":
                        Console.WriteLine("Придумайте пароль");
                        password = Console.ReadLine();
                        Console.WriteLine("\n 1 = Set Name \n 2 = Set Age \n 3 = Set Password \n 4 = Check Information");
                        userInput = Console.ReadLine();
                        break;
                    case "4":
                        Console.WriteLine(" Name = " + name + "\n Age = " + age + " \n Password = " + password);
                        Console.WriteLine("\n 1 = Set Name \n 2 = Set Age \n 3 = Set Password \n 4 = Check Information");
                        userInput = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Введите указанное выше число");
                        userInput = Console.ReadLine();
                        break;
                }
            }
        }
    }
}
