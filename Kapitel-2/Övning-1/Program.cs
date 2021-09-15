using System;

namespace Övning_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.Write("Skriv ett heltal: ");
            int tal = Convert.ToInt32(Console.ReadLine());

            Console.Write("Skriv ett substantiv: ");
            string substantiv = Console.ReadLine();
            
            Console.Write("Skriv ett verb: ");
            string verb = Console.ReadLine();

            Console.Write("Skriv ett till verb: ");
            string verb2 = Console.ReadLine();

            Console.Write("Skriv ett adjektiv: ");
            string adjektiv = Console.ReadLine();

            Console.Write("Skriv ett addverb: ");
            string addverb = Console.ReadLine();

            Console.Write("Skriv ett namn: ");
            string namn = Console.ReadLine();

            Console.Write("Skriv \"Han\" eller \"Hon\": ");
            string pronomen = Console.ReadLine();

            Console.Write("Skriv en plats: ");
            string plats = Console.ReadLine();

            Console.WriteLine($"Det var en gång en {substantiv} som hette {namn} och var {tal} år gammal. {pronomen} gillade att {verb} väldigt {addverb}. Men en dag blev {namn} trött på att {verb}. Så {pronomen} bestämde sig för att flytta till {plats} För att hitta en ny passion. När {namn} kom fram till {plats} så fastnade {pronomen} direkt för att {verb2}. Vilket såklart är förståeligt...");
        }
    }
}
