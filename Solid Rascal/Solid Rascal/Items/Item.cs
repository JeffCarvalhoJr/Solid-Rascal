using System;
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
        public string Name { get; set; }

        //if player have given a name for the item.
        public bool catalog { get; set; }

        public int xPos { get; set; }
        public int yPos { get; set; }


        public void SetNewPosition(int X, int Y)
        {
            xPos = X;
            yPos = Y;
        }

        public void Collect()
        {
            switch (iCat)
            {
                case 1:
                    //Wear/Wield equipment
                    break;
                case 2:
                    //Collectibles
                    break;
                case 3:
                    //Consumables
                    Console.WriteLine("GOT SOME DIAMONDS!");
                    Console.ReadLine();
                    break;
                default:
                    break;
            }
        }

    }
}
