using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race_Betting
{
    public class Bet
    {
        public int Amount;
        public int Dog;
        public Guy Bettor;

        public Bet(int Amount, int Dog, Guy Bettor)
        {
            this.Amount = Amount;
            this.Dog = Dog;
            this.Bettor = Bettor;
        }

        public string GetDescription()
        {
            string description = "";
            if (Amount > 0)
            {
                description = Bettor.Name + " placed " + Amount + " bucks on dog number" + Dog;
            }
            else
            {
                description = Bettor.Name + " has not placed any bets";
            }

            return description;

        }

        public int PayOut(int Winner)
        {
            if (Dog == Winner)
            {
                return Amount;
            }

            return -Amount;

        }
    }
}
