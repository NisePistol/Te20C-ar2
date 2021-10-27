using System;

namespace _21.an
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            int spelareSumma = 0;
            int datorSumma = 0;
            int datorTal = 0;
            string draKort = "j";
            Random generator = new Random();

            Console.WriteLine("Blackjack\n------------");

            Console.WriteLine("Klicka för att dra första kortet");
            Console.ReadKey();

            while (draKort == "j")
            {
                Console.Clear();
                Console.WriteLine("Blackjack\n------------");

                //slumpar spelarens tal
                int spelareTal = generator.Next(1, 11);
                
                //Adderar talet spelaren fick till spelarens summa
                spelareSumma += spelareTal;

                //Skriver ut
                Console.WriteLine($"Du drog en {spelareTal}a");

                //slumpar datorns tal
                datorTal = generator.Next(1, 11);

                //Adderar talet datorn fick till datorns summa
                datorSumma += datorTal;

                //Skriver ut
                Console.WriteLine($"Datorn drog en {datorTal}a");

                //Skriver ut summorna
                Console.WriteLine($"Du har totalt: {spelareSumma}");
                Console.WriteLine($"Datorn har totalt: {datorSumma}");

                if (spelareSumma>=21 || datorSumma>=21) {
                    break;
                }

                Console.Write("Vill du dra ett till kort? (j/n) ");
                draKort = Console.ReadLine();
            }

            Console.Clear();

            //slumpar datorns tal
            datorTal = generator.Next(1, 11);

            //Adderar talet datorn fick till datorns summa
            datorSumma += datorTal;

            //Skriver ut
            Console.WriteLine($"Datorn drog en {datorTal}a och har nu totalt: {datorSumma}\n----------------------------");

            if (datorSumma>21 && spelareSumma <= 21)
            {
                Console.WriteLine("Du vann");
            }
            else
            {
                
            }
        }
    }
}

