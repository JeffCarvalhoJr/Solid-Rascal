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

        public int _ATK;

        public int _Health;

        public int _AiChoice;

        public void SetNewPosition(int x, int y)
        {
            xPos = x;
            yPos = y;
        }

    }
}
