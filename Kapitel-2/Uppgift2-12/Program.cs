using System;

namespace Uppgift2_12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hur många dagar vill du hyra bilen? ");
            int hyrDagar = int.Parse(Console.ReadLine());

            Console.Write("Hur många kilometer ska du köra bilen? ");
            int kilometer = int.Parse(Console.ReadLine());

            int totalaHyran = 300 + (hyrDagar-1) * 500 + kilometer;
            Console.WriteLine($"Den totala hyran blir {totalaHyran}");
        }
    }
}
