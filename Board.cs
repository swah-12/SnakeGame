using System;
using System.Drawing;

namespace Snake
{
    public class Board
    {
        private int height = 20;
        private int leftMargin = 5;
        private int topMargin = 4;
        private int width = 60;
        public Point[] deadPoints = new Point[220];
        public int x = 0;

        public Board()
        {

        }

        /// <summary>
        /// Display confine area where the snake can move
        /// </summary>
        public void GameBoard()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            for (int i = leftMargin; i < (width + leftMargin); i++)
            {
                for (int j = topMargin; j < (height + topMargin); j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
            }

            for (int i = 0; i < 62; i++)
            {

            }
        }

        /// <summary>
        /// create obstacles
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        public void Obstacles(int left, int top)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(left, top);
            deadPoints[x].X = left;
            deadPoints[x].Y = top;
            x++;
            Console.Write(" ");

        }

        /// <summary>
        /// expand obstacles from left to right
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="width"></param>
        public void ObstaclesLength(int left, int top, int width)
        {
            for (int i = left; i < (left + width); i++)
            {
                Obstacles(i, top);
            }
        }

        /// <summary>
        /// expand obstacles from top to buttom 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="height"></param>
        public void ObstaclesHigh(int left, int top, int height)
        {
            for (int i = top; i < (top + height); i++)
            {
                Obstacles(left, i);
            }
        }

        public void AddDeadPerim()
        {
            for (int i = 0; i < width + 2; i++) //Top Border
            {
                deadPoints[x].X = i + leftMargin - 1;
                deadPoints[x].Y = topMargin - 1;
                x++;
            }
            for (int i = 0; i < width + 2; i++) //Bottom Border
            {
                deadPoints[x].X = i + leftMargin - 1;
                deadPoints[x].Y = topMargin + height;
                x++;
            }
            for (int i = 0; i < height; i++) //Right Border
            {
                deadPoints[x].X = leftMargin + width;
                deadPoints[x].Y = topMargin + i;
                x++;
            }
            for (int i = 0; i < height; i++) //Left Border
            {
                deadPoints[x].X = leftMargin - 1;
                deadPoints[x].Y = topMargin + i;
                x++;
            }
        }
    }
}