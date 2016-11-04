using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Characters.Enemies
{
    class Slime : Character
    {
        public Slime(int x, int y) { 

            xPos = x;
            yPos = y;

            sARMOR = 0;

            charNAME = "Slime";
            charID = 54;

            sHP = 20;
            sMHP = 20;
           
        }
    }
}
