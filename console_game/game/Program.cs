using System;

namespace console_game 
{
    public class Program
    {
        public static void Main(String[] args)
        {
            Random random = new Random();
            Console.CursorVisible = false;

            // SetFixedConsoleSize(20, 180);

            int sideBar = 3;
            int height = Console.WindowHeight - sideBar;
            int width = (int)(Console.WindowWidth / 1.5);
            // int bottomCursorPosition = height - 1;
            bool shouldExit = false;

            // player position
            int playerX = 1;
            int playerY = sideBar + 1;

            // food position 
            int foodX = 0;
            int foodY = 0;

            int countPoints = 0;

            string[] playerStates = {"'-'", "^-^", "X_X"};
            string[] foodTypes = {"@@@", "$$$", "###"};

            // starting player state
            string player = playerStates[0];

            // current food index
            int food = 0;

            InitializeGame();

            while (!shouldExit)
            {
                if (TerminalResized())
                {
                    // Console.Clear();

                    Console.WriteLine("\n\n\n\n\t\t\t  ------------------------------------------");
                    Console.WriteLine("\t\t\t  |   Console was resized. Quitting game.  |");
                    Console.WriteLine("\t\t\t  ------------------------------------------\n\n\n");
                    
                    shouldExit = true;
                }
                else 
                {
                    if (PlayerFaster())
                    {
                        Move(2, false);
                    }
                    else if (PlayerStick())
                    {
                        FreezePlayer();
                    }
                    else
                    {
                        Move(otherKeysExit: false);
                    }

                    if (GotFood())
                    {
                        ChangePlayer();
                        ShowFood();
                    }
                }
            }
            if (shouldExit)
            {
                Console.WriteLine("\n\n\n");
            }

            bool TerminalResized()
            {
                // true if terminal was resized
                return height != Console.WindowHeight - sideBar
                    || width != (int)(Console.WindowWidth / 1.5);
            }

            void ShowFood()
            {
                do
                {
                    // randomize food
                    food = random.Next(0, foodTypes.Length);

                    // randomize food position
                    foodX = random.Next(1, width - player.Length - 1);
                    foodY = random.Next(sideBar + 1, height - 1);
                }
                while (foodX != playerX && foodY != playerY);

                // display food 
                Console.SetCursorPosition(foodX, foodY);
                Console.Write(foodTypes[food]);
            }

            bool GotFood()
            {
                // true if player got food
                return playerY == foodY && playerX == foodX;
            }

            bool PlayerStick()
            {
                // true if player stick
                return player.Equals(playerStates[2]);
            }

            bool PlayerFaster()
            {
                // true if player faster
                return player.Equals(playerStates[1]);
            }

            void ChangePlayer()
            {
                // changes the player to match the food consumed
                player = playerStates[food];

                // update points
                if (foodTypes[food] == "@@@")
                {
                    countPoints++;
                }
                else if (foodTypes[food] == "$$$")
                {
                    countPoints += 2;
                }
                else if (foodTypes[food] == "###")
                {
                    countPoints--;
                }

                Console.SetCursorPosition(0, 0);
                Console.Write($"Welcome to my game! \t\t\t\t Points: {countPoints}");

                Console.SetCursorPosition(playerX, playerY);
                Console.Write(player);
            }

            void FreezePlayer()
            {
                // temp stops the player from moving
                System.Threading.Thread.Sleep(1000);
                player = playerStates[0];
            }

            void Move(int speed = 1, bool otherKeysExit = false)
            {
                int lastX = playerX;
                int lastY = playerY;

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                    {
                        playerY--;
                        break;
                    }
                    case ConsoleKey.DownArrow:
                    {
                        playerY++;
                        break;
                    }
                    case ConsoleKey.LeftArrow:
                    {
                        playerX -= speed;
                        break;
                    }
                    case ConsoleKey.RightArrow:
                    {
                        playerX += speed;
                        break;
                    }
                    case ConsoleKey.Escape:
                    {
                        Console.Clear();

                        Console.WriteLine("\n\n\n\t\t\t--------------------------------------------");
                        Console.WriteLine("\t\t\t|   Quitting game. Thanks for playing ^-^  |");
                        Console.WriteLine("\t\t\t  ------------------------------------------\n\n\n");
                        
                        // Console.SetCursorPosition(0, bottomCursorPosition + 3); // ?????
                        shouldExit = true;
                        break;
                    }
                    default:
                    {
                        shouldExit = otherKeysExit;
                        break;
                    }
                }
            
                // clear characters at the previous position
                Console.SetCursorPosition(lastX, lastY);
                for (int i = 0; i < player.Length; i++)
                {
                    Console.Write(" ");
                }

                // keep player within the bounds of window
                playerX = (playerX < 1) ? 1 : (playerX >= width - player.Length ? 
                                                width - player.Length - 1 : playerX);
                playerY = (playerY < sideBar + 1) ? sideBar + 1 : (playerY >= height - 1 ? height - 2 : playerY);

                // draw player at the new location
                Console.SetCursorPosition(playerX, playerY);
                Console.Write(player); 
            }

            void DrawBorders()
            {
                // top borders
                Console.SetCursorPosition(0, sideBar);
                Console.Write("╔" + new string('═', width - 2) + "╗");

                // bottom border
                Console.SetCursorPosition(0, height - 1);
                Console.Write("╚" + new string('═', width - 2) + "╝");

                // side borders
                for (int row = sideBar + 1; row < height - 1; row++)
                {
                    // rigth
                    Console.SetCursorPosition(0, row);
                    Console.Write("║");

                    // left
                    Console.SetCursorPosition(width - 1, row);
                    Console.Write("║");
                }
            }

            void InitializeGame()
            {
                Console.Clear();
                Console.WriteLine($"Welcome to my game! \t\t\t\t Points: {countPoints}" 
                                + "\nPress Esc to exit.\n\n");

                DrawBorders();

                ShowFood();

                Console.SetCursorPosition(playerX, playerY);
                Console.Write(player);
            }
        }

        static void SetFixedConsoleSize(int height, int width)
        {
            try
            {
                Console.WindowHeight = height;
                Console.WindowWidth = width;
            }
            catch (Exception except)
            {
                Console.WriteLine($"Error: {except}");
            }
        }
    }
}