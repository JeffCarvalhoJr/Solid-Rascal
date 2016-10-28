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



        public Battle(Character attacker, Character defender)
        {
            _Alert = new Alert();

            _Alert.Warning("" + attacker.charNAME + " Attacks the " + defender.charNAME);

        }
    }
}
