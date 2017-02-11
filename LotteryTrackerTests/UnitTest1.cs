using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LotteryTracker;

namespace LotteryTrackerTests
{
    [TestClass]
    public class LotteryTests
    {
        [TestMethod]
        public void TestGetWinnerNumberOn10thFebruary2017() {
            Lottery nationalLottery = new QuinielaLottery();
            //8020 is a known number
            Assert.AreEqual(8020, nationalLottery.getFirstNumberOn("10022017") ) ;
        }

        [TestMethod]
        public void TestGetWinnerNumberOn9thFebruary2017()
        {
            Lottery nationalLottery = new QuinielaLottery();
            //5948 is a known number
            Assert.AreEqual(5948, nationalLottery.getFirstNumberOn("09022017") );
        }

    }

    /*
    [TestClass]
    public class ExcelTests
    {
        [TestMethod]
        public void TestOpenEditA1CellAndClose()
        {
            ExcelFile file = new ExcelFile("TestFile.xlsx");
            file.delete();            
        }

    }
    */
}
