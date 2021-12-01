using System;
using System.IO;

namespace Bordsbokning
{
    class Program
    {
        static void Main(string[] args)
        {
            string filNamn = "bordsinfo.txt";
            string[] bordsinformation = new string[8];
            string tommaBord = "0;inga gäster";
            int antalBord = 8;

            Console.Clear();
            Console.WriteLine("Detta är Centralrestaurangens bordshanterare");

            if (File.Exists(filNamn))
            {
                bordsinformation = File.ReadAllLines(filNamn);
                Console.WriteLine("Filen lästes in");
            }
            else
            {
                Console.WriteLine($"Filen med namnet '{filNamn}' hittades inte, ny fil har skapats");
                for (var i = 0; i < antalBord; i++)
                {
                    bordsinformation[i] = tommaBord;
                }
                File.WriteAllLines(filNamn, bordsinformation);
            }

            string alternativ = "0";
            while (alternativ != "4")
            {
                Console.WriteLine("\nVälj ett alternativ\n1. Visa alla bord\n2. Lägg till/ändra bordsinformation\n3. Avboka\n4. Avsluta programmet");
                alternativ = Console.ReadLine();

                switch (alternativ)
                {
                    case "1":
                        //Visa alla bord
                        int totaltAntalGäster = 0;
                        for (var i = 0; i < bordsinformation.Length; i++)
                        {
                            //Om bordet är tomt
                            if (bordsinformation[i] == tommaBord)
                            {
                                Console.WriteLine($"Bord {i + 1} - Inga gäster");
                                continue;
                            }

                            //Om det inte är tomt
                            string[] bord = bordsinformation[i].Split(';');
                            Console.WriteLine($"Bord {i + 1} - Namn: {bord[1]}, antal gäster: {bord[0]}");
                            totaltAntalGäster += int.Parse(bord[0]);

                        }
                        Console.WriteLine($"Totalt antal gäster: {totaltAntalGäster}");
                        break;
                    case "2":
                        //Lägg till eller ändra information för ett bord
                        Console.Write("Vilket bordsnummer vill du lägga till/ändra informationen för? ");
                        string bordsNummer = Console.ReadLine();

                        //Fångar ogiltig input
                        int intBordsNummer = 0;
                        bool kollaSiffra = int.TryParse(bordsNummer, out intBordsNummer);
                        if (intBordsNummer > bordsinformation.Length || intBordsNummer < 1 || kollaSiffra == false)
                        {
                            Console.WriteLine("\nOgiltigt bordsnummer angavs");
                            break;
                        }

                        //Frågar efter bordets namn och lägger in det i en array
                        string[] nyttBordInfo = new string[2];
                        Console.Write("Skriv in bordets namn: ");
                        nyttBordInfo[1] = Console.ReadLine();

                        //Fångar ogiltig input
                        bool innehållerSemiKolon = nyttBordInfo[1].Contains(';');
                        if (innehållerSemiKolon || nyttBordInfo[1].Length <= 1 || nyttBordInfo[1].Length > 20)
                        { 
                            Console.WriteLine("\nOgiltigt namn angavs");
                            break;
                        }

                        Console.Write("Hur många gäster finns vid bordet?: ");
                        nyttBordInfo[0] = Console.ReadLine();

                        int antalGäster = 0;
                        //Fångar ogiltig input
                        kollaSiffra = int.TryParse(nyttBordInfo[0], out antalGäster);
                        if (antalGäster > 5 || antalGäster < 1 || kollaSiffra == false)
                        {
                            Console.WriteLine("\nOgiltigt antal angavs");
                            break;
                        }

                        //Lägger ihop bordets namn och antal gäster till en sträng som separeras med ett semikolon och skriver det till filen
                        bordsinformation[intBordsNummer - 1] = string.Join(";", nyttBordInfo);
                        File.WriteAllLines(filNamn, bordsinformation);
                        break;
                    case "3":
                        //Avboka
                        Console.Write("Vilket bordsnummer vill du avboka? ");
                        bordsNummer = Console.ReadLine();

                        kollaSiffra = int.TryParse(bordsNummer, out intBordsNummer);
                        if (intBordsNummer > bordsinformation.Length || intBordsNummer < 1 || kollaSiffra == false)
                        {
                            Console.WriteLine("\nOgiltigt bordsnummer angavs");
                            break;
                        }

                        if (bordsinformation[intBordsNummer - 1] == tommaBord)
                        {
                            Console.WriteLine("Detta bord är redan tomt");
                        }
                        else
                        {
                            bordsinformation[intBordsNummer - 1] = tommaBord;
                            File.WriteAllLines(filNamn, bordsinformation);
                            Console.WriteLine($"Bord nummer {bordsNummer} är nu avbokat");
                        }
                        break;
                    case "4":
                        //Avslutar programmet
                        break;
                    default:
                        Console.WriteLine("Ogiltigt svar angavs");
                        break;
                }

            }
        }
    }
}