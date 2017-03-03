using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Items.Armors
{
    class BandedMail : Armor
    {
        public BandedMail()
        {
            iName = "Banded Mail";
            iValue = 6;
            iModifier = rand.Next(-3, 5);
        }

        public override int DefenseRoll()
        {
            return _die.Roll(2, 4) + iModifier + iValue;
        }
    }
}
