using _2048.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2048.Tests
{
    [TestClass]
    public class Left_Shifts
    {
        [TestMethod]
        public void Can_Shift_Left()
        {
            var board = new GameBoard(new Row(a: 2, b: 2),
                Row.Empty,
                Row.Empty,
                Row.Empty);

            var actual = board.ShiftLeft();

            var expected = new GameBoard(new Row(a: 4), Row.Empty, Row.Empty, Row.Empty);

            Assert.AreEqual(expected, actual, "Left shift");
        }

        [TestMethod]
        public void Fold_Left_First()
        {
            var board = new GameBoard(new Row(a: 2, b: 2, c: 2),
                Row.Empty,
                Row.Empty,
                Row.Empty);

            var actual = board.ShiftLeft();

            var expected = new GameBoard(new Row(a: 4, b: 2), Row.Empty, Row.Empty, Row.Empty);

            Assert.AreEqual(expected, actual, "Left shift");
        }

        [TestMethod]
        public void Ignore_Nulls()
        {
            var board = new GameBoard(new Row(b: 2, d: 2),
                Row.Empty,
                Row.Empty,
                Row.Empty);

            var actual = board.ShiftLeft();

            var expected = new GameBoard(new Row(a: 4), Row.Empty, Row.Empty, Row.Empty);

            Assert.AreEqual(expected, actual, "Left shift");
        }

        [TestMethod]
        public void Folds_Double_Combos()
        {
            var board = new GameBoard(new Row(a: 2, b: 2, c: 2, d: 2),
                Row.Empty,
                Row.Empty,
                Row.Empty);

            var actual = board.ShiftLeft();

            var expected = new GameBoard(new Row(a: 4, b : 4), Row.Empty, Row.Empty, Row.Empty);

            Assert.AreEqual(expected, actual, "Left shift");
        }
    }
}
