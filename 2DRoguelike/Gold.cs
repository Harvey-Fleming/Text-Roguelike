using System;

namespace _2DRoguelike
{
    class Gold : Tile
    {
        Random random = new Random();
        private int gold;

        public Gold()
        {
            symbol = "G";
            
            gold = random.Next(0, 10);
        }

        public int GoldAmount { get => gold; set => gold = value; }
    }
}
