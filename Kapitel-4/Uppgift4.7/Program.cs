using System;

namespace Uppgift4._7
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tar in summan
            Console.Write("Skriv din summa: ");
            string siffror = Console.ReadLine();
            
            int summa = 0;
            int intSiffra = 0;
            //Loopa igenom summaText
            for (int i = 0; i < siffror.Length; i++)
            {
                char siffra = siffror[i];
                intSiffra = siffra;
                //Console.WriteLine($"Loop nr {i+1}, variabeln siffror är {siffror[i]}");
                //Console.WriteLine($"Loop nr {i+1}, variabeln siffra är {siffra}");
                Console.WriteLine($"Loop nr {i+1}, variabeln intSiffra är {intSiffra}");
                //summa += siffra;
            }

            //Console.WriteLine(summa);
        }
    }
}
