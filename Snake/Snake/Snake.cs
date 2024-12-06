namespace Snake
{
    internal class Program
    {
        private static void Main()
        {
            Console.WindowHeight = 16;
            Console.WindowWidth = 32;
            int screenWidth = Console.WindowWidth;
            int screenHeight = Console.WindowHeight;
            Random randomNumberGenerator = new();
            Pixel firstHead = new()
            {
                XPos = screenWidth / 2,
                YPos = screenHeight / 2,
                ScreenColor = ConsoleColor.Red
            };
            string movement = "RIGHT";
            List<int> axis = [];
            int score = 0;
            Pixel secondHead = new()
            {
                XPos = screenWidth / 2,
                YPos = screenHeight / 2,
                ScreenColor = ConsoleColor.Red
            };
            List<int> axisPosition = [secondHead.XPos, secondHead.YPos];
            string obstacle = "*";
            int obstacleXpos = randomNumberGenerator.Next(1, screenWidth);
            int obstacleYpos = randomNumberGenerator.Next(1, screenHeight);

            while (true)
            {
                Console.Clear();

                //Draw Obstacle
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(obstacleXpos, obstacleYpos);
                Console.Write(obstacle);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(secondHead.XPos, secondHead.YPos);
                Console.Write("■");

                Console.ForegroundColor = ConsoleColor.White;
                for (int i = 0; i < screenWidth; i++)
                {
                    Console.SetCursorPosition(i, 0);
                    Console.Write("■");
                }

                for (int i = 0; i < screenWidth; i++)
                {
                    Console.SetCursorPosition(i, screenHeight - 1);
                    Console.Write("■");
                }

                for (int i = 0; i < screenHeight; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write("■");
                }

                for (int i = 0; i < screenHeight; i++)
                {
                    Console.SetCursorPosition(screenWidth - 1, i);
                    Console.Write("■");
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Score: " + score);

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("H");

                for (int i = 0; i < axis.Count; i++)
                {
                    Console.SetCursorPosition(axis[i], axis[i + 1]);
                    Console.Write("■");
                }

                //Draw Snake
                Console.SetCursorPosition(secondHead.XPos, secondHead.YPos);
                Console.Write("■");

                Console.SetCursorPosition(secondHead.XPos, secondHead.YPos);
                Console.Write("■");

                Console.SetCursorPosition(secondHead.XPos, secondHead.YPos);
                Console.Write("■");

                Console.SetCursorPosition(secondHead.XPos, secondHead.YPos);
                Console.Write("■");

                ConsoleKeyInfo info = Console.ReadKey();

                //Game Logic
                switch (info.Key)
                {
                    case ConsoleKey.UpArrow:
                        movement = "UP";

                        break;

                    case ConsoleKey.DownArrow:
                        movement = "DOWN";

                        break;

                    case ConsoleKey.LeftArrow:
                        movement = "LEFT";

                        break;

                    case ConsoleKey.RightArrow:
                        movement = "RIGHT";

                        break;
                }

                if (movement == "UP")
                    secondHead.YPos--;

                if (movement == "DOWN")
                    secondHead.YPos++;

                if (movement == "LEFT")
                    secondHead.XPos--;

                if (movement == "RIGHT")
                    secondHead.XPos++;

                // Obstacle Hitting
                if (secondHead.XPos == obstacleXpos && secondHead.YPos == obstacleYpos)
                {
                    score++;
                    obstacleXpos = randomNumberGenerator.Next(1, screenWidth);
                    obstacleYpos = randomNumberGenerator.Next(1, screenHeight);
                }

                axisPosition.Insert(0, secondHead.XPos);
                axisPosition.Insert(1, secondHead.YPos);

                axisPosition.RemoveAt(axisPosition.Count - 1);
                axisPosition.RemoveAt(axisPosition.Count - 1);

                // Collision with wall or with yourself
                if (secondHead.XPos == 0 || secondHead.XPos == screenWidth - 1 || secondHead.YPos == 0 || secondHead.YPos == screenHeight - 1)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(screenWidth / 5, screenHeight / 2);
                    Console.WriteLine("Game Over");

                    Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 1);
                    Console.WriteLine("Dein Score ist: " + score);

                    Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 2);

                    Environment.Exit(0);
                }

                for (int i = 0; i < axis.Count; i += 2)
                {
                    if (secondHead.XPos == axis[i] && secondHead.YPos == axis[i + 1])
                    {
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(screenWidth / 5, screenHeight / 2);

                        //???

                        Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 1);
                        Console.WriteLine("Dein Score ist: " + score);

                        Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 2);

                        Environment.Exit(0);
                    }
                }

                Thread.Sleep(50);
            }
        }
    }
}