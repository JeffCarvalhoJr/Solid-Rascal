using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Characters.Enemies
{
    class Bat : Character
    {
        public Bat()
        {
            sDEF = 0;

            cName = "Bat";
            cType = 101;

            sHP = 10;
            sMHP = 10;
        }

        public override int GetAttackRoll()
        {
            return _die.Roll(1, 6);
        }
    }
}
