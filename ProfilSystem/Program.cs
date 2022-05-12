using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace ProfilSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            bool hittade = false;
            bool namnUpptaget = false;
            string[] namnOchHighscore = new string[2];
            string filVäg = @"C:\github\Te20C-ar2\Testing\highscore.csv";
            string användarnamn = "";
            string harProfil = "";
            List<string> allaRekord = new List<string>();

            Console.Clear();

            //Kollar om csvfilen finns
            if (File.Exists(filVäg))
            {
                //Om den finns
                //Lägger in profilerna från filen i en lista
                allaRekord = File.ReadAllLines(filVäg).ToList();
            }
            //Om den inte finns
            else
            {
                //Skapar en ny fil
                Console.WriteLine("Hittade inte textfilen... skapar ny fil");
                File.Create(filVäg);
            }

            while (true)
            {
                //Frågar om användaren har en profil sen tidigare
                Console.Write("Har du en profil sen tidigare? (j/n) ");
                harProfil = Console.ReadLine().ToLower();

                if (harProfil == "j")
                {
                    while (true)
                    {
                        //Frågar efter användarnamnet
                        Console.Write("Vad är ditt användarnamn: ");
                        användarnamn = Console.ReadLine();

                        //Loopar igenom alla rader i csv filen
                        foreach (var namn in allaRekord)
                        {
                            //Splittar på namnet och rekordet och lägger in det i en array
                            namnOchHighscore = namn.Split(';');

                            //Kollar om användarnamnet finns
                            if (användarnamn == namnOchHighscore[0])
                            {
                                //Om det finns bryts man ut ur loopen
                                hittade = true;
                                break;
                            }
                            else
                            {
                                //Om det inte finns så får användaren skriva namn igen
                                hittade = false;
                            }
                        }

                        //Kollar om profilen med användarnamnet finns
                        if (hittade)
                        {
                            //Om profilen finns så skrivs profilen ut
                            Console.WriteLine("Letar efter din profil...");
                            Console.WriteLine($"Användarnamn: \"{användarnamn}\" ditt högsta highscore är {namnOchHighscore[1]} coins");
                            break;
                        }
                        else
                        {
                            //Annars får användaren testa ett annat användarnamn
                            Console.WriteLine("Letar efter din profil...");
                            Console.WriteLine($"Hittade ingen profil med namnet \"{användarnamn}\", testa igen");
                        }
                    }

                    Console.Write("Vad är ditt nya highscore? ");
                    string nyttRekord = Console.ReadLine(); //Måste vara int

                    //loopar igenom alla rader i csv filen
                    for (var i = 0; i < allaRekord.Count; i++)
                    {
                        //Lägger in namnet för profilen med index 'i' i variabeln "namn"
                        string namn = allaRekord[i].Split(';')[0];

                        //Kollar om det finns en profil med användarnamnet som användaren skrev in
                        if (namn == användarnamn)
                        {
                            //Om det nya rekordet är större än det gamla rekordet
                            if (int.Parse(nyttRekord) > int.Parse(namnOchHighscore[1]))
                            {
                                //Byter ut det gamla rekordet i användarens profil med det nya rekordet
                                allaRekord[i] = $"{användarnamn};{nyttRekord}";

                                //Skriver ut den nya listan av profiler
                                File.WriteAllLines(filVäg, allaRekord);
                            }
                            break;
                        }
                    }
                    break;
                }

                //Om användaren inte har en profil
                else if (harProfil == "n")
                {
                    while (true)
                    {
                        //Frågar efter användarnamn
                        Console.Write("Välj användarnamn: ");
                        användarnamn = Console.ReadLine();

                        //Loopar igenom alla rader i csv filen
                        foreach (var namn in allaRekord)
                        {
                            //Splittar på namnet och rekordet och lägger in det i en array
                            namnOchHighscore = namn.Split(';');

                            //Kollar om namnet som användaren valde redan finns
                            if (användarnamn == namnOchHighscore[0])
                            {
                                //Om det redan finns så måste användaren testa ett annat användarnamn
                                namnUpptaget = true;
                                break;
                            }
                            else
                            {
                                namnUpptaget = false;
                            }
                        }

                        //Om namnet är upptaget får användaren testa ett annat namn
                        if (namnUpptaget)
                        {
                            Console.WriteLine("Namnet är upptaget, testa ett annat namn");
                        }
                        else
                        {
                            //Annars skapas en ny profil till användaren
                            Console.WriteLine($"Profil skapad, ditt användarnamn är: {användarnamn}");

                            Console.Write("Vad är ditt nya highscore? ");
                            string nyttRekord = Console.ReadLine(); //Måste vara int

                            //Lägger till den nya profilen i csv filen
                            File.AppendAllText(filVäg, $"{användarnamn};{nyttRekord}");

                            break;
                        }
                    }
                    break;
                }
            }
        }
    }
}
