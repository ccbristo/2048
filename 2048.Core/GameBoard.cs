using System;
using System.Collections.Generic;
using System.Linq;

namespace _2048.Core
{
    public sealed class GameBoard
    {
        private const int Size = 4;
        private readonly int?[,] Cells;
        private readonly Random Random = new Random();

        public GameBoard()
            : this(new int?[Size, Size])
        { }

        public GameBoard(int?[,] cells)
        {
            if (cells.Rank != 2 ||
                cells.GetUpperBound(0) != Size - 1 ||
                cells.GetUpperBound(1) != Size - 1)
                throw new ArgumentException(string.Format("cells must be a {0}x{0} array.", Size), "cells");

            Cells = cells;
        }

        public IEnumerable<Row> AllRows
        {
            get
            {
                yield return new Row(Cells[0, 0], Cells[0, 1], Cells[0, 2], Cells[0, 3]);
                yield return new Row(Cells[1, 0], Cells[1, 1], Cells[1, 2], Cells[1, 3]);
                yield return new Row(Cells[2, 0], Cells[2, 1], Cells[2, 2], Cells[2, 3]);
                yield return new Row(Cells[3, 0], Cells[3, 1], Cells[3, 2], Cells[3, 3]);
            }
        }

        public GameBoard GenerateNewPiece()
        {
            var template = new { Row = 0, Column = 0 };
            var openCells = Enumerable.Repeat(template, 0).ToList();

            for (int row = 0; row < Size; row++)
                for (int column = 0; column < Size; column++)
                    if (Cells[row, column] == null)
                        openCells.Add(new { Row = row, Column = column });

            int indexToReplace = Random.Next(openCells.Count);
            var itemToReplace = openCells[indexToReplace];

            int newValue = Random.Next(5) == 5 ? 4 : 2;
            GameBoard newBoard = this.ReplaceCell(itemToReplace.Row, itemToReplace.Column, newValue);
            return newBoard;
        }

        private GameBoard ReplaceCell(int rowIndex, int columnIndex, int newValue)
        {
            var newCells = new int?[Size, Size];
            Array.Copy(Cells, newCells, Cells.Length);
            newCells[rowIndex, columnIndex] = newValue;
            return new GameBoard(newCells);
        }

        private GameBoard ReplaceRow(int rowIndex, int?[] newRow)
        {
            var newCells = new int?[Size, Size];
            Array.Copy(Cells, newCells, Cells.Length);
            for (int column = 0; column < Size; column++)
                newCells[rowIndex, column] = newRow[column];

            return new GameBoard(newCells);
        }

        public GameBoard ShiftLeft()
        {
            return Shift();
        }

        public GameBoard ShiftRight()
        {
            return this.ReverseRows().Shift().ReverseRows();
        }

        public GameBoard ShiftUp()
        {
            return Invert().Shift().Invert();
        }

        public GameBoard ShiftDown()
        {
            return Invert()
                .ReverseRows()
                .Shift()
                .ReverseRows()
                .Invert();
        }

        private GameBoard Shift()
        {
            GameBoard board = this;
            for (int rowIndex = 0; rowIndex < Size; rowIndex++)
            {
                int?[] newRow = ShiftRow(rowIndex);
                board = board.ReplaceRow(rowIndex, newRow);
            }

            return board;
        }

        private int?[] ShiftRow(int rowIndex)
        {
            var row = new int?[] { Cells[rowIndex, 0], Cells[rowIndex, 1], Cells[rowIndex, 2], Cells[rowIndex, 3] };
            var nonNulls = row.Where(i => i != null).ToList();
            var remaining = nonNulls.Skip(1).ToList();
            int? previous = nonNulls.FirstOrDefault();
            var result = new List<int?> { previous };

            while (remaining.Count > 0)
            {
                int? current = remaining[0];

                if (previous == current)
                {
                    result[result.Count - 1] = previous * 2;
                    previous = null;
                }
                else
                {
                    previous = current;
                    result.Add(previous);
                }

                remaining.RemoveAt(0);
            }

            while (result.Count < 4)
                result.Add(null);

            return result.ToArray();
        }

        private GameBoard ReverseRows()
        {
            var newCells = new int?[Size, Size];
            Array.Copy(Cells, newCells, Cells.Length);

            for (int row = 0; row < Size; row++)
                for (int column = 0; column < Size; column++)
                    newCells[row, column] = Cells[row, Size - column - 1];

            return new GameBoard(newCells);
        }

        private GameBoard Invert()
        {
            var newCells = new int?[Size, Size];
            for (int column = 0; column < Size; column++)
                for (int row = 0; row < Size; row++)
                    newCells[column, row] = Cells[row, column];

            return new GameBoard(newCells);
        }

        public bool IsEquivalentTo(GameBoard other)
        {
            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            for (int row = 0; row < Size; row++)
                for (int column = 0; column < Size; column++)
                    if (this.Cells[row, column] != other.Cells[row, column])
                        return false;

            return true;
        }
    }
}