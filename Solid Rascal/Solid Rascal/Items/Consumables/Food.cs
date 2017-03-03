using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Items.Consumables
{
    class Food : Consumable
    {
        public Food()
        {
            iName = "Ration";
            iType = 260;
            iValue = 250;
            iModifier = 4;
        }
    }
}
