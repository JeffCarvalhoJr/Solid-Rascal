using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Characters.Enemies
{
    class Minotaur : Character
    {
        public Minotaur()
        {
            sDEF = 0;

            cName = "Minotaur";
            cType = 112;

            sHP = 10;
            sMHP = 10;
        }

        public override int GetAttackRoll()
        {
            return _die.Roll(3, 6);
        }
    }
}
