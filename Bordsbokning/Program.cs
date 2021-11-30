using System;
using System.IO;

namespace Bordsbokning
{
    class Program
    {
        static void Main(string[] args)
        {
            string filNamn = "bordsinfo.txt";
            string[] bordsinformation;
            
            Console.Clear();
            Console.WriteLine("Detta är Centralrestaurangens bordshanterare\n");

            Console.WriteLine("Välj ett alternativ\n1. Visa alla bord\n2. Lägg till/ändra bordsinformation\n3. Markera att ett bord är tomt\n4. Avsluta programmet");
            string alternativ = Console.ReadLine();
            

        }
    }
}
