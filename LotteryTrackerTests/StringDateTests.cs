using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LotteryTracker;

namespace LotteryTrackerTests
{
    [TestClass]
    public class StringDateTests
    {

        [TestMethod]
        public void TestCreateAStringDateAndGetItInDDMMYYYYformat()
        {
            StringDate date = new StringDate(1, 2, 2017);
            Assert.AreEqual("01022017", date.getDate());
        }

        [TestMethod]
        public void TestIncrementDateByOneDay()
        {
            StringDate date = new StringDate(1, 1, 2017);
            date.nextDay();
            Assert.AreEqual("02012017", date.getDate());
        }

        [TestMethod]
        public void TestIncrementDateByOneDayAndThatIncrementChangesTheMonth()
        {
            StringDate date = new StringDate(31, 1, 2017);
            date.nextDay();
            Assert.AreEqual("01022017", date.getDate());
        }

        [TestMethod]
        public void TestIncrementDateByOneDayAndThatIncrementChangesTheYear()
        {
            StringDate date = new StringDate(31, 12, 2015);
            date.nextDay();
            Assert.AreEqual("01012016", date.getDate());
        }

        [TestMethod]
        public void TestCheckIfIsSundayReturnsTrueOnASundayDate()
        {
            //12nd February 2017 was on Sunday
            StringDate date = new StringDate(12, 2, 2017);
            Assert.IsTrue(date.isSunday());
        }

        [TestMethod]
        public void TestCheckIfIsSundayReturnsFalseOnANonSundayDate()
        {
            //3rd February 2017 was on Friday
            StringDate date = new StringDate(3, 2, 2017);
            Assert.IsFalse(date.isSunday());
        }
    }
}
