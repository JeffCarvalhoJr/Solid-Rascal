using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Items.Armors
{
    class ScaleMail : Armor
    {
        public ScaleMail()
        {
            iName = "Scale Mail";
            iValue = 5;
            iModifier = rand.Next(-4, 8);
        }

        public override int DefenseRoll()
        {
            return _die.Roll(2, 6) + iModifier + iValue;
        }
    }
}
