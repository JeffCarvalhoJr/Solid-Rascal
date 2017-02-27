using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Items
{
    class Weapon : Item
    {  

        public Weapon()
        {
            iName = "NoName";
            iType = 200;
            iCat = 1;
            iModifier = 1;
        }

        public virtual int DamageRoll()
        {
            return _die.Roll(1, 1) + iModifier  ;
        }
    }
}