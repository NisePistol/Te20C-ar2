using System;

namespace Uppgift4._6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.Write("Skriv ett meddelande: ");
            string meddelande = Console.ReadLine();
            
            //Skriv ut vertikalt
            for (int i = 0; i < meddelande.Length; i++)
            {
                Console.WriteLine(meddelande[i]);
            }

            Console.WriteLine("------------------");

            //Skriv ut baklänges
            for (int i = meddelande.Length-1; i >= 0; i--)
            {
                Console.WriteLine(meddelande[i]);
            }
        }
    }
}
