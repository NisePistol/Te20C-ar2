using System;

namespace Lyckohjul
{
    class Program
    {
        static void Main(string[] args)
        {
            int försök = 3;

            while (försök > 0)
            {
                Console.Clear();
                Console.WriteLine("Lyckohjul");
                Console.Write("Välj ett tal mellan 1-10: ");
                int anvTal = int.Parse(Console.ReadLine());

                Random generator = new Random();

                int slumpTal = generator.Next(1, 11);

                Console.WriteLine($"Lyckohjulet landade på {slumpTal}");

                if (anvTal == slumpTal)
                {
                    Console.WriteLine("Du vann!");
                    break;
                }
                else
                {
                    Console.WriteLine("Du vann inte!");
                    Console.WriteLine("Klicka varsomhelst för att fortsätta programmet");
                    försök--;
                    Console.ReadKey();
                }
            }
        }
    }
}
