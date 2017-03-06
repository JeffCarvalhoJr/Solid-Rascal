using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Characters.Enemies
{
    class Antlion : Character
    {
        public Antlion()
        {
            sDEF = 0;

            cName = "Antlion";
            cType = 100;

            sHP = 25;
            sMHP = 25;

            xpDrop = 12;
        }

        public override int GetAttackRoll()
        {
            return _die.Roll(2, 10);
        }
    }
}
