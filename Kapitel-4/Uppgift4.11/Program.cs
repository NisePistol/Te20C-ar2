using System;

namespace Uppgift4._11
{
    class Program
    {
        static void Main(string[] args)
        {
            //Deklarerar variablerna som behövs som villkor
            string land = "";
            int försök = 5;

            while(land!="ryssland") {

                Console.Clear();
                Console.WriteLine("Gissa land program");
                Console.WriteLine("--------------------");

                //Efter första försöket så läggs "kvar" till efter antalet försök för att det ska vara snyggare
                if(försök<5) {
                    Console.Write($"Vilket är Europas folkrikaste land? (Du har {försök} försök kvar) ");
                }
                else {
                    Console.Write($"Vilket är Europas folkrikaste land? (Du har {försök} försök) ");
                }
                land = Console.ReadLine().ToLower();

                //Tar bort 1 från antal försök
                försök--; 
                
                if(land=="ryssland") {
                    //Om man gissar rätt
                    Console.WriteLine("Grattis! Du hade rätt!");
                    break;
                }
                
                else if (försök<=0) {
                    //Om man har slut på försök
                    Console.WriteLine("Fel! Du har slut på försök!");
                    break;
                }

                else if(land!="ryssland") {
                    //Om man gissar fel
                    Console.WriteLine("Fel! klicka varsomhelst för att försöka igen!");
                    Console.ReadKey();
                }
            }
            
        }
    }
}
