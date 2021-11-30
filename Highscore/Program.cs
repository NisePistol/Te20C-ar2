using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Highscore
{
    class Program
    {
        static void Main(string[] args)
        {
            Random gen = new Random();
            string filNamn = "highscore.txt";
            string spelaIgen = "j";

            //Läser in highscoret från textfilen och lägger det i en lista strings
            List<string> highscoreList = File.ReadAllLines(filNamn).ToList();

            //Lägger in highscoret i en lista av ints
            List<int> intHighscoreList = new List<int>();
            intHighscoreList.Add(int.Parse(highscoreList[0]));

            while (spelaIgen == "j")
            {
                Console.Clear();

                //Skriver ut det största talet i listan
                Console.WriteLine($"Highscore på den här enheten är: {intHighscoreList.Max()}");

                //Skapar ett slumptal
                int num = gen.Next(1, 1001);

                //Skriver ut slumptalet
                if (num > intHighscoreList.Max())
                {
                    Console.WriteLine($"Nytt highscore!! Du fick {num}!");
                }
                else
                {
                    Console.WriteLine($"Du fick {num}\n");
                }
                //lägger in slumptalet i listan
                intHighscoreList.Add(num);

                //Frågar om man vill spela igen
                Console.Write("\nVill du spela igen? (j/n) ");
                spelaIgen = Console.ReadLine().ToLower();
                if (spelaIgen == "n")
                {
                    break;
                }
            }
            //lägger in det största talet i text filen
            File.WriteAllText(filNamn, intHighscoreList.Max().ToString());
        }
    }
}