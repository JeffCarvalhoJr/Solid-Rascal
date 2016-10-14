using Solid_Rascal.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal
{
    class MainGame
    {
        //This is random
        public static Random rand = new Random();

        //Room Placement Tries
        public static int TRIES = 0;

        public Map mapGen;
        public int[,] currentMap;

        public Tileset TILESET;

        //map Variables
        public int MAPHeight;
        public int MAPWidth;
        public int MaxRooms;

        //public static List<Room> _RoomsL;
        public Room[,] _RoomsL;

        public static List<Corridor> _CorridorsL;

        Alert alert = new Alert();

        public string playerAnswer;


        public MainGame()
        {
            TILESET = new Tileset();
            GameStart();

        }


        void GameStart()
        {

            MAPWidth = 90;
            MAPHeight = 30;

            MaxRooms = 9;

            //generating map loop
            do
            {
                try
                {
                    mapGen = new Map(MAPWidth, MAPHeight);
                    currentMap = mapGen.GetMap();
                    PrintMap();
                }
                catch
                {
                    alert.Warning("An error ocurried while the map was being generated");
                }
                
                
                try
                {
                    playerAnswer = alert.Question("Want to generate again? (y/n)");
                }
                catch
                {
                    playerAnswer = "y";
                }
            } while (playerAnswer.Equals("Y") || playerAnswer.Equals("y"));

        }
 
        void PrintMap()
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            for (int i = 0; i < MAPHeight; i++)
            {
                if (i > 0)
                    Console.Write("\n");
                for (int j = 0; j < MAPWidth; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write(TILESET.TileType(mapGen.MAP[i, j]));
                    //System.Threading.Thread.Sleep(1);//function to see the map being printed on the console with a delay (kinda nice)
                }
            }
        }   
    }
}
