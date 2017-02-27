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
                //Low level
                case 100:
                    nextChar = new Bat();
                    return nextChar;
                case 101:
                    nextChar = new Rat();
                    return nextChar;
                case 102:
                    nextChar = new Kobold();
                    return nextChar;
                case 103:
                    nextChar = new Slime();
                    return nextChar;
                case 104:
                    nextChar = new Farmer();
                    return nextChar;
                case 105:
                    nextChar = new Imp();
                    return nextChar;
                case 106:
                    nextChar = new Zombie();
                    return nextChar;
                case 107:
                    nextChar = new Phantom();
                    return nextChar;
                case 108:
                    nextChar = new Goblin();
                    return nextChar;
                case 109:
                    nextChar = new Witch();
                    return nextChar;
                //Mid level
                case 110:
                    nextChar = new Harpy();
                    return nextChar;
                case 111:
                    nextChar = new Elemental();
                    return nextChar;
                case 112:
                    nextChar = new Nymph();
                    return nextChar;
                case 113:
                    nextChar = new Vampire();
                    return nextChar;
                case 114:
                    nextChar = new Lamia();
                    return nextChar;
                case 115:
                    nextChar = new Qilin();
                    return nextChar;
                case 116:
                    nextChar = new Unicorn();
                    return nextChar;
                case 117:
                    nextChar = new Jinn();
                    return nextChar;
                case 118:
                    nextChar = new Xorn();
                    return nextChar;
                case 119:
                    nextChar = new Antlion();
                    return nextChar;
                //High level
                case 120:
                    nextChar = new Yeti();
                    return nextChar;
                case 121:
                    nextChar = new Orc();
                    return nextChar;
                case 122:
                    nextChar = new Minotaur();
                    return nextChar;
                case 123:
                    nextChar = new Troll();
                    return nextChar;
                case 124:
                    nextChar = new Cyclop();
                    return nextChar;
                case 125:
                    nextChar = new Drake();
                    return nextChar;
                default:
                    nextChar = new Slime();
                    return nextChar;
            }
        }
    }
}
