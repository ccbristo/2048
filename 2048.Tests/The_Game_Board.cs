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
            GameBoardAssert.AreEquivalent(boardA, boardB);
        }

        [TestMethod]
        public void Can_Generate_The_Next_Piece()
        {
            var board = new GameBoard(Row.Empty, Row.Empty, Row.Empty, Row.Empty);
            board.GenerateNewPiece();
            board.GenerateNewPiece();
        }
    }
}
