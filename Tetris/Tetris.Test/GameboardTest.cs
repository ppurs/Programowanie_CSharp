using System.Reflection;

namespace Tetris.Test
{
    [TestFixture]    
    public class GameboardTest
    {
        [Test]
        public void IsBoardSizeCorrectlyInitialized()
        {
            int numOfRows = 22;
            int numOfCols = 10;

            Gameboard board = new Gameboard(numOfRows, numOfCols);

            Assert.That(numOfRows, Is.EqualTo(board.Rows));
            Assert.That(numOfCols, Is.EqualTo(board.Columns));
        }

        [Test]
        public void IsBoardFilledWithZerosAfterInitialize()
        {
            int numOfRows = 22;
            int numOfCols = 10;

            Gameboard board = new Gameboard(numOfRows, numOfCols);

            for (int i = 0; i < numOfRows; i++)
            {
                for (int j = 0; j < numOfCols; j++)
                {
                    Assert.That(0, Is.EqualTo(board.GetElement(i, j)));
                }
            }
        }

        [TestCase( 1, 1, 5, ExpectedResult = 5 )]
        [TestCase(1, 1, 0, ExpectedResult = 0)]
        [TestCase(1, 1, -1, ExpectedResult = -1)]
        public int SetAndGetSingleElementWithAnyValue( int row, int col, int value )
        {
            int numOfRows = 22;
            int numOfCols = 10;
            Gameboard board = new Gameboard(numOfRows, numOfCols);

            board.SetElement(row, col, value);

            return board.GetElement(row, col);
        }

        [TestCase(0, 0, ExpectedResult = true)]
        [TestCase(0, 10, ExpectedResult = false)]
        [TestCase(10, 0, ExpectedResult = true)]
        [TestCase(22, 0, ExpectedResult = false)]
        [TestCase(0, 22, ExpectedResult = false)]
        [TestCase(-1, 0, ExpectedResult = false)]
        [TestCase(21, 9, ExpectedResult = true)]
        [TestCase(0, 9, ExpectedResult = true)]
        [TestCase(21, 0, ExpectedResult = true)]
        [TestCase(0, -1, ExpectedResult = false)]
        public bool IsInside( int row, int col )
        {
            int numOfRows = 22;
            int numOfCols = 10;
            Gameboard board = new Gameboard(numOfRows, numOfCols);

            return board.IsInside(row, col);  
        }

        [Test]
        public void IsEmpty_EmptyBoard()
        {
            int numOfRows = 22;
            int numOfCols = 10;
            Gameboard board = new Gameboard(numOfRows, numOfCols);

            for (int i = 0; i < numOfRows; i++)
            {
                for (int j = 0; j < numOfCols; j++)
                {
                    Assert.IsTrue(board.IsEmpty(i, j));
                }
            }

        }

        [Test]
        public void IsEmpty_NonEmptyBoard()
        {
            int numOfRows = 22;
            int numOfCols = 10;
            Gameboard board = new Gameboard(numOfRows, numOfCols);

            board.SetElement(0, 0, 5);
            board.SetElement(0, 1, 22);
            board.SetElement(0, 2, 10);
            board.SetElement(0, 3, -1);
            board.SetElement(21, 1, 5);
            board.SetElement(20, 1, 22);
            board.SetElement(1, 9, 10);
            board.SetElement(10, 1, -1);

            Assert.IsFalse(board.IsEmpty(0, 0));
            Assert.IsFalse(board.IsEmpty(0, 1));
            Assert.IsFalse(board.IsEmpty(0, 2));
            Assert.IsFalse(board.IsEmpty(0, 3));
            Assert.IsFalse(board.IsEmpty(21, 1));
            Assert.IsFalse(board.IsEmpty(20, 1));
            Assert.IsFalse(board.IsEmpty(1, 9));
            Assert.IsFalse(board.IsEmpty(10, 1));
        }

