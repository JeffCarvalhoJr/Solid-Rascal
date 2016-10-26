using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Characters
{
    class Character
    {
        public int xPos { get; set; }
        public int yPos { get; set; }
        public int charID { get; set; }
        public int aHealth;


        public void SetNewPosition(int x, int y)
        {
            xPos = x;
            yPos = y;
        }

    }
}
