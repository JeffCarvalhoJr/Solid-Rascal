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
        public Dice _die;
        public Random rand;

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
            rand = MainGame.rand;
            _die = new Dice();
            CreateItem();
        }

        public void SetNewPosition(int X, int Y)
        {
            xPos = X;
            yPos = Y;
        }

        public void CreateItem()
        {

            switch (iCat)
            {
         
                case 1:
                    //Weapon
                    iName = "Weapon";
                    iType = 200;
                    break;
                case 2:
                    //Armor
                    iName = "Armor";
                    iType = 220;
                    break;
                case 3:
                    //Consumable
                    iName = "Consumable";
                    iType = 230;
                    break;
                case 4:
                    //Collectible
                    iName = "Collectible";
                    iType = 250;
                    break;
                default:
                    break;
            }
        }

        public void Collect(Player player)
        {
          player.AddItem(this);
        }

    }
}
