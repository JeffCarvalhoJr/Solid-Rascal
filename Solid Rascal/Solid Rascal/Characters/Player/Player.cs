using System;
using Solid_Rascal.Items;
using System.Collections.Generic;
using Solid_Rascal.UI;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Characters.Player
{
    class Player : Character
    {
        Alert alert;

        public bool hasEWeapon;
        public bool hasEArmor;

        public List<Item> inv { get; set; } //inventory

        public Player(string name)
        {
            alert = new Alert();

            inv = new List<Item>();

            hasEWeapon = false;
            hasEArmor = false;

            isPlayer = true;

            charNAME = name;
            charID = 52;

            sSTR = 5;
            sMSTR = 5;
            sDEF = 1;
            sHP = 50;
            sMHP = 50;
            sDiamonds = 0;
        }

        public override int GetAttackRoll()
        {
            if (hasEWeapon)//Has equiped weapon
            {
                return eWeapon.DamageRoll();
            }
            else
            {
                return 1;//unnarmed attack
            }
        }

        public override int GetDefenseRoll()
        {
            if (hasEArmor)
            {
                return eArmor.DefenseRoll();
            }else
            {
                return 1;
            }
        }

        public void AddItem(Item item)
        {
            inv.Add(item);
        }

        public void AddGold(int value)
        {
            sDiamonds += value;
        }

        public void Wield(int index)
        {
            try
            {
                if (inv[index].iCat != 1)
                {
                    alert.Action("Invalid Choice");
                }
                else
                {
                    alert.Action("You equipped the " + inv[index].iName);
                    eWeapon = inv[index] as Weapon;
                    inv[index].iName = inv[index].iName + " [e]";
                    hasEWeapon = true;
                }
            }
            catch{alert.Action("Invalid Choice");}
        }

        public void Wear(int index)
        {
            try
            {
                if (inv[index].iCat != 2)
                {
                    alert.Action("Invalid Choice");
                }
                else
                {
                    alert.Action("You equipped the " + inv[index].iName);
                    eArmor = inv[index] as Armor;
                    inv[index].iName = inv[index].iName + " [e]";
                    hasEArmor = true;
                }
            }
            catch{alert.Action("Invalid Choice");}
        }

        public void Drink(int index)
        {
            try
            {
                if (inv[index].iCat != 3)
                {
                    alert.Action("Invalid Choice");
                }
                else
                {
                    //Consumir poção
                    alert.Action("You drank the " + inv[index].iName);
                }
            }
            catch
            {
                alert.Action("Invalid Choice");
            }
        }

    }
}