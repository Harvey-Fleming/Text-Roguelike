namespace _2DRoguelike
{
    class Player : Tile
    {
        int xPosition;
        int yPosition;
        int health;
        int goldPurse;
        Weapon weapon;

        public Player(int xPosition, int yPosition, int health, int goldPurse, Weapon weapon)
        {
            symbol = "Pl";
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.health = health;
            this.goldPurse = goldPurse;
            this.weapon = weapon;
        }

        public int XPosition { get => xPosition; set => xPosition = value; }
        public int YPosition { get => yPosition; set => yPosition = value; }
        public int Health { get => health; set => health = value; }
        public int GoldPurse { get => goldPurse; set => goldPurse = value; }
        internal Weapon Weapon { get => weapon; set => weapon = value; }

        #region - Player Combat
        public void OnAttack(Monster monster)
        {
            monster.OnTakeDamage(weapon.damage);
        }

        public void OnTakeDamage(int damageTaken)
        {
            health -= damageTaken;
        }
        #endregion
    }
}
