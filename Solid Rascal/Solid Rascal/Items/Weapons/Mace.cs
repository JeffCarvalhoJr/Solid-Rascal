using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Items.Weapons
{
    class Mace : Weapon
    {
        public Mace()
        {
            iName = "Mace";
            iModifier = MainGame.rand.Next(-2, 3);
        }

        public override int DamageRoll()
        {
            return _die.Roll(1, 6) + iModifier;
        }
    }
}
