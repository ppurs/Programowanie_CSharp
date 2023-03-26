namespace Tetris
{
    public class Game
    {
        private const int NUMBER_OF_ROWS = 20;
        private const int NUMBER_OF_COLUMNS = 10;


        private Block currentBlock;

        public Block CurrentBlock
        {
            get => currentBlock;
            private set
            {
                currentBlock = value;
                currentBlock.Reset();

                for (int i = 0; i < 2; i++)
                {
                    currentBlock.Move(1, 0);

                    if (!BlockFits())
                    {
                        currentBlock.Move(-1, 0);
                    }
                }
            }
        }

        public BlocksQueue BlocksQueue { get; }
        public Gameboard Gameboard { get; }
        public bool GameOver { get; private set; }
        public int Score { get; private set; }

        public Game()
        {   
            Gameboard = new Gameboard(NUMBER_OF_ROWS + 2, NUMBER_OF_COLUMNS);
            BlocksQueue = new BlocksQueue();
            CurrentBlock = BlocksQueue.GetNext();
        }

        private bool BlockFits()
        {
            foreach ( Point p in CurrentBlock.TilePoints())
            {
                if (!Gameboard.IsEmpty(p.Row, p.Column))
                {
                    return false;
                }
            }

            return true;
        }

        public void RotateBlockClockwise()
        {
            CurrentBlock.RotateClockwise();

            if (!BlockFits())
            {
                CurrentBlock.RotateCounterclockwise();
            }
        }

        public void RotateBlockCounterclockwise()
        {
            CurrentBlock.RotateCounterclockwise();

            if (!BlockFits())
            {
                CurrentBlock.RotateClockwise();
            }
        }

        public void MoveBlockDown()
        {
            CurrentBlock.Move(1, 0);

            if (!BlockFits())
            {
                CurrentBlock.Move(-1, 0);
                PlaceBlock();
            }
        }

        public void MoveBlockLeft()
        {
            CurrentBlock.Move(0, -1);

            if (!BlockFits())
            {
                CurrentBlock.Move(0, 1);
            }
        }

        public void MoveBlockRight()
        {
            CurrentBlock.Move(0, 1);

            if (!BlockFits())
            {
                CurrentBlock.Move(0, -1);
            }
        }

        private bool IsGameOver()
        {
            return !(Gameboard.IsRowEmpty(0) && Gameboard.IsRowEmpty(1));
        }

        private void PlaceBlock()
        {
            foreach (Point p in CurrentBlock.TilePoints())
            {
                Gameboard.SetElement(p.Row, p.Column, CurrentBlock.Id);
            }

            Score += Gameboard.ClearFullRows();

            if (IsGameOver())
            {
                GameOver = true;
            }
            else
            {
                CurrentBlock = BlocksQueue.GetNext();
            }
        }

        private int PointDropDistance(Point p)
        {
            int drop = 0;

            while (Gameboard.IsEmpty(p.Row + drop + 1, p.Column))
            {
                drop++;
            }

            return drop;
        }

        public int BlockDropDistance()
        {
            int drop = Gameboard.Rows;

            foreach (Point p in CurrentBlock.TilePoints())
            {
                drop = System.Math.Min(drop, PointDropDistance(p));
            }

            return drop;
        }

        public void DropBlock()
        {
            CurrentBlock.Move(BlockDropDistance(), 0);
            PlaceBlock();
        }
    }
}
