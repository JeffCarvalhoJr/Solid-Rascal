using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Items.Weapons
{
    class Longsword : Weapon
    {
        public Longsword()
        {
            iName = "Longsword";
            iModifier = rand.Next(-2, 5);
        }

        public override int DamageRoll()
        {
            return _die.Roll(3, 4) + iModifier;
        }
    }
}
