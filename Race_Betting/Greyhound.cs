using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Race_Betting
{
    public class Greyhound
    {
        public int StartingPosition;
        public int RacetrackLength;
        public PictureBox MyPictureBox;
        public int Location = 0;
        public Random MyRandom;

        public bool Run()
        {
            MyRandom = new Random();
            int move = MyRandom.Next(1, 5);
            Location = Location + move;
            MyPictureBox.Left = StartingPosition + Location;

            MyPictureBox.Update();
            
            if ( Location >= RacetrackLength)  
                return true;
            else
                return false;
        }

        public void TakeStartingPosition()
        {
            Location = 0;
            MyPictureBox.Left = Location;
        }
    }
}
