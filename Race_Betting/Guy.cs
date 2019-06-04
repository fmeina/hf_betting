using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Race_Betting
{
    public class Guy
    {
        public string Name;
        public Bet MyBet;
        public int Cash;


        public RadioButton MyRadioButton;
        public Label MyLabel;

        public Guy(string Name, Bet MyBet, int Cash, RadioButton MyRadioButton, Label MyLabel)
        {
            this.Name = Name;
            this.MyBet = MyBet;
            this.Cash = Cash;
            this.MyRadioButton = MyRadioButton;
            this.MyLabel = MyLabel;
        }

        public void UpdateLabels()
        {
            MyRadioButton.Text = Name + " has " + Cash + " bucks ";         

            if(MyBet != null)
            {
                MyLabel.Text = MyBet.GetDescription(); 
            }
            else
            {
                MyLabel.Text = Name + " has not placed any bets";
            }
        }

        public void ClearBet()
        {
            MyBet.Amount = 0;
        }

        public bool PlaceBet(int Amount, int DogToWin)
        {
            if (Cash >= Amount)
            {
                MyBet = new Bet(Amount, DogToWin, this);
                return true;
            }
            else
                return false;
        }

        public void Collect(int Winner)
        {
            Cash += MyBet.PayOut(Winner);
        }

    }
}
