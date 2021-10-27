using System;

namespace Tärning
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Tärningsprogram\n---------------");

            Console.Write("Hur många tärningar vill du kasta? ");
            int antalTärningar = int.Parse(Console.ReadLine());

            for (var i = 0; i < antalTärningar; i++)
            {
                Console.Write($"Hur många sidor ska tärning {i+1} ha? ");
                int antalSidor = int.Parse(Console.ReadLine());

                Random generator = new Random();

                int tärning = generator.Next(1, antalSidor);
                Console.WriteLine($"Tärning {i+1} blev {tärning}");
                Console.WriteLine("-----------------");
            }
        }
    }
}
