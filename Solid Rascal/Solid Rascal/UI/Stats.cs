using System;
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

        public void Action(Player newPlayer)
        {
            PLAYER = newPlayer;
            Console.SetCursorPosition(0, UIHeight + 2);
           
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(@"
╔══════════╦══════════╦═════════╦════════╦═══════════╦════════╗
║♥HP:{0}({1})" + @"│STR:00(00)│Armor:000│Gold:000│EXP:000/000│LEVEL:00║  
╚══════════╩══════════╩═════════╩════════╩═══════════╩════════╝", PLAYER._Health.ToString("00"),PLAYER._Health.ToString("00"));
        }
    }
}
