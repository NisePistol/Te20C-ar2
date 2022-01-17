using System;
using Raylib_cs;

namespace Grunder
{
    class Program
    {
        static int ballPosX;
        static int ballPosY;
        static int ballSpeedY;
        static int ballSpeedX;
        static int ballRad;

        static int recW;
        static int recH;
        static int recPosX;
        static int recPosY;

        static int rec2PosX;
        static int rec2PosY;

        static int width = 1000;
        static int height = 600;
        static string title = "Minecraft";

        static int blåPoäng;
        static int rödPoäng;

        static void Main(string[] args)
        {
            int ballStartPosX = width / 2;
            int ballStartPosY = height / 2;

            ballPosX = ballStartPosX;
            ballPosY = ballStartPosY;
            ballRad = 10;
            ballSpeedX = 6;
            ballSpeedY = 6;

            recW = 20;
            recH = 100;
            recPosX = width / 5;
            recPosY = height / 2 - (recH / 2);
            int recSpeed = 10;

            rec2PosX = width / 2 + width / 5;
            rec2PosY = recPosY;

            blåPoäng = 0;
            rödPoäng = 0;

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

                RitaFormer();

                FlyttaSpelare();

                //Om man gör mål
                if (ballPosX - ballRad > width)
                {
                    //Om blå får poäng
                    ballPosX = ballStartPosX;
                    ballPosY = ballStartPosY;
                    blåPoäng++;
                    ballSpeedX *= -1;
                }
                else if (ballPosX + ballRad <= 0)
                {
                    //Om röd får poäng
                    ballPosX = ballStartPosX;
                    ballPosY = ballStartPosY;
                    rödPoäng++;
                    ballSpeedX *= -1;
                }
                //Bollen studsar på kanterna
                else if (ballPosY + ballRad >= height)
                {
                    ballSpeedY *= -1;
                }
                else if (ballPosY - ballRad <= 0)
                {
                    ballSpeedY *= -1;
                }

                //KONTROLL FÖR SPELARE 1
                if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
                {
                    recPosY -= recSpeed;
                }
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
                {
                    recPosY += recSpeed;
                }
                //KONTROLL FÖR SPELARE 2
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
                if (ballPosX - ballRad < recPosX + recW && ballPosY >= recPosY && ballPosY <= recPosY + recH && ballPosX - ballRad! > recPosX)
                {
                    ballSpeedX *= -1;
                }
                else if (ballPosX + ballRad > rec2PosX && ballPosY >= rec2PosY && ballPosY <= rec2PosY + recH && ballPosX + ballRad! < rec2PosX + recW)
                {
                    ballSpeedX *= -1;
                }

                //Avslutar ritningen
                Raylib.EndDrawing();
            }
        }

        static void FlyttaSpelare()
        {
            ballPosX += ballSpeedX;
            ballPosY += ballSpeedY;
        }

        static void RitaFormer()
        {
            //RITA Bollen
            Raylib.DrawCircle(ballPosX, ballPosY, ballRad, Color.BROWN);

            //Rita spelarna
            Raylib.DrawRectangle(recPosX, recPosY, recW, recH, Color.BLUE);
            Raylib.DrawRectangle(rec2PosX, rec2PosY, recW, recH, Color.RED);

            //Rita poäng texten
            Raylib.DrawText($"Poäng: {blåPoäng}", width / 2 - width / 3, 10, width / 27, Color.BLUE);
            Raylib.DrawText($"Poäng: {rödPoäng}", width / 2 + width / 5, 10, width / 27, Color.RED);
        }

        static void Kollision(int posY)
        {
            
            
        }
    }
}
