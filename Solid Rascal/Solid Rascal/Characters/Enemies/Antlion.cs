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

            sHP = 10;
            sMHP = 10;
        }

        public override int GetAttackRoll()
        {
            return _die.Roll(2, 6);
        }
    }
}
