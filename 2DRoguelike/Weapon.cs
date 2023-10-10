using System;

namespace _2DRoguelike
{
    class Weapon : Tile
    {
        public enum WeaponType { Dagger, Sword, Bow }
        private WeaponType Type;
        private int upgradeCost = 5;
        private int damage;
        private int durability;

        internal WeaponType weaponType { get => Type; set => Type = value; }
        public int UpgradeCost { get => upgradeCost; set => upgradeCost = value; }
        public int Damage { get => damage; set => damage = value; }
        public int Durability { get => durability; set => durability = value; }

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

        public void UpgradeWeapon()
        {
            upgradeCost += 5;
            durability += 2;
            damage += 1;
        }
    }
}
