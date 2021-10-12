using System;

namespace GissaLand
{
    class Program
    {
        static void Main(string[] args)
        {
            string land = "";
            while(land!="japan") {
                
                Console.Clear();
                Console.WriteLine("Gissa land program");
                Console.WriteLine("--------------------");
                Console.WriteLine("Gissa vilket land jag tänker på");
                land = Console.ReadLine().ToLower();

                if(land!="japan") {
                    Console.WriteLine("Fel! Klicka varsomhelst för att föröka igen!");
                    Console.ReadKey();
                }
            }

            Console.WriteLine("Grattis du hade rätt!");
        }
    }
}
