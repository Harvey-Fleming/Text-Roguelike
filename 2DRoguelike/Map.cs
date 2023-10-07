using System;

namespace _2DRoguelike
{
    class Map
    {
        public enum Direction {up, down, left, right };
        private Tile[,] mapTiles;
        private Player playerTile;
        Random random = new Random();

        public Map(Tile[,] mapTiles)
        {
            this.mapTiles = mapTiles;

            PopulateGrid(mapTiles);
        }

        internal Tile[,] MapTiles { get => mapTiles; set => mapTiles = value; }

        public void PopulateGrid(Tile[,] GridToFill)
        {

            int Gridx = GridToFill.GetLength(0);
            int Gridy = GridToFill.GetLength(1);

            Tile randtile = new Tile();
            int randTileNum;

            for (int i = 0; i < Gridx; i++)
            {
                for (int j = 0; j < Gridy; j++)
                {
                    randTileNum = random.Next(1, 5);

                    switch (randTileNum)
                    {
                        case (1):
                            randtile = new Gold();
                            break;
                        case (2):
                            randtile = new Potion();
                            break;
                        case (3):
                            randtile = new Monster(0, 100, 10, 30);
                            break;
                        case (4):
                            randtile = new Weapon();
                            break;
                    }
                    
                    GridToFill[i, j] = randtile;
                }  
            }
            PlacePlayer(GridToFill, Gridx, Gridy);
        }

        private void PlacePlayer(Tile[,] gridtoFill, int gridx, int gridy)
        {
            int ranx = random.Next(1, gridx);
            int rany = random.Next(1, gridy);
            playerTile = new Player(ranx, rany, 100, 0, new Weapon());
            gridtoFill[ranx, rany] = playerTile;
        }

        public void MovePlayer(Direction direction)
        {
            if(CheckMovement(direction))
            {
                switch (direction)
                {
                    case Direction.up:
                        playerTile.YPosition += 1;
                        break;
                    case Direction.down:
                        playerTile.YPosition -= 1;
                        break;
                    case Direction.left:
                        playerTile.XPosition -= 1;
                        break;
                    case Direction.right:
                        playerTile.XPosition += 1;
                        break;
                }

                //TODO - Ask for direction
                //Check if player can go that Direction
                //If so, change player position and check type of tile.
                //Run Code for individual tile type. Fight, heal, find weapon. etc
            }

            bool CheckMovement(Direction directiontomove)
            {


                return true;
            }
        }
    }
}