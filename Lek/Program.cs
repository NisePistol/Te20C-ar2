using System;

namespace Lek
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            string svar = "";
            while(svar!="1") {
                Console.WriteLine("skriv 1");
                svar = Console.ReadLine();
            }
        }
    }
}
