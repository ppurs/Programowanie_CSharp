using System.Collections.Generic;

namespace Tetris
{
    public abstract class Block
    {
        public abstract int Id { get; }
        protected abstract Point[][] Positions { get; }
        protected abstract Point StartOffset { get; }

        private Point offset;
        private int rotationState;

        public Block()
        {
            offset = new Point(StartOffset.Row, StartOffset.Column);
        }

        public void Move(int rows, int columns)
        {
            offset.Row += rows;
            offset.Column += columns;
        }

        public void Reset()
        {
            rotationState = 0;
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column;
        }

        public void RotateClockwise()
        {
            rotationState = (rotationState + 1) % Positions.Length;
        }

        public void RotateCounterclockwise()
        {
            if (rotationState == 0)
            {
                rotationState = Positions.Length - 1;
            }
            else
            {
                rotationState--;
            }
        }

        public IEnumerable<Point> TilePoints()
        {
            foreach (Point p in Positions[rotationState])
            {
                yield return new Point(p.Row + offset.Row, p.Column + offset.Column);
            }
        }
    }
}
