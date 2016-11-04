using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Characters
{
    class Character
    {
        public string charNAME;

        public int xPos { get; set; }
        public int yPos { get; set; }
        public int charID { get; set; }

        public int sLEVEL { get; set; }
        public int sARMOR { get; set; }
        public int sSTR { get; set; }
        public int sMSTR { get; set; }
        public int sHP { get; set; }
        public int sMHP { get; set; }

        //public int _AiChoice;

        public void SetNewPosition(int x, int y)
        {
            xPos = x;
            yPos = y;
        }

        public void IncreaseHealth(int value)
        {
            sHP += value;

            if (sHP > 100)
            {
                sHP = 100;
            }
        }

        public void ReduceHealth(int value)
        {
            sHP -= value;
            if (sHP < 0)
            {
                sHP = 0;
            }
        }
    }
}
