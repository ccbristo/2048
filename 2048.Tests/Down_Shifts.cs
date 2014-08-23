using _2048.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2048.Tests
{
    [TestClass]
    public class Down_Shifts
    {
        [TestMethod]
        public void Combine_Siblings()
        {
            var board = new GameBoard(new Row(a: 2),
                new Row(a: 2), 
                Row.Empty,
                Row.Empty);

            var actual = board.ShiftDown();

            var expected = new GameBoard(
                Row.Empty,
                Row.Empty,
                Row.Empty,
                new Row(a: 4));

            GameBoardAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void Fold_Down_First()
        {
            var board = new GameBoard(new Row(a: 2),
                new Row(a: 2),
                new Row(a: 2),
                Row.Empty);

            var actual = board.ShiftDown();

            var expected = new GameBoard(
                Row.Empty,
                Row.Empty,
                new Row(a: 2),
                new Row(a: 4));

            GameBoardAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void Ignore_Nulls()
        {
            var board = new GameBoard(new Row(a: 2),
                Row.Empty,
                Row.Empty,
                new Row(a: 2));

            var actual = board.ShiftDown();

            var expected = new GameBoard(
                Row.Empty,
                Row.Empty,
                Row.Empty,
                new Row(a: 4));

            GameBoardAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void Folds_Double_Combos()
        {
            var board = new GameBoard(new Row(a: 2),
                new Row(a: 2),
                new Row(a: 2),
                new Row(a: 2));

            var actual = board.ShiftDown();

            var expected = new GameBoard(
                Row.Empty, 
                Row.Empty,
                new Row(a: 4),
                new Row(a: 4));

            GameBoardAssert.AreEquivalent(expected, actual);
        }
    }
}
