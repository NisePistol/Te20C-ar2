using System;
using Raylib_cs;

namespace Grunder
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 1000;
            int height = 600;
            string title = "Minecraft";

            int ballStartPosX = width / 2;
            int ballStartPosY = height / 2;
            int ballPosX = ballStartPosX;
            int ballPosY = ballStartPosY;
            int rad = 10;
            int ballSpeedX = 6;
            int ballSpeedY = 6;

            int recW = 20;
            int recH = 100;
            int recPosX = width / 5;
            int recPosY = height / 2 - (recH / 2);
            int recSpeed = 15;

            int rec2PosX = width/2+width/4;
            int rec2PosY = recPosY;

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

                Raylib.DrawRectangle(recPosX, recPosY, recW, recH, Color.BLUE);
                Raylib.DrawRectangle(rec2PosX, rec2PosY, recW, recH, Color.RED);

                ballPosX += ballSpeedX * -1;
                ballPosY += ballSpeedY;

                //ÅK INTE UTANFÖR SKÄRMEN
                if (ballPosX + rad > width)
                {
                    ballPosX = ballStartPosX;
                    ballPosY = ballStartPosY;
                    ballSpeedX = 6;
                }
                else if (ballPosX - rad <= 0)
                {
                    ballPosX = ballStartPosX;
                    ballPosY = ballStartPosY;
                }
                else if (ballPosY + rad >= height)
                {
                    ballSpeedY *= -1;
                }
                else if (ballPosY - rad <= 0)
                {
                    ballSpeedY *= -1;
                }


                //KONTROLL
                if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
                {
                    recPosY -= recSpeed;
                }
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
                {
                    recPosY += recSpeed;
                }
                //KONTROLL
                if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                {
                    rec2PosY -= recSpeed;
                }
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
                {
                    rec2PosY += recSpeed;
                }

                //Kollision med kanter för rektangel
                if (recPosY + recH >= height)
                {
                    recPosY = height - recH;
                }
                else if (recPosY <= 0)
                {
                    recPosY = 0;
                }
                //Kollision med kanter för rektangel
                if (rec2PosY + recH >= height)
                {
                    rec2PosY = height - recH;
                }
                else if (rec2PosY <= 0)
                {
                    rec2PosY = 0;
                }

                //Kollision med boll och rektangel
                if (ballPosX - rad < recPosX + recW && ballPosY >= recPosY && ballPosY <= recPosY + recH && ballPosX-rad !> recPosX)
                {
                    ballSpeedX*=-1;
                }
                if (ballPosX + rad > rec2PosX && ballPosY >= rec2PosY && ballPosY <= rec2PosY + recH && ballPosX+rad !< rec2PosX+recW)
                {
                    ballSpeedX*=-1;
                }
                //Avslutar ritningen
                Raylib.EndDrawing();
            }
        }
    }
}