        [Test]
        public void IsRowFull_FullFirstRow()
        {
            int numOfRows = 22;
            int numOfCols = 10;
            Gameboard board = new Gameboard(numOfRows, numOfCols);

            for( int i = 0; i < numOfCols; i++ )
            {
                board.SetElement(0, i, 5);
            }

            Assert.IsTrue(board.IsRowFull(0));
        }

        [Test]
        public void IsRowFull_FullLastRow()
        {
            int numOfRows = 22;
            int numOfCols = 10;
            int lastRow = numOfRows - 1;
            Gameboard board = new Gameboard(numOfRows, numOfCols);

            for (int i = 0; i < numOfCols; i++)
            {
                board.SetElement( lastRow, i, 5);
            }

            Assert.IsTrue(board.IsRowFull(lastRow));
        }

        [Test]
        public void IsRowFull_NonFullRow_firstElementEmpty()
        {
            int numOfRows = 22;
            int numOfCols = 10;
            Gameboard board = new Gameboard(numOfRows, numOfCols);

            for (int i = 1; i < numOfCols; i++)
            {
                board.SetElement(0, i, 5);
            }

            Assert.IsFalse(board.IsRowFull( 0 ));
        }

        [Test]
        public void IsRowFull_NonFullRow_lastElementEmpty()
        {
            int numOfRows = 22;
            int numOfCols = 10;
            Gameboard board = new Gameboard(numOfRows, numOfCols);

            for (int i = 0; i < numOfCols - 1 ; i++)
            {
                board.SetElement(0, i, 5);
            }

            Assert.IsFalse(board.IsRowFull(0));
        }

        [Test]
        public void IsRowFull_NonFullRow_ElementInsideEmpty()
        {
            int numOfRows = 22;
            int numOfCols = 10;
            Gameboard board = new Gameboard(numOfRows, numOfCols);

            for (int i = 0; i < numOfCols; i++)
            {
                board.SetElement(0, i, 5);
            }

            board.SetElement(0, 3, 0);

            Assert.IsFalse(board.IsRowFull(0));
        }

        [Test]
        public void IsRowEmpty_NonFullRow_firstElementEmpty()
        {
            int numOfRows = 22;
            int numOfCols = 10;
            Gameboard board = new Gameboard(numOfRows, numOfCols);

            for (int i = 1; i < numOfCols; i++)
            {
                board.SetElement(0, i, 5);
            }

            Assert.IsFalse(board.IsRowEmpty(0));
        }

        [Test]
        public void IsRowEmpty_FullRow_lastElementEmpty()
        {
            int numOfRows = 22;
            int numOfCols = 10;
            Gameboard board = new Gameboard(numOfRows, numOfCols);

            for (int i = 0; i < numOfCols - 1; i++)
            {
                board.SetElement(0, i, 5);
            }

            Assert.IsFalse(board.IsRowFull(0));
        }

        [Test]
        public void IsRowEmpty_CommonUse()
        {
            int numOfRows = 22;
            int numOfCols = 10;
            int lastRow = numOfRows - 1;
            Gameboard board = new Gameboard(numOfRows, numOfCols);

            Assert.IsTrue(board.IsRowEmpty(lastRow - 2));
        }

        [Test]
        public void IsRowEmpty_NonFullRow_lastElementEmpty()
        {
            int numOfRows = 22;
            int numOfCols = 10;
            Gameboard board = new Gameboard(numOfRows, numOfCols);

            for (int i = 0; i < numOfCols - 1; i++)
            {
                board.SetElement(0, i, 5);
            }

            Assert.IsFalse(board.IsRowEmpty(0));
        }


        [Test]
        public void ClearRow()
        {
            int numOfRows = 22;
            int numOfCols = 10;
            Gameboard board = new Gameboard(numOfRows, numOfCols);

            for (int i = 0; i < numOfCols; i++)
            {
                board.SetElement(0, i, 5);
            }

            MethodInfo? methodInfo = typeof(Gameboard).GetMethod("ClearRow", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] param = { 0 };

            methodInfo?.Invoke(board, param );

            for (int i = 0; i < numOfCols; i++)
            {
                Assert.AreEqual(0, board.GetElement(0, i));
            }
        }

