using System;
using System.Collections.Generic;

namespace Lek
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Gissa siffran spel\n-----------------");

            string spelaIgen = "j";
            while (spelaIgen == "j")
            {
                //Skapar alla special frågor
                Frågor.SkapaFrågor();

                //Låter spelaren välja svårighetsgrad
                int[] räckvidd = VäljSvårighetsGrad();

                //Låter spelaren gissa siffra
                GissaSiffra(räckvidd);

                Console.WriteLine("Vill du spela igen? (j/n)");
                spelaIgen = Console.ReadLine().ToLower();
            }
        }

        public static int[] VäljRäckvidd(string svårighetsgrad)
        {   
            int[] räckvidd = new int[2];

            if (svårighetsgrad == "enkelt")
                {
                    //Räckvidden är 1-10
                    räckvidd = BestämRäckvidd(1, 10);
                }
                else if (svårighetsgrad == "medel")
                {
                    //Räckvidden är 1-50
                    räckvidd = BestämRäckvidd(1, 50);
                }
                else if (svårighetsgrad == "svår")
                {
                    //Räckvidden är 1-100
                    räckvidd = BestämRäckvidd(1, 100);
                }
                else
                {
                    FelMeddelande("Du måste svara \"Enkelt\", \"medel\" eller \"svår\"");
                    räckvidd[0] = -1;
                }


            return räckvidd;
        }

        public static int[] BestämRäckvidd(int minTal, int maxTal)
        {
            int[] räckvidd = {minTal, maxTal};
            return räckvidd;
        }

        public static int[] VäljSvårighetsGrad()
        {
            int[] räckvidd = {-1, 0};
            while (räckvidd[0] == -1)
            {
                Console.WriteLine("-----Välj svårighetsgrad-----");
                Console.WriteLine("Enkelt/Medel/Svår");

                //Tar in svårighetsgraden och bestämmer räckvidden
                //Om användaren ger felaktigt input så kommer räckvidd[0] = -1 och whilen kommer loopa
                räckvidd = VäljRäckvidd(Console.ReadLine().ToLower());
            }

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
            int siffraAttGissa = gen.Next(räckvidd[0], räckvidd[1] + 1);
            int gissning = siffraAttGissa + 1;
            int antalGissningar = 5;

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
                    GissningsResultat("\nDu gissade för högt", ref antalGissningar);
                }
                else
                {
                    GissningsResultat("\nDu gissade för lågt", ref antalGissningar);
                }

                int tur = gen.Next(4);
                if (tur == 2)
                {
                    VinnEnExtraGissning(ref antalGissningar);
                }

                AntalGissningarKvar(antalGissningar);
            }

            Console.WriteLine($"Det rätta svaret var {siffraAttGissa}");
        }

        public static void GissningsResultat(string meddelande, ref int antalGissningar)
        {
            //Skriver ut meddelandet
            Console.WriteLine(meddelande);

            antalGissningar -= 1;

        }

        public static void AntalGissningarKvar(int antalGissningar)
        {
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
            if (frågorLista.Count > 0)
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

