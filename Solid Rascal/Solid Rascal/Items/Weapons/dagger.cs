using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Items.Weapons
{
    class Dagger : Weapon
    {
        public Dagger()
        {
            iName = "Dagger";
            iModifier = rand.Next(-3, 8);
        }

        public override int DamageRoll()
        {
            return _die.Roll(1, 12) + iModifier;
        }
    }
}
