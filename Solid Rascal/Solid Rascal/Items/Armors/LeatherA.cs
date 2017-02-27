using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Items.Armors
{
    class LeatherA : Armor
    {
        public LeatherA()
        {
            iName = "Plake Mail";
            iValue = 3;
            iModifier = rand.Next(-3, 1);
        }

        public override int DefenseRoll()
        {
            return _die.Roll(1, 6) + iModifier + iValue;
        }
    }
}