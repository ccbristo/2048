
namespace _2048.Core
{
    public sealed class Row
    {
        private readonly int?[] Values = new int?[4];

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