using System;

namespace DinamicArray
{
    class Program
    {
        static void Main(string[] args)
        {
          
            //string stro4ka;
            //bool tryy;
            //int Parse(string stro4ka);


            string[] userArray = new string[0];
            string exit = "Exit";
            string sum = "sum";
            int intSum = 0;

            while (true)
            {
                string userInput = Console.ReadLine();
                string[] tempArray = new string[userArray.Length + 1];

                for (int i = 0; i < userArray.Length; i++)
                {
                    tempArray[i] = userArray[i];
                }
                tempArray[tempArray.Length - 1] = userInput;
                userArray = tempArray;
                Console.WriteLine(userArray.Length);

                if (userInput == exit)
                {
                    break;
                }
                if (userInput == "sum")
                {
                    int[] tempIntArray = new int[userArray.Length];
                    for (int i = 0; i < userArray.Length; i++)
                    {
                        tempIntArray[i] = Int32.Parse(userArray[i]);
                    }
                    for (int i = 0; i < tempIntArray.Length; i++)
                    {
                        intSum += tempIntArray[i];
                    }
                    Console.WriteLine(intSum);
                }

            }


            //for (int i = 0; i < userArray.Length; i++)
            //{
            //   tempArray[i] = userArray[i];


            //}
            //tempArray[tempArray.Length - 1] = 3;
            //userArray = tempArray;
            //Console.WriteLine($"Длина массива {userArray.Length}");

        }
    }
}
