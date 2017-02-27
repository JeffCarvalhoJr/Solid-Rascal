using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solid_Rascal.Characters.Player;

namespace Solid_Rascal.Items
{
    class Consumable : Item
    {
        public Consumable()
        {
            iName = "Potion with noname";
            iType = 230;
            iCat = 3;
        }

        public virtual void Consume(Player player)
        {
            player.Consume(iModifier, iValue);
        }

    }
}
