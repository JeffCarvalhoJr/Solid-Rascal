using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Characters.Enemies
{
    class Goblin : Character
    {
        public Goblin()
        {
            sDEF = 1;

            cName = "Goblin";
            cType = 106;

            sHP = 30;
            sMHP = 30;

            xpDrop = 10;
        }

        public override int GetAttackRoll()
        {
            return _die.Roll(1, 10);
        }
    }
}
