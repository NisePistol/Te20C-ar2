using System;

namespace Slumptal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Slumptal");

            //Slumpgenerator
            Random numGen = new Random();

            //Slumpa fram ett tal 1-10
            int slumpTal = numGen.Next(1, 11);
            int slumpTal2 = numGen.Next(1, 7);
        }
    }
}
