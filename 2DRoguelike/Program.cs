using _2DRoguelike;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DRoguelike
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input for How big the map should be
            Console.Write("Grid X Size?: \n");
            int xSize = Convert.ToInt32(Console.ReadLine());
            Console.Write("Grid Y Size?: \n");
            int ySize = Convert.ToInt32(Console.ReadLine());
            GameEngine gameEngine = new GameEngine(new Map(new Tile[xSize, ySize]));

            //Print Grid to Console
            for (int i = 0; i < gameEngine.map.MapTiles.GetLength(0); i++)
            {
                Console.Write("\n");
                for (int j = 0; j < gameEngine.map.MapTiles.GetLength(1); j++)
                {
                    Console.Write("{0}\t", gameEngine.map.MapTiles[i, j].symbol);
                }
                Console.Write("\n\n");
            }


            //TODO
            //Monster Combat
            //Potion Heal Player
            //Find Weapon
            //Find Gold

            //Issues - How to access variables of specific tiles - for future implementing when player moves
            //How to check for wrong input when asking for user input - Generates error Currently

        }
    }
}
