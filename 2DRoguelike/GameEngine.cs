using System;
using System.Threading.Tasks;

namespace _2DRoguelike
{
    class GameEngine
    {
        private Map map;
        private Player playerTile;

        //Storage for co-ords of previous tile
        int prevX, prevY;

        public GameEngine(Map map)
        {
            this.map = map;
            playerTile = map.PlayerTile;
        }

        internal Map Map { get => map; set => map = value; }


        public void DisplayGrid()
        {
            //Print Grid to Console
            for (int i = 0; i < Map.MapTiles.GetLength(0); i++)
            {
                Console.Write("\n");
                for (int j = 0; j < Map.MapTiles.GetLength(1); j++)
                {
                    Console.Write("{0}\t", Map.MapTiles[j, i].symbol);
                }
                Console.Write("\n\n");
            }
            Console.WriteLine("What would you like to do? 'm' = move, 'u' = upgrade weapon, 'r' = reset");
            string response = Console.ReadLine();
            if (response == "m")
            {
                GetDirectioninput();
            }
            else if(response == "u")
            {
                UpgradeWeapon();
                DisplayGrid();
            }
            else if(response == "r")
            {
                map = new Map(new Tile[map.MapTiles.GetLength(0), map.MapTiles.GetLength(1)]);
                Console.Clear();
                DisplayGrid();
            }
        }

        private void GetDirectioninput()
        {
            Console.WriteLine("Where would you like to go? \n'u' = up, 'd' = down, 'l' = left, 'r' = right");
            string directionInput = Console.ReadLine();
            
            prevX = playerTile.XPosition;
            prevY = playerTile.YPosition;
            switch (directionInput)
            {
                case "u":
                    DetermineTile(Map.MovePlayer(Map.Direction.up));
                    break;
                case "d":
                    DetermineTile(Map.MovePlayer(Map.Direction.down));
                    break;
                case "l":
                    DetermineTile(Map.MovePlayer(Map.Direction.left));
                    break;
                case "r":
                    DetermineTile(Map.MovePlayer(Map.Direction.right));
                    break;
                default:
                    break;
            }   
        }

        private void DetermineTile(Tile nextTile)
        {
            ReplaceTile(prevX, prevY);
            Console.Clear();
            switch (nextTile.GetType().Name)
            {
                case "Gold":
                    Console.WriteLine("Tile is Gold");
                    Gold GoldTile = (Gold)nextTile;
                    FindGold(GoldTile.GoldAmount);
                    break;
                case "Potion":
                    Console.WriteLine("Tile is Potion");
                    Potion potionTile = (Potion)nextTile;
                    HealPlayer(potionTile.HealingAmount);
                    break;
                case "Monster":
                    Console.WriteLine("Tile is Monster");
                    Monster monsterTile = (Monster)nextTile;
                    FindMonster(monsterTile);
                    break;
                case "Weapon":
                    Console.WriteLine("Tile is Weapon");
                    Weapon weaponTile = (Weapon)nextTile;
                    FindWeapon(weaponTile);
                    break;
                case "Tile":
                    Console.WriteLine("Tile is Weapon");
                    DisplayGrid();
                    break;
                case "Player":
                    Console.WriteLine("Tile is player");
                    DisplayGrid();
                    break;
                default:
                    break;
            }
        }

        private void ReplaceTile(int oldX, int oldY)
        {
            Map.MapTiles[playerTile.XPosition, playerTile.YPosition] = playerTile;
            Map.MapTiles[oldX, oldY] = new Tile(); 
        }

        #region - Individual Tile Code
        private void HealPlayer(int healamount)
        {
            Map.PlayerTile.Health += healamount;
            DisplayGrid();
        }

        private void FindGold(int goldAmount)
        {
            Map.PlayerTile.GoldPurse += goldAmount;
            DisplayGrid();
        }


        private void FindWeapon(Weapon weaponFound)
        {
            Console.Clear();
            Console.WriteLine("You come accross a brand new " + weaponFound.weaponType);
            Console.WriteLine("It does " + weaponFound.Damage + " points of damage");
            Console.WriteLine("It has " + weaponFound.Durability + " points of durability");

            Console.WriteLine();

            Console.WriteLine("Your current weapon stats: ");

            Console.WriteLine("It does " + playerTile.Weapon.Damage + " points of damage");
            Console.WriteLine("It has " + playerTile.Weapon.Durability + " points of durability");

            Console.WriteLine();

            Console.WriteLine("Do you want to keep it? y/n");
            string response = Console.ReadLine();
            if (response == "y")
            {
                playerTile.Weapon = weaponFound;
            }
            DisplayGrid();
        }

        private void UpgradeWeapon()
        {
            Console.WriteLine("It will cost " + playerTile.Weapon.UpgradeCost + " to upgrade this weapon");
            Console.WriteLine("Do you wish to proceed? y/n");

            string response = Console.ReadLine();
            if(response == "y")
            {
                playerTile.Weapon.UpgradeWeapon();
            }
            else
            {
                Console.Clear();
            }
        }

        private void FindMonster(Monster monster)
        {
            while(monster.Health > 0 && (playerTile.Health > 0 | playerTile.Weapon.Durability <=0))
            {
                playerTile.OnAttack(monster);
                
                monster.OnAttack(playerTile);
            }

            if(playerTile.Health <= 0)
            {
                Console.Clear();
                Console.WriteLine("You Have Died");
                Console.WriteLine();
                Console.WriteLine("Do want to play again? y/n");
                string response = Console.ReadLine();
                if(response == "y")
                {
                    map = new Map(new Tile[map.MapTiles.GetLength(0), map.MapTiles.GetLength(1)]);
                    DisplayGrid();
                }
            }
            else if(monster.Health <= 0)
            {
                Console.WriteLine("Monster Has Died");
                FindGold(monster.GoldDrop);
                DisplayGrid();
            }
        }

        #endregion
    }
}