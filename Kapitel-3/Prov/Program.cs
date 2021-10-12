using System;

namespace Prov
{
    class Program
    {
        static void Main(string[] args)
        {
            string försökIgen = "y";

            while(försökIgen=="y") {

                //Tömmer konsolen
                Console.Clear();

                //Skriver ut vad programmet handlar om
                Console.WriteLine("Uträkning av Nettolön");
                Console.WriteLine("-------------------");

                //Frågar och tar in namn på användaren
                Console.Write("Vad heter du? ");
                string namn = Console.ReadLine();
            
                //Frågar och tar in bruttolön på användaren
                Console.Write("Ange din bruttolön i kronor: ");
                int bruttoLön = int.Parse(Console.ReadLine());

                //Frågar och tar in skattesats på användaren
                Console.Write("Ange din skattesats i %: ");
                int skattesats = int.Parse(Console.ReadLine());

                Console.WriteLine("---------------------");

                //Kollar om bruttolönen är mellan 10 000 och 45 000 och skattesatsen är mellan 10 och 45%
                if(bruttoLön >= 10000 && bruttoLön <= 45000 && skattesats >= 10 && skattesats <= 45) {

                    //Skriver ut nettolönen
                    Console.WriteLine($"{namn} din nettolön är { bruttoLön * (100-skattesats)/100 } kr.");
                    Console.WriteLine($"Baserat på bruttolönen {bruttoLön} kr och skattesatsen {skattesats}%");
                }

                //Kollar om skattesatsen är mindre än 10 eller större än 45%
                else if(skattesats < 10 || skattesats > 45){

                    //Skriver ut felmeddelande
                    Console.WriteLine($"{namn}, skattesatsen måste vara mellan 10 och 45%!");
                } 

                //Kollar om bruttolönen är under 10 000 eller större än 45 000
                else if(bruttoLön < 10000 || bruttoLön > 45000) {

                    //Skriver ut felmeddelande
                    Console.WriteLine($"{namn}, bruttolönen måste vara mellan 10000 och 45000 kr.");
                }

                Console.Write("Vill du försöka igen? (y/n) ");
                försökIgen = Console.ReadLine().ToLower();
            }

            
        }
    }
}
