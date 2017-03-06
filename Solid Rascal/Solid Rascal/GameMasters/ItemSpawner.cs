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
                case 101:
                    nextItem = new Dagger();
                    return nextItem;
                case 102:
                    nextItem = new Spear();
                    return nextItem;
                case 103:
                    nextItem = new Longsword();
                    return nextItem;
                case 150:
                    nextItem = new LeatherA();
                    return nextItem;
                case 151:
                    nextItem = new ChainMail();
                    return nextItem;
                case 152:
                    nextItem = new ScaleMail();
                    return nextItem;
                case 153:
                    nextItem = new BandedMail();
                    return nextItem;
                case 154:
                    nextItem = new PlateMail();
                    return nextItem;
                case 200:
                    nextItem = new Health_Potion();
                    return nextItem;
                case 201:
                    nextItem = new STR_Potion();
                    return nextItem;
                case 202:
                    nextItem = new DEF_Potion();
                    return nextItem;
                case 250:
                    nextItem = new Food();
                    return nextItem;
                case 251:
                    nextItem = new Scroll_Ident();
                    return nextItem;
                case 252:
                    nextItem = new Diamond();
                    return nextItem;
                default:
                    nextItem = new Mace();
                    return nextItem;
            }
        }
        

       
    }
}
