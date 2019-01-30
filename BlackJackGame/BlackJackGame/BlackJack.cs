using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackGame
{
   public abstract class BlackJack
    {
        protected String Choice = "";
        protected int NewDealerValue = 0, NewPlayerValue = 0;
        protected int DealerValue = 0, PlayerValue = 0;
        protected bool BustStatus = false;

       public enum Status
        {
            DEALERWINS,
            PLAYERWINS,
            DRAW
        }

      public abstract void PlayGame();

        // static methods cannot be marked as abstract
      public abstract bool DoDouble(int DealerValue, int PlayerValue, out int NewDealerValue, out int NewPlayerValue);

        public abstract bool CheckBust(int CardValue);

       public Status CheckStatus(int DealerValue, int playerCardValue)
        {

            // Check Draw or Win Status
            try
            {


                if (DealerValue > playerCardValue)
                {
                    return Status.DEALERWINS;
                }
                else if (DealerValue < playerCardValue)
                {
                    return Status.PLAYERWINS;
                }
                else
                {
                    return Status.DRAW;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
