using System;
using System.Collections.Generic;
using System.Linq;

namespace Lek
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Gissa siffran spel\n-----------------");
            
            //Skapar alla special frågor
            Frågor.SkapaFrågor();

            //Låter spelaren välja räckvidd att gissa på
            int[] räckvidd = VäljRäckvidd();

            //Låter spelaren gissa siffra
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
            int antalGissningar = 5;

            int siffraAttGissa = gen.Next(räckvidd[0], räckvidd[1]);
            int gissning = siffraAttGissa + 1;

            Console.WriteLine($"\nDatorn har valt ett tal mellan {räckvidd[0]}-{räckvidd[1]}");

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

                int tur = 2;
                if (tur == 2)
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
            Console.WriteLine("\nDU HAR CHANSEN ATT VINNA EN GRATIS GISSNING!!!");
            Console.WriteLine("Om du svarar rätt på denna fråga får du en extra gissning!\n");

            //Ställer en fråga och tar in en gissning från användaren
            string gissning = Frågor.StällFråga().ToLower();

            if (gissning == Frågor.rättSvar)
            {
                Console.WriteLine("Du gissade rätt!");
                antalGissningar += 1;
                Console.WriteLine($"Antal gissningar: {antalGissningar}\n");

                //Tar bort frågan från listan
                Frågor.TaBortFråga();
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

    class Frågor
    {
        static List<string> frågorLista = new List<string>();
        static string valdFråga;
        public static string rättSvar;
        static int slumpIndex;

        public static void SlumpaFråga()
        {
            Random generator = new Random();

            //Skapar slump index
            slumpIndex = generator.Next(frågorLista.Count);

            //Om det är slut på frågor
            if (frågorLista.Count < 1)
            {
                Console.WriteLine("Slut på frågor");
            }
            else
            {
                //Deklarerar den valda frågan och dett rätta svaret
                valdFråga = frågorLista[slumpIndex].Split(';')[0];
                rättSvar = frågorLista[slumpIndex].Split(';')[1];
            }
        }

        public static void TaBortFråga()
        {
            //Tar bort frågan från listan
            frågorLista.RemoveAt(slumpIndex);
        }


        public static void SkapaFrågor()
        {
            //Lägger till frågor
            //Varje fråga har sitt respektive svar efter ' ; ' täcknet
            frågorLista.Add("Vad är roten ur 49?;7");
            frågorLista.Add("Vad heter Zlatan i efternamn?;ibrahimovic");
            frågorLista.Add("Vad heter 16 upphöjt till 0?;1");
            frågorLista.Add("Vilket år dog hitler?;1945");
            frågorLista.Add("Vad heter kaninen i Bamse?;lille skutt");
            frågorLista.Add("Vilket år skapades programmerings språket \"C#\";2000");
        }

        public static string StällFråga()
        {
            //Slumpar fram en fråga
            SlumpaFråga();

            string gissning = "";
            //Om det finns frågor i listan
            if(frågorLista.Count > 0)
            {
                //Skriver ut frågan
                Console.WriteLine(valdFråga);

                //Tar in en gissning
                gissning = Console.ReadLine();
            }

            return gissning;
        }
    }
}

