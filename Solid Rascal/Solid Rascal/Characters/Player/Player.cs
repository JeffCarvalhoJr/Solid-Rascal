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
        public bool activePotion;

        public List<Item> inv { get; set; } //inventory

        public int sHunger;

        public Player(string name)
        {
            alert = new Alert();

            inv = new List<Item>();

            hasEWeapon = false;
            hasEArmor = false;

            isPlayer = true;

            cName = name;
            cType = 52;

            sHunger = 1000;
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
            }
            else
            {
                return 1;
            }
        }

        public void AddItem(Item item)
        {
            inv.Add(item);
        }

        public void AddDiamonds(int value)
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

                    if (!hasEWeapon)
                    {
                        alert.Action("You equipped the " + inv[index].iName);
                        eWeapon = inv[index] as Weapon;
                        eWeapon.isEquipped = true;
                        hasEWeapon = true;
                    }
                    else
                    {
                        if (eWeapon == inv[index])
                        {
                            eWeapon.isEquipped = false;
                            eWeapon = null;
                            hasEWeapon = false;

                            alert.Action("You unequipped your weapon!");
                        }else
                        {
                            eWeapon.isEquipped = false;
                            alert.Action("You equipped the " + inv[index].iName);
                            eWeapon = inv[index] as Weapon;
                            eWeapon.isEquipped = true;
                            hasEWeapon = true;
                        }
                    }

                }
            }
            catch { alert.Action("Invalid Choice"); }
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
                    if (!hasEArmor)
                    {
                        alert.Action("You equipped the " + inv[index].iName);
                        eArmor = inv[index] as Armor;
                        eArmor.isEquipped = true;
                        hasEArmor = true;
                    }else
                    {
                        if(eArmor == inv[index])
                        {
                            eArmor.isEquipped = false;
                            eArmor = null;
                            hasEArmor = false;

                            alert.Action("You unequipped your armor!");
                        }else
                        {
                            eArmor.isEquipped = false;
                            alert.Action("You equipped the " + inv[index].iName);
                            eArmor = inv[index] as Armor;
                            eArmor.isEquipped = true;
                            hasEArmor = true;
                        }
                    }
                }
            }
            catch { alert.Action("Invalid Choice"); }
        }

        public void Use(int index)
        {
            try
            {
                if (inv[index].iCat != 3)
                {
                    alert.Action("Invalid Choice");
                }
                else
                {
                    if (inv[index].iModifier != 5)
                    {
                        alert.Action("You consumed the " + inv[index].iName);
                        Consumable currentPotion = inv[index] as Consumable;
                        currentPotion.Consume(this);
                        inv.RemoveAt(index);
                    }
                    else
                    {
                        //identification scroll
                        IdentifyItem(index);
                    }
                }
            }
            catch { alert.Action("Invalid Choice"); }
        }

        public void Consume(int type, int value = 0, int time = 0)
        {
            switch (type)
            {
                //HP
                case 1:
                    ChangeHealth(value);
                    break;
                //STR
                case 2:
                    break;
                //DEF
                case 3:
                    break;
                //Food
                case 4:
                    ChangeFood(value);
                    break;
                default:
                    break;
            }
        }

        void IdentifyItem(int index)
        {
            //checks if inventory has items
            //Pick a item from your inventory
            //Compare the category
            //tell if it can be indentified
            //tell if it is already indentified
            //Identify the item: Reveal if the item has positive or negative modifier 
            if (inv.Count > 1)
            {
                alert.Action("Choose an Item to identify (press i to check your inventory)");

                ConsoleKeyInfo userCKI = Console.ReadKey();
                Item itemToIdentify = null;
                int i_Index;

                if (userCKI.Key == ConsoleKey.I)
                {

                }
                else if (char.IsDigit(userCKI.KeyChar))
                {
                    i_Index = int.Parse(userCKI.KeyChar.ToString());

                    try
                    {
                        itemToIdentify = inv[i_Index];


                        if (itemToIdentify.iCat != 1 && itemToIdentify.iCat != 2)
                        {
                            alert.Action("You can only identify weapons and armors");
                        }
                        else
                        {
                            inv[i_Index].iName = inv[i_Index].iName + " (" + inv[i_Index].iModifier + ")";
                            alert.Action("You have indentified the: " + inv[i_Index].iName);
                            inv.RemoveAt(index);
                        }

                    }
                    catch
                    {
                        alert.Warning("Invalid Choice !");
                    }
                }
            }
            else
            {
                alert.Warning("You dont have nothing to identify");
            }

        }

        void ChangeHealth(int amount)
        {
            sHP += amount;
            if (sHP >= sMHP)
            {
                sHP = sMHP;
            }
        }

        void ChangeFood(int amount)
        {
            sHunger += amount;
            if (sHunger >= 1000)
            {
                sHunger = 1000;
            }
        }
    }
}