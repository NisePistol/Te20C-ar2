using System;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Hur många världen vill du ha? ");
            int antal = int.Parse(Console.ReadLine());

            int[] värden = new int[antal];
            int summa = 0;
        
            for (int i = 0; i < antal; i++)
            {
                Console.Write($"Sätt in värde {i+1}: ");
                summa += int.Parse(Console.ReadLine());
            }

            Console.WriteLine($"Minsta värdet är: {värden.Min()}");
            Console.WriteLine($"Medelvärdet är: {summa/antal}");
        }
    }
}
