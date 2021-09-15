using System;

namespace Kartinki
{
    class Program
    {
        static void Main(string[] args)
        {
            int imagesInRow = 3;
            int imagesCount = 52;
            int countFullRow = imagesCount/imagesInRow;
            int countExtraImages = imagesCount%imagesInRow; 
            
            Console.WriteLine(countFullRow+" полностью заполненных рядов и останется " +countExtraImages+" картинка(и)");
        }
    }
}
