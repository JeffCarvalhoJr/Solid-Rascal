using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Items.Armors
{
    class ChainMail : Armor
    {
        public ChainMail()
        {
            iName = "Chain Mail";
            iValue = 4;
            iModifier = rand.Next(-5, 5);
        }

        public override int DefenseRoll()
        {
            return _die.Roll(2, 4) + iModifier + iValue;
        }
    }
}
