using System.Reflection;

namespace Tetris.Test
{
    [TestFixture]
    public class GameTest
    {
        [Test]
        public void BlockFits_EmptyBoard()
        {
            Game game = new Game();

            MethodInfo? methodInfo = typeof(Game).GetMethod("BlockFits", BindingFlags.NonPublic | BindingFlags.Instance);
            object? result = methodInfo?.Invoke(game, null);

            Assert.IsTrue((bool)result);
        }

        [Test]
        public void BlockFits_BlockOverlayAnotherPoint()
        {
            Game game = new Game();
            game.Gameboard.SetElement(2, 4, 5);

            MethodInfo? methodInfo = typeof(Game).GetMethod("BlockFits", BindingFlags.NonPublic | BindingFlags.Instance);
            object? result = methodInfo?.Invoke(game, null);

            Assert.IsFalse((bool)result);
        }

        [Test]
        public void MoveBlockDown_Available()
        {
            Game game = new Game();
            Point? p = game.CurrentBlock.TilePoints().First();

            game.MoveBlockDown();

            Point? result = game.CurrentBlock.TilePoints().First();

            Assert.That(p.Row, Is.EqualTo(result.Row - 1));
            Assert.That(p.Column, Is.EqualTo(result.Column));
        }

        [Test]
        public void MoveBlockDown_Unavailable()
        {
            Game game = new Game();

            game.Gameboard.SetElement(3, 3, 5);
            game.MoveBlockDown();

            Assert.IsFalse(game.Gameboard.IsRowEmpty(2));
        }

        [Test]
        public void MoveBlockLeft_Available()
        {
            Game game = new Game();

            Point? p = game.CurrentBlock.TilePoints().First();

            game.MoveBlockLeft();

            Point? result = game.CurrentBlock.TilePoints().First();

            Assert.That(p.Row, Is.EqualTo(result.Row));
            Assert.That(p.Column, Is.EqualTo(result.Column + 1));
        }

        [Test]
        public void MoveBlockLeft_Unavailable()
        {
            Game game = new Game();
            game.Gameboard.SetElement(2, 2, 5);

            Point? p = game.CurrentBlock.TilePoints().First();

            game.MoveBlockLeft();

            Point? result = game.CurrentBlock.TilePoints().First();

            Assert.That(p.Row, Is.EqualTo(result.Row));
            Assert.That(p.Column, Is.EqualTo(result.Column));
        }

        [Test]
        public void MoveBlockRight_Available()
        {
            Game game = new Game();

            Point? p = game.CurrentBlock.TilePoints().First();

            game.MoveBlockRight();

            Point? result = game.CurrentBlock.TilePoints().First();

            Assert.That(p.Row, Is.EqualTo(result.Row ));
            Assert.That(p.Column, Is.EqualTo(result.Column - 1));
        }

        [Test]
        public void MoveBlockRight_Unavailable()
        {
            Game game = new Game();
            Point? p = game.CurrentBlock.TilePoints().First();
            Point? last = game.CurrentBlock.TilePoints().Last();
            game.Gameboard.SetElement(last.Row, last.Column + 1, 5);

            game.MoveBlockRight();

            Point? result = game.CurrentBlock.TilePoints().First();

            Assert.That(p.Row, Is.EqualTo(result.Row));
            Assert.That(p.Column, Is.EqualTo(result.Column));
        }

        [Test]
        public void IsGameOver_OnlySecondRowFull()
        {
            Game game = new Game();

            for( int i = 0; i < game.Gameboard.Columns; i++ )
            {
                game.Gameboard.SetElement(1, i, 5);
            }

            MethodInfo? methodInfo = typeof(Game).GetMethod("IsGameOver", BindingFlags.NonPublic | BindingFlags.Instance);
            object? result = methodInfo?.Invoke(game, null);

            Assert.IsTrue((bool)result);
        }

        [Test]
        public void IsGameOver_TwoFirstRowsFull()
        {
            Game game = new Game();

            for (int i = 0; i < game.Gameboard.Columns; i++)
            {
                game.Gameboard.SetElement(1, i, 5);
                game.Gameboard.SetElement(0, i, 5);
            }

            MethodInfo? methodInfo = typeof(Game).GetMethod("IsGameOver", BindingFlags.NonPublic | BindingFlags.Instance);
            object? result = methodInfo?.Invoke(game, null);

            Assert.IsTrue((bool)result);
        }

