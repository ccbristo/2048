using _2048.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2048.Tests
{
    public static class GameBoardAssert
    {
        public static void AreEquivalent(GameBoard expected, GameBoard actual)
        {
            bool result = expected.IsEquivalentTo(actual);
            Assert.IsTrue(result);
        }
    }
}
