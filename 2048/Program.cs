using System;
using _2048.Core;

namespace _2048
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new GameBoard()
                .GenerateNewPiece()
                .GenerateNewPiece();

            bool canMove = true;

            while (canMove)
            {
                Console.Clear();
                Print(board);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                GameBoard originalBoard = board;
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        board = board.ShiftUp();
                        break;
                    case ConsoleKey.LeftArrow:
                        board = board.ShiftLeft();
                        break;
                    case ConsoleKey.RightArrow:
                        board = board.ShiftRight();
                        break;
                    case ConsoleKey.DownArrow:
                        board = board.ShiftDown();
                        break;
                }

                if (!originalBoard.IsEquivalentTo(board))
                    board = board.GenerateNewPiece();
                else
                    canMove = CanMove(board, originalBoard);
            }

            Console.WriteLine("Game Over");
            Console.ReadLine();
        }

        private static bool CanMove(GameBoard board, GameBoard originalBoard)
        {
            GameBoard dummy = board.ShiftLeft();

            if (!dummy.IsEquivalentTo(board))
                return true;

            dummy = board.ShiftRight();

            if (!dummy.IsEquivalentTo(originalBoard))
                return true;

            dummy = board.ShiftUp();

            if (!dummy.IsEquivalentTo(originalBoard))
                return true;

            dummy = board.ShiftDown();

            if (!dummy.IsEquivalentTo(originalBoard))
                return true;

            return false;
        }

        private static void Print(GameBoard board)
        {
            Console.WriteLine("Score: {0,7}", board.Score);
            Console.WriteLine();


            Console.WriteLine("┌───────┬───────┬───────┬───────┐");
            int rowNumber = 0;

            foreach (var row in board.AllRows)
            {
                for (int i = 0; i < 4; i++)
                    Console.Write("│ {0,5} ", row[i]);

                Console.WriteLine("│");

                if(rowNumber != 3)
                    Console.WriteLine("├───────┼───────┼───────┼───────┤");

                rowNumber++;
            }

            Console.WriteLine("└───────┴───────┴───────┴───────┘");
            
        }
    }
}
