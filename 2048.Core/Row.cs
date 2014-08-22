using System;
using System.Collections.Generic;
using System.Linq;

namespace _2048.Core
{
    public sealed class Row : IEquatable<Row>
    {
        public int? A { get; private set; }
        public int? B { get; private set; }
        public int? C { get; private set; }
        public int? D { get; private set; }

        public static readonly Row Empty = new Row();

        private Row()
        { }

        public Row(int? a = null, int? b = null, int? c = null, int? d = null)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }

        internal Row(List<int?> seed)
        {
            if (seed.Count > 0)
                A = seed[0];
            if (seed.Count > 1)
                B = seed[1];
            if (seed.Count > 2)
                C = seed[2];
            if (seed.Count > 3)
                D = seed[3];
        }

        public bool Equals(Row other)
        {
            return this.A == other.A &&
                   this.B == other.B &&
                   this.C == other.C &&
                   this.D == other.D;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Row;
            return Equals(other);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
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
    }
}