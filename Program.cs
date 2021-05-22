using System;
using System.Diagnostics;
using System.Threading;

namespace Snake
{
    class Program
    {
        //public static string[] directions = { "up", "down", "left", "right" };
        public static string currentDir = "left";
        //public static bool isDead = false;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(5, 2);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Snake Game!   Press any key to start the game :)");

            Board myBoard = new Board();
            myBoard.GameBoard();
            myBoard.AddDeadPerim();

            //Obstacles
            myBoard.ObstaclesLength(10, 6, 5);
            myBoard.ObstaclesLength(10, 20, 5);
            myBoard.ObstaclesLength(40, 6, 15);
            myBoard.ObstaclesLength(40, 17, 15);
            myBoard.ObstaclesHigh(30, 12, 7);
            myBoard.ObstaclesHigh(50, 7, 5);

            //Create snake
            Snake snake = new Snake();
            snake.CreateSnake();

            //Control keys
            ConsoleKey key = Console.ReadKey(true).Key;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(19, 2);
            Console.WriteLine("                                                       ");

            //create a new instance of StopWatch
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            


            ConsoleKeyInfo cki;
            while (!IsDead())
            {
                while (Console.KeyAvailable == false)
                {
                    if (currentDir == "left")
                    {
                        snake.MoveLeft();
                        Thread.Sleep(200);
                        if (IsDead())
                            break;
                    }
                    if (currentDir == "down")
                    {
                        snake.MoveDown();
                        Thread.Sleep(600);
                        if (IsDead())
                            break;
                    }
                    if (currentDir == "up")
                    {
                        snake.MoveUp();
                        Thread.Sleep(600);
                        if (IsDead())
                            break;
                    }
                    if (currentDir == "right")
                    {
                        snake.MoveRight();
                        Thread.Sleep(200);
                        if (IsDead())
                            break;
                    }
                }
                if (IsDead())
                    break;

                cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.LeftArrow)
                {
                    currentDir = "left";
                }
                if (cki.Key == ConsoleKey.RightArrow)
                {
                    currentDir = "right";
                }
                if (cki.Key == ConsoleKey.UpArrow)
                {
                    currentDir = "up";
                }
                if (cki.Key == ConsoleKey.DownArrow)
                {
                    currentDir = "down";
                }
            }


            bool IsDead()
            {
                for (int i = 0; i < 215; i++)
                {
                    if (snake.horiCursor[snake.tail] == myBoard.deadPoints[i].X)
                        if (snake.vertCursor[snake.tail] == myBoard.deadPoints[i].Y)
                        {
                            return true;
                        }
                }
                for (int i = 0; i < 20; i++)
                {
                    if (snake.horiCursor[snake.tail] == snake.horiCursor[i])
                        if (snake.vertCursor[snake.tail] == snake.vertCursor[i])
                        {
                            if (snake.tail != i)
                            {
                                return true;
                            }
                        }
                }
                
                return false;
            }
            //sound effect when the game end
            Console.Beep();
            //print current time
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(40, 20);
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime: " + elapsedTime);

            // press any key...
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.CursorTop = 26;
        }
    }
}
