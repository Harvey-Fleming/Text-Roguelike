using System;

namespace _2DRoguelike
{
    class Gold : Tile
    {
        public int gold { get; private set; }

        public Gold()
        {
            symbol = "G";
            Random random = new Random();
            gold = random.Next(0, 10);
        }
    }
}
