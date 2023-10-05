using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DRoguelike
{
    class Tile
    {
        
    }

    class Player : Tile
    {
        public string symbol = "Pl";
        int xPosition;
        int yPosition;
        int health;
        int goldPurse;
        Weapon weapon;

        public Player(int xPosition, int yPosition, int health, int goldPurse, Weapon weapon)
        {
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.health = health;
            this.goldPurse = goldPurse;
            this.weapon = weapon;
        }

        public void OnAttack(Monster monster)
        {
            monster.OnTakeDamage(weapon.damage);
        }

        public void OnTakeDamage(int damageTaken)
        {
            health -= damageTaken;
        }
    }

    class Weapon : Tile
    {
        public string symbol = "W";
        public enum WeaponType {Dagger, Sword, Bow }
        public WeaponType weaponType { get; private set; }
        public int upgradeCost { get; private set; }
        public int damage { get; private set; }
        public int durability { get; private set; }

        public Weapon()
        {
            GenerateStats();

        }

        void GenerateStats()
        {
            Random random = new Random();
            int ranweaponInt = random.Next(0,3);
            weaponType = (WeaponType)ranweaponInt;
            switch (weaponType)
            {
                case WeaponType.Dagger:
                    durability = random.Next(1,5);
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

    class Gold : Tile
    {
        public string symbol = "G";
        public int gold { get; private set; }

        public Gold()
        {
            Random random = new Random();
            gold = random.Next(0, 10);
        }
    }

    class Potion : Tile
    {
        public string symbol = "H";
        public int healingAmount { get; private set; }

        public Potion()
        {
            Random random = new Random();
            healingAmount = random.Next(1, 5);
        }
    }

    class Monster : Tile
    {
        public string symbol = "M";
        public enum MonsterType { Zombie, Skeleton, Spider }
        private MonsterType monsterType;
        public int health;
        public int goldDrop;
        public int attack;

        public Monster(MonsterType type, int health, int goldDrop, int attack)
        {
            this.monsterType = type;
            this.health = health;
            this.goldDrop = goldDrop;
            this.attack = attack;
        }

        public MonsterType GetMonsterType()
        {
            Random random = new Random();
            int type = random.Next(0, 3);
            return (MonsterType)type;
        }

        public void OnAttack(Player player)
        {
            player.OnTakeDamage(attack);
        }

        public void OnTakeDamage(int damageTaken)
        {
            health -= damageTaken;
        }
    }

    class Map
    {
        public Tile[,] mapTiles;

        public Map(Tile[,] mapTiles)
        {
            this.mapTiles = mapTiles;

            PopulateGrid(mapTiles);
        }

        public void PopulateGrid(Tile[,] GridToFill)
        {
            Random random = new Random();
            int Gridx = GridToFill.GetLength(0);
            int Gridy = GridToFill.GetLength(1);

            float totalgrid = Gridx * Gridy;

            int filledTiles = (int)Math.Round(totalgrid * 0.66);

            Tile randtile = new Tile();

            bool IsPlayerPlaced = false;
            int randTileNum;

            for (int i = 0; i < Gridx; i++)
            {
                for (int j = 0; j < Gridy; j++)
                {

                    
                    if (IsPlayerPlaced)
                    {
                        randTileNum = random.Next(2, 6);
                    }
                    else
                    {
                        randTileNum = random.Next(1, 6);
                    }

                    switch (randTileNum)
                    {
                        case (1):
                            randtile = new Player(0, 0, 100, 0, new Weapon());
                            IsPlayerPlaced = true;
                            break;
                        case (2):
                            randtile = new Gold();
                            break;
                        case (3):
                            randtile = new Potion();
                            break;
                        case (4):
                            randtile = new Monster(0, 100, 10, 30);
                            break;
                        case (5):
                            randtile = new Weapon();
                            break;
                    }
                    GridToFill[i, j] = randtile;
                }
            }
        }
    }

    class GameEngine
    {
        public Map map = new Map(new Tile[9,9]);
    }



    class Program
    {
        static void Main(string[] args)
        {
            GameEngine gameEngine = new GameEngine();

            for(int i = 0; i < gameEngine.map.mapTiles.GetLength(0); i++)
            {
                Console.Write("\n"); 
                for (int j = 0; j < gameEngine.map.mapTiles.GetLength(1); j++)
                {
                    
                    Console.Write("{0}\t", gameEngine.map.mapTiles[i, j]);
                }
                Console.Write("\n\n");
            }
            
        }
    }


}
