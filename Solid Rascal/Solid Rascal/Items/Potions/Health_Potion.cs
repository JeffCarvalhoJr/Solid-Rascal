using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Items.Potions
{
    class Health_Potion : Consumable
    {
        public Health_Potion()
        {
            iName = "Health Potion";
            iValue = 10;
            iModifier = 1;
        }
    }
}
