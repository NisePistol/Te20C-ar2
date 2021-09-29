using System;

namespace BoolskaUttryck
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Coronasympton");

            Console.Write("Har du feber? (j/n) ");
            string feber = Console.ReadLine();

            Console.Write("Hostar du? (j/n) ");
            string hosta = Console.ReadLine();
            
            Console.Write("Har du tappat smaken? (j/n) ");
            string smak = Console.ReadLine();

            Console.Write("Är du vaccinerad mot Covid-19? (j/n) ");
            string vaccin = Console.ReadLine();

            /* //Om dessa tre villkor är uppfyllda har du troligen corona
            if (feber == "j" && hosta == "j" && smak == "j"){
                Console.WriteLine("Du har Troligen Covid-19");
            }
            else if (hosta == "j" && smak == "j")
            {
                Console.WriteLine("Du har troligen Covid-19");   
            }
            else if (feber == "j" && smak == "j")
            {
                Console.WriteLine("Du har troligen Covid-19");   
            } */

            if (feber == "j" || hosta == "j" && smak == "j")
            {
                Console.WriteLine("Du har troligen Covid-19");   
            }
        }
    }
}
