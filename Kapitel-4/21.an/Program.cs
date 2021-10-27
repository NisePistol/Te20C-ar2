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
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Du drog en {spelareTal}a");

                //Skriver ut summan
                Console.WriteLine($"Du har totalt: {spelareSumma}");

                //slumpar datorns tal
                datorTal = generator.Next(1, 11);

                //Adderar talet datorn fick till datorns summa
                datorSumma += datorTal;

                //Skriver ut
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Datorn drog en {datorTal}a");

                //Skriver ut summan
                Console.WriteLine($"Datorn har totalt: {datorSumma}");
                
                Console.ForegroundColor = ConsoleColor.White;
                //Om spelaren går över 21
                if (spelareSumma >= 21)
                {
                    Console.WriteLine("----------\nDu förlora!");
                    break;
                } 
                //Om datorn går över 21
                else if (datorSumma >= 21)
                {
                    Console.WriteLine("----------\nDu vann!");
                    break;
                }

                //Frågar om spelaren vill dra ett till kort
                Console.Write("Vill du dra ett till kort? (j/n) ");
                draKort = Console.ReadLine();

                //Om spelaren INTE vill dra ett till kort så ska datorn dra ett sista kort
                if (draKort != "j")
                {
                    //slumpar datorns tal
                    datorTal = generator.Next(1, 11);

                    //Adderar talet datorn fick till datorns summa
                    datorSumma += datorTal;

                    //Skriver ut
                    Console.WriteLine($"Datorn drog en {datorTal}a och har nu totalt: {datorSumma}\n----------------------------");

                    //Om datorn är över 21 eller om spelaren har mer än datorn
                    if (datorSumma > 21 || spelareSumma > datorSumma)
                    {
                        Console.WriteLine("Du vann!");
                    }
                    //Om datorn är under eller likamed 21 och har mer än spelaren
                    else if (datorSumma > spelareSumma)
                    {
                        Console.WriteLine("Du förlora!");
                    }
                }
            }
        }
    }
}

