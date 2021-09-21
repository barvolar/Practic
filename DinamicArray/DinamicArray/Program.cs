using System;

namespace DinamicArray
{
    class Program
    {
        static void Main(string[] args)
        {

            string input ;
            int sum=0;
            int userNumber;
            int[] usserArray = new int[0];
            while (true)
            {               
                input = Console.ReadLine();

                if (input != "Exit")
                {
                    userNumber =  Convert.ToInt32(input);
                    int[] tempArray = new int[usserArray.Length + 1];

                    for (int i = 0; i < usserArray.Length; i++)
                    {
                        tempArray[i] = usserArray[i];
                    }
                    tempArray[tempArray.Length - 1] = userNumber;
                    usserArray = tempArray;
                    Console.WriteLine(usserArray.Length);
                }
                else if (input == "Sum")
                {
                    for (int i = 0; i < usserArray.Length; i++)
                    {
                        sum += usserArray[i];
                    }
                    Console.WriteLine($"Сумма = { sum}") ;
                }
            }                     
        }
    }
}
