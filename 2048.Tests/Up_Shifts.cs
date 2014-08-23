using _2048.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2048.Tests
{
    [TestClass]
    public class Up_Shifts
    {
        [TestMethod]
        public void Combine_Siblings()
        {
            var board = new GameBoard(new Row(a: 2),
                new Row(a: 2), 
                Row.Empty,
                Row.Empty);

            var actual = board.ShiftUp();

            var expected = new GameBoard(new Row(a: 4), Row.Empty, Row.Empty, Row.Empty);

            GameBoardAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void Fold_Up_First()
        {
            var board = new GameBoard(new Row(a: 2),
                new Row(a: 2),
                new Row(a: 2),
                Row.Empty);

            var actual = board.ShiftUp();

            var expected = new GameBoard(new Row(a: 4),
                new Row(a: 2),
                Row.Empty,
                Row.Empty);

            GameBoardAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void Ignore_Nulls()
        {
            var board = new GameBoard(new Row(a: 2),
                Row.Empty,
                Row.Empty,
                new Row(a: 2));

            var actual = board.ShiftUp();

            var expected = new GameBoard(new Row(a: 4), Row.Empty, Row.Empty, Row.Empty);

            GameBoardAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void Folds_Double_Combos()
        {
            var board = new GameBoard(new Row(a: 2),
                new Row(a: 2),
                new Row(a: 2),
                new Row(a: 2));

            var actual = board.ShiftUp();

            var expected = new GameBoard(new Row(a: 4),
                new Row(a: 4),
                Row.Empty, 
                Row.Empty);

            GameBoardAssert.AreEquivalent(expected, actual);
        }
    }
}
