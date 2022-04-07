using System;
using Raylib_cs;

namespace Pong
{
    class Program
    {
        static int screenWidth = 1200;
        static int screenHeight = 600;
        static string title = "Pong";

        static int ballStartPosX = screenWidth / 2;
        static int ballStartPosY = screenHeight / 2;

        static int ballPosX = ballStartPosX;
        static int ballPosY = ballStartPosY;

        static int ballSpeedX = -6;
        static int ballSpeedY = 6;
        static int ballRad = 10;

        static int blueScore = 0;
        static int redScore = 0;

        static int winTxtPosX = screenWidth / 2 - screenWidth / 4;
        static int winTxtPosY = screenHeight / 9;
        static int border = screenWidth / 20;

        static int mouseX;
        static int mouseY;

        static int scen = 0;

        static bool flag = true;

        static Random generator = new Random();

        static string name1;
        static string name2;
        static Color nameColor = Color.BLUE;
        static int nameX = screenWidth / 2 - 25;
        static int nameSize = 75;

        static bool overlay = true;

        static void Main(string[] args)
        {
            //Starta ett fönster
            Raylib.InitWindow(screenWidth, screenHeight, title);

            //Ställ in FPS
            Raylib.SetTargetFPS(60);

            while (!Raylib.WindowShouldClose())
            {
                //Börja rita
                Raylib.BeginDrawing();

                //Sätter bakgrunden
                Raylib.ClearBackground(Color.BEIGE);

                //Kör start scenen
                if (scen == 0)
                {
                    StartScreen();
                }

                //Kör namn scenen
                if (scen == 1)
                {
                    NameScreen();
                }

                //Kör själva spelet
                if (scen == 2)
                {

                    if (overlay)
                    {
                        Raylib.DrawRectangle(0, 0, screenWidth, screenHeight, Color.LIGHTGRAY);
                        Raylib.DrawText("W", 175, 500, 50, Color.BLACK);
                        Raylib.DrawText("S", 275, 500, 50, Color.BLACK);
                        Raylib.DrawText("UP", 875, 500, 50, Color.BLACK);
                        Raylib.DrawText("Down", 1000, 500, 50, Color.BLACK);

                        Raylib.DrawRectangleLines(162, 490, 62, 62, Color.BLACK);
                        Raylib.DrawRectangleLines(260, 490, 62, 62, Color.BLACK);
                        Raylib.DrawRectangleLines(862, 490, 88, 62, Color.BLACK);
                        Raylib.DrawRectangleLines(987, 490, 150, 62, Color.BLACK);
                        if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
                        {
                            overlay = false;
                        }
                    }
                    else
                    {
                        //Kollar efter input för spelaren och flyttar på spelaren
                        Player.PlayerController();

                        //Flyttar på bollen
                        MoveBall();
                    }

                    //Om ingen har vunnit så ritas spelarna
                    if (blueScore < 5 && redScore < 5)
                    {
                        Player.DrawPlayer();
                    }

                    //Ritar user interface
                    DrawUI();

                    //Kollar om bollen nuddar nån av spelarna
                    BallPlayerCollision(Player.player1PosX, Player.player1PosY, Player.player2PosX, Player.player2PosY, Player.playerW, Player.playerH);

                    //Kör slut scenen
                    if (blueScore >= 5 || redScore >= 5)
                    {
                        EndScreen();
                    }
                }

                //Avslutar ritningen
                Raylib.EndDrawing();
            }
        }

