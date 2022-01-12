using System;
using Raylib_cs;

namespace Grunder
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 800;
            int height = 600;
            string title = "Minecraft";

            int ballPosX = width / 2;
            int ballPosY = height / 2;
            int ballSpeed = 5;
            int rad = 15;

            Random gen = new Random();
            int fiendeRad = gen.Next(30, 50);
            int fiendePosX = gen.Next(fiendeRad, width - fiendeRad);
            int fiendePosY = gen.Next(fiendeRad, height - fiendeRad);

            //Starta ett fönster
            Raylib.InitWindow(width, height, title);

            //Ställ in FPS
            Raylib.SetTargetFPS(60);

            while (!Raylib.WindowShouldClose())
            {
                //Börja rita
                Raylib.BeginDrawing();

                //Sätter bakgrunden
                Raylib.ClearBackground(Color.BEIGE);

                //RITA SPELARE
                Raylib.DrawCircle(ballPosX, ballPosY, rad, Color.BROWN);

                //KONTROLL
                if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
                {
                    ballPosX += ballSpeed;
                }
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                {
                    ballPosX -= ballSpeed;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                {
                    ballPosY -= ballSpeed;
                }
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
                {
                    ballPosY += ballSpeed;
                }

                //ÅK INTE UTANFÖR SKÄRMEN
                if (ballPosX - rad > width)
                {
                    ballPosX = rad * -1;
                }
                else if (ballPosX + rad < 0)
                {
                    ballPosX = width + rad;
                }
                else if (ballPosY - rad > height)
                {
                    ballPosY = rad * -1;
                }
                else if (ballPosY + rad < 0)
                {
                    ballPosY = height + rad;
                }

                //FIENDE
                Fiende måns = new Fiende(fiendeRad, fiendePosX, fiendePosY);

                

                //Avslutar ritningen
                Raylib.EndDrawing();
            }
        }
    }

    class Fiende
    {
        Random gen = new Random();
        int fiendeRad;
        int fiendePosX;
        int fiendePosY;

        public Fiende(int _fiendeRad, int _fiendePosX, int _fiendePosY)
        {
            int fiendeRad = _fiendeRad;
            int fiendePosX = _fiendePosX;
            int fiendePosY = _fiendePosY;
        }

        void RitaFiende()
        {
            Raylib.DrawCircle(fiendePosX, fiendePosY, fiendeRad, Color.BLACK);
        }
    }
}
