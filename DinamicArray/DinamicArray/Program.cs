using System;

namespace DinamicArray
{
    class Program
    {
        static void Main(string[] args)
        {

            string userInput ;
            int sum=0;
            int userNumber;
            int[] usserArray = new int[0];
            bool work = true;

            while (work)
            {               
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "Sum":
                        Console.WriteLine("Massiv");
                        for (int i = 0; i < usserArray.Length; i++)
                        {
                            Console.Write(+usserArray[i] + " ");
                            sum += usserArray[i];
                        }
                        Console.WriteLine("\nСумма массива = " + sum);
                        sum = 0;
                        break;

                    case "Exit":
                        Console.WriteLine("Завершение , нажмите что-нибудь");
                        Console.ReadKey();
                        work = false;
                        break;

                    default:
                        userNumber = Convert.ToInt32(userInput);
                        int[] tempArray = new int[usserArray.Length + 1];

                        for (int i = 0; i < usserArray.Length; i++)
                        {
                            tempArray[i] = usserArray[i];                           
                        }
                        tempArray[tempArray.Length - 1] = userNumber;
                        usserArray = tempArray;
                        break;                    
                }              
            }                     
        }
    }
}
