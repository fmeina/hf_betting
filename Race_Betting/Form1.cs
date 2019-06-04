using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Race_Betting
{
    public partial class Form1 : Form
    {
        Greyhound[] dogs = new Greyhound[4];
        Guy[] guys = new Guy[3];

        public Form1()
        {
            InitializeComponent();

            SetupRaceTracks();
        }

        private void SetupRaceTracks()
        { 
            MinBetLabel.Text = "Minimum bet" + cashNumeric.Minimum;

            int startingPosition = dogPic1.Right - racetrack.Left;
            int raceTrackLength = racetrack.Size.Width;


            dogs[0] = new Greyhound()
            {
                MyPictureBox = dogPic1,
                RacetrackLength = raceTrackLength,
                StartingPosition = startingPosition
            };
            dogs[1] = new Greyhound()
            {
                MyPictureBox = dogPic2,
                RacetrackLength = raceTrackLength,
                StartingPosition = startingPosition
            };
            dogs[2] = new Greyhound()
            {
                MyPictureBox = dogPic3,
                RacetrackLength = raceTrackLength,
                StartingPosition = startingPosition
            };
            dogs[3] = new Greyhound()
            {
                MyPictureBox = dogPic4,
                RacetrackLength = raceTrackLength,
                StartingPosition = startingPosition
            };

            guys[0] = new Guy("Joe", null, 50, joeRadioButton, joeBetLabel);
            guys[1] = new Guy("Bob", null, 75, bobRadioButton, bobBetLabel);
            guys[2] = new Guy("Al", null, 45, alRadioButton, alBetLabel);

            foreach (Guy guy in guys)
            {
                guy.UpdateLabels();
            }
        }

        private void SetBettorNameTextLabel(string Name)
        {
            nameLabel.Text = Name;
        }

        private void joeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SetBettorNameTextLabel("Joe");
        }

        private void bobRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SetBettorNameTextLabel("Bob");
        }

        private void alRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SetBettorNameTextLabel("Al");
        }

        private void betsButton_Click(object sender, EventArgs e)
        {
            int GuyNumber = 0;

            if (joeRadioButton.Checked)
            {
                GuyNumber = 0;
            }
            if (bobRadioButton.Checked)
            {
                GuyNumber = 1;
            }
            if (alRadioButton.Checked)
            {
                GuyNumber = 2;
            }

            guys[GuyNumber].PlaceBet((int)cashNumeric.Value, (int)chartNumeric.Value);
            guys[GuyNumber].UpdateLabels();

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            bool NoWinner = true;
            int dogWinner;
            startButton.Enabled = false;

            while (NoWinner)
            {
                Application.DoEvents();
                for (int i = 0; i < dogs.Length; i++)
                {
                    if (dogs[i].Run())
                    {
                        dogWinner = i + 1;
                        NoWinner = false;
                        MessageBox.Show("We have a winner - dog number" + dogWinner);
                        foreach (Guy guy in guys)
                        {
                            if (guy.MyBet != null)
                            {
                                guy.Collect(dogWinner);
                                guy.MyBet = null;
                                guy.UpdateLabels();
                            }
                        }
                        foreach (Greyhound dog in dogs)
                        {
                            dog.TakeStartingPosition();
                        }
                        break;
                    }
                }
            }

            startButton.Enabled = true;
        }
    }
}
