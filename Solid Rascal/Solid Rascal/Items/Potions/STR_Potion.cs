using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Items.Potions
{
    class STR_Potion : Consumable
    {
        public STR_Potion()
        {
            iName = "Strength Potion";
            iValue = rand.Next(2, 4);
            iModifier = 2;
        }
    }
}
