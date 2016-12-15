using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Items.Consumables
{
    class HealthPotion : Item
    {


        public HealthPotion()
        {
            iName = "Health Potion";
            iCat = 2;
            iType = 200;
            iModifier = 5;
        }

    }
}
