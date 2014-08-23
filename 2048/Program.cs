using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2048.Core;

namespace _2048
{
    class Program
    {
        static void Main(string[] args)
        {
            GameBoard board = new GameBoard();
            board = board.GenerateNewPiece();
            board = board.GenerateNewPiece();

            while (true)
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

            }
        }

        private static void Print(GameBoard board)
        {
            foreach (var row in board.AllRows)
            {
                for (int i = 0; i < 4; i++)
                {
                    Console.Write(row[i].ToString().PadLeft(5, ' '));
                }

                Console.WriteLine();
            }
        }
    }
}
