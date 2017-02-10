using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LotteryTracker;

namespace LotteryTrackerTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1() {
            TestClass prueba = new TestClass();
            Assert.AreEqual(5, prueba.dameUn5() );
        }
    }
}
