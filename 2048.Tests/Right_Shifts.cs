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
            var board = new GameBoard(new int?[,]
            {
                {2, 2, null, null },
                {null, null, null, null},
                {null, null, null, null},
                {null, null, null, null}
            });

            var actual = board.ShiftRight();

            var expected = new GameBoard(new int?[,]
            {
                {null, null, null, 4 },
                {null, null, null, null},
                {null, null, null, null},
                {null, null, null, null}
            });

            GameBoardAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void Fold_Right_First()
        {
            var board = new GameBoard(new int?[,]
            {
                {2, 2, 2, null },
                {null, null, null, null},
                {null, null, null, null},
                {null, null, null, null}
            });

            var actual = board.ShiftRight();

            var expected = new GameBoard(new int?[,]
            {
                {null, null, 2, 4 },
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
                {2, null, null, 2 },
                {null, null, null, null},
                {null, null, null, null},
                {null, null, null, null}
            });

            var actual = board.ShiftRight();

            var expected = new GameBoard(new int?[,]
            {
                {null, null, null, 4 },
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

            var actual = board.ShiftRight();

            var expected = new GameBoard(new int?[,]
            {
                {null, null, 4, 4 },
                {null, null, null, null},
                {null, null, null, null},
                {null, null, null, null}
            });

            GameBoardAssert.AreEquivalent(expected, actual);
        }
    }
}
