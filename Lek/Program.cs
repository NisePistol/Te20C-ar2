using System;

namespace Lek
{
    class Person
    {
        int ålder;
        string namn;
        public int styrka;
        public int hunger;

        public Person(string _namn, int _ålder)
        {
            namn = _namn;
            ålder = _ålder;
            hunger = 5;
            styrka = 0;
        }

        public void Träna()
        {
            Console.WriteLine($"{namn} tränade! Du fick +2 i styrka men det kostade en hunger poäng");
            styrka += 2;
            hunger--;
        }

        public void ät()
        {
            Console.WriteLine("Du åt! Du fick +2 i hunger!");
            hunger+=2;
        }

        public void stats() {
            Console.WriteLine($"Din styrka är: {styrka}");
            Console.WriteLine($"Din hunger är: {hunger}");
            Console.WriteLine($"");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random gen = new Random();
            double d = gen.NextDouble();
            Console.WriteLine(d);
        }

        static void StartaProgram() {
            
        }
    }
}
