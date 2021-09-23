using System;

namespace String
{
    class Program
    {

        static void Main(string[] args)
        {
            string[] name = new string[0];
            string[] post = new string[0];
            string addName ;
            string addPost;
            bool isRun = true;

            while (isRun)
            {
                
                Console.WriteLine("\n1 - добавить досье\n2 - показать сотрудников\n3 - удалить все досье\n4 - найти сотрудника\n5 - выход");
                string userInput = Console.ReadLine();
                Console.Clear();
             
                if (userInput == "1") 
                {
                    Console.WriteLine("\nДобавьте сотрудника, введите имя");
                    addName = Console.ReadLine();
                    AddWorker(ref name, addName);
                    Console.WriteLine("\nВведите его должность");
                    addPost = Console.ReadLine();
                    AddWorker(ref post, addPost);
                }
                if (userInput == "2")
                {
                    ShowWorker(ref name, ref post); 
                }
                if (userInput == "3")
                {
                    ClearArray(ref name);
                    ClearArray(ref post);
                }
                if (userInput == "4")
                {
                    Console.WriteLine("Введите имя сотруднка");
                    string input = Console.ReadLine();
                    FindWorker(input,ref name,ref post);

                }
                if (userInput == "5")
                {
                    Console.WriteLine("Всего доброго");
                    isRun = false;
                }
                
            }

        }
        static void ShowWorker(ref string[] arrayName,ref string[] arrayPost)
        {
            Console.WriteLine("\nСотрудники : ");

            for (int i = 0; i < arrayName.Length; i++)
            {
                Console.Write($" {i + 1}) {arrayName[i]} - {arrayPost[i]};");
            }
        }
        static void AddWorker(ref string[] array, string addName)
        {
            string[] tempArray = new string[array.Length + 1];
            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }
            tempArray[tempArray.Length - 1] = addName;
            array = tempArray;
        }
        static void ClearArray(ref string[] array)
        {
            array = new string[0];
        }
        static void FindWorker( string worker, ref string[]name,ref string[]post)
        {
            for(int i = 0; i < name.Length; i++)
            {
                if (worker == name[i])
                {
                    Console.WriteLine($" Сотрудник {worker} найден\n1 - уволить\n2 - назначить на другую должность");
                    int input = Convert.ToInt32(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                            Console.WriteLine($"{worker} уволен ");
                            name[i] = "<<Вакант>>";                            
                            break;
                        case 2:
                            Console.WriteLine($"Введите должность для сотрудника {worker}");
                            string tempVariable = Console.ReadLine();
                            post[i] = tempVariable;
                            break;
                        default:
                            Console.WriteLine("Ошибка");
                            break;
                    }
                    break;
                }
            }
            
        }
       
    }
}
