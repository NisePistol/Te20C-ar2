using System;
using Raylib_cs;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialisering
            //--------------------------------------------------------------------------------------
            const int fönsterB = 800;
            const int fönsterH = 600;

            Raylib.InitWindow(fönsterB, fönsterH, "raylib [cs]");
            Raylib.SetTargetFPS(60);

            // TODO: Infoga variabler och objekt här
            //--------------------------------------------------------------------------------------

            // Animationsloopen
            while (!Raylib.WindowShouldClose())
            {
                // Updatering
                //----------------------------------------------------------------------------------
                // TODO: Uppdatera variabler här
                //----------------------------------------------------------------------------------

                // Rita
                //----------------------------------------------------------------------------------
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);

                Raylib.DrawText("Mitt första fönster!", 190, 200, 20, Color.GRAY);

                Raylib.EndDrawing();
                //----------------------------------------------------------------------------------
            }
        }
    }
}