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


            //How to check for wrong input when asking for user input - Generates error Currently

        }
    }
}
