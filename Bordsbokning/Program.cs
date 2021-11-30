using System;
using System.IO;

namespace Bordsbokning
{
    class Program
    {
        static void Main(string[] args)
        {
            string filNamn = "bordsinfo.txt";
            string[] bordsinformation = File.ReadAllLines(filNamn);

            Console.Clear();
            Console.WriteLine("Detta är Centralrestaurangens bordshanterare\n");

            bool stanna = true;
            while (stanna)
            {
                Console.WriteLine("Välj ett alternativ\n1. Visa alla bord\n2. Lägg till/ändra bordsinformation\n3. Markera att ett bord är tomt\n4. Avsluta programmet");
                string alternativ = Console.ReadLine();

                if (alternativ == "1")
                {
                    foreach (var item in bordsinformation)
                    {
                        Console.WriteLine(item);
                    }
                }

                else if (alternativ == "2")
                {
                    Console.Write("Vilket bordsnummer vill du lägga till/ändra informationen för? ");
                    string bordsnummer = Console.ReadLine();

                    if (int.Parse(bordsnummer) > 8 || int.Parse(bordsnummer) < 1)
                    {
                        Console.WriteLine("Vi har bara 8 bord!");
                    }

                    Console.Write("Skriv in bordets namn: ");
                    string bordsNamn = Console.ReadLine();

                    Console.Write("Hur många gäster finns vid bordet?: ");
                    string antalGäster = Console.ReadLine();

                }

                else if (alternativ == "3")
                {

                }
                else if (alternativ == "3")
                {
                    break;
                }
            }
        }
    }
}
