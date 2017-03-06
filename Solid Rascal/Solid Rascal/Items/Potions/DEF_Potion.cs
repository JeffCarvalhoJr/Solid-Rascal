using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solid_Rascal.Characters.Player;

namespace Solid_Rascal.Items.Potions
{
    class DEF_Potion : Consumable
    {
        public DEF_Potion()
        {
            iName = "Defense Potion";
            iValue = rand.Next(2, 4);
            iModifier = 3;
        }

    }
}
