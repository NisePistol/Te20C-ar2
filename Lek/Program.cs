using System;
using System.Collections.Generic;

namespace Lek
{
    class Program
    {
        static int chans;

        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Gissa siffran spel\n-------------------");

            //Skapar alla special frågor
            Frågor.SkapaFrågor();

            string spelaIgen = "j";
            while (spelaIgen == "j")
            {
                chans = 4;
                //Låter spelaren välja svårighetsgrad
                int[] räckvidd = VäljSvårighetsGrad();

                //Låter spelaren gissa siffra
                GissaSiffra(räckvidd);

                Console.Write("Vill du spela igen? (j/n) ");
                spelaIgen = Console.ReadLine().ToLower();
            }
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
                //Om användaren ger felaktigt input så kommer räckvidd[0] = -1 och användaren kommer få skriva igen
                string svårighetsgrad = Console.ReadLine().ToLower();
                räckvidd = VäljRäckvidd(svårighetsgrad);
            }

            return räckvidd;
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

        /// <summary>
        /// Returnerar räckvidden i en array (Denna metod är för att göra koden snyggare)
        /// </summary>
        /// <param name="minTal"></param>
        /// <param name="maxTal"></param>
        /// <returns></returns>
        public static int[] BestämRäckvidd(int minTal, int maxTal)
        {
            int[] räckvidd = { minTal, maxTal };
            return räckvidd;
        }

        public static void GissaSiffra(int[] räckvidd)
        {
            Random gen = new Random();
            bool användarenVann = false;

            //Antal gissningar användaren får
            int antalGissningar = 5;

            //Slumpar en siffra inom räckvidden som användaren ska gissa
            int siffraAttGissa = gen.Next(räckvidd[0], räckvidd[1] + 1);

            //Variabeln "gissning" måste ha ett värde för att kunna användas senare i koden
            int gissning = siffraAttGissa + 1;

            Console.WriteLine($"\nDatorn har valt ett tal mellan {räckvidd[0]}-{räckvidd[1]}");
            Console.WriteLine($"Du börjar med {antalGissningar} gissningar");

            while (antalGissningar > 0)
            {
                //Tar in en gissning från användaren och kollar om det är en int
                gissning = KollaInt("Gissa en siffra: ");

                //Om användaren gissade rätt
                if (gissning == siffraAttGissa)
                {
                    Console.WriteLine("Du gissade rätt!\n");
                    användarenVann = true;
                    break;
                }
                //Om användaren gissade för högt
                else if (gissning > siffraAttGissa)
                {
                    //Skriver ut resultatet och minskar antal gissningar
                    GissningsResultat("Du gissade för högt\n", ref antalGissningar);
                }
                //Annars = om användaren gissade för lågt
                else
                {
                    //Skriver ut resultatet och minskar antal gissningar
                    GissningsResultat("Du gissade för lågt\n", ref antalGissningar);
                }

                //Slumpar en siffra
                int tur = gen.Next(chans);
                Console.WriteLine($"Chans = {chans}");

                //Om siffran är 0 så får man en chans att vinna en extra gissning
                if (tur == 0)
                {
                    VinnEnExtraGissning(ref antalGissningar);
                }

                //Om siffran inte blir 0 så blir chansen för det större nästa runda
                else if (chans > 0)
                {
                    chans--;
                }
                
                //Skriver ut hur många gissningar användaren har kvar
                AntalGissningarKvar(antalGissningar);
            }

            //Om man förlorar skrivs den rätt siffran ut
            if (!användarenVann)
            {
                Console.WriteLine($"Det rätta svaret var {siffraAttGissa}");
            }
        }

        public static void GissningsResultat(string meddelande, ref int antalGissningar)
        {
            //Skriver ut meddelandet
            Console.WriteLine(meddelande);

            //Minskar antal gissningar
            antalGissningar -= 1;
        }

        /// <summary>
        /// Metoden skriver ut antal gissningar eller att användaren har slut på gissningar om hen har det
        /// </summary>
        /// <param name="antalGissningar"></param>
        public static void AntalGissningarKvar(int antalGissningar)
        {
            //Om man har över 0 gissningar så skrivs antal gissningar ut
            if (antalGissningar > 0)
            {
                Console.WriteLine($"Du har {antalGissningar} gissningar kvar");
            }

            //Annars skrivs det ut att man har slut på gissningar
            else
            {
                Console.WriteLine("Du har slut på gissningar");
            }
        }

        public static void VinnEnExtraGissning(ref int antalGissningar)
        {
            //Ändrar textfärgen
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nDU HAR CHANSEN ATT VINNA EN GRATIS GISSNING!!!");
            Console.WriteLine("Om du svarar rätt på denna fråga får du en extra gissning!\n");

            //Ställer en fråga och tar in en gissning från användaren
            string gissning = Frågor.StällFråga().ToLower();

            //Om användaren gissade rätt
            if (gissning == Frågor.rättSvar)
            {
                //Ger användaren en till gissning
                Console.WriteLine("Du gissade rätt!");
                antalGissningar += 1;
                Console.WriteLine($"Antal gissningar: +1\n");

                //Tar bort frågan från listan
                Frågor.TaBortFråga();
            }
            else
            {
                Console.WriteLine("Du gissade fel!\n");
            }

            //Ändrar tillbaka textfärgen
            Console.ForegroundColor = ConsoleColor.White;
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

        public static void FelMeddelande(string meddelande)
        {
            //Skrive ut felmeddelandet med röd färg
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

        static void SlumpaFråga()
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

