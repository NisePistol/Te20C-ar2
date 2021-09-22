using System;

namespace Interaktiv_berättelse
{
    class Program
    {
        static void Main(string[] args)
        {
            // Rensar consolen
            Console.Clear();

            // Frågar och tar in första valet från användaren
            Console.Write("Väljer du att åka buss eller tåg till skolan? ");
            string transport = Console.ReadLine().ToLower();
            
            if (transport == "buss") 
            {
                // Rensar consolen
                Console.Clear();

                // Skriver ut händelsen och frågar nästa fråga
                Console.Write("Du väljer att ta bussen till skolan. En man med svart rock kliver på bussen... Han tar fram en pistol och ber dig att ge honom alla dina pengar, ger du honom dina pengar eller försöker du ta pistolen ifrån honom? (svara med \"ge\" eller \"ta\") ");
                string rån = Console.ReadLine().ToLower(); // Läser in svaret

                if (rån == "ge") 
                {
                    // Rensar consolen
                    Console.Clear();

                    // Skriver ut händelsen
                    Console.WriteLine("Du ger mannen alla dina pengar och dör sedan av en hjärtattack från all räddsla");

                    // Slut på programmet
                }
                else if (rån == "ta") 
                {
                    // Rensar consolen
                    Console.Clear();

                    // Skriver ut händelsen och frågar nästa fråga
                    Console.Write("Du känner dig modig idag och sträcker ut handen för att ta pistolen ifrån mannen... rånaren hinner inte reagera och du håller nu i pistolen... vill du skjuta rånaren eller springa därifrån? (\"skjuta\" eller \"springa\") ");
                    string pistol1 = Console.ReadLine().ToLower(); // Läser in svaret

                    if (pistol1 == "skjuta") 
                    {
                        // Rensar consolen
                        Console.Clear();

                        // Skriver ut händelsen och frågar nästa fråga
                        Console.Write("Du skjuter rånaren och han faller ner på marken helt blodig... han är död. Alla på bussen börjar skrika och en gammal tant på bussen tar upp mobilen för att ringa polisen, skjuter du henne också eller springer du därifrån? (skjuta eller springa) ");
                        string pistol2 = Console.ReadLine().ToLower(); // Läser in svaret
                        
                        if (pistol2 == "skjuta")
                        {
                            Console.Write("Du skjuter tanten och du ser rädslan i folket runt omkring dig..du springer snabbt av bussen men vet inte vart du ska ta vägen... vart springer du? (höger eller vänster) ");
                            string håll = Console.ReadLine().ToLower(); // Läser in svaret
                            
                        }
                        else if(pistol2 == "springa") 
                        {
                            // Rensar consolen
                            Console.Clear();

                            // Skriver ut händelsen och frågar nästa fråga
                            Console.Write("Du struntar i tanten och springer istället av bussen... men halvvägs ut känner du ett pistolskott i ryggen... du faller ihop och vänder dig om och ser tanten stå bredbent och stolt samtidigt som hon ler nöjt mot dig med en pistol i handen... du dog");

                            // Slut på programmet
                        }
                    }
                    else if(pistol1 == "springa") 
                    {
                        // Rensar consolen
                        Console.Clear();

                        // Skriver ut händelsen och frågar nästa fråga
                        Console.Write("Du springer av bussen men halvvägs ut känner du ett pistolskott i ryggen... du faller ihop och vänder dig om och ser mannen med en till pistol i handen... du dog");

                        // Slut på programmet
                    }
                }
            } 
            
            else if (transport == "tåg") 
            {
                // Rensar consolen
                Console.Clear();

                // Skriver ut händelsen och frågar nästa fråga
                Console.Write("Du väljer att ta tåget till skolan, men när du kliver av tåget så ramlar du ner på spåret... Nästa tåg kommer om en minut, försöker du klättra upp på perrongen eller gömmer du dig under perrong-skyddet tills nästa tåg har åkt förbi? (svara med \"klättra\" eller \"gömma\"?) ");          
                string perrong = Console.ReadLine().ToLower(); // Läser in svaret

                if (perrong == "klättra")
                {   
                    // Rensar consolen
                    Console.Clear();

                    // Skriver ut händelsen
                    Console.WriteLine("Du börjar klättra upp på perrongen och en man med svart kappa kommer och hjälper dig upp... men han tar sen din plånbok och knuffar ner dig på spåret igen, en kort stund efter kommer tåget och kör över dig... du dog.");
                }
                else if (perrong == "gömma")
                {   
                    // Rensar consolen
                    Console.Clear();

                    // Skriver ut händelsen och frågar nästa fråga
                    Console.Write("Du gömmer dig under Perrongen och väntar ut tåget... Det kommer sedan personal och hjälper dig upp... efter denna traumatiska händelse tappar du suget att gå till skolan och börja överväga att gå hem istället, vart går du? (skolan eller hem?) ");
                    string varthän = Console.ReadLine().ToLower(); // Läser in svaret
                    
                    if(varthän == "hem") 
                    {
                        // Rensar consolen
                        Console.Clear();

                        // Skriver ut händelsen och frågar nästa fråga
                        Console.WriteLine("Du väljer att gå hem... men påvägen känner du att du börjar bli hungrig så du vill gå och äta nåt, men du har svårt att välja mellan McDonalds och Max... vad väljer du? ");
                        string restaurang = Console.ReadLine().ToLower(); // Läser in svaret
                        

                        if (restaurang == "max")
                        {
                            // Rensar consolen
                            Console.Clear();

                            // Skriver ut händelsen och frågar nästa fråga
                            Console.Write("Du går in till Max för att beställa en burgare... tar du en kött eller kyckling burgare? (kött/kyckling) ");
                            string burgare = Console.ReadLine().ToLower(); // Läser in svaret

                            if (burgare == "Kyckling")
                            {
                                // Rensar consolen
                                Console.Clear();

                                // Skriver ut händelsen och frågar nästa fråga
                                Console.Write("Du beställer din kyckling burgare och tycker att den luktar lite konstigt men du tar en tugga ändå... du känner smaken av koriander och tappar direkt all kontroll över din kropp... din sista tanke innan du dör är att du aldrig skulle ha gått till Max... McDonalds e ju faktiskt bättre... Du dog.");

                                // Slut på programmet
                            }
                            else if (burgare == "kött") 
                            {
                                // Rensar consolen
                                Console.Clear();

                                // Skriver ut händelsen och frågar nästa fråga
                                Console.Write("Du beställer din kött burgare och tycker att den luktar lite konstigt men du tar en tugga ändå... du känner smaken av gift och tappar direkt all kontroll över din kropp... din sista tanke innan du dör är att du aldrig skulle ha gått till Max... McDonalds e ju faktiskt bättre... Du dog.");

                                // Slut på programmet
                            }
                        }
                        else if(restaurang == "mcdonalds")
                        {
                            // Rensar consolen
                            Console.Clear();

                            // Skriver ut händelsen och frågar nästa fråga
                            Console.Write("Du går in på McDonalds för att beställa... tar du McNuggets eller kycklingburgare? (nuggets/kyckling)");
                            string donkenMat = Console.ReadLine().ToLower(); // Läser in svaret
                            
                            if (donkenMat == "mcnuggets")
                            {
                                // Rensar consolen
                                Console.Clear();

                                // Skriver ut händelsen och frågar nästa fråga
                                Console.Write("Du får dina nuggets och de smakar jätte gott! På andra sidan av rummet ser du en annan elev som du känner igen... går hen också på din skolan kanske? Stannar du eller går du fram för att prata med personen? (prata/stanna) ");
                            }
                            else if (donkenMat == "kyckling")
                            {
                                // Rensar consolen
                                Console.Clear();

                                // Skriver ut händelsen och frågar nästa fråga
                                Console.Write("Du får din kycklingburgare och den smakar jätte gott! På andra sidan av rummet ser du en annan elev som du känner igen... Stannar du eller går du fram för att prata med personen? (prata/stanna) ");
                                string prata = Console.ReadLine(); // Läser in svaret
                            }
                        }
                    }
                }   
            }                    
        }
    }
}
