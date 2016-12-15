using System;
using Solid_Rascal.Characters.Player;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Items
{
    class Item
    {
        public int iType { get; set; }
        public int iCat { get; set; }
        public int iValue { get; set; }
        public int iModifier { get; set; }
        public string iName { get; set; }

        //if player have given a name for the item.
        public bool catalog { get; set; }

        public int xPos { get; set; }
        public int yPos { get; set; }

        public Item()
        {
            iName = "missing";
            iCat = -1;
            iType = -1;
            iValue = -1;
            iModifier = -1;
        }

        public void SetNewPosition(int X, int Y)
        {
            xPos = X;
            yPos = Y;
        }

        public void Collect(Player player)
        {
            switch (iCat)
            {
                case 1:
                    //Wear/Wield equipment
                    break;
                case 2:
                    //Collectibles
                    player.AddItem(iCat, this);
                    break;
                case 3:
                    //Consumables
                    player.AddGold(10);
                    break;
                default:
                    break;
            }
        }

    }
}
