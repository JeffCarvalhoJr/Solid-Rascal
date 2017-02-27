using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Characters.Enemies
{
    class Lamia : Character
    {
        public Lamia()
        {
            sDEF = 0;

            cName = "Lamia";
            cType = 111;

            sHP = 10;
            sMHP = 10;
        }

        public override int GetAttackRoll()
        {
            return _die.Roll(2, 6);
        }
    }
}
