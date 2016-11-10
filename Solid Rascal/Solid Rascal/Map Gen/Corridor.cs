using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal
{
    class Corridor
    {
        //this is random
        Random rand;

        ///Rooms coordinates
        //Room1
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int H1 { get; set; }
        public int W1 { get; set; }
        //Room2
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public int H2 { get; set; }
        public int W2 { get; set; }

        /// Corridor values
        //Corridor relative positions to rooms
        public bool VERTICAL { get; set; }
        public bool HORIZONTAL { get; set; }
        public bool POSITIVE { get; set; }
        ///Corridor coordinates
        ///corridor cX1 and cY1 are the coordinates of the corridor going out of the room1
        ///corridor cX2 and cY2 are going out of the room 2
        ///rmp = Random Middle Point
        public int cX1;
        public int cY1;
        public int cX2;
        public int cY2;
        int rmp;

        //Corridors sizes
        public int c1 { get; set; }
        public int c2 { get; set; }
        public int cConnection { get; set; }

        public Corridor(Room room1, Room room2)
        {
            rand = MainGame.rand;
            int coin = rand.Next(0, 2);

            ///Rooms coordinates
            //room 1
            X1 = room1.X;
            Y1 = room1.Y;
            H1 = room1.Height - 1;
            W1 = room1.Width - 1;
            //room 2
            X2 = room2.X;
            Y2 = room2.Y;
            H2 = room2.Height - 1;
            W2 = room2.Width - 1;



            //Will determine if the room that will be the origin of the corridor
            //are at the left/right down/up of the target room
            if ((X1 + W1) < X2 || (X2 + W2) < X1)
            {
                VERTICAL = true;
            }

            if (Y1 + H1 < Y2 || Y2 + H2 < Y1)
            {
                HORIZONTAL = true;
            }

            //If both conditions are true, random shall decide which direction the corridor will go
            if (VERTICAL && HORIZONTAL)
            {
                if (coin == 0)
                {
                    BuildVertical();
                }
                else
                {
                    BuildHorizontal();
                }
            }
            else if (VERTICAL)
            {
                BuildVertical();
            }
            else if (HORIZONTAL)
            {
                BuildHorizontal();
            }
            else
            {
                //note to self: build a proper exception
                Console.WriteLine("Algo deu errado Jack!");
                Console.ReadLine();
            }
        }

        //Construct the corridor values for a vertical intersection
        void BuildVertical()
        {
            VERTICAL = true;
            HORIZONTAL = false;
            //if the first room are on the left of the second room
            //set the positive bool so the when the corridor is being printed on the map
            //the cursor will go to the right way
            if ((X1 + W1) < X2)
            {
                ///Corridor goes right from the first room
                POSITIVE = true;

                //Random middle point is determined and the corridors coordinates are generated
                rmp = rand.Next((X1 + W1) + 1, (X2));
                cX1 = X1 + W1;
                cY1 = rand.Next((Y1 + 1), (Y1 + H1));

                cX2 = X2;
                cY2 = rand.Next((Y2 + 1), (Y2 + H2));

                //get the sizes of the corridor 1 and 2 towards the middle intersection
                c1 = Math.Abs(cX1 - rmp);
                c2 = Math.Abs(cX2 - rmp);
                //gets the size of the middle intersection
                cConnection = Math.Abs(cY1 - cY2);
            }
            else if ((X2 + W2) < X1)
            {
                //Left
                POSITIVE = false;

                rmp = rand.Next((X2 + W2) + 1, X1);

                cX1 = X1;
                cY1 = rand.Next((Y1 + 1), (Y1 + H1));

                cX2 = X2 + W2;
                cY2 = rand.Next((Y2 + 1), (Y2 + H2));

                c1 = Math.Abs(cX1 - rmp);
                c2 = Math.Abs(cX2 - rmp);
                cConnection = Math.Abs(cY1 - cY2);
            }

        }

        void BuildHorizontal()
        {
            //Same as the building vertical but with the coordinates for horizontal intersection
            HORIZONTAL = true;
            VERTICAL = false;
            if (Y1 > Y2 + H2)
            {
                POSITIVE = true;
                //Corredor goes up
                rmp = rand.Next((Y2 + H2) + 1, Y1);

                cX1 = rand.Next(X1 + 1, (X1 + W1) - 1);
                cY1 = Y1;

                cX2 = rand.Next(X2 + 1, (X2 + W2) - 1);
                cY2 = Y2 + H2;

                c1 = Math.Abs(cY1 - rmp);
                c2 = Math.Abs(cY2 - rmp);
                cConnection = Math.Abs(cX1 - cX2);
            }
            else if (Y1 + H1 < Y2)
            {
                POSITIVE = false;
                //Corredor goes down
                rmp = rand.Next((Y1 + H1) + 1, Y2);

                cX1 = rand.Next(X1 + 1, (X1 + W1) - 1);
                cY1 = Y1 + H1;

                cX2 = rand.Next(X2 + 1, (X2 + W2) - 1);
                cY2 = Y2;

                c1 = Math.Abs(cY1 - rmp);
                c2 = Math.Abs(cY2 - rmp);
                cConnection = Math.Abs(cX1 - cX2);
            }
        }
    }
}
