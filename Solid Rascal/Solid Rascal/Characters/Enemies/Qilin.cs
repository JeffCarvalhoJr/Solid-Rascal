using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Characters.Enemies
{
    class Qilin : Character
    {
        public Qilin()
        {
            sDEF = 0;

            cName = "Qilin";
            cType = 116;

            sHP = 25;
            sMHP = 25;

            xpDrop = 15;
        }

        public override int GetAttackRoll()
        {
            return _die.Roll(2, 10);
        }
    }
}
