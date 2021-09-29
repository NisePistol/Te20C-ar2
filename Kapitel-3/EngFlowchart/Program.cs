using System.Text;
using System;

namespace EngFlowchart
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Clear();

            Console.WriteLine("Engeneering flowchart");
            
            Console.Write("Does it move? (y/n)");
            string answer1 = Console.ReadLine().ToLower();

            if (answer1=="y") {
                Console.Write("Should it? (y/n) ");
                string answer2 = Console.ReadLine().ToLower();

                if (answer2=="y") {
                    Console.WriteLine("No problem! 😀");
                }
                else if (answer2 == "n") {
                    Console.WriteLine("Use duck tape! 😆");
                }
            }
            else if (answer1=="n") {
                Console.Write("Should it? (y/n) ");
                string answer3 = Console.ReadLine().ToLower();

                if (answer3=="y") {
                    Console.Write("Use WD-40 😉");    
                }
                else if (answer3=="n") {
                    Console.Write("No problem! 🤣");
                }
            }
            
        }
    }
}
