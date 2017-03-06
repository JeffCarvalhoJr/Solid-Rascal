using System;
using Solid_Rascal.Characters;
using Solid_Rascal.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal
{
    class Battle
    {

        public Alert _Alert;
        public Dice _Dice;
        public float FD, FA;

        public int ATK, DEF;

        public Battle(Character attacker, Character defender)
        {
            _Alert = new Alert();
            _Dice = new Dice();

            if (attacker.isPlayer)
            {
                FA = attacker.sSTR + attacker.mSTR + attacker.GetAttackRoll() + (attacker.pLevel * 0.25f);
                FD = defender.sDEF + attacker.mDEF + defender.GetDefenseRoll() + (defender.pLevel * 0.25f);
            }
            else
            {
                FA = attacker.sSTR + attacker.GetAttackRoll() + (defender.pLevel * 0.25f);
                FD = defender.sDEF + defender.GetDefenseRoll() + (attacker.pLevel * 0.25f);
            }
         

            //doing tests 
            ATK = (int)FA;
            DEF = (int)FD;

           // _Alert.Warning("[DEBUG] ATK: " + ATK + " DEF " + DEF + " [DEBUG]");

            if (ATK > DEF - 2)
            {
                //Acertou
                defender.ReduceHealth((int)FA);
                _Alert.Warning("" + attacker.cName + " Attacks " + defender.cName + " for " + (int)FA + " damage");
            }
            else if(ATK <= DEF - 2)
            {
                //Errou
                _Alert.Warning("" + attacker.cName + " Attacks " + defender.cName + " and Misses!");
            }

            if(defender.sHP <= 0)
            {
                //Ded
                _Alert.Warning("" + attacker.cName + " Defeats the " + defender.cName);
                if (attacker.isPlayer)
                {
                    attacker.ReceiveXp(defender.xpDrop);
                }
                MainGame.KillAnCharacter(defender);
            }
        }
    }
}   
