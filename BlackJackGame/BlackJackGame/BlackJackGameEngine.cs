using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackGame
{
    
   public class BlackJackGameEngine : BlackJack
    {
       public static void Main(string[] args)
        {

            BlackJackGameEngine engineObj = new BlackJackGameEngine();
            engineObj.PlayGame();
        }

      public override void PlayGame()
        {
            
            // Step 1 : Assign Random cards to dealer and Player (two Cards - Here Random number <= 21)
            Console.WriteLine("********* WELCOME TO BLACK JACK CONSOLE GAME*************");
            Console.WriteLine("*********PRESS ANY KEY TO START, PRESS X TO EXIT**************");

            Choice = Console.ReadLine();

            try
            {

            
            while (Choice != "X")
            {
                if (Choice != "Continue")
                {
                    Console.WriteLine("Card Issued for Dealer");
                    DealerValue = GenerateRandomNumberForDealer();
                    Console.WriteLine("Press any key to issue card to player");
                    Console.ReadLine();
                    PlayerValue = GenerateRandomNumberForPlayer();

                    Console.WriteLine("Your Card Value is " + PlayerValue);

                        bool isBlackJack = CheckBlackJack(PlayerValue);
                    if (isBlackJack)
                    {
                        Console.WriteLine("You've got Black Jack Please Press S to  Stand ");

                        Choice = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Do you want to Stand (S) or Double (D) ");

                        Choice = Console.ReadLine();
                    }

                }
                else
                {
                    Console.WriteLine("Your Card Value is " + PlayerValue);
                    Console.WriteLine("Do you want to Stand (S) or Double (D) ");

                    Choice = Console.ReadLine();
                }



                if (Choice == "S")
                {
                    Status s;
                    s = CheckStatus(DealerValue, PlayerValue);

                    if (s == Status.DEALERWINS)
                    {
                        Console.WriteLine("Player Lost the Game, Dealer has card value " + DealerValue + " and player has card value" + PlayerValue);
                        Console.WriteLine("*****Press any key to exit*****");
                        Console.ReadLine();
                        break;
                    }
                    else if (s == Status.PLAYERWINS)
                    {
                        Console.WriteLine("Player won the Game, Dealer has card value " + DealerValue + " and player has card value" + PlayerValue);
                        Console.WriteLine("*****Press any key to exit*****");
                        Console.ReadLine();
                        break;
                    }
                    else if (s == Status.DRAW)
                    {
                        Console.WriteLine("Game Draw, Dealer has card value " + DealerValue + " and player has card value " + PlayerValue);
                        Console.WriteLine("*****Press any key to exit*****");
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Result Unknown for this game");
                        Console.WriteLine("*****Press any key to exit*****");
                        Console.ReadLine();
                        break;
                    }

                }
                else if (Choice == "D")
                {
                        bool canDouble = CheckDoubleClaimLimitForPlayer(PlayerValue);
                    if (canDouble)
                    {


                        DoDouble(DealerValue, PlayerValue, out NewDealerValue, out NewPlayerValue);
                        BustStatus = CheckBust(NewPlayerValue);
                        if (BustStatus)
                        {
                            Console.WriteLine("Game Over!!!, Player1 got busted");
                            Console.WriteLine("*****Press any key to exit*****");
                            Console.ReadLine();
                            break;
                        }
                        BustStatus = CheckBust(NewDealerValue);
                        if (BustStatus)
                        {
                            Console.WriteLine("Player1 have won, Dealer got Busted!!!!!!");
                            Console.WriteLine("*****Press any key to exit*****");
                            Console.ReadLine();
                            break;
                        }
                        Choice = "Continue";
                        DealerValue = NewDealerValue;
                        PlayerValue = NewPlayerValue;
                    }
                    else
                    {
                        Console.WriteLine("You Cannot Double with a card value more 17");
                        Choice = "Continue";
                    }
                }
                else if (Choice == "X")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter S or D as choice");
                    Choice = Console.ReadLine();
                }
                
                
            }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured in BlackJackGameEngine and Exception Detail : " + ex.Message);
            } 
        }

        public  bool CheckDoubleClaimLimitForPlayer(int PlayerValue)
        {
            try
            {

           
            if(PlayerValue <= 17)
            {
                return true;
            }
            else
            {
                return false;
            }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public  bool CheckBlackJack(int PlayerValue)
        {
            if (PlayerValue == 21)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
            
       public static int GenerateRandomNumberForPlayer()
        {
            int rInt = 0;
            try
            {

            
            Console.WriteLine("Card Shuffled For Player");
            Random r = new Random();
                rInt = r.Next(1, 21);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return rInt;
        }

       public static int GenerateRandomNumberForDealer()
        {
            try
            {

            
            Random r = new Random();
            int rInt = r.Next(1, 21);
            return rInt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #region Deprecated Method
        //static bool CheckRandomNumberMaxLimit(int Number)
        //{
        //    return true;
        //}
        #endregion



      public override bool DoDouble(int DealerValue, int PlayerValue, out int NewDealerValue, out int NewPlayerValue)
        {
            // Here Another number will be generated but max will be 11 and will be added to Player's existing total
            
            try
            {

           if(PlayerValue <=17)
                { 
            int rInt = 0;
            Random r = new Random();
            rInt = r.Next(1, 11);
            NewPlayerValue = rInt + PlayerValue;

            NewDealerValue = r.Next(1, 11) + DealerValue;
                    return true;
                }
           else
                {
                    NewDealerValue = DealerValue;
                    NewPlayerValue = PlayerValue;
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public override bool CheckBust(int CardValue)
        {
            // Here we will check whether player's Card value crossed 21
            try
            {

           
            if (CardValue > 21)
            {
                return true;

            }
            else
            {
                return false;
            }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        
    }
}
