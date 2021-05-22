using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{

    class Snake
    {
        private int head;
        public int tail;
        private int n;
        private int capacity;
        public int[] horiCursor;
        public int[] vertCursor;

        public Snake()
        {
            capacity = 20;
            head = -1;
            tail = -1;
            n = 0;
            horiCursor = new int[capacity];
            vertCursor = new int[capacity];
        }

        public void CreateSnake()
        {
            for (int i = 0; i < capacity; i++)
            {
                //Console.SetCursorPosition(30 - i, 8);
                Enqueue(40 - i, 9);
            }
            PaintSnake();
        }

        public void PaintSnake()
        {
            for (int i = 0; i < capacity; i++)   //Paints the body of the snake
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(horiCursor[(head + i) % capacity], vertCursor[(head + i) % capacity]);
                Console.Write(" ");
            }

            //Paints the head of the snake
            Console.BackgroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(horiCursor[tail], vertCursor[tail]);
            Console.Write(" ");

            //Console.WriteLine(string.Join(", ", horiCursor));
            //Console.WriteLine(string.Join(", ", vertCursor));
        }

        #region Circular Queue
        public void Enqueue(int horiz, int vert)
        {
            if (IsEmpty())
                head = 0;

            tail++;
            tail %= capacity;
            horiCursor[tail] = horiz;
            vertCursor[tail] = vert;
            n++;
        }

        public void Dequeue()
        {
            Console.SetCursorPosition(horiCursor[head], vertCursor[head]);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write(" ");

            horiCursor[head] = 0; // avoid loitering
            vertCursor[head] = 0; // avoid loitering

            head++;
            head %= capacity;
            n--;

            if (IsEmpty())
            {
                head = -1;
                tail = -1;
            }
        }

        public bool IsEmpty()
        {
            return n == 0;
        }
        #endregion

        #region Movement
        public void MoveLeft()
        {
            Dequeue();
            Enqueue(horiCursor[tail] - 1, vertCursor[tail]);
            PaintSnake();
        }

        public void MoveRight()
        {
            Dequeue();
            Enqueue(horiCursor[tail] + 1, vertCursor[tail]);
            PaintSnake();
        }

        public void MoveUp()
        {
            Dequeue();
            Enqueue(horiCursor[tail], vertCursor[tail] - 1);
            PaintSnake();
        }

        public void MoveDown()
        {
            Dequeue();
            Enqueue(horiCursor[tail], vertCursor[tail] + 1);
            PaintSnake();
        }
        #endregion
    }
}
