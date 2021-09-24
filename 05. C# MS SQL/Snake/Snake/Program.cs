using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static Snake.Program;

namespace Snake
{
    public class Direction
    {
        private Coordinates coordinatesDirection;
        private string name;
        
        public Direction()
        {
            this.coordinatesDirection = new Coordinates(0, 0);
        }
        public Direction(string direction)
        {
            if (direction == "right")
            {
                this.coordinatesDirection = new Coordinates(0, 1);
                this.Name = "right";
            }
            else if (direction == "left")
            {
                this.coordinatesDirection = new Coordinates(0, -1);
                this.Name = "left";
            }
            else if (direction == "up")
            {
                this.coordinatesDirection = new Coordinates(-1, 0);
                this.Name = "up";
            }
            else if (direction == "down")
            {
                this.coordinatesDirection = new Coordinates(1, 0);
                this.Name = "down";
            }
        }


        public Coordinates CoordinatesDirection
        {
            get { return coordinatesDirection; }
            private set { coordinatesDirection = value; }
        }
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public void ChangeDirection(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                this.CoordinatesDirection = new Coordinates(-1, 0);
                this.Name = "up";
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                this.CoordinatesDirection = new Coordinates(1, 0);
                this.Name = "down";
            }
            else if (keyInfo.Key == ConsoleKey.LeftArrow)
            {
                this.CoordinatesDirection = new Coordinates(0, -1);
                this.Name = "left";
            }
            else if (keyInfo.Key == ConsoleKey.RightArrow)
            {
                this.CoordinatesDirection = new Coordinates(0, 1);
                this.Name = "right";
            }
        }
    }

    public class Snake
    {
        private Queue<Coordinates> snakeParts;
        private Coordinates snakeHead;
        private Direction direction;

        public Snake(Queue<Coordinates> snakeParts)
        {
            this.snakeParts = snakeParts;
            this.snakeHead = this.snakeParts.Last();
            this.direction = new Direction("right");
        }

        public IReadOnlyCollection<Coordinates> SnakeParts
        {
            get { return this.snakeParts.ToList().AsReadOnly(); }
        }

        public Coordinates SnakeHead
        {
            get { return this.snakeHead; }
            set 
            {
                if (value.col < 0 || value.row < 0)
                {
                    throw new ArgumentException("Invalid Coordinates for SnakeHead");
                }
                this.snakeHead = value;
            }
        }

        public Direction Direction 
        { 
            get { return this.direction; } 
            set { this.direction = value; }
        }


        public void Move()
        {
            this.snakeParts.Enqueue(new Coordinates(this.snakeHead.row + direction.CoordinatesDirection.row, this.snakeHead.col + direction.CoordinatesDirection.col));
            this.SnakeHead = this.snakeParts.Last();
            var droppedPartCoordinates = this.snakeParts.Dequeue();
            Console.SetCursorPosition(droppedPartCoordinates.col, droppedPartCoordinates.row);
            Console.Write(' ');
            Console.SetCursorPosition(SnakeHead.col, SnakeHead.row);
            Console.Write('*');
            
        }
        public void AddPart(Coordinates coordinatesOfNewPart)
        {
            this.snakeParts.Enqueue(coordinatesOfNewPart);
            this.snakeHead = this.snakeParts.Last();
        }

        public void RemovePart()
        {
            this.snakeParts.Dequeue();
        }
    }

    public class Program
    {
        public struct Coordinates
        {
            public Coordinates(int row, int col)
            {
                this.row = row;
                this.col = col;
            }

            public int col { get; }
            public int row { get; }
        }

        public static void Main()
        {
            Queue<Coordinates> snakeParts = new Queue<Coordinates>();

            for (int i = 0; i < 4; i++)
            {
                snakeParts.Enqueue(new Coordinates(0, i));
            }
            Snake snake = new Snake(snakeParts);

            foreach (var item in snake.SnakeParts)
            {
                Console.SetCursorPosition(item.col, item.row);
                Console.Write('*');
            }

            string[,] board = new string[20, 40];

            for (int i = 0; i < board.GetLength(1); i++)
            {
                board[0, i] = "#";
            }
            for (int i = 1; i < board.GetLength(0) - 1; i++)
            {
                Console.Write("#");
                for (int j = 1; j < board.GetLength(1) - 1; j++)
                {
                    Console.Write(' ');
                }
                Console.Write("#");
                Console.WriteLine();
            }
            for (int i = 0; i < board.GetLength(1); i++)
            {
                board[board.GetLength(0) - 1, i] = "#";
            }

            foreach (var item in board)
            {
                Console.WriteLine(string.Join("", item));
            }

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    snake.Direction.ChangeDirection(Console.ReadKey());
                }
                snake.Move();
                Thread.Sleep(300);
            }
        }
    }
}
