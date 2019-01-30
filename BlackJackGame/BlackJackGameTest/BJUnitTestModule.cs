// <copyright file="BlackJackGameEngine.cs" company="GitHub/VeeraTheCoder">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>VEERARAJENDRAN J</author>
// <date>01/31/2019 12:39:58 AM </date>
// <summary>Class representing a Sample entity</summary>
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlackJackGame;
namespace BlackJackGameTest
{
    [TestClass]
    public class BJUnitTestModule : TestParameters
    {
        [TestMethod]
        public void UnitTestMethod_CheckBustSuccess()
        {
            BlackJackGameEngine BJEngineObj = new BlackJackGameEngine();
            isBusted = BJEngineObj.CheckBust(23);
            bool isBustedSuccess = true;
            Assert.AreEqual(isBusted,isBustedSuccess);
        }
        [TestMethod]
        public void UnitTestMethod_CheckBustFailure()
        {
            BlackJackGameEngine BJEngineObj = new BlackJackGameEngine();
            isBusted = BJEngineObj.CheckBust(21);
            bool isBustedfail = false;
            Assert.AreEqual(isBusted, isBustedfail);
        }
        [TestMethod]
        public void UnitTestMethod_CheckStatus_DealerWin()
        {
            BlackJackGameEngine BJEngineObj = new BlackJackGameEngine();
            BlackJack.Status actualResult = BJEngineObj.CheckStatus(21,20);
            BlackJack.Status expectedResult = BlackJack.Status.DEALERWINS;
            Assert.AreEqual(actualResult,expectedResult);
        }

        [TestMethod]
        public void UnitTestMethod_CheckStatus_PlayerWin()
        {
            BlackJackGameEngine BJEngineObj = new BlackJackGameEngine();
            BlackJack.Status actualResult = BJEngineObj.CheckStatus(20, 21);
            BlackJack.Status expectedResult = BlackJack.Status.PLAYERWINS;
            Assert.AreEqual(actualResult, expectedResult);
        }
        [TestMethod]
        public void UnitTestMethod_CheckStatus_GameDraw()
        {
            BlackJackGameEngine BJEngineObj = new BlackJackGameEngine();
            BlackJack.Status actualResult = BJEngineObj.CheckStatus(20, 20);
            BlackJack.Status expectedResult = BlackJack.Status.DRAW;
            Assert.AreEqual(actualResult, expectedResult);
        }
        [TestMethod]
        public void UnitTestMethod_DoDoubleForPlayerSuccess()
        {
            BlackJackGameEngine BJEngineObj = new BlackJackGameEngine();
            ExpectedResult = true;
           bool PlayerDoubleStatus = BJEngineObj.DoDoubleForPlayer(16,out int playerValue);
            Assert.AreEqual(PlayerDoubleStatus, ExpectedResult);
        }
        [TestMethod]
        public void UnitTestMethod_DoDoubleForPlayerFail()
        {
            BlackJackGameEngine BJEngineObj = new BlackJackGameEngine();
            ExpectedResult = false;
            bool PlayerDoubleStatus = BJEngineObj.DoDoubleForPlayer(18,out int playerValue);
            Assert.AreEqual(PlayerDoubleStatus, ExpectedResult);
        }
        //[TestMethod]
        //public void UnitTestMethod_DoDoubleForDealerSuccess()
        //{
        //    BlackJackGameEngine BJEngineObj = new BlackJackGameEngine();
        //    ExpectedResult = true;
        //    bool DealerDoubleStatus = BJEngineObj.DoDoubleForDealer(17, out int dealerValue);
        //    Assert.AreEqual(DealerDoubleStatus, ExpectedResult);
        //}
        //[TestMethod]
        //public void UnitTestMethod_DoDoubleForDealerFail()
        //{
        //    BlackJackGameEngine BJEngineObj = new BlackJackGameEngine();
        //    ExpectedResult = false;
        //    bool DealerDoubleStatus = BJEngineObj.DoDoubleForDealer(18, out int dealerValue);
        //    Assert.AreEqual(DealerDoubleStatus, ExpectedResult);
        //}
        [TestMethod]
        public void UnitTestMethod_CheckDoubleClaimLimitForPlayerSuccess()
        {
            BlackJackGameEngine BJEngineObj = new BlackJackGameEngine();
            ExpectedResult = true;
            bool DoubleClaimStatus = BJEngineObj.CheckDoubleClaimLimitForPlayer(17);
            Assert.AreEqual(DoubleClaimStatus,ExpectedResult);
        }
        [TestMethod]
        public void UnitTestMethod_CheckDoubleClaimLimitForPlayerFail()
        {
            BlackJackGameEngine BJEngineObj = new BlackJackGameEngine();
            ExpectedResult = false;
            bool DoubleClaimStatus = BJEngineObj.CheckDoubleClaimLimitForPlayer(18);
            Assert.AreEqual(DoubleClaimStatus, ExpectedResult);
        }
        [TestMethod]
        public void UnitTestMethod_CheckBlackJackForPlayerSuccess()
        {
            BlackJackGameEngine BJEngineObj = new BlackJackGameEngine();
            ExpectedResult = true;
            bool BlackJackStatus = BJEngineObj.CheckBlackJack(21);
            Assert.AreEqual(BlackJackStatus,ExpectedResult);
        }

        [TestMethod]
        public void UnitTestMethod_CheckBlackJackForPlayerFail()
        {
            BlackJackGameEngine BJEngineObj = new BlackJackGameEngine();
            ExpectedResult = false;
            bool BlackJackStatus = BJEngineObj.CheckBlackJack(19);
            Assert.AreEqual(BlackJackStatus, ExpectedResult);
        }

    }
    public class TestParameters
    {
        public bool isBusted;
        public bool ExpectedResult;
    }

}
