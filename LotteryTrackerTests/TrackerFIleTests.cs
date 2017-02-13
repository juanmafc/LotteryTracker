using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LotteryTracker;

namespace LotteryTrackerTests
{    
    [TestClass]
    public class TrackerFIleTests
    {        

        [TestMethod]
        public void TestTrackerFileAddsAnEmptyEntryOnFebruary12th2017()
        {
            TrackerFile file = new TrackerFile(@"..\..\TestFiles\LotteryTrackerFile.xlsx");
            file.addEmptyEntry(12, 2, 2017);
            //TODO: automate this assert
        }
    }
}
