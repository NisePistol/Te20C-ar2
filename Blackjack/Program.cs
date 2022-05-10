using System;

namespace Blackjack
{
    class Program
    {
        //Static variabler för spelaren
        static bool spelareHaftEss;
        static int spelareSumma;
        static int spelareKort;
        static bool spelareFickEss;

        //Static variabler för dealern
        static bool dealerHaftEss;
        static int dealerSumma;

        //Självstående static variabler
        static string spelaIgen;
        static string flerKort;

        static void Main(string[] args)
        {
            int intSatsning = 1;
            int pengar = 100;
            spelaIgen = "j";
            Random generator = new Random();

            while (spelaIgen == "j")
            {
                //Variabler för spelaren
                spelareHaftEss = false;
                spelareSumma = 0;
                spelareKort = 0;
                spelareFickEss = false;
                int pengarFrånBörjan = pengar;

                //Variabler för dealern
                dealerSumma = 0;
                dealerHaftEss = false;
                int dealerKort = 0;

                //Självstående variabeler
                flerKort = "j";
                int runda = 1;

                Console.Clear();

                while (true)
                {
                    if (pengar > 0)
                    {

                        //Frågar hur mycket användaren vill satsa
                        Console.WriteLine("--- BLACKJACK ---");
                        Console.WriteLine($"Du har {pengar} kronor");
                        Console.Write("Hur mycket vill du satsa? ");
                        string satsning = Console.ReadLine();


                        //Kollar om satsningen är en siffra
                        bool kollaInt = int.TryParse(satsning, out intSatsning);

                        //Om man ger ett ogiltigt svar skrivs ett felmeddelande ut och man får svara igen
                        if (kollaInt == false || intSatsning < 1 || intSatsning > pengar)
                        {
                            FelMeddelande("Ogiltigt svarsalternativ");
                        }
                        //Om man skriver ett giltigt svar kommer man ut ur loopen
                        else
                        {
                            pengar -= intSatsning;
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Du kan inte spela mer för att du har slut på pengar");
                        break;
                    }
                }

                //Om man har pengar får man spela
                if (pengar > 0 || intSatsning == pengarFrånBörjan)
                {
                    Console.Clear();
                    //Här börjar korten delas ut
                    while (flerKort == "j")
                    {
                        //Skriver ut vilken runda det är
                        Console.WriteLine($"\n-----Nu delas kort {runda} ut-----");

                        //Slumpar fram spelarens kort
                        spelareKort = NyttKort(spelareHaftEss);

                        //Skriver ut vilket kort spelaren fick och returnerar om spelaren fick ett ess eller inte
                        SkrivUtKort("Du", spelareKort);

                        //Andra rundan får man inte veta vad dealern tog upp för kort
                        if (runda == 2)
                        {
                            Console.WriteLine("Dealern tog upp sitt andra kort\n---------------");
                            //Kortet tas upp påriktigt utanför dennna while loop
                        }

                        //Första rundan måste spelaren ta upp två kort
                        if (runda == 1)
                        {
                            //Slumpar fram dealerns kort
                            dealerKort = NyttKort(false);

                            //Skriver ut vilket kort dealern fick och returnerar om dealern fick ett ess eller inte
                            SkrivUtKort("Dealern", dealerKort);

                            Console.WriteLine("Tryck för att dela ut andra kortet");
                            Console.ReadKey();
                        }

                        //Resten av rundorna får spelaren välja om den vill ta upp ett till kort
                        else
                        {
                            //Om spelaren har fått ett ess
                            if (spelareHaftEss)
                            {
                                //Skriver ut spelarens poäng och att spelaren har ett ess
                                Console.WriteLine($"Du har sammanlagt {spelareSumma} poäng och ett ess");
                            }

                            //Om spelaren INTE har haft ett ess
                            else
                            {
                                //Skriver bara ut spelarens poäng
                                SkriverUtPoäng("Du", spelareSumma);
                            }

                            //Frågar användaren om hen vill ta ett till kort
                            hitEllerStand();
                        }
                        runda++;
                    }

                    //Om man får exakt 21
                    if (spelareSumma == 21 && spelareFickEss == false)
                    {
                        Console.WriteLine("\nDu fick 21! Du vinner!");
                        pengar += intSatsning * 2;
                    }

                    //Om spelaren har över 21 
                    else if (spelareSumma > 21)
                    {
                        Console.WriteLine("Du förlorar");
                    }
                    //Skriver endast ut vad dealern fick om användaren har 21 eller under
                    else if (spelareSumma < 21)
                    {
                        //Om dealerns summa är mindre än 16
                        while (dealerSumma <= 16)
                        {
                            //Slumpar fram dealerns kort
                            dealerKort = NyttKort(dealerHaftEss);

                            string fras = "";
                            runda = 0;
                            switch (runda)
                            {
                                case 0:
                                    //För att programmet ska vara mer begrippligt för användaren så har jag två olika fraser för att skriva ut när dealern tar upp ett kort
                                    fras = $"\nDealerns nästa kort är en {dealerKort}a";
                                    break;
                                default:
                                    fras = $"\nDealern tog upp ett till kort och fick en {dealerKort}a";
                                    break;
                            }

                            //Om dealern får ett 'ess'
                            if (dealerKort == 11)
                            {
                                //Denna if-sats bestämmer vilket värde dealerns 'ess' ska ha
                                if (dealerSumma <= 10)
                                {
                                    //Esset blir en 11a
                                    dealerSumma += 11;
                                    Console.WriteLine("\nDealern fick ett ess och valde att använda den som en 11a");
                                }
                                else
                                {
                                    //Esset blir en 1a
                                    dealerSumma += 1;
                                    Console.WriteLine("\nDealern fick ett ess och valde att använda den som en 1a");
                                }
                            }

                            //Om dealern inte fick ett 'ess' adderas kortet till dealerns summa
                            else
                            {
                                Console.WriteLine(fras);
                                dealerSumma += dealerKort;
                            }

                            //Skriver ut dealerns summa
                            Console.WriteLine($"Dealern har sammanlagt {dealerSumma}");
                            Console.WriteLine("Tryck på enter för att fortsätta");
                            Console.ReadKey();
                            runda++;
                        }
                    }

                    //Skriver ut vem som vann
                    //Om dealern har mer än 21 vinner spelaren
                    if (dealerSumma > 21)
                    {
                        Console.WriteLine("\nDu vann!");
                        pengar += intSatsning * 2;
                    }
                    //Om de har lika mycket blir det lika
                    else if (spelareSumma == dealerSumma)
                    {
                        //Skriver ut bådas poäng och vem som vann
                        SkrivUtResultat("Det blev oavgjort!", spelareSumma, dealerSumma);
                        pengar += intSatsning;
                    }
                    //Om spelaren har mer poäng än dealern
                    else if (spelareSumma > dealerSumma && spelareSumma < 21)
                    {
                        //Skriver ut bådas poäng och att spelaren vann
                        SkrivUtResultat("Du vann!", spelareSumma, dealerSumma);

                        //Lägger till pengarna man vann
                        pengar += intSatsning * 2;
                    }
                    //Om dealern har mer poäng än spelaren
                    else if (spelareSumma < dealerSumma && spelareSumma < 21)
                    {
                        //Skriver ut bådas poäng och vem som vann
                        SkrivUtResultat("Du Förlorade", spelareSumma, dealerSumma);
                    }

                    //Frågar spelare om hen vill spela igen
                    SpelaIgen();
                }
                else
                {
                    spelaIgen = "n";
                    Console.WriteLine("Tryck för att avsluta");
                    Console.ReadKey();
                }
            }
        }

        static int NyttKort(bool harEss)
        {
            int kort = 0;
            Random generator = new Random();

            //Gör så att man inte kan få fler än ett ess
            switch (harEss)
            {
                case true:
                    kort = generator.Next(1, 11);
                    break;
                case false:
                    kort = generator.Next(1, 12);
                    break;
            }
            return kort;
        }

        static void FelMeddelande(string meddelande)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(meddelande);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Tryck på \"Enter\" för att försöka igen\n");
            Console.ReadKey();
        }

