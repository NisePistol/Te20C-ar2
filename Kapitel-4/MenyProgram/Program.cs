using System;

namespace MenyProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sten, sax, påse\n--------------");

            //Skapa en slumpgenerator
            Random tärning = new Random();

            //Programloopen
            while (true)
            {
                string slumpVal = tärning.Next(1, 4).ToString();

                Console.Write("Väljer du sten, sax eller påse? (1/2/3) ");
                string användarVal = Console.ReadLine();
                
                if (användarVal == "1" && slumpVal == "1"){
                    Console.WriteLine("Det blir lika!");
                }
                else if (användarVal == "1" && slumpVal == "2"){
                    Console.WriteLine("Du vinner!");
                }
                else if(användarVal == "2" && slumpVal == "1") {
                    Console.WriteLine("Du förlorar");
                }
                else if(användarVal == "2" && slumpVal == "2") {
                    Console.WriteLine("Det blir lika!");
                }
                else if(användarVal == "2" && slumpVal == "3") {
                    Console.WriteLine("Du vinner");
                }
                else if(användarVal == "3" && slumpVal == "1") {
                    Console.WriteLine("Du vinner");
                }
                else if(användarVal == "3" && slumpVal == "2") {
                    Console.WriteLine("Du förlorar");
                }
                else if(användarVal == "3" && slumpVal == "3") {
                    Console.WriteLine("Det blir lika!");
                }
            }
        }
    }
}
