using System;

namespace _2DRoguelike
{
    class Weapon : Tile
    {
        public enum WeaponType { Dagger, Sword, Bow }
        public WeaponType weaponType { get; private set; }
        public int upgradeCost { get; private set; }
        public int damage { get; private set; }
        public int durability { get; private set; }

        public Weapon()
        {
            symbol = "W";
            GenerateStats();

        }

        //Generate Random weapon stats when one is spawned on a tile
        void GenerateStats()
        {
            Random random = new Random();
            int ranweaponInt = random.Next(0, 3);
            weaponType = (WeaponType)ranweaponInt;
            switch (weaponType)
            {
                case WeaponType.Dagger:
                    durability = random.Next(1, 5);
                    damage = random.Next(1, 4);
                    break;
                case WeaponType.Sword:
                    durability = random.Next(2, 5);
                    damage = random.Next(5, 11);
                    break;
                case WeaponType.Bow:
                    durability = random.Next(6, 11);
                    damage = random.Next(2, 6);
                    break;
            }
        }
    }
}
