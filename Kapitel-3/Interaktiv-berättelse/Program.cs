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
                Console.Write("Du väljer att ta bussen till skolan. En man med svart rock kliver på bussen... Han tar fram en pistol och ber dig att ge honom alla dina pengar, ger du honom dina pengar eller försöker du ta pistolen ifrån honom? (ge/ta) ");
                string rån = Console.ReadLine().ToLower(); // Läser in svaret

                if (rån == "ge") 
                {
                    // Rensar consolen
                    Console.Clear();
                    //Ändrar textfärgen till röd
                    Console.ForegroundColor = ConsoleColor.Red;

                    // Skriver ut händelsen
                    Console.WriteLine("Du ger mannen alla dina pengar men dör sedan av en hjärtattack från all räddsla");
                    // Slut på programmet
                }
                else if (rån == "ta") 
                {
                    // Rensar consolen
                    Console.Clear();

                    // Skriver ut händelsen och frågar nästa fråga
                    Console.Write("Du känner dig modig idag och sträcker ut handen för att ta pistolen ifrån mannen... rånaren hinner inte reagera och du håller nu i pistolen... vill du skjuta rånaren eller springa därifrån? (skjuta/springa) ");
                    string pistol1 = Console.ReadLine().ToLower(); // Läser in svaret

                    if (pistol1 == "skjuta") 
                    {
                        // Rensar consolen
                        Console.Clear();

                        // Skriver ut händelsen och frågar nästa fråga
                        Console.Write("Du skjuter rånaren och han faller ner på marken helt blodig... han är död. Alla på bussen börjar skrika och en gammal tant på bussen tar upp mobilen för att ringa polisen, skjuter du henne också eller springer du därifrån? (skjuta/springa) ");
                        string pistol2 = Console.ReadLine().ToLower(); // Läser in svaret
                        
                        if (pistol2 == "skjuta")
                        {
                            Console.Clear();

                            //Ändrar textfärgen till gul
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Du skjuter tanten och du ser rädslan i folket runt omkring dig...du springer snabbt av bussen och går sedan till skolan... Du vann! ");
                            //Slut på programmet
                        }
                        else if(pistol2 == "springa") 
                        {
                            // Rensar consolen
                            Console.Clear();
                            //Ändrar textfärgen till röd
                            Console.ForegroundColor = ConsoleColor.Red;

                            // Skriver ut händelsen och frågar nästa fråga
                            Console.Write("Du struntar i tanten och springer istället av bussen... men halvvägs ut känner du ett pistolskott i ryggen... du faller ihop och när du vänder dig om så ser du tanten stå bredbent och stolt samtidigt som hon ler nöjt mot dig med en pistol i handen... du dog.");
                            // Slut på programmet
                        }
                    }
                    else if(pistol1 == "springa") 
                    {
                        // Rensar consolen
                        Console.Clear();
                        //Ändrar textfärgen till röd
                        Console.ForegroundColor = ConsoleColor.Red;

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
                Console.Write("Du väljer att ta tåget till skolan, men när du kliver av tåget så ramlar du ner på spåret... Nästa tåg kommer om en minut, försöker du klättra upp på perrongen eller gömmer du dig under perrong-skyddet tills nästa tåg har åkt förbi? (klättra/gömma) ");          
                string perrong = Console.ReadLine().ToLower(); // Läser in svaret

                if (perrong == "klättra")
                {   
                    // Rensar consolen
                    Console.Clear();
                    //Ändrar textfärgen till röd
                    Console.ForegroundColor = ConsoleColor.Red;

                    // Skriver ut händelsen
                    Console.WriteLine("Du börjar klättra upp på perrongen men du knuffas ner av alla människor som går förbi... en kort stund efter kommer tåget och kör över dig... du dog.");
                    //Slut på programmet
                }
                else if (perrong == "gömma")
                {   
                    // Rensar consolen
                    Console.Clear();

                    // Skriver ut händelsen och frågar nästa fråga
                    Console.Write("Du gömmer dig under Perrongen och väntar ut tåget... Det kommer sedan personal och hjälper dig upp... efter denna traumatiska händelse tappar du suget att gå till skolan och börja överväga att gå hem istället, vart går du? (skolan/hem) ");
                    string varthän = Console.ReadLine().ToLower(); // Läser in svaret
                    
                    if(varthän == "hem") 
                    {
                        // Rensar consolen
                        Console.Clear();

                        // Skriver ut händelsen och frågar nästa fråga
                        Console.WriteLine("Du väljer att gå hem... men påvägen känner du att du börjar bli hungrig så du vill gå och äta nåt, vad väljer du? (max/mcdonalds) ");
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
                                //Ändrar textfärgen till röd
                                Console.ForegroundColor = ConsoleColor.Red;

                                // Skriver ut händelsen och frågar nästa fråga
                                Console.Write("Du beställer din kyckling burgare och tycker att den luktar lite konstigt men du tar en tugga ändå... du känner smaken av koriander och tappar direkt all kontroll över din kropp... din sista tanke innan du dör är att du aldrig skulle ha gått till Max... McDonalds e ju faktiskt bättre... Du dog.");
                                // Slut på programmet
                            }
                            else if (burgare == "kött") 
                            {
                                // Rensar consolen
                                Console.Clear();
                                //Ändrar textfärgen till röd
                                Console.ForegroundColor = ConsoleColor.Red;

                                // Skriver ut händelsen och frågar nästa fråga
                                Console.Write("Du beställer din kött burgare och tycker att den luktar lite konstigt men du tar en tugga ändå... du känner smaken av koriander och tappar direkt all kontroll över din kropp... din sista tanke innan du dör är att du aldrig skulle ha gått till Max... McDonalds e ju faktiskt bättre... Du dog.");
                                // Slut på programmet
                            }
                        }
                        else if(restaurang == "mcdonalds")
                        {
                            // Rensar consolen
                            Console.Clear();

                            // Skriver ut händelsen och frågar nästa fråga
                            Console.Write("Du går in på McDonalds för att beställa... tar du McNuggets eller kycklingburgare? (mcnuggets/kyckling) ");
                            string donkenMat = Console.ReadLine().ToLower(); // Läser in svaret
                            
                            if (donkenMat == "mcnuggets")
                            {
                                // Rensar consolen
                                Console.Clear();

                                // Skriver ut händelsen och frågar nästa fråga
                                Console.Write("Du får dina McNuggets och de smakar jätte gott! På andra sidan av rummet ser du en annan elev som du känner igen... Stannar du eller går du fram för att prata med personen? (prata/stanna) ");
                                string träff1 = Console.ReadLine().ToLower(); // Läser in svaret

                                if (träff1=="stanna")
                                {   
                                    // Rensar consolen
                                    Console.Clear();
                                    //Ändrar textfärgen till röd
                                    Console.ForegroundColor = ConsoleColor.Red;

                                    // Skriver ut händelsen och frågar nästa fråga
                                    Console.WriteLine("Du väljer att stanna... sekunden efter kommer en man med svart rock in för att råna donken... han börjar med att skjuta dig för att få folkets uppmärksamhet... Du dog.");
                                }
                                else if (träff1=="prata") 
                                {   
                                    // Rensar consolen
                                    Console.Clear(); 
                                    //Ändrar textfärgen till gul
                                    Console.ForegroundColor = ConsoleColor.Yellow; 
                                    
                                    // Frågar och tar in första valet från användaren
                                    Console.WriteLine("Du väljer att gå och prata med personen... när du kommer fram så ser du att det är din bästa kompis... efter det går ni hem och spelar datorspel resten av dagen... Du vann!");
                                    //Slut på programmet
                                }
                            }
                            else if (donkenMat == "kyckling")
                            {
                                // Rensar consolen
                                Console.Clear();

                                // Skriver ut händelsen och frågar nästa fråga
                                Console.Write("Du får din kycklingburgare och den smakar jätte gott! På andra sidan av rummet ser du en annan elev som du känner igen... Stannar du eller går du fram för att prata med personen? (prata/stanna) ");
                                string träff2 = Console.ReadLine().ToLower(); // Läser in svaret

                                if (träff2=="stanna")
                                {   
                                    // Rensar consolen
                                    Console.Clear();
                                    //Ändrar textfärgen till röd
                                    Console.ForegroundColor = ConsoleColor.Red;

                                    // Frågar och tar in första valet från användaren
                                    Console.WriteLine("Du väljer att stanna... sekunden efter kommer en man med svart rock in för att råna donken han börjar med att skjuta dig för att få folkets uppmärksamhet... Du dog.");
                                    //Slut på programmet
                                }
                                else if (träff2=="prata") 
                                {   
                                    // Rensar consolen
                                    Console.Clear(); 
                                    //Ändrar textfärgen till gul
                                    Console.ForegroundColor = ConsoleColor.Yellow; 
                                    
                                    // Frågar och tar in första valet från användaren
                                    Console.WriteLine("Du väljer att gå och prata med personen... när du kommer fram så ser du att det är din bästa kompis... efter det går ni hem och spelar datorspel resten av dagen... Du vann!");
                                }
                            }
                        }
                    }
                    else if(varthän=="skolan")
                    {
                        //Rensar consolen
                        Console.Clear();
                        //Ändrar textfärgen till röd
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine("Du väljer att gå till skolan men påvägen så går du på en landmina... du dog");
                        //slut på programmet
                    }
                }   
            }     
            Console.ReadKey();               
        }
    }
}
