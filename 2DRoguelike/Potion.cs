using System;

namespace _2DRoguelike
{
    class Potion : Tile
    {
        Random random = new Random();
        private int healingAmount;

        public Potion()
        {
            symbol = "H";
            healingAmount = random.Next(1, 5);
        }

        public int HealingAmount { get => healingAmount; set => healingAmount = value; }
    }
}
