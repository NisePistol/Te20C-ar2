using System;

namespace Parse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hur mycket väger du? ");
            float vikt = float.Parse(Console.ReadLine());

            float viktLbs = vikt*2.2f;

            string viktString = viktLbs.ToString("0.##");
            Console.WriteLine($"Din vikt i blir {viktString} i lbs");
        }
    }
}
