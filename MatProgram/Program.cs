using System;

namespace MatProgram
{
    class Program
    {
        static double kcal = 0;
        static double fett = 0;
        static double protein = 0;

        static double ingrediensKcal = 0;
        static double ingrediensFett = 0;
        static double ingrediensProtein = 0;

        static string ingrediens;

        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("---Mat Program---");
            Console.WriteLine("Hur många ingredienser innehåller måltiden? ");
            int antalIngredienser = int.Parse(Console.ReadLine());

            for (var i = 0; i < antalIngredienser; i++)
            {
                Console.Write($"Skriv ingrediens {i + 1}: ");
                ingrediens = Console.ReadLine().ToLower();
                i += IngrediensLista();
            }

            Console.WriteLine($"Hela din maträtt innehåller {(int)kcal}kcal, {(int)fett}g mättat fett och {(int)protein}g protein.");
        }

        static int IngrediensLista()
        {
            int i = 0;
            int enhet;

            if (ingrediens == "banan")
            {
                //Frågar hur mycket av ingrediensen man har
                enhet = FrågaHurMånga("gram");

                //Räknar ut hur mycket kcal, fett och protein ingrediensen innehåller
                Uträkning(enhet, 0.887, 0.001, 0.011);

                //Adderar ingrediensens värden till maträttens summa och skriver ut ingrediensens innehåll
                AdderaVärdenOchSkrivUt(ingrediensKcal, ingrediensFett, ingrediensProtein, enhet);
            }
            else if (ingrediens == "ägg")
            {
                //Frågar hur mycket av ingrediensen man har
                enhet = FrågaHurMånga("gram");

                //Räknar ut hur mycket kcal, fett och protein ingrediensen innehåller
                Uträkning(enhet, 1.55, 0.033, 0.13);

                //Adderar ingrediensens värden till maträttens summa och skriver ut ingrediensens innehåll
                AdderaVärdenOchSkrivUt(ingrediensKcal, ingrediensFett, ingrediensProtein, enhet);
            }
            else if (ingrediens == "jordnötssmör")
            {
                //Frågar hur mycket av ingrediensen man har
                enhet = FrågaHurMånga("gram");

                //Räknar ut hur mycket kcal, fett och protein ingrediensen innehåller
                Uträkning(enhet, 5.88, 0.10, 0.25);

                //Adderar ingrediensens värden till maträttens summa och skriver ut ingrediensens innehåll
                AdderaVärdenOchSkrivUt(ingrediensKcal, ingrediensFett, ingrediensProtein, enhet);
            }
            else if (ingrediens == "pumpakärnor")
            {
                //Frågar hur mycket av ingrediensen man har
                enhet = FrågaHurMånga("gram");

                //Räknar ut hur mycket kcal, fett och protein ingrediensen innehåller
                Uträkning(enhet, 4.66, 0.037, 0.19);

                //Adderar ingrediensens värden till maträttens summa och skriver ut ingrediensens innehåll
                AdderaVärdenOchSkrivUt(ingrediensKcal, ingrediensFett, ingrediensProtein, enhet);
            }
            else if (ingrediens == "solroskärnor")
            {
                //Frågar hur mycket av ingrediensen man har
                enhet = FrågaHurMånga("gram");

                //Räknar ut hur mycket kcal, fett och protein ingrediensen innehåller
                Uträkning(enhet, 5.94, 0.052, 0.23);

                //Adderar ingrediensens värden till maträttens summa och skriver ut ingrediensens innehåll
                AdderaVärdenOchSkrivUt(ingrediensKcal, ingrediensFett, ingrediensProtein, enhet);
            }
            else if (ingrediens == "mjölk")
            {
                //Frågar hur mycket av ingrediensen man har
                enhet = FrågaHurMånga("gram");

                //Räknar ut hur mycket kcal, fett och protein ingrediensen innehåller
                Uträkning(enhet, 0.45, 0.01, 0.034);

                //Adderar ingrediensens värden till maträttens summa och skriver ut ingrediensens innehåll
                AdderaVärdenOchSkrivUt(ingrediensKcal, ingrediensFett, ingrediensProtein, enhet);
            }
            else if (ingrediens == "mandelmjölk")
            {
                //Frågar hur mycket av ingrediensen man har
                enhet = FrågaHurMånga("ml");

                //Räknar ut hur mycket kcal, fett och protein ingrediensen innehåller
                Uträkning(enhet, 0.13, 0, 0.004);

                //Adderar ingrediensens värden till maträttens summa och skriver ut ingrediensens innehåll
                AdderaVärdenOchSkrivUt(ingrediensKcal, ingrediensFett, ingrediensProtein, enhet);
            }
            else if (ingrediens == "spenat")
            {
                //Frågar hur mycket av ingrediensen man har
                enhet = FrågaHurMånga("gram");

                //Räknar ut hur mycket kcal, fett och protein ingrediensen innehåller
                Uträkning(enhet, 0.20, 0, 0.029);

                //Adderar ingrediensens värden till maträttens summa och skriver ut ingrediensens innehåll
                AdderaVärdenOchSkrivUt(ingrediensKcal, ingrediensFett, ingrediensProtein, enhet);
            }
            else if (ingrediens == "linfrön")
            {
                //Frågar hur mycket av ingrediensen man har
                enhet = FrågaHurMånga("gram");

                //Räknar ut hur mycket kcal, fett och protein ingrediensen innehåller
                Uträkning(enhet, 5.33, 0.037, 0.018);

                //Adderar ingrediensens värden till maträttens summa och skriver ut ingrediensens innehåll
                AdderaVärdenOchSkrivUt(ingrediensKcal, ingrediensFett, ingrediensProtein, enhet);
            }
            else
            {
                //Om man skriver en ingrediens som inte finns 
                Console.WriteLine("Programmet hittade ingen sådan ingrediens, försök igen");
                i = -1;
            }

            return i;
        }

        static int FrågaHurMånga(string enhet)
        {
            //Frågar hur mycket ml eller gram man har av ingrediensen
            Console.Write($"Hur många {enhet} {ingrediens}? ");
            return int.Parse(Console.ReadLine());
        }

        static void Uträkning(int enhet, double förKcal, double förFett, double förProtein)
        {
            //Räknar ut hur mycket ingrediensen innehåller
            ingrediensKcal = enhet * förKcal;
            ingrediensFett = enhet * förFett;
            ingrediensProtein = enhet * förProtein;
        }

        static void AdderaVärdenOchSkrivUt(double _kcal, double _fett, double _protein, double enhet)
        {
            //Adderar ingrediensens värden till maträttens summa
            kcal += _kcal;
            fett += _fett;
            protein += _protein;

            //Skriver ut ingrediensens innehåll
            Console.WriteLine($"{enhet}g {ingrediens} innehåller {_kcal}kcal, {_fett}g mättat fett och {_protein}g protein.");
        }
    }
}
