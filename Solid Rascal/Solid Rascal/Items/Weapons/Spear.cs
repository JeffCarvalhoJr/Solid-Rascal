using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Items.Weapons
{
    class Spear : Weapon
    {

        public Spear()
        {
            iName = "Spear";
            iModifier = rand.Next(-2, 6);
        }

        public override int DamageRoll()
        {
            return _die.Roll(2, 4) + iModifier;
        }
    }
}
