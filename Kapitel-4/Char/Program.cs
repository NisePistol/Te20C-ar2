using System;

namespace Char
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            string meddelande = "Hej på dig!";

            //Skriv ut hela strängen
            Console.WriteLine(meddelande);

            //Skriv ut första bokstaven 'H'
            Console.WriteLine(meddelande[0]);

            //Skriv ut sista tecknet '!'
            Console.WriteLine(meddelande[meddelande.Length-1]);

            char bokstav = 'z';

            //Skriv ut alla tecken
            for (int i = 0; i < meddelande.Length; i++)
            {
                Console.WriteLine($"index {i} {meddelande[i]}");
            }
        }
    }
}
