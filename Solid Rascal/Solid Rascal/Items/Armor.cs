using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Items
{
    class Armor : Item
    {

        public Armor()
        {
            iName = "NoName";
            iType = 220;
            iCat = 2;
            iModifier = 1;
        }

        public virtual int DefenseRoll()
        {
            return _die.Roll(1,1) + iModifier;
        }
    }
}
