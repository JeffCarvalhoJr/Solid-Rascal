using System;
using Solid_Rascal.Items;
using Solid_Rascal.Items.Weapons;
using Solid_Rascal.Items.Armors;
using Solid_Rascal.Items.Potions;
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
                case 100:
                    nextItem = new Mace();
                    return nextItem;
                case 150:
                    nextItem = new LeatherA();
                    return nextItem;
                case 200:
                    nextItem = new Health_Potion();
                    return nextItem;
                case 250:
                    nextItem = new Food();
                    return nextItem;
                default:
                    nextItem = new Mace();
                    return nextItem;
            }
        }
        

       
    }
}