        static void SkriverUtPoäng(string vem, int poäng)
        {
            Console.WriteLine($"{vem} har sammanlagt {poäng} poäng");
        }

        static void SkrivUtKort(string vem, int kort)
        {
            if (kort == 11)
            {
                //Om spelaren får ett ess
                if (vem == "Du")
                {
                    spelareFickEss = true;
                    spelareHaftEss = true;
                    Console.WriteLine($"Du fick ett ess... I slutet av rundan kommer du få välja vilket värde det ska ha.");
                }
                //Om dealern får ett ess
                else
                {
                    dealerHaftEss = true;
                    Console.WriteLine("Dealern fick ett ess och valde att använda den som en 11a");
                    dealerSumma += 11;
                }
            }
            else
            {
                //Om spelaen får ett annat kort
                if (vem == "Du")
                {
                    spelareFickEss = false;
                    Console.WriteLine($"Du fick en {kort}a");
                    spelareSumma += spelareKort;
                }
                //Om dealern får ett annat kort
                else
                {
                    Console.WriteLine($"Dealern fick en {kort}a");
                    dealerSumma += kort;
                }
            }
        }

        static void SkrivUtResultat(string vemVann, int spelareSumma, int dealerSumma)
        {
            Console.WriteLine(" ");
            //Skriver ut spelarens poäng
            SkriverUtPoäng("Du", spelareSumma);

            //Skriver ut datorns poäng
            SkriverUtPoäng("Dealern", dealerSumma);

            //Skriver ut vem som vann
            Console.WriteLine(vemVann);
        }

