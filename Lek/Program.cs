using System;
using System.Collections.Generic;

namespace Lek
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Gissa siffran spel\n-------------------");

            //Skapar alla special frågor
            Frågor.SkapaFrågor();

            string spelaIgen = "j";
            while (spelaIgen == "j")
            {
                //Låter spelaren välja svårighetsgrad
                int[] räckvidd = VäljSvårighetsGrad();

                //Låter spelaren gissa siffra
                GissaSiffra(räckvidd);

                Console.Write("Vill du spela igen? (j/n) ");
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
                Console.ReadKey();
                räckvidd[0] = -1;
            }

            return räckvidd;
        }

        public static int[] BestämRäckvidd(int minTal, int maxTal)
        {
            int[] räckvidd = { minTal, maxTal };
            return räckvidd;
        }

        public static int[] VäljSvårighetsGrad()
        {
            int[] räckvidd = { -1, 0 };
            while (räckvidd[0] == -1)
            {
                Console.Clear();
                Console.WriteLine("-----Välj svårighetsgrad-----");
                Console.WriteLine("Enkelt/Medel/Svår");

                //Tar in svårighetsgraden och bestämmer räckvidden
                //Om användaren ger felaktigt input så kommer räckvidd[0] = -1 och koden kommer loopa
                räckvidd = VäljRäckvidd(Console.ReadLine().ToLower());
            }

            return räckvidd;
        }

        public static int KollaInt(string fråga)
        {
            while (true)
            {
                //Skriver ut frågan man vill ställa
                Console.Write(fråga);

                //Tar in input från användaren och kollar om det är en int
                if (int.TryParse(Console.ReadLine(), out int siffra))
                {
                    //Returnerar siffran om det är en int
                    return siffra;
                }
                else
                {
                    //Skriver felmeddelande
                    FelMeddelande("Du måste skriva ett heltal");
                }
            }
        }

        public static void GissaSiffra(int[] räckvidd)
        {
            Random gen = new Random();
            int siffraAttGissa = gen.Next(räckvidd[0], räckvidd[1] + 1);
            int gissning = siffraAttGissa + 1;
            int antalGissningar = 5;
            bool användarenVann = false;

            Console.WriteLine($"\nDatorn har valt ett tal mellan {räckvidd[0]}-{räckvidd[1]}");
            Console.WriteLine($"Du börjar med {antalGissningar} gissningar");

            while (antalGissningar > 0)
            {
                gissning = KollaInt("Gissa en siffra: ");

                if (gissning == siffraAttGissa)
                {
                    Console.WriteLine("Du gissade rätt!\n");
                    användarenVann = true;
                    break;
                }
                else if (gissning > siffraAttGissa)
                {
                    GissningsResultat("Du gissade för högt\n", ref antalGissningar);
                }
                else
                {
                    GissningsResultat("Du gissade för lågt\n", ref antalGissningar);
                }

                int tur = gen.Next(3);
                if (tur == 2)
                {
                    if (Frågor.frågorLista.Count > 0)
                    {
                        VinnEnExtraGissning(ref antalGissningar);
                    }
                    else
                    {
                        FelMeddelande("Det finns inga fler special frågor");
                    }
                }

                AntalGissningarKvar(antalGissningar);
            }

            if (!användarenVann)
            {
                Console.WriteLine($"Det rätta svaret var {siffraAttGissa}");
            }
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
        public static List<string> frågorLista = new List<string>();
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
            frågorLista.Add("Vad är roten ur 49? ;7");
            frågorLista.Add("Vad heter Zlatan i efternamn? ;ibrahimovic");
            frågorLista.Add("Vad heter 16 upphöjt till 0? ;1");
            frågorLista.Add("Vilket år dog hitler? ;1945");
            frågorLista.Add("Vad heter kaninen i Bamse? ;lille skutt");
            frågorLista.Add("Vilket år skapades programmerings språket \"C#\"? ;2000");
        }

        public static string StällFråga()
        {
            //Slumpar fram en fråga
            SlumpaFråga();
            Console.WriteLine($"Antal frågor kvar: {frågorLista.Count}");

            string gissning = "";
            //Om det finns frågor i listan
            if (frågorLista.Count > 0)
            {
                //Skriver ut frågan
                Console.Write(valdFråga);

                //Tar in en gissning
                gissning = Console.ReadLine();
            }

            return gissning;
        }
    }
}

