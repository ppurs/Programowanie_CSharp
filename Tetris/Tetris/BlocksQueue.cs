using System;
using System.Collections.Generic;
using System.Linq;

namespace Tetris
{
    public class BlocksQueue
    {
        private readonly List<Block> blocks = new List<Block> 
        {
            new IBlock(),
            new JBlock(),
            new LBlock(),
            new SBlock(),
            new TBlock(),
            new ZBlock(),
            new OBlock(),
        };

        public Block NextBlock { get; private set; }

        public BlocksQueue()
        {
            NextBlock = RandomBlock();
        }

        public Block GetNext()
        {
            NextBlock = RandomBlock();

            return NextBlock;
        }

        private Block RandomBlock()
        {
            Random random = new Random();
            int randomIndex = random.Next(blocks.Count);


            var result = blocks.Select(block => block).Where((block, index) => index == randomIndex).First();

            return result;
        }
       
    }
}
