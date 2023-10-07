using System;

namespace _2DRoguelike
{
    class Potion : Tile
    {
        private int healingAmount;

        public Potion()
        {
            symbol = "H";
            Random random = new Random();
            healingAmount = random.Next(1, 5);
        }

        public int HealingAmount { get => healingAmount; set => healingAmount = value; }
    }
}