        static void hitEllerStand()
        {
            if (spelareSumma < 21 || spelareSumma <= 21 && spelareFickEss)
            {
                bool stanna = true;
                while (stanna)
                {
                    Console.Write("Vill du ta ett till kort? (j/n) ");
                    flerKort = Console.ReadLine().ToLower();

                    //Om spelaren inte vill ta upp fler kort och spelaren har ett ess
                    if (flerKort == "n" && spelareHaftEss)
                    {
                        while (stanna)
                        {
                            //Frågar vilket värde spelaren vill ha på sitt ess
                            Console.WriteLine("Vad vill du att ditt ess ska ha för värde? ('1' eller '11')");
                            string essVärde = Console.ReadLine();

                            //Gör så att man bara kan svara 1 eller 11
                            if (essVärde == "1" || essVärde == "11")
                            {
                                //Adderar essets värde till summan
                                spelareSumma += int.Parse(essVärde);
                                stanna = false;
                                spelareFickEss = false;
                            }
                            else
                            {
                                //Om man svarar något ogiltigt
                                FelMeddelande("Du måste välja '1' eller '11'");
                            }
                        }
                    }
                    else if (flerKort == "j" || flerKort == "n")
                    {
                        //Om man svarar 'j' eller 'n' så kommer man ut ur loopen
                        break;
                    }
                    else
                    {
                        //Om man svarar något ogiltigt
                        FelMeddelande("Ogiltigt svarsalternativ");
                    }
                }
            }
            else
            {
                Console.WriteLine("--------------");
                flerKort = "n";
            }
        }

        static void SpelaIgen()
        {
            //Frågar om spelaren vill spela igen (man kan bara svara 'j' eller 'n')
            while (true)
            {
                Console.Write("Vill du spela igen? (j/n) ");
                spelaIgen = Console.ReadLine().ToLower();
                if (spelaIgen == "j" || spelaIgen == "n")
                {
                    break;
                }
                else
                {
                    FelMeddelande("Du måste svara 'j' eller 'n'");
                }
            }
        }
    }
}