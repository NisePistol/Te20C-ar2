using System;
using System.Linq;
using System.Collections.Generic;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            //Skapar alla frågor
            Frågor.SkapaFrågor();
            int points = 0;

            //Kör en for-loop 5 gånger för att ställa 5 frågor
            for (var i = 0; i < 3; i++)
            {
                //Skapar en ny fråga
                Frågor fråga = new Frågor();

                //Ställer frågan och tar in en gissning från användaren
                string gissning = fråga.StällFråga();

                //Om användaren gissar rätt
                if (gissning == fråga.rättSvar)
                {
                    //Får ett poäng
                    points++;

                    //Tar bort frågan ur listan
                    fråga.TaBortFråga();
                }
                else
                {
                    i--;
                }

                //Skriver ut användarens poäng
                Console.WriteLine($"Du har {points} poäng");
            }
        }
    }

    class Frågor
    {
        static List<string> frågorLista = new List<string>();
        static string valdFråga;
        static int slumpIndex;
        public string rättSvar;

        public Frågor()
        {
            Random gen = new Random();
            slumpIndex = gen.Next(frågorLista.Count);
            if (frågorLista.Count < 1)
            {
                Console.WriteLine("Slut på frågor");
            }
            else
            {
                valdFråga = frågorLista[slumpIndex].Split(';')[0];
                rättSvar = frågorLista[slumpIndex].Split(';')[1];
            }
        }

        public void TaBortFråga()
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
        }

        public string StällFråga()
        {
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
