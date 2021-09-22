using System;

namespace Interaktiv_berättelse
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Väljer du att åka buss eller tåg till skolan? ");
            string transport = Console.ReadLine().ToLower();
            
            if (transport == "buss") 
            {

                Console.Write("Du väljer att ta bussen till skolan. En man med svart rock kliver på bussen... Han tar fram en pistol och ber dig att ge honom alla dina pengar, ger du honom dina pengar eller försöker du ta pistolen ifrån honom? (svara med \"ge\" eller \"ta\") ");
                string rån = Console.ReadLine().ToLower();

                if (rån == "ge") 
                {
                    Console.WriteLine("Du ger mannen alla dina pengar och dör sedan av en hjärtattack från all räddsla");
                }
                else if (rån == "ta") 
                {
                    Console.Write("Du känner dig modig idag och sträcker ut handen för att ta pistolen ifrån mannen... rånaren hinner inte reagera och du håller nu i pistolen... vill du skjuta rånaren eller springa därifrån? (\"skjuta\" eller \"springa\") ");
                    string pistol = Console.ReadLine();
                }
            } 
            
            else if (transport == "tåg") 
            {

                Console.Write("Du väljer att ta tåget till skolan, men när du kliver av tåget så ramlar du ner på spåret... Nästa tåg kommer om en minut, försöker du klättra upp på perrongen eller gömma dig under perrong-skyddet tills nästa tåg har åkt förbi? (svara med \"klättra\" eller \"gömma\"?) ");          
                string perrong = Console.ReadLine().ToLower();

                if (perrong == "klättra")
                {
                    Console.WriteLine("Du börjar klättra upp på perrongen men du lyckas inte komma upp på grund av all rusningstrafik på perrongen... Till sist kommer en man med svart kappa som hjälper dig upp på perrongen... men han tar sen din plånbok och knuffar ner dig på spåret igen, en kort stund efter kommer tåget och kör över dig... du dog.");
                }
                else if (perrong == "gömma")
                {
                    Console.WriteLine();
                }   
            }                    
        }
    }
}
