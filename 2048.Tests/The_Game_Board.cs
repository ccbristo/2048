using _2048.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2048.Tests
{
    [TestClass]
    public class The_Game_Board
    {
        [TestMethod]
        public void Can_Be_Compared_For_Equality()
        {
            var boardA = new GameBoard(Row.Empty, Row.Empty, Row.Empty, Row.Empty);
            var boardB = new GameBoard(Row.Empty, Row.Empty, Row.Empty, Row.Empty);
            Assert.AreEqual(boardA, boardB);
        }
    }
}