        [Test]
        public void MoveRowDown_NegativeNumOfRows()
        {
            int numOfRows = 22;
            int numOfCols = 10;
            Gameboard board = new Gameboard(numOfRows, numOfCols);

            for (int i = 0; i < numOfCols; i++)
            {
                board.SetElement(3, i, 5);
            }

            MethodInfo? methodInfo = typeof(Gameboard).GetMethod("MoveRowDown", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] param = { 3, -1 };

            methodInfo?.Invoke(board, param);

            for (int i = 0; i < numOfCols; i++)
            {
                Assert.AreEqual(5, board.GetElement(3, i));
            }

        }

        [Test]
        public void MoveRowDown_NoneNumOfRows()
        {
            int numOfRows = 22;
            int numOfCols = 10;
            Gameboard board = new Gameboard(numOfRows, numOfCols);

            for (int i = 0; i < numOfCols; i++)
            {
                board.SetElement(3, i, 5);
            }

            MethodInfo? methodInfo = typeof(Gameboard).GetMethod("MoveRowDown", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] param = { 3, 0 };

            methodInfo?.Invoke(board, param);

            for (int i = 0; i < numOfCols; i++)
            {
                Assert.AreEqual(5, board.GetElement(3, i));
            }

        }

        [Test]
        public void MoveRowDown_CommonUseCase()
        {
            int numOfRows = 22;
            int numOfCols = 10;
            Gameboard board = new Gameboard(numOfRows, numOfCols);

            for (int i = 0; i < numOfCols; i++)
            {
                board.SetElement(3, i, 5);
            }

            MethodInfo? methodInfo = typeof(Gameboard).GetMethod("MoveRowDown", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] param = { 3, 4 };

            methodInfo?.Invoke(board, param);

            for (int i = 0; i < numOfCols; i++)
            {
                Assert.AreEqual(5, board.GetElement(7, i));
            }

        }

        [Test]
        public void ClearFullRows_OnlyFirstRow()
        {
            int numOfRows = 22;
            int numOfCols = 10;
            Gameboard board = new Gameboard(numOfRows, numOfCols);

            for (int i = 0; i < numOfCols; i++)
            {
                board.SetElement(0, i, 5);
            }

            int result = board.ClearFullRows();

            Assert.AreEqual(1, result );

            for (int i = 0; i < numOfCols; i++)
            {
                Assert.AreEqual(0, board.GetElement(0, i));
            }

        }

        [Test]
        public void ClearFullRows_OnlyLastRow()
        {
            int numOfRows = 22;
            int numOfCols = 10;
            int lastRow = numOfRows - 1;
            Gameboard board = new Gameboard(numOfRows, numOfCols);

            for (int i = 0; i < numOfCols; i++)
            {
                board.SetElement(lastRow, i, 5);
            }

            int result = board.ClearFullRows();

            Assert.AreEqual(1, result);

            for (int i = 0; i < numOfCols; i++)
            {
                Assert.AreEqual(0, board.GetElement(lastRow, i));
            }
        }

        [Test]
        public void ClearFullRows_ThreeRowsInTheMiddle()
        {
            int numOfRows = 22;
            int numOfCols = 10;
            Gameboard board = new Gameboard(numOfRows, numOfCols);

            for( int j = 1; j < 4; j++ )
            {
                for (int i = 0; i < numOfCols; i++)
                {
                    board.SetElement(j, i, 5);
                }
            }

            int result = board.ClearFullRows();

            Assert.AreEqual(3, result);

            for (int j = 1; j < 4; j++)
            {
                for (int i = 0; i < numOfCols; i++)
                {
                    Assert.AreEqual(0, board.GetElement(j, i));
                }
            }
        }
    }
}
