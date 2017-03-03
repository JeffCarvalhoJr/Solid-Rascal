using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Items.Armors
{
    class PlateMail : Armor
    {
        public PlateMail()
        {
            iName = "Plate Mail";
            iValue = 8;
            iModifier = rand.Next(-2, 6);
        }

        public override int DefenseRoll()
        {
            return _die.Roll(3, 5) + iModifier + iValue;
        }
    }
}
