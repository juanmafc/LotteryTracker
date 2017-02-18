using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LotteryTracker;
using System.IO;
using System.Text;


namespace LotteryTrackerTests
{
    [TestClass]
    public class LotteryTests
    {
        [TestMethod]
        public void TestGetWinnerNumberOn10thFebruary2017()
        {
            Lottery nationalLottery = new QuinielaLottery();
            //8020 is a known number
            Assert.AreEqual("8020", nationalLottery.getFirstNumberOn("10022017"));
        }

        [TestMethod]
        public void TestGetWinnerNumberOn9thFebruary2017()
        {
            Lottery nationalLottery = new QuinielaLottery();
            //5948 is a known number
            Assert.AreEqual("5948", nationalLottery.getFirstNumberOn("09022017"));
        }

        [TestMethod]
        public void TestGetOnlyWinnerNumbersLastDigitOn9thFebruary2017()
        {
            Lottery nationalLottery = new QuinielaLottery();
            //5948 is a known number
            Assert.AreEqual("8", nationalLottery.getFirstNumberOn("09022017", 1));
        }

        [TestMethod]
        public void TestWinnerNumberOnADayWithNoResultsReturnsAnEmptyString()
        {
            Lottery nationalLottery = new QuinielaLottery();
            //05022017 was Sunday, no results
            Assert.AreEqual("", nationalLottery.getFirstNumberOn("05022017", 1));
        }

    }    
}