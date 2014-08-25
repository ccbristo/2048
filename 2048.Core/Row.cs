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

        public Row(int? a = null, int? b = null, int? c = null, int? d = null)
        {
            Values = new[] {a, b, c, d};
        }
    }
}