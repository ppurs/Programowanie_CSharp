namespace Tetris
{
    public class Gameboard
    {
        private readonly int[,] board;
        public int Rows { get; }
        public int Columns { get; }

        public Gameboard(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            board = new int[rows, columns];
        }

        public int GetElement(int row, int col)
        {
            return board[row, col];
        }

        public void SetElement(int row, int col, int value)
        {
            board[row, col] = value;
        }

        public bool IsInside(int row, int col)
        {
            return ( row >= 0 && row < Rows ) && ( col >= 0 && col < Columns );
        }

        public bool IsEmpty(int row, int col)
        {
            return IsInside(row, col) && board[row, col] == 0;
        }

        public bool IsRowFull(int row)
        {

            for (int i = 0; i < Columns; i++)
            {
                if ( board[row, i] == 0 )
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsRowEmpty(int row)
        {
            for (int i = 0; i < Columns; i++)
            {
                if ( board[row, i] != 0 )
                {
                    return false;
                }
            }

            return true;
        }

        private void ClearRow(int row)
        {
            for (int i = 0; i < Columns; i++)
            {
                board[row, i] = 0;
            }
        }

        private void MoveRowDown(int row, int numberOfRows)
        {
            if (numberOfRows > 0 && ( numberOfRows + row < Rows ) )
            {
                for (int i = 0; i < Columns; i++)
                {
                    board[row + numberOfRows, i] = board[row, i];
                    board[row, i] = 0;
                }
            }
        }

        public int ClearFullRows()
        {
            int cleared = 0;

            for (int i = Rows - 1; i >= 0; i--)
            {
                if (IsRowFull( i ))
                {
                    ClearRow( i );
                    cleared++;
                }
                else if (cleared > 0)
                {
                    MoveRowDown( i, cleared);
                }
            }

            return cleared;
        }
    }
}
