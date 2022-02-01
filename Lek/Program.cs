using System;

namespace Lek
{
    
    class Program
    {
        static void Main(string[] args)
        {
            string name = "adrian";
            Console.WriteLine(name);
            string newName = name.Remove(name.Length-1, 1);
            Console.WriteLine(newName);
        }
    }
}
