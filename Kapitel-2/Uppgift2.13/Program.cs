using System;

namespace Parse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Vad är lönen för person 1? ");
            int lön01 = int.Parse(Console.ReadLine());
            
            Console.Write("Vad är lönen för person 2? ");
            int lön02 = int.Parse(Console.ReadLine());

            Console.Write("Vad är lönen för person 3? ");
            int lön03 = int.Parse(Console.ReadLine());

            float medelvärde = (lön01+lön02+lön03)/3;

            Console.WriteLine($"Medellönen är: {medelvärde}");
        }
    }
}
