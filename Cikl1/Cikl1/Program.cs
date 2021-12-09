using System;
using System.Collections.Generic;

namespace Cikl1
{
    class Program
    {
       
        static void Main(string[] args)
        {
            List<int> list = new List<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}
