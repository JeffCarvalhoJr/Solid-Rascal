using System;
using Solid_Rascal.Items;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Characters.Player
{
    class Player : Character
    {
        public List<Item> inv1 { get; set; } //Consumables
        public List<Item> inv2 { get; set; } //Equipament

        public Player(string name)
        {
            inv1 = new List<Item>();
            inv2 = new List<Item>();

            isPlayer = true;

            charNAME = name;
            charID = 52;

            sSTR = 10;
            sMSTR = 10;
            sARMOR = 1;
            sHP = 50;
            sMHP = 50;
            sDiamonds = 0;  
        }


        public void AddItem(int invType, Item item)
        {
            switch (invType)
            {
                case 1:
                    inv1.Add(item);
                    break;
                case 2:
                    inv2.Add(item);
                    break;
                default:
                    break;
            }
        }

        public void AddGold(int value)
        {
            sDiamonds += value;
        }

        public void Wear()
        {

        }

        public void Consume()
        {

        }

        public void Wield()
        {

        }

    }
}
