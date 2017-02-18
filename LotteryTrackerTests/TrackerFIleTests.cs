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

        [TestMethod]
        public void TestTrackerFileAddAnEntryForAWinningNumber5OnFebruary12th2017()
        {
            TrackerFile file = new TrackerFile(@"..\..\TestFiles\LotteryTrackerFile2.xlsx");
            file.addEntryForWinningNumber(12, 2, 2017, "3");
            /*
            for (int i = 0; i < 50; i ++)
            {                            
                if ( (i % 7) == 0 )
                {
                    file.addEmptyEntry(12, 2, 2017);
                }
                else
                {
                    Random rd = new Random();
                    file.addEntryForWinningNumber(12, 2, 2017, rd.Next(10).ToString());
                }
            }
            */
            //TODO: automate this assert
        }
    }
}
