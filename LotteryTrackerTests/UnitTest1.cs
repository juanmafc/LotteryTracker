using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LotteryTracker;

namespace LotteryTrackerTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetWinnerNumberForAnSpecificDate() {
            Lottery nationalLottery = new QuinielaLottery();
            //8020 is a known number
            Assert.AreEqual(8020, nationalLottery.getFirstNumberOn(9, 2, 2017) ) ;
        }

    }
}
