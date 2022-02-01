using Raylib_cs;
using System;

namespace Scener
{
    class Program
    {
        static string scen = "Scen 0";
        static float sek = 60;

        static int bajsX = 100;
        static int bajsY = 100;

        static int spelareCenterX = bajsX + 36;
        static int spelareCenterY = bajsY + 36;

        static int fiendeCenterX;
        static int fiendeCenterY;

        static int spelareHastighet = 5;
        
        static int poäng = 0;

        static Color bakgrundsFärg = Color.LIME;

        static void Main(string[] args)
        {
            Raylib.InitWindow(800, 600, "raylib [cs]");
            Raylib.SetTargetFPS(60);
            Random generator = new Random();

            //Läser in bilderna
            Texture2D spelare = Raylib.LoadTexture(@"./Resurser/emoji.png");
            Texture2D fiende = Raylib.LoadTexture(@"./Resurser/emoji_mad.png");

            Color fiendeColor = Color.LIGHTGRAY;

            //Slumpar fiendens position
            int fiendeX = generator.Next(700);
            int fiendeY = generator.Next(500);

            while (!Raylib.WindowShouldClose())
            {
                Raylib.ClearBackground(bakgrundsFärg);

                if (scen != "Slut")
                {   
                    //Rita scen 1 och 2
                    Scen();

                    //Kontrollen för spelaren
                    SpelareKontroll();

                    //Rita spelare 
                    Raylib.DrawTexture(spelare, bajsX, bajsY, Color.YELLOW);
                    //Rita fiende
                    Raylib.DrawTexture(fiende, fiendeX, fiendeY, fiendeColor);

                    //Om Spelaren nuddar fienden
                    if (spelareCenterX + spelare.width / 2 > fiendeX+36 - fiende.width / 2 && spelareCenterX - spelare.width / 2 < fiendeX+36 + fiende.width / 2 && spelareCenterY + spelare.width / 2 > fiendeY+36 - fiende.width / 2 && spelareCenterY - spelare.width / 2 < fiendeY+36 + fiende.width / 2)
                    {
                        //Byter plats på fienden
                        fiendeX = generator.Next(100, 700);
                        fiendeY = generator.Next(100, 500);
                        poäng++;
                    }

                }

                //Slut scenen
                else if (scen == "Slut")
                {
                    //Rita ut text
                    Raylib.DrawText("Game Over!", 200, 200, 50, Color.RED);
                    Raylib.DrawText($"Poäng: {poäng}", 200, 400, 50, Color.RED);
                }

                //Minska tiden
                sek -= Raylib.GetFrameTime();
                Raylib.EndDrawing();
            }
        }

        static void Scen()
        {
            // Rita ut text
            Raylib.DrawText(scen, 10, 10, 50, Color.RED);
            Raylib.DrawText($"Poäng: {poäng}", 310, 10, 50, Color.RED);

            // Rita ut tiden
            Raylib.DrawText($"Tid {(int)sek}", 600, 10, 50, Color.RED);

            //När det är slut på tiden
            if (sek < 0)
            {
                //Pausar tiden och stänger av hastigheten
                sek = 0;
                spelareHastighet = 0;
                Raylib.DrawText($"Klicka för att gå vidare", 100, 300, 50, Color.RED);

                //När man klickar 'space' kommer man vidare till nästa scen
                if (sek <= 0 && Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
                {
                    spelareHastighet = 10;
                    if (scen == "Scen 0")
                    {
                        //Sätter game state variabler för scen 1
                        scen = "Scen 1";
                        bakgrundsFärg = Color.BLUE;
                        sek = 45;
                    }
                    else
                    {
                        //Sätter game state variabler för slut scenen
                        scen = "Slut";
                        bakgrundsFärg = Color.BROWN;
                    }
                }
            }
        }

        static void SpelareKontroll()
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                bajsX -= spelareHastighet;
                spelareCenterX -= spelareHastighet;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                bajsX += spelareHastighet;
                spelareCenterX += spelareHastighet;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                bajsY -= spelareHastighet;
                spelareCenterY -= spelareHastighet;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                bajsY += spelareHastighet;
                spelareCenterY += spelareHastighet;
            }
        }
    }
}