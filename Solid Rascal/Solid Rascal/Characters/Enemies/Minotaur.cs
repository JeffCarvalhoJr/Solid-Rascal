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

            sHP = 75;
            sMHP = 75;

            xpDrop = 50;
        }

        public override int GetAttackRoll()
        {
            return _die.Roll(3, 10);
        }
    }
}
