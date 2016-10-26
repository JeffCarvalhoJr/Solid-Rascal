using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.UI
{
    class Alert
    {

        //Values from map to the alerts be adjusted to the screen
        int MAPHeight;

        public Alert()
        {
            MAPHeight = 30;
        }

        //method to receive input for the user
        //put the cursor of the Console on the bottom of the map
        //Clear the line and type in the Message.
        public string Question(string QUESTION)
        {
            ClearLine();
            if (MAPHeight > 0)
            {
                Console.SetCursorPosition(0, MAPHeight + 1);
            }
            else
            {
                Console.SetCursorPosition(0, Console.CursorTop);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("" + QUESTION + ": ");

            return Console.ReadLine();
        }

        //method to display messages of information for the user
        //as the Question method, the cursor of the console will be placed on the bottom of the map
        //the line will be cleared and the message will be typed in
        public void Warning(string WARNING)
        {
            ClearLine();
            if (MAPHeight > 0)
            {
                Console.SetCursorPosition(0, MAPHeight + 1);
            }
            else
            {
                Console.SetCursorPosition(0, Console.CursorTop);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("" + WARNING + "!");
            Console.ReadLine();
        }

        public void Action(string ACTION)
        {
            ClearLine();
            if (MAPHeight > 0)
            {
                Console.SetCursorPosition(0, MAPHeight + 1);
            }
            else
            {
                Console.SetCursorPosition(0, Console.CursorTop);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("" + ACTION + "!");
        }

        //Method to clear a single line for the console
        //Mainly to be used with the Question and Warning methods
        void ClearLine()
        {
            for (int i = 0; i < 100; i++)
            {
                if (MAPHeight > 0)
                    Console.SetCursorPosition(i, MAPHeight + 1);
                else
                    Console.SetCursorPosition(i, Console.CursorTop);
                Console.Write(" ");
            }
        }
    }
}
