using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Characters.Enemies
{
    class Harpy : Character
    {
        public Harpy()
        {
            sDEF = 0;

            cName = "Harpy";
            cType = 107;

            sHP = 20;
            sMHP = 20;

            xpDrop = 15;
        }

        public override int GetAttackRoll()
        {
            return _die.Roll(2, 10);
        }
    }
}