        static void NameScreen()
        {
            Raylib.DrawText("ENTER NAME", screenWidth / 3 - 50, 20, 75, Color.RAYWHITE);
            //Om spelare 1 väljer namn
            if (flag)
            {
                //Lägger till en bokstav och ritar ut det
                name1 += WriteNameText(name1);

                if (name1.Length > 0)
                {
                    //Om man klickar på backspace eller skriver in fler än 6 bokstäver
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_BACKSPACE) || name1.Length > 6)
                    {
                        //Raderar den senaste bokstaven i "name1"
                        name1 = RemoveLetter(name1);
                    }
                }
            }
            //Om spelare 2 väljer namn
            else
            {
                //Lägger till en bokstav och ritar ut det
                name2 += WriteNameText(name2);

                if (name2.Length > 0)
                {
                    //Om man klickar på backspace eller skriver in fler än 6 bokstäver
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_BACKSPACE) || name2.Length > 6)
                    {
                        //Raderar den senaste bokstaven i "name2"
                        name2 = RemoveLetter(name2);
                    }
                }
            }

            //När man valt sitt namn så klickar man enter för att komma vidare
            if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER) && flag && name1.Length > 0)
            {
                //Ändrar boolens värde så att spelare 2 kan välja namn
                flag = false;

                //Ändrar färgen
                nameColor = Color.RED;

                //Återställer name positionen
                nameX = screenWidth / 2 - 20;
            }
            //När spelare 2 har valt sitt namn
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER) && !flag && name2.Length > 0)
            {
                //Byter scen
                scen = 2;
            }
        }

        static string WriteNameText(string name)
        {
            Raylib.DrawText(name, nameX, 100, nameSize, nameColor);
            return AddLetter();
        }
        static string RemoveLetter(string name)
        {
            //Raderar den senaste bokstaven i "name1"
            name = name.Remove(name.Length - 1);
            nameX += 15;
            return name;
        }

        static void BallPlayerCollision(int recPosX, int recPosY, int rec2PosX, int rec2PosY, int recW, int recH)
        {
            //Om man gör mål
            if (ballPosX - ballRad > screenWidth)
            {
                //Om blå får poäng
                ballPosX = ballStartPosX;
                ballPosY = ballStartPosY;
                blueScore++;
                ballSpeedX *= -1;
                //slumpar om bollen åker upp eller ner i början
                int slump = generator.Next(2);
                if (slump == 1)
                {
                    ballSpeedY *= -1;
                }
            }
            else if (ballPosX + ballRad <= 0)
            {
                //Om röd får poäng
                ballPosX = ballStartPosX;
                ballPosY = ballStartPosY;
                redScore++;
                ballSpeedX *= -1;

                //slumpar om bollen åker upp eller ner i början
                int slump = generator.Next(2);
                if (slump == 1)
                {
                    ballSpeedY *= -1;
                }
            }
            //Bollen studsar på kanterna
            else if (ballPosY + ballRad >= screenHeight)
            {
                ballSpeedY *= -1;
            }
            else if (ballPosY - ballRad <= 0)
            {
                ballSpeedY *= -1;
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
        }

        static void StartScreen()
        {
            Raylib.ClearBackground(Color.BEIGE);

            //"Play" textens värden
            int playX = screenWidth / 2 - screenWidth / 5;
            int playY = screenHeight / 7;

            //"Play" knappens värden
            int playButtonX = playX - 40;
            int playButtonY = playY - 10;
            int playButtonW = screenWidth / 2;
            int playButtonH = screenWidth / 6;

            int pwX = screenWidth / 2 - screenWidth / 3;
            int pwY = screenHeight - screenHeight / 3 - 45;
            Color playColor = Color.BLANK;
            Color pwColor = Color.BLANK;

            //"Power" knappens värden
            int pwButtonX = pwX - 40;
            int pwButtonY = pwY - 10;
            int pwButtonW = screenWidth / 2 + screenWidth / 3 - 75;
            int pwButtonH = screenWidth / 6;

            //Hämtar musens position
            mouseX = Raylib.GetMouseX();
            mouseY = Raylib.GetMouseY();

            DrawBackground();

            //Om man hooverar över play knappen
            if (mouseX > playButtonX && mouseX < playButtonX + playButtonW && mouseY > playButtonY && mouseY < playButtonY + playButtonH || Raylib.IsKeyDown(KeyboardKey.KEY_UP))
            {
                playColor = Color.GRAY;
            }
            //Om man trycker på play knappen
            if (mouseX > playButtonX && mouseX < playButtonX + playButtonW && mouseY > playButtonY && mouseY < playButtonY + playButtonH && Raylib.IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON))
            {
                scen = 1;
            }

            //Om man hovverar över power knappen
            if (mouseX > pwButtonX && mouseX < pwButtonX + pwButtonW && mouseY > pwButtonY && mouseY < pwButtonY + pwButtonH)
            {
                pwColor = Color.GRAY;
            }
            //Om man trycker på power knappen
            if (mouseX > pwButtonX && mouseX < pwButtonX + pwButtonW && mouseY > pwButtonY && mouseY < pwButtonY + pwButtonH && Raylib.IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON))
            {
                //PowerScreen();
            }

            Raylib.DrawRectangle(playButtonX, playButtonY, playButtonW, playButtonH, playColor);
            Raylib.DrawRectangle(pwButtonX, pwButtonY, pwButtonW, pwButtonH, pwColor);

            Raylib.DrawText("PLAY", playX, playY, screenWidth / 6, Color.RAYWHITE);
            Raylib.DrawText("POWERS", pwX, pwY, screenWidth / 6, Color.RAYWHITE);
        }

        static void DrawBackground()
        {

        }

        static void MoveBall()
        {
            //Flyttar bollen
            ballPosX += ballSpeedX;
            ballPosY += ballSpeedY;
        }

        static void DrawUI()
        {
            //RITA Bollen
            if (blueScore < 5 && redScore < 5)
            {
                //Rita poäng texten
                Raylib.DrawText($"{blueScore}", screenWidth / 2 - screenWidth / 5, 10, screenWidth / 15, Color.BLUE);
                Raylib.DrawText($"{redScore}", screenWidth / 2 + screenWidth / 5, 10, screenWidth / 15, Color.RED);

                int lineW = 10;
                Raylib.DrawRectangle(screenWidth / 2 - lineW / 2, 20, lineW, screenHeight / 10, Color.RAYWHITE);
                Raylib.DrawRectangle(screenWidth / 2 - lineW / 2, 120, lineW, screenHeight / 10, Color.RAYWHITE);
                Raylib.DrawRectangle(screenWidth / 2 - lineW / 2, 220, lineW, screenHeight / 10, Color.RAYWHITE);
                Raylib.DrawRectangle(screenWidth / 2 - lineW / 2, 320, lineW, screenHeight / 10, Color.RAYWHITE);
                Raylib.DrawRectangle(screenWidth / 2 - lineW / 2, 420, lineW, screenHeight / 10, Color.RAYWHITE);
                Raylib.DrawRectangle(screenWidth / 2 - lineW / 2, 520, lineW, screenHeight / 10, Color.RAYWHITE);

                //Rita bollen
                Raylib.DrawCircle(ballPosX, ballPosY, ballRad, Color.BROWN);
                Raylib.DrawRectangle(ballPosX, ballPosY, ballRad * 2, ballRad * 2, Color.BROWN);
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

            if (blueScore == 5)
            {
                winner = name1;
            }
            else
            {
                winner = name2;
            }

            AnimateText();

            //Skriver ut vem som vann
            Raylib.DrawText($"{winner} WON!", winTxtPosX, winTxtPosY, screenWidth / 10, Color.BROWN);
            //Skriver ut "spela igen?"
            Raylib.DrawText($"PLAY AGAIN?", screenWidth / 3 - 55, screenHeight / 2, screenWidth / 15, Color.GOLD);

            int buttonW = screenWidth / 4;
            int buttonH = screenHeight / 6;
            int buttonX = screenWidth / 2 - (buttonW / 2);
            int buttonY = screenHeight - (buttonH + buttonH / 2);

            int txtX = buttonX + (buttonW / 4) + 5;
            int txtY = buttonY + (buttonH / 15);
            int txtSize = 100;

            mouseX = Raylib.GetMouseX();
            mouseY = Raylib.GetMouseY();

            Color buttonColor = Color.RAYWHITE;

            //Om man hooverar över "JA" knappen
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

            //Om man trycker på "JA" knappen, enter eller space
            if (mouseX > buttonX && mouseX < buttonX + buttonW && mouseY > buttonY && mouseY < buttonY + buttonH && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON) || Raylib.IsKeyDown(KeyboardKey.KEY_SPACE) || Raylib.IsKeyDown(KeyboardKey.KEY_ENTER))
            {
                ResetVariables();
            }

            //Ritar knappen
            Raylib.DrawRectangle(buttonX, buttonY, buttonW, buttonH, buttonColor);
            //Ritar knappens kanter
            Raylib.DrawRectangleLines(buttonX, buttonY, buttonW, buttonH, Color.BLACK);
            //Ritar texten innuti
            Raylib.DrawText("JA", txtX, txtY, txtSize, Color.BLACK);
        }

        static void ResetVariables()
        {
            //Återställer bådas poäng
            blueScore = 0;
            redScore = 0;

            //Återställer bollens hastighet
            ballSpeedX = 6;
            ballSpeedY = 6;

            //Återställer spelarna
            Player.ResetPlayers();

            //Återställer spelarnas namn
            name1 = "";
            name2 = "";

            //Sätter tillbaka flag till true så att spelare 1 får välja namn först
            flag = true;

            //Sätter på första scenen
            scen = 0;

            //Återställer namn färgen
            nameColor = Color.BLUE;
        }

        static void AnimateText()
        {
            if (winTxtPosX < border)
            {
                winTxtPosX += 5;
                border = screenWidth - 800;
            }
            else
            {
                winTxtPosX -= 5;
                border = screenWidth / 20;
            }
        }

        static string AddLetter()
        {
            int decrement = 15;
            string n = "";
            //Variabeln "n" får värdet för bokstaven man trycker på och metoden returnerar sedan n
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_A))
            {
                n = "A";
                //För snygghetsskull så flyttas texten för ens namn lite til vänster varje gång man skriver in en bokstav
                nameX -= decrement;
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_B))
            {
                n = "B";
                nameX -= decrement;
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_C))
            {
                n = "C";
                nameX -= decrement;
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_D))
            {
                n = "D";
                nameX -= decrement;
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_E))
            {
                n = "E";
                nameX -= decrement;
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_F))
            {
                n = "F";
                nameX -= decrement;
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_G))
            {
                n = "G";
                nameX -= decrement;
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_H))
            {
                n = "H";
                nameX -= decrement;
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_I))
            {
                n = "I";
                nameX -= decrement;
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_J))
            {
                n = "J";
                nameX -= decrement;
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_K))
            {
                n = "K";
                nameX -= decrement;
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_L))
            {
                n = "L";
                nameX -= decrement;
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_M))
            {
                n = "M";
                nameX -= decrement;
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_N))
            {
                n = "N";
                nameX -= decrement;
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_O))
            {
                n = "O";
                nameX -= decrement;
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_P))
            {
                n = "P";
                nameX -= decrement;
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_Q))
            {
                n = "Q";
                nameX -= decrement;
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_R))
            {
                n = "R";
                nameX -= decrement;
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_S))
            {
                n = "S";
                nameX -= decrement;
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_T))
            {
                n = "T";
                nameX -= decrement;
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_U))
            {
                n = "U";
                nameX -= decrement;
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_V))
            {
                n = "V";
                nameX -= decrement;
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_W))
            {
                n = "W";
                nameX -= decrement;
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_X))
            {
                n = "X";
                nameX -= decrement;
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_Y))
            {
                n = "Y";
                nameX -= decrement;
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_Z))
            {
                n = "Z";
                nameX -= decrement;
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                n = " ";
                nameX -= decrement;
            }

            return n;
        }
    }

    class Player
    {
        static int screenWidth = 1200;
        static int screenHeight = 600;

        public static int playerW = 20;
        public static int playerH = 100;

        static int player1StartPosX = (screenWidth / 5) - 2;
        static int player1StartPosY = screenHeight / 2 - (playerH / 2);
        public static int player1PosX = player1StartPosX;
        public static int player1PosY = player1StartPosY;

        static int player2StartPosX = (screenWidth - screenWidth / 5) + 1;
        static int player2StartPosY = player1PosY;
        public static int player2PosX = player2StartPosX;
        public static int player2PosY = player2StartPosY;

        public static void PlayerController()
        {
            int recSpeed = 10;
            //KONTROLL FÖR SPELARE 1
            if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                player1PosY -= recSpeed;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                player1PosY += recSpeed;
            }
            //KONTROLL FÖR SPELARE 2
            if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
            {
                player2PosY -= recSpeed;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
            {
                player2PosY += recSpeed;
            }

            //Kollision med kanter för rektangel
            if (player1PosY + playerH >= screenHeight)
            {
                player1PosY = screenHeight - playerH;
            }
            else if (player1PosY <= 0)
            {
                player1PosY = 0;
            }
            //Kollision med kanter för rektangel
            if (player2PosY + playerH >= screenHeight)
            {
                player2PosY = screenHeight - playerH;
            }
            else if (player2PosY <= 0)
            {
                player2PosY = 0;
            }
        }

        public static void DrawPlayer()
        {
            //Rita spelarna
            Raylib.DrawRectangle(player1PosX, player1PosY, playerW, playerH, Color.BLUE);
            Raylib.DrawRectangle(player2PosX, player2PosY, playerW, playerH, Color.RED);
        }

        public static void ResetPlayers()
        {
            //Återställer spelare 1s position
            player1PosX = player1StartPosX;
            player1PosY = player1StartPosY;

            //Återställer spelare 1s position
            player2PosX = player2StartPosX;
            player2PosY = player2StartPosY;
        }
    }
}
