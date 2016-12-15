using System;
using Solid_Rascal.Items;
using Solid_Rascal.Items.Collectibles;
using Solid_Rascal.Items.Consumables;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.GameMasters
{
    class ItemSpawner
    {
        public Item GetItem(int id)
        {
            Item nextItem;
            switch (id)
            {
                //Potions
                case 200:
                    nextItem = new HealthPotion();
                    return nextItem;
                case 201:
                    nextItem = new Diamond();
                    return nextItem;
                //Collectibles
                case 210:
                    nextItem = new Diamond();
                    return nextItem;
                default:
                    nextItem = new Diamond();
                    return nextItem;

            }
        }
    }
}