        [Test]
        public void IsGameOver_TwoFirstRowsEmpty()
        {
            Game game = new Game();

            MethodInfo? methodInfo = typeof(Game).GetMethod("IsGameOver", BindingFlags.NonPublic | BindingFlags.Instance);
            object? result = methodInfo?.Invoke(game, null);

            Assert.IsFalse((bool)result);
        }

        [Test]
        public void PlaceBlock()
        {
            Game game = new Game();

            MethodInfo? methodInfo = typeof(Game).GetMethod("PlaceBlock", BindingFlags.NonPublic | BindingFlags.Instance);
            methodInfo?.Invoke(game, null);

            Assert.IsFalse(game.Gameboard.IsRowEmpty(2));
        }

        [Test]
        public void PointDropDistance_EmptyBoard()
        {
            Game game = new Game();
            Point point = new Point(0, 0);

            MethodInfo? methodInfo = typeof(Game).GetMethod("PointDropDistance", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] param = { point };
            object? result = methodInfo?.Invoke(game, param);

            Assert.AreEqual(game.Gameboard.Rows-1, (int)result);

        }

        [Test]
        public void PointDropDistance_CommonUse()
        {
            Game game = new Game();
            Point point = new Point(0, 0);

            game.Gameboard.SetElement(5, 0, 6);

            MethodInfo? methodInfo = typeof(Game).GetMethod("PointDropDistance", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] param = { point };
            object? result = methodInfo?.Invoke(game, param);

            Assert.AreEqual(4, (int)result);

        }

        [Test]
        public void PointDropDistance_FullColumn()
        {
            Game game = new Game();
            Point point = new Point(0, 0);

            game.Gameboard.SetElement(1, 0, 6);

            MethodInfo? methodInfo = typeof(Game).GetMethod("PointDropDistance", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] param = { point };
            object? result = methodInfo?.Invoke(game, param);

            Assert.AreEqual(0, (int)result);

        }

        [Test]
        public void BlockDropDistance_EmptyBoard()
        {
            Game game = new Game();

            if( game.CurrentBlock is IBlock )
            {
                Assert.That(game.Gameboard.Rows - 3, Is.EqualTo(game.BlockDropDistance()));
            }
            else
            {
                Assert.That(game.Gameboard.Rows - 4, Is.EqualTo(game.BlockDropDistance()));
            }
        }

        [Test]
        public void BlockDropDistance_LastTwoRowsFull()
        {
            Game game = new Game();
            int lastRowIndex = game.Gameboard.Rows - 1;

            for (int i = 0; i < game.Gameboard.Columns; i++)
            {
                game.Gameboard.SetElement(lastRowIndex, i, 3);
                game.Gameboard.SetElement(lastRowIndex - 1, i, 3);
            }


            if (game.CurrentBlock is IBlock)
            {
                Assert.That(game.Gameboard.Rows - 3 - 2, Is.EqualTo(game.BlockDropDistance()));
            }
            else
            {
                Assert.That(game.Gameboard.Rows - 4 - 2, Is.EqualTo(game.BlockDropDistance()));
            }

        }

        [Test]
        public void DropBlock_EmptyBoard()
        {
            Game game = new Game();
            Assert.IsTrue(game.Gameboard.IsRowEmpty(game.Gameboard.Rows - 1));

            game.DropBlock();
            Assert.IsFalse(game.Gameboard.IsRowEmpty( game.Gameboard.Rows - 1 ));

        }

        [Test]
        public void DropBlock_LastTwoRowsNearlyFull()
        {
            Game game = new Game();
            int lastRowIndex = game.Gameboard.Rows - 1;

            for (int i = 1; i < game.Gameboard.Columns; i++ )
            {
                game.Gameboard.SetElement(lastRowIndex, i, 3);
                game.Gameboard.SetElement( lastRowIndex-1, i, 3);
            }
            
            game.DropBlock();
            Assert.IsFalse(game.Gameboard.IsRowEmpty(lastRowIndex-2));
        }
    }
}


