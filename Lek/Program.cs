using System;

namespace Lek
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Gissa siffran spel\n-----------------");

            int[] räckvidd = VäljRäckvidd();
            GissaSiffra(räckvidd);
        }

        public static int[] VäljRäckvidd()
        {
            int högstaSiffran = 0;
            int lägstaSiffran = 1;
            Console.WriteLine("Du får själv välja räckvidden på siffror man kan gissa");

            while (lägstaSiffran > högstaSiffran)
            {
                högstaSiffran = KollaInt("Vad är högstsa siffran man ska gissa? ");

                lägstaSiffran = KollaInt("Vad är minsta siffran man ska gissa? ");

                if (lägstaSiffran > högstaSiffran)
                {
                    FelMeddelande("Den högsta siffran är mindre än den minsta siffran\n");
                }
            }

            int[] räckvidd = { lägstaSiffran, högstaSiffran };
            return räckvidd;
        }

        public static int KollaInt(string fråga)
        {
            while (true)
            {
                Console.Write(fråga);
                string stringAttKolla = Console.ReadLine();

                if (int.TryParse(stringAttKolla, out int siffra))
                {
                    return siffra;
                }
                else
                {
                    FelMeddelande("Det var inte ett heltal");
                }
            }
        }

        public static void GissaSiffra(int[] räckvidd)
        {
            Random gen = new Random();
            int siffraAttGissa = gen.Next(räckvidd[0], räckvidd[1]);
            int antalGissningar = 5;
            int gissning = siffraAttGissa+1;

            Console.WriteLine($"\nDatorn har valt ett tal mellan {räckvidd[0]}-{räckvidd[1]}");
            Console.WriteLine(siffraAttGissa);

            while (antalGissningar > 0)
            {
                gissning = KollaInt("Gissa en siffra: ");

                if (gissning == siffraAttGissa)
                {
                    Console.WriteLine("\nDu gissade rätt!");
                    break;
                }
                else if (gissning > siffraAttGissa)
                {
                    Console.WriteLine("\nDu gissade för högt!");
                    MinskaAntalGissningar(ref antalGissningar);
                }
                else
                {
                    Console.WriteLine("\nDu gissade för lågt!");
                    MinskaAntalGissningar(ref antalGissningar);
                }
                
                int tur = gen.Next(3);
                if (tur == 2 || antalGissningar == 0)
                {
                    VinnEnExtraGissning(ref antalGissningar);
                }
            }
        }

        public static void MinskaAntalGissningar(ref int antalGissningar)
        {
            antalGissningar -= 1;
            if (antalGissningar > 0)
            {
                Console.WriteLine($"Du har {antalGissningar} gissningar kvar"); 
            }
            else
            {
                Console.WriteLine("Du har slut på gissningar");
            }
        }

        public static void VinnEnExtraGissning(ref int antalGissningar)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("DU HAR CHANSEN ATT VINNA EN GRATIS GISSNING!!!");
            Console.WriteLine("Om du svarar rätt på denna fråga får du en extra gissning!\n");

            int gissning = KollaInt("Vad är roten ur 49? ");
            if(gissning == 7)
            {
                Console.WriteLine("Du gissade rätt!");
                antalGissningar+=1;
                Console.WriteLine($"Antal gissningar: {antalGissningar}\n");
            }
            else
            {
                Console.WriteLine("Du gissade fel!");
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void FelMeddelande(string meddelande)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(meddelande);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
