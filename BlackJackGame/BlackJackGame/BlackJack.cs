// <copyright file="BlackJackGameEngine.cs" company="GitHub/VeeraTheCoder">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>VEERARAJENDRAN J</author>
// <date>01/31/2019 12:39:58 AM </date>
// <summary>Class representing a Sample entity</summary>
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
        protected int playerCardDoubleCounter = 0;
        protected Random rGen = new Random();
        public enum Status
        {
            DEALERWINS,
            PLAYERWINS,
            DRAW
        }

      public abstract void PlayGame();

        // static methods cannot be marked as abstract
        //public abstract bool DoDouble(int DealerValue, int PlayerValue, out int NewDealerValue, out int NewPlayerValue);
        public abstract bool DoDoubleForPlayer(int PlayerValue, out int NewPlayerValue);
        public abstract bool DoDoubleForDealer(int PlayerValue, out int NewPlayerValue);
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
