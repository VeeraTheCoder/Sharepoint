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
using System.Threading;
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
            
            
            
            Console.WriteLine("********* WELCOME TO BLACK JACK CONSOLE GAME*************");
            Console.WriteLine("*********PRESS ANY KEY TO START, PRESS X TO EXIT**************");

            Choice = Console.ReadLine();

            try
            {

            
            while (Choice != "x")
            {
                if (Choice != "Continue")
                {
                        
                        PlayerValue = GenerateRandomNumberForPlayer();
                        DealerValue = GenerateRandomNumberForDealer();
                   

                        bool isBlackJack = CheckBlackJack(PlayerValue);
                    if (isBlackJack)
                    {
                        Console.WriteLine("You've got Black Jack, do you want another card (y/n)? ");

                        Choice = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Do you want another card (y/n)? ");

                        Choice = Console.ReadLine();
                    }

                }
                else
                {
                    
                    Console.WriteLine("Do you want another card (y/n)? ");

                    Choice = Console.ReadLine();
                }



                if (Choice == "n")
                {
                        for (int i = 0; i < playerCardDoubleCounter; i++)
                        {
                            DoDoubleForDealer(DealerValue, out NewDealerValue);
                            DealerValue = NewDealerValue;
                        }
                    Status s;
                        BustStatus = CheckBust(DealerValue);
                        if (BustStatus)
                        {
                            Console.WriteLine("You Won!!!, Computer got busted");
                            Console.WriteLine("*****Press any key to exit*****");
                            Console.ReadLine();
                            break;
                        }
                        s = CheckStatus(DealerValue, PlayerValue);

                    if (s == Status.DEALERWINS)
                    {
                        Console.WriteLine("Your Score : "+PlayerValue);
                        Console.WriteLine("Computer Score : " + DealerValue);
                        Console.WriteLine("You Lost!!! ");
                        Console.WriteLine("*****Press any key to exit*****");
                        Console.ReadLine();
                        break;
                    }
                    else if (s == Status.PLAYERWINS)
                    {
                        Console.WriteLine("Computer Score : " + DealerValue);
                        Console.WriteLine("Your Score : " + PlayerValue);
                        Console.WriteLine("You won! ");
                        Console.WriteLine("*****Press any key to exit*****");
                        Console.ReadLine();
                        break;
                    }
                    else if (s == Status.DRAW)
                    {
                        Console.WriteLine("Computer Score : " + DealerValue);
                        Console.WriteLine("Your Score : " + PlayerValue);
                        Console.WriteLine("Game Draw!");
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
                else if (Choice == "y")
                {
                        bool canDouble = CheckDoubleClaimLimitForPlayer(PlayerValue);
                    if (canDouble)
                    {


                        
                        DoDoubleForPlayer(PlayerValue, out NewPlayerValue);
                        BustStatus = CheckBust(NewPlayerValue);
                        if (BustStatus)
                        {
                            Console.WriteLine("Game Over!!!, you got busted");
                            Console.WriteLine("*****Press any key to exit*****");
                            Console.ReadLine();
                            break;
                        }
                           
                            Choice = "Continue";
                        
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
                    Console.WriteLine("Enter y or n as choice, x to exit");
                    Choice = Console.ReadLine();
                    Choice = "Continue";
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
            
       public  int GenerateRandomNumberForPlayer()
        {
            int firstCard=0, secondCard = 0;
            try
            {

            
            
            
                firstCard = rGen.Next(1, 10);
                secondCard = rGen.Next(1,10);
                Console.WriteLine("Your Cards : " +firstCard+" "+secondCard+" = "+(firstCard + secondCard));
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return firstCard + secondCard;
        }

       public  int GenerateRandomNumberForDealer()
        {
            int firstCard = 0, secondCard = 0;
            try
            {


                
                
                firstCard = rGen.Next(1, 10);
                secondCard = rGen.Next(1, 10);
                Console.WriteLine("Computer's Cards : " + firstCard + " " + secondCard + " = " + (firstCard + secondCard));
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return firstCard + secondCard;
        }

       public override bool DoDoubleForPlayer(int PlayerValue, out int NewPlayerValue)
        {
            try
            {

                if (PlayerValue <= 17)
                {
                    int rInt = 0;
                    
                    rInt = rGen.Next(1, 10);
                    
                    NewPlayerValue = rInt + PlayerValue;
                    Console.WriteLine("Hit: "+rInt+" Your total is " +NewPlayerValue);
                    playerCardDoubleCounter++;
                    return true;
                }
                else
                {
                   
                    NewPlayerValue = PlayerValue;
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public override bool DoDoubleForDealer(int DealerValue, out int NewDealerValue)
        {
            try
            {

               
                    int rInt = 0;
                    Thread.Sleep(500);    
                    rInt = rGen.Next(1, 10);

                    NewDealerValue = rInt + DealerValue;
                    Console.WriteLine("The Computer takes a card : " +rInt);

                    return true;
                
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public override bool CheckBust(int CardValue)
        {
            
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
