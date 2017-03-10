using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.UI
{
    class MainMenu
    {

        public MainGame mainGame;


        public ConsoleKeyInfo userCKI;
        public int optionN;

        public MainMenu()
        {
            optionN = 1;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                Console.Write(@"
                                _____       ___     __   ____                        __
                               / ___/____  / (_)___/ /  / __ \____ _______________ _/ /
                               \__ \/ __ \/ / / __  /  / /_/ / __ `/ ___/ ___/ __ `/ / 
                              ___/ / /_/ / / / /_/ /  / _, _/ /_/ (__  ) /__/ /_/ / /  
                             /____/\____/_/_/\__,_/  /_/ |_|\__,_/____/\___/\__,_/_/   
");
                Options();
            } while (userCKI.Key != ConsoleKey.Escape);
        }

        public void Options()
        {
            switch (optionN)
            {
                case 1:
                    Console.SetCursorPosition(51, 9);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(@"> Start <");
                    Console.SetCursorPosition(51, 11);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(@"  Credits  ");
                    Console.SetCursorPosition(51, 13);
                    Console.Write(@"  How to play  ");
                    Console.SetCursorPosition(51, 15);
                    Console.Write(@"  Exit  ");
                    Console.ForegroundColor = ConsoleColor.Black;
                    GetUserInput();
                    break;
                case 2:
                    Console.SetCursorPosition(51, 9);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(@"  Start  ");
                    Console.SetCursorPosition(51, 11);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(@"> Credits <");
                    Console.SetCursorPosition(51, 13);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(@"  How to play  ");
                    Console.SetCursorPosition(51, 15);
                    Console.Write(@"  Exit  ");
                    Console.ForegroundColor = ConsoleColor.Black;
                    GetUserInput();
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.SetCursorPosition(51, 9);
                    Console.Write(@"  Start  ");
                    Console.SetCursorPosition(51, 11);
                    Console.Write(@"  Credits  ");
                    Console.SetCursorPosition(51, 13);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(@"> How to play <");
                    Console.SetCursorPosition(51, 15);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(@"  Exit  ");
                    Console.ForegroundColor = ConsoleColor.Black;
                    GetUserInput();
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.SetCursorPosition(51, 9);
                    Console.Write(@"  Start  ");
                    Console.SetCursorPosition(51, 11);
                    Console.Write(@"  Credits  ");
                    Console.SetCursorPosition(51, 13);
                    Console.Write(@"  How to play  ");
                    Console.SetCursorPosition(51, 15);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(@"> Exit <");
                    Console.ForegroundColor = ConsoleColor.Black;
                    GetUserInput();
                    break;

            }
        }

        void GetUserInput()
        {
            userCKI = Console.ReadKey();

            if (userCKI.Key == ConsoleKey.UpArrow)
            {
                if (optionN > 1)
                    optionN--;
            }
            else if (userCKI.Key == ConsoleKey.DownArrow)
            {
                if (optionN < 4)
                    optionN++;
            }
            else if (userCKI.Key == ConsoleKey.Spacebar || userCKI.Key == ConsoleKey.Enter)
            {
                if (optionN == 1)
                {
                    //Start
                    mainGame = new MainGame();
                }
                else if (optionN == 2)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                    Console.Write(@"


Developed by: Jeferson Carvalho

Solid Rascal is a tribute and an experiment, that is helping me to
understand more of the fantastic world of Procedural Generation and Roguelike Development.");

                    Console.ReadKey();
                }
                else if (optionN == 3)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                    Console.Write(@"

Keys:
Arrow Keys = Movement
Q = Use item
W = Equip weapon
E = Equip armor
Spacebar = Go to the next dungeon level / rest
I = inventory

Characters:
@ = Player
A-Z = Monsters

Objects:
║ = Dungeon wall
▓ = Corridor
. = Dungeon Floor
↕ = Staircase
↑ = Weapon
Δ = Armor
¿ = Potions
♫ = Scroll of identification
♦ = Diamond
≈ = Food");

                    Console.ReadKey();
                }
                else if (optionN == 4)
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
