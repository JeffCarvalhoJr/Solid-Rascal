using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Characters.Enemies
{
    class Yeti : Character
    {
        public Yeti()
        {
            sDEF = 0;

            cName = "Yeti";
            cType = 124;

            sHP = 80;
            sMHP = 80;

            xpDrop = 25;
        }

        public override int GetAttackRoll()
        {
            return _die.Roll(3, 10);
        }
    }
}
