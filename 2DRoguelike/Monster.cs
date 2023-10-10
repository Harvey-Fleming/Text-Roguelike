using System;

namespace _2DRoguelike
{
    class Monster : Tile
    {
        Random random = new Random();
        public enum MType { Zombie, Skeleton, Spider }
        private MType monsterType;
        private int health;
        private int goldDrop;
        private int attack;

        internal MType MonsterType { get => monsterType; set => monsterType = value; }
        public int Health { get => health; set => health = value; }
        public int GoldDrop { get => goldDrop; set => goldDrop = value; }
        public int Attack { get => attack; set => attack = value; }

        public Monster()
        {
            symbol = "M";
            this.monsterType = GetRandMonsterType();
            this.health = random.Next(1,21);
            this.goldDrop = random.Next(1,8);
            this.attack = random.Next(1, 10);
        }

        //Generate Random Monster Type
        public MType GetRandMonsterType()
        {
            
            int type = random.Next(0, 3);
            return (MType)type;
        }

        #region - Monster Combat
        public void OnAttack(Player player)
        {
            Console.WriteLine("Monster has Attacked");
            player.OnTakeDamage(attack);
        }

        public void OnTakeDamage(int damageTaken)
        {
            Console.WriteLine("Monster has taken damage");
            health -= damageTaken;
        }
        #endregion
    }
}
