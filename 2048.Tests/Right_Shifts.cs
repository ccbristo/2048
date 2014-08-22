using _2048.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2048.Tests
{
    [TestClass]
    public class Right_Shifts
    {
        [TestMethod]
        public void Combine_Siblings()
        {
            var board = new GameBoard(new Row(a: 2, b: 2),
                Row.Empty,
                Row.Empty,
                Row.Empty);

            var actual = board.ShiftRight();

            var expected = new GameBoard(new Row(d: 4), Row.Empty, Row.Empty, Row.Empty);

            Assert.AreEqual(expected, actual, "Right shift");
        }

        [TestMethod]
        public void Fold_Right_First()
        {
            var board = new GameBoard(new Row(a: 2, b: 2, c: 2),
                Row.Empty,
                Row.Empty,
                Row.Empty);

            var actual = board.ShiftRight();

            var expected = new GameBoard(new Row(c: 2, d: 4), Row.Empty, Row.Empty, Row.Empty);

            Assert.AreEqual(expected, actual, "Right shift");
        }

        [TestMethod]
        public void Ignore_Nulls()
        {
            var board = new GameBoard(new Row(a: 2, d: 2),
                Row.Empty,
                Row.Empty,
                Row.Empty);

            var actual = board.ShiftRight();

            var expected = new GameBoard(new Row(d: 4), Row.Empty, Row.Empty, Row.Empty);

            Assert.AreEqual(expected, actual, "Right shift");
        }

        [TestMethod]
        public void Folds_Double_Combos()
        {
            var board = new GameBoard(new Row(a: 2, b: 2, c: 2, d: 2),
                Row.Empty,
                Row.Empty,
                Row.Empty);

            var actual = board.ShiftRight();

            var expected = new GameBoard(new Row(c: 4, d : 4), Row.Empty, Row.Empty, Row.Empty);

            Assert.AreEqual(expected, actual, "Right shift");
        }
    }
}
