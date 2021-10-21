using System;

namespace TryParse
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isPlay = true;
            
            while (isPlay)
            {
                Console.WriteLine("Введите ваш новый пароль. Пароль должен состоять из цифр.");
                string password = Console.ReadLine();
                AddPassцord(password, ref isPlay);
            }
        }
        
        static void AddPassцord(string txt, ref bool isPlay)
        {
            if(int.TryParse(txt, out int resul))
            {
                Console.WriteLine($"Ваш пароль {resul}");
                isPlay = false;
            }
            else
            {
                Console.WriteLine("Ошибка!!! \nПароль должен состоять из цифр");
            }
        }
    }
}
