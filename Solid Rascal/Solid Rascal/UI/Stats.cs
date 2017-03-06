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
            for (int i = 0; i < PLAYER.inv.Count; i++)
            {
                Console.SetCursorPosition(0, i);
                if (PLAYER.inv[i].isEquipped)
                {
                    Console.WriteLine(i + ")" + " " + PLAYER.inv[i].iName + " [e]");
                }
                else
                {
                    Console.WriteLine(i + ")" + " " + PLAYER.inv[i].iName);
                }
               
            }
        }

        public void Action(Player newPlayer)
        {
            PLAYER = newPlayer;
            Console.SetCursorPosition(0, UIHeight + 2);
           
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(@"
╔════════════╦══════════╦══════════╦═════╦════════╗
║♥HP:{0}({1})" + @"│STR:{2}({3})│DEF:{4}({5})│♦:{6}│LEVEL:{7}║  
╚════════════╩══════════╩══════════╩═════╩════════╝", PLAYER.sHP.ToString("000"), PLAYER.sMHP.ToString("000"),
                                                            (PLAYER.sSTR + PLAYER.mSTR).ToString("00"), PLAYER.sMSTR.ToString("00"),
                                                            (PLAYER.sDEF + PLAYER.mDEF).ToString("00"), PLAYER.sMDEF.ToString("00"),PLAYER.sDiamonds.ToString("000"),MainGame.currentLevel.ToString("00"));
            if (newPlayer.sHunger < 500)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(51, UIHeight + 4);
                Console.Write(@"Peckish");
            }
            else if (newPlayer.sHunger < 250)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(51, UIHeight + 4);
                Console.Write(@"Starving");
            }
            else
            {
                Console.SetCursorPosition(51, UIHeight + 4);
                Console.Write(@"FINE   ");
            }
        }
    }
}
