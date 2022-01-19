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

        static int ballStartPosX;
        static int ballStartPosY;

        static int width = 1000;
        static int height = 600;
        static string title = "Pong";

        static int blåPoäng;
        static int rödPoäng;

        static int winTxtPosX;
        static int winTxtPosY;
        static int border = width - 500;

        static string spelaIgen = "j";

        static void Main(string[] args)
        {
            ballStartPosX = width / 2;
            ballStartPosY = height / 2;

            winTxtPosY = height / 9;
            winTxtPosX = width / 2 - width / 4;

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

            rec2PosX = width - width / 5;
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

                FlyttaBoll();

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
                    ballSpeedX = 0;
                    ballSpeedY = 0;
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
                    ballSpeedY+=1;
                }
                else if (ballPosX + ballRad > rec2PosX && ballPosY >= rec2PosY && ballPosY <= rec2PosY + recH && ballPosX + ballRad! < rec2PosX + recW)
                {
                    ballSpeedX *= -1;
                    ballSpeedY-=1;
                }

                if (blåPoäng >= 5 || rödPoäng >= 5)
                {
                    EndScreen();
                }

                //Avslutar ritningen
                Raylib.EndDrawing();
            }
        }

        static void FlyttaBoll()
        {
            //Flyttar bollen
            ballPosX += ballSpeedX;
            ballPosY += ballSpeedY;
        }

        static void RitaFormer()
        {
            //RITA Bollen
            if (blåPoäng < 5 && rödPoäng < 5)
            {
                Raylib.DrawCircle(ballPosX, ballPosY, ballRad, Color.BROWN);

                //Rita spelarna
                Raylib.DrawRectangle(recPosX, recPosY, recW, recH, Color.BLUE);
                Raylib.DrawRectangle(rec2PosX, rec2PosY, recW, recH, Color.RED);

                //Rita poäng texten
                Raylib.DrawText($"{blåPoäng}", width / 2 - width / 5, 10, width / 15, Color.BLUE);
                Raylib.DrawText($"{rödPoäng}", width / 2 + width / 5, 10, width / 15, Color.RED);

                int lineW = 10;
                Raylib.DrawRectangle(width/2-lineW/2, 10, lineW, height/10, Color.RAYWHITE);
                Raylib.DrawRectangle(width/2-lineW/2, 110, lineW, height/10, Color.RAYWHITE);
                Raylib.DrawRectangle(width/2-lineW/2, 210, lineW, height/10, Color.RAYWHITE);
                Raylib.DrawRectangle(width/2-lineW/2, 310, lineW, height/10, Color.RAYWHITE);
                Raylib.DrawRectangle(width/2-lineW/2, 410, lineW, height/10, Color.RAYWHITE);
                Raylib.DrawRectangle(width/2-lineW/2, 510, lineW, height/10, Color.RAYWHITE);
            }
            else
            {
                Raylib.ClearBackground(Color.BEIGE);
            }
        }

        static void EndScreen()
        {
            string winner = "";
            ballSpeedX = 0;
            ballSpeedY = 0;
            if (blåPoäng == 5)
            {
                winner = "Blå";
            }
            else if (rödPoäng == 5)
            {
                winner = "Röd";
            }

            if (winTxtPosX < border)
            {
                winTxtPosX += 5;
                border = width - 500;
            }
            else
            {
                winTxtPosX -= 5;
                border = 100;
            }

            //Skriver ut vem som vann
            Raylib.DrawText($"{winner} vann!", winTxtPosX, winTxtPosY, width / 10, Color.PINK);
            //Skriver ut "spela igen?"
            Raylib.DrawText($"Spela igen?", width / 3, height / 2, width / 15, Color.GOLD);

            int buttonW = width / 4;
            int buttonH = height / 6;
            int buttonX = width / 2 - (buttonW / 2);
            int buttonY = height - (buttonH + buttonH / 2);

            int txtX = buttonX + (buttonW / 4) + 5;
            int txtY = buttonY + (buttonH / 15);
            int txtSize = 100;

            int mouseX = Raylib.GetMouseX();
            int mouseY = Raylib.GetMouseY();

            Color buttonColor = Color.RAYWHITE;

            //Om man hooverar över knappen
            if (mouseX > buttonX && mouseX < buttonX + buttonW && mouseY > buttonY && mouseY < buttonY + buttonH)
            {
                //Byter knappens färg
                buttonColor = Color.LIGHTGRAY;

                //Gör knappen större
                buttonW += 20;
                buttonH += 15;

                //Fixar positionen
                buttonX -= 10;
                buttonY -= 15 / 2;

                txtSize += 10;
                txtX -= 5;
                txtY -= 5;
            }

            //Om man trycker på börja om knappen, enter eller space
            if (mouseX > buttonX && mouseX < buttonX + buttonW && mouseY > buttonY && mouseY < buttonY + buttonH && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON) || Raylib.IsKeyDown(KeyboardKey.KEY_SPACE) || Raylib.IsKeyDown(KeyboardKey.KEY_ENTER))
            {
                blåPoäng = 0;
                rödPoäng = 0;
                ballSpeedX = 6;
                ballSpeedY = 6;
            }

            //Ritar knappen
            Raylib.DrawRectangle(buttonX, buttonY, buttonW, buttonH, buttonColor);
            //Ritar knappens kanter
            Raylib.DrawRectangleLines(buttonX, buttonY, buttonW, buttonH, Color.BLACK);
            //Ritar texten innuti
            Raylib.DrawText("JA", txtX, txtY, txtSize, Color.BLACK);
        }
    }
}
