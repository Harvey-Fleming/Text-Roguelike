using System;

namespace _2DRoguelike
{
    class Monster : Tile
    {
        public enum MonsterType { Zombie, Skeleton, Spider }
        private MonsterType monsterType;
        public int health { get; private set; }
        public int goldDrop { get; private set; }
        public int attack { get; private set; }

        public Monster(MonsterType type, int health, int goldDrop, int attack)
        {
            symbol = "M";
            this.monsterType = type;
            this.health = health;
            this.goldDrop = goldDrop;
            this.attack = attack;
        }

        //Generate Random Monster Type
        public MonsterType GetRandMonsterType()
        {
            Random random = new Random();
            int type = random.Next(0, 3);
            return (MonsterType)type;
        }

        #region - Monster Combat
        public void OnAttack(Player player)
        {
            player.OnTakeDamage(attack);
        }

        public void OnTakeDamage(int damageTaken)
        {
            health -= damageTaken;
        }
        #endregion
    }
}
