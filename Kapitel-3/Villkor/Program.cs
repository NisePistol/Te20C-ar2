using System;

namespace Villkor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Be användaren om ålder
            Console.Write("Hur gammal är du? (heltal) ");
            int ålder = int.Parse(Console.ReadLine());
            
            // Om ålder större än 18, du får ta körkort
            if (ålder >= 18)
            {
                Console.WriteLine("Du är 18 eller äldre, du får ta körkort");
            }

            // Om åldern är 15 eller högre får man ta körkort för moped
            else if (ålder >= 15) {
                Console.WriteLine("Du är 15 eller äldre, du får ta körkort");
            }

            // Fråga användaren vad ABBAs senaste låt heter
            Console.Write("Vad heter ABBAs senaste album? ");
            string låt = Console.ReadLine();
            
            // Är albumet korrekt
            if (låt == "Voyage" || låt == "voyage")
            {
                Console.WriteLine("Yippie, du hade rätt!");
            }
            else
            {
                Console.WriteLine("Fel! Albumet heter Voyage!");
            }

            // Sista TP-fråga
            Console.Write("Vem missade sista straffen i matchen England-Frankrike?  (efternamn) ");

            // Läs in och tvinga till små bokstäver
            string spelare = Console.ReadLine().ToLower();
            
            if (spelare == "mbappe")
            {
                Console.WriteLine("Bra, du är proffs på det här!");
            }
            else
            {
                Console.WriteLine("Fel, det var Mbappe");
            }
        }
    }
}
