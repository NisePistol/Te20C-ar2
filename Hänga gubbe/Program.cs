using System;
using System.Collections.Generic;

namespace Hänga_gubbe
{
    class Program
    {
        static void Main(string[] args)
        {
            int försök = 13;

            Console.Clear();
            Console.Write("Ange frasen: ");
            string stringFras = Console.ReadLine().ToLower();
            Console.Clear();

            List<char> x = new List<char>();

            for (int i = 0; i < stringFras.Length; i++)
            {
                x.Add(stringFras[i]);
            }

            while (försök>0)
            {
                Console.Write("Gissa en bokstav: ");
                char gissning = char.Parse(Console.ReadLine());
                
                for (int i = 0; i < x.Count; i++)
                {
                    if (x[i] == gissning)
                    {
                        Console.WriteLine($"{gissning} finns i frasen!");
                        x.Remove(x[i]);
                    }
                    else
                    {
                        Console.WriteLine($"{gissning} finns inte i frasen");
                        försök--;
                    }
                }
            }

        }
    }
}
