using System;
using System.IO;

namespace musiklista
{
    class Program
    {
        static void Main(string[] args)
        {
            string filNamn = "topplista.csv";
            string[] topplista = new string[20];
            int antalLåtar = 20;
            string tomPlats = "ingen låt";
            Console.Clear();
            if (File.Exists(filNamn))
            {
                topplista = File.ReadAllLines(filNamn);
                Console.WriteLine("Text filen lästes in");
            }
            else
            {
                Console.WriteLine("Ingen text fil hittades, ny fil har skapats");
                for (int i = 0; i < antalLåtar; i++)
                {
                    topplista[i] = tomPlats;
                }
                File.WriteAllLines(filNamn, topplista);
            }

            string menyVal = "0";
            while (menyVal != "4")
            {
                Console.WriteLine("Välj ett alternativ\n1. Visa min topplista (1)\n2. Lägg till/ändra låtar i topplista (2)\n3. Sök efter låtar (3)\n4. Avsluta (4)");
                menyVal = Console.ReadLine();

                switch (menyVal)
                {
                    case "1":
                        //Visa topplistan
                        for (int i = 0; i < topplista.Length; i++)
                        {
                            Console.WriteLine($"{i + 1}. {topplista[i]}");
                        }
                        break;
                    case "2":
                        //Lägg till eller ändra låt
                        for (int i = 0; i < topplista.Length; i++)
                        {
                            Console.Write($"Vad heter låt nr {i + 1}? ");
                            string låtNamn = Console.ReadLine();

                            topplista[i] = låtNamn;
                            File.WriteAllLines(filNamn, topplista);
                        }
                        break;
                    case "3":
                        //Söka efter låt
                        Console.Write("Skriv vad du vill söka på: ");
                        string sökFras = Console.ReadLine().ToLower();

                        bool fanns = false;
                        for (var j = 0; j < topplista.Length; j++)
                        {
                            if(topplista[j].Contains(sökFras))
                            {
                                Console.WriteLine($"{topplista[j]}");
                                fanns = true;
                            }
                        }
                        if(fanns == false)
                        {
                            Console.WriteLine("Din sökning gav inga resultat");
                        }

                        break;
                    case "4":
                        //Avslutar
                        break;
                    default:
                        Console.WriteLine("Ogiltigt svars alternativ\n");
                        break;
                }

            }
        }
    }
}
