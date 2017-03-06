using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Characters.Enemies
{
    class Unicorn : Character
    {
        public Unicorn()
        {
            sDEF = 0;

            cName = "Unicorn";
            cType = 120;

            sHP = 30;
            sMHP = 30;

            xpDrop = 18;
        }

        public override int GetAttackRoll()
        {
            return _die.Roll(2, 10);
        }
    }
}
