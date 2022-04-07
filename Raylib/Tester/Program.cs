using System;
using Raylib_cs;
using System.Numerics;

namespace Tester
{
    class Program
    { 
        static void Main(string[] args)
        {
            // Starta grafikmotorn
            Raylib.InitWindow(800, 600, "Mitt Raylib fönster");

            // Bestäm skärmuppdatering
            Raylib.SetTargetFPS(60);
            
            

            while (!Raylib.WindowShouldClose())
            {
                // Börja rita
                Raylib.BeginDrawing();

                // Töm ritytan
                Raylib.ClearBackground(Color.DARKBLUE);

                

                // Ritat ut på fönstret
                Raylib.EndDrawing();


            }
        }
    }
}
