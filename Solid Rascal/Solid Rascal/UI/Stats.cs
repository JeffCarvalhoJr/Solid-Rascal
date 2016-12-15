using System;
using Solid_Rascal.Items;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solid_Rascal.Characters.Player;

namespace Solid_Rascal.UI
{
    class Stats
    {
        int UIHeight;
        Player PLAYER;

        public Stats(int height, Player newPlayer)
        {
            UIHeight = height;
            PLAYER = newPlayer;
        }

        public void Inventory()
        {
            for(int i = 0; i < PLAYER.inv2.Count; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine((i+1)+")" + " "+PLAYER.inv2[i].iName);
            }
            
        }

        public void Action(Player newPlayer)
        {
            PLAYER = newPlayer;
            Console.SetCursorPosition(0, UIHeight + 2);
           
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(@"
╔══════════╦══════════╦════════╦═════╦════════╗
║♥HP:{0}({1})" + @"│STR:{2}({3})│Armor:{4}│♦:{5}│LEVEL:{6}║  
╚══════════╩══════════╩════════╩═════╩════════╝", PLAYER.sHP.ToString("00"),PLAYER.sMHP.ToString("00"), 
                                                            PLAYER.sSTR.ToString("00"), PLAYER.sMSTR.ToString("00"),
                                                            PLAYER.sARMOR.ToString("00"),PLAYER.sDiamonds.ToString("000"),MainGame.currentLevel.ToString("00"));
        }
    }
}
