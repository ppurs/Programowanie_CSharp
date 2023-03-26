﻿namespace Tetris
{
    public class TBlock : Block
    {
        public override int Id => 6;

        protected override Point StartOffset => new(0, 3);

        protected override Point[][] Positions => new Point[][] {
            new Point[] {new(0,1), new(1,0), new(1,1), new(1,2)},
            new Point[] {new(0,1), new(1,1), new(1,2), new(2,1)},
            new Point[] {new(1,0), new(1,1), new(1,2), new(2,1)},
            new Point[] {new(0,1), new(1,0), new(1,1), new(2,1)}
        };
    }
}
