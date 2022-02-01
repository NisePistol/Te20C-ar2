using System;
using Raylib_cs;

namespace Snowflakes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialisering
            //--------------------------------------------------------------------------------------
            const int fönsterB = 800;
            const int fönsterH = 600;

            Raylib.InitWindow(fönsterB, fönsterH, "Snöflingor");
            Raylib.SetTargetFPS(60);

            // TODO: Infoga variabler och objekt här
            Rectangle snö = new Rectangle(0, 0, 10, 10);

            // Animationsloopen
            while (!Raylib.WindowShouldClose())
            {
                // Updatering
                //----------------------------------------------------------------------------------
                // TODO: Uppdatera variabler här
                //----------------------------------------------------------------------------------

                // Rita
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.DARKBLUE);

                Raylib.DrawRectangleRec(snö, Color.WHITE);
                Raylib.DrawText("Mitt första fönster!", 190, 200, 20, Color.GRAY);

                Raylib.EndDrawing();
                //----------------------------------------------------------------------------------
            }
        }
    }
}