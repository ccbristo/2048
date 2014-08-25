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
            var board = new GameBoard(new int?[,]
            {
                {2, 2, null, null },
                {null, null, null, null},
                {null, null, null, null},
                {null, null, null, null}
            });

            var actual = board.ShiftLeft();

            var expected = new GameBoard(new int?[,]
            {
                {4, null, null, null },
                {null, null, null, null},
                {null, null, null, null},
                {null, null, null, null}
            });

            GameBoardAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void Fold_Left_First()
        {
            var board = new GameBoard(new int?[,]
            {
                {2, 2, 2, null },
                {null, null, null, null},
                {null, null, null, null},
                {null, null, null, null}
            });

            var actual = board.ShiftLeft();

            var expected = new GameBoard(new int?[,]
            {
                {4, 2, null, null },
                {null, null, null, null},
                {null, null, null, null},
                {null, null, null, null}
            });

            GameBoardAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void Ignore_Nulls()
        {
            var board = new GameBoard(new int?[,]
            {
                {null, 2, null, 2 },
                {null, null, null, null},
                {null, null, null, null},
                {null, null, null, null}
            });

            var actual = board.ShiftLeft();

            var expected = new GameBoard(new int?[,]
            {
                {4, null, null, null },
                {null, null, null, null},
                {null, null, null, null},
                {null, null, null, null}
            });

            GameBoardAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void Folds_Double_Combos()
        {
            var board = new GameBoard(new int?[,]
            {
                {2, 2, 2, 2 },
                {null, null, null, null},
                {null, null, null, null},
                {null, null, null, null}
            });

            var actual = board.ShiftLeft();

            var expected = new GameBoard(new int?[,]
            {
                {4, 4, null, null },
                {null, null, null, null},
                {null, null, null, null},
                {null, null, null, null}
            });

            GameBoardAssert.AreEquivalent(expected, actual);
        }
    }
}
