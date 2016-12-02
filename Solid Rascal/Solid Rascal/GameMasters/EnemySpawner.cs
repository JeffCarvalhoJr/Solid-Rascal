using System;
using Solid_Rascal.Characters;
using Solid_Rascal.Characters.Enemies;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.GameMasters
{
    class EnemySpawner
    {
        public Character GetEnemy(int id)
        {
            Character nextChar;
            switch (id)
            {
                case 100:
                    nextChar = new Slime();
                    return nextChar;
                case 101:
                    nextChar = new Phantom();
                    return nextChar;
                case 102:
                    nextChar = new Golem();
                    return nextChar;
                default:
                    nextChar = new Slime();
                    return nextChar;
            }
        }
    }
}
