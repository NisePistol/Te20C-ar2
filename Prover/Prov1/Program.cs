using System;

namespace Prov1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            //Berätta vad programmet gör
            Console.WriteLine("Uträckning av nettolön\n-----------------");


            while (köraIgen=="j") {
                //Fråga efter namn
                Console.Write("Vad heter du? ");
                string namn = Console.ReadLine();
            
                //Fråga efter bruttolön
                Console.Write("Ange din bruttolön i kronor: ");
                int bruttolön = int.Parse(Console.ReadLine());

                if (bruttolön >= 10000 && bruttolön <= 45000)
                {
                    //Fråga efter bruttolön
                    Console.Write("Ange din skattesats i %: ");
                    int skattesats = int.Parse(Console.ReadLine());

                    //Kolla att villkoren är uppfylda för skattesats
                    if (skattesats >= 10 && skattesats <= 45)
                    {
                        //räkna ut nettolön
                        int nettolön = bruttolön * (100 - skattesats) / 100;
                        Console.WriteLine($"{namn}, din nettolön är {nettolön} ");
                        Console.WriteLine("------------------------");
                    }
                    else
                    {
                        Console.WriteLine("skattesats måste vara 10 och 45");
                    }
                }
                else
                {
                    Console.WriteLine("Bruttolönen måste vara 10000 och 45000");
                }

                Console.Write("Vill du köra igen? (j/n) ");
                string köraIgen = Console.ReadLine();
            }
        }
    }
}
