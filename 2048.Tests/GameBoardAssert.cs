using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2048.Core;

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
