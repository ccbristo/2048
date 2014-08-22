using System;

namespace _2048.Core
{
    public sealed class GameBoard : IEquatable<GameBoard>
    {
        public Row Row1 { get; private set; }
        public Row Row2 { get; private set; }
        public Row Row3 { get; private set; }
        public Row Row4 { get; private set; }

        public GameBoard(Row row1, Row row2, Row row3, Row row4)
        {
            Row1 = row1;
            Row2 = row2;
            Row3 = row3;
            Row4 = row4;
        }

        public GameBoard ShiftLeft()
        {
            var rows = new[] { Row1, Row2, Row3, Row4 };
            var newRows = new Row[4];
            bool shifted = false;
            int i = 0;

            foreach (var row in rows)
            {
                bool thisRowShifted;
                newRows[i] = row.ShiftLeft(out thisRowShifted);
                shifted |= thisRowShifted;
                i++;
            }

            return new GameBoard(newRows[0],
                                 newRows[1],
                                 newRows[2],
                                 newRows[3]);
        }

        public GameBoard ShiftRight()
        {
            var rows = new[] { Row1, Row2, Row3, Row4 };
            var newRows = new Row[4];
            bool shifted = false;
            int i = 0;

            foreach (var row in rows)
            {
                bool thisRowShifted;
                newRows[i] = row.ShiftRight(out thisRowShifted);
                shifted |= thisRowShifted;
                i++;
            }

            return new GameBoard(newRows[0],
                                 newRows[1],
                                 newRows[2],
                                 newRows[3]);
        }

        public override bool Equals(object obj)
        {
            var other = obj as GameBoard;
            return Equals(other);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public bool Equals(GameBoard other)
        {
            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return this.Row1.Equals(other.Row1) &&
                   this.Row2.Equals(other.Row2) &&
                   this.Row3.Equals(other.Row3) &&
                   this.Row4.Equals(other.Row4);
        }
    }
}
