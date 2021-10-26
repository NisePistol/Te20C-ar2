using System;

namespace Labb1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            // Presentera programmet
            Console.WriteLine("Program för Ceasar-kryptering");

            // Be användaren mata in ett ord
            Console.Write("Ange ett ord: ");
            string ord = Console.ReadLine().ToUpper();

            Console.Write("Ange en nyckel (1-9): ");
            int nyckel = int.Parse(Console.ReadLine());

            string meddelandeKrypterad = "";
            // Loopa igenom ordet bokstav-för-bokstav
            for (int i = 0; i < ord.Length; i++)
            {
                //Lägger in alla bokstäver i en char
                char bokstav = ord[i];

                //Hittar koden till varje bokstav
                int kod = (int)bokstav;

                // Lägger till nyckeln
                kod += nyckel;

                // Tecken av ASCII-kod
                char bokstavKrypterad = (char)(kod);

                //Lägger till alla bokstäver i slutmeddelandet
                meddelandeKrypterad += bokstavKrypterad.ToString();
            }

            //Skriver ut resultatet
            Console.WriteLine($"\"{ord}\" blir \"{meddelandeKrypterad}\"");
        }
    }
}
