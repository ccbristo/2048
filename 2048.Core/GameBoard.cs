using System;
using System.Collections.Generic;
using System.Linq;

namespace _2048.Core
{
    public sealed class GameBoard
    {
        public Row Row1 { get; private set; }
        public Row Row2 { get; private set; }
        public Row Row3 { get; private set; }
        public Row Row4 { get; private set; }

        public IEnumerable<Row> AllRows
        {
            get
            {
                yield return Row1;
                yield return Row2;
                yield return Row3;
                yield return Row4;
            }
        }

        private readonly Random Random = new Random();

        public GameBoard()
            : this(Row.Empty, Row.Empty, Row.Empty, Row.Empty)
        { }

        public GameBoard(Row row1, Row row2, Row row3, Row row4)
        {
            Row1 = row1;
            Row2 = row2;
            Row3 = row3;
            Row4 = row4;
        }

        public GameBoard GenerateNewPiece()
        {
            while (true)
            {
                int rowIndex = Random.Next(3);
                Row row = AllRows.Skip(rowIndex).First();
                
                if (row.Full)
                    continue;

                int cell = Random.Next(3);
                if (row[cell] != null)
                    continue;

                int nextValue = Random.Next(5) == 5 ? 4 : 2;
                Row newRow = row.SetCell(cell, nextValue);
                GameBoard newBoard = this.Replace(rowIndex, newRow);
                return newBoard;
            }
        }

        private GameBoard Replace(int rowNumber, Row newRow)
        {
            return new GameBoard(
                rowNumber == 0 ? newRow : Row1,
                rowNumber == 1 ? newRow : Row2,
                rowNumber == 2 ? newRow : Row3,
                rowNumber == 3 ? newRow : Row4);
        }

        public GameBoard ShiftLeft()
        {
            bool shifted;
            return HorizontalShift(r => r.ShiftLeft(out shifted));
        }

        public GameBoard ShiftRight()
        {
            bool shifted;
            return HorizontalShift(r => r.ShiftRight(out shifted));
        }

        private GameBoard HorizontalShift(Func<Row, Row> shiftFunc)
        {
            var rows = new[] { Row1, Row2, Row3, Row4 };
            var newRows = rows.Select(shiftFunc).ToList();

            return new GameBoard(newRows[0],
                                 newRows[1],
                                 newRows[2],
                                 newRows[3]);
        }

        public GameBoard ShiftUp()
        {
            return Transpose().ShiftLeft().Transpose();
        }

        public GameBoard ShiftDown()
        {
            return Transpose().ShiftRight().Transpose();
        }

        private GameBoard Transpose()
        {
            var row1 = new Row(Row1.A, Row2.A, Row3.A, Row4.A);
            var row2 = new Row(Row1.B, Row2.B, Row3.B, Row4.B);
            var row3 = new Row(Row1.C, Row2.C, Row3.C, Row4.C);
            var row4 = new Row(Row1.D, Row2.D, Row3.D, Row4.D);
            return new GameBoard(row1, row2, row3, row4);
        }

        public bool IsEquivalentTo(GameBoard other)
        {
            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return this.Row1.IsEquivalentTo(other.Row1) &&
                   this.Row2.IsEquivalentTo(other.Row2) &&
                   this.Row3.IsEquivalentTo(other.Row3) &&
                   this.Row4.IsEquivalentTo(other.Row4);
        }
    }
}
