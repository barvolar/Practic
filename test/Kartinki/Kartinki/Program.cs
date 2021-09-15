using System;

namespace Kartinki
{
    class Program
    {
        static void Main(string[] args)
        {
            int row = 3;
            int imagesCount = 52;
            Console.WriteLine(imagesCount / row+" полностью заполненных рядов и останется " +imagesCount%row+" картинка(и)");
        }
    }
}
