using System;
using System.Collections.Generic;
using System.Linq;

namespace _2048.Core
{
    public sealed class Row
    {
        public static readonly Row Empty = new Row();
        private readonly int?[] Values = new int?[4];

        public int? A
        {
            get { return Values[0]; }
        }

        public int? B
        {
            get { return Values[1]; }
        }

        public int? C
        {
            get { return Values[2]; }
        }

        public int? D
        {
            get { return Values[3]; }
        }

        public int? this[int index]
        {
            get { return Values[index]; }
        }

        private Row()
        { }

        public Row(int? a = null, int? b = null, int? c = null, int? d = null)
        {
            Values = new[] {a, b, c, d};
        }

        internal Row(IEnumerable<int?> seed)
        {
            if(seed.Count() != 4)
                throw new ArgumentException("Seed must be 4 items long.");

            Values = seed.ToArray();
        }

        public bool Full
        {
            get { return Values.All(v => v != null); }
        }

        public bool IsEquivalentTo(Row other)
        {
            return this.A == other.A &&
                   this.B == other.B &&
                   this.C == other.C &&
                   this.D == other.D;
        }

        public Row ShiftLeft(out bool shifted)
        {
            var nonNulls = new List<int?> { A, B, C, D }.Where(i => i != null).ToList();
            var remaining = nonNulls.Skip(1).ToList();
            int? previous = nonNulls.FirstOrDefault();
            var result = new List<int?> { previous };
            
            while (remaining.Count > 0)
            {
                int? current = remaining[0];
                if (current == null)
                {
                    remaining.RemoveAt(0);
                }
                else if (previous == current)
                {
                    result[result.Count - 1] = previous * 2;
                    previous = null;
                    remaining.RemoveAt(0);
                }
                else
                {
                    previous = current;
                    result.Add(previous);
                    remaining.RemoveAt(0);
                }
            }

            shifted = remaining.Count != result.Count;
            while(result.Count < 4)
                result.Add(null);
            return new Row(result);
        }

        public Row ShiftRight(out bool shifted)
        {
            return this.Reverse().ShiftLeft(out shifted).Reverse();
        }

        private Row Reverse()
        {
            return new Row(D, C, B, A);
        }

        internal Row SetCell(int cell, int value)
        {
            var newValues = new int?[4];
            Array.Copy(Values, newValues, Values.Length);
            newValues[cell] = value;
            return new Row(newValues);
        }
    }
}