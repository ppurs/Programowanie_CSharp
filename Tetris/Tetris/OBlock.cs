namespace Tetris
{
    public class OBlock : Block
    {
        private readonly Point[][] tiles = new Point[][]
        {
            new Point[] { new(0,0), new(0,1), new(1,0), new(1,1) }
        };

        public override int Id => 4;
        protected override Point StartOffset => new Point(0, 4);
        protected override Point[][] Positions => tiles;
    }
}
