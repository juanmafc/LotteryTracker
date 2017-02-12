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

    
    [TestClass]
    public class ExcelTests
    {

        //Setup empty test file
        [TestInitialize]
        public void setUp()
        {
            //TODO: create empty file and start Excel
        }

        [TestCleanup]
        public void tearDown()
        {
            //TODO: delete empty file and quit Excel
        }
        

        //cleanup delete empty test file
        [TestMethod]
        public void TestOpenEditA1CellAndClose()
        {
            //Excel is closed and then opened, refactor this
            {
                ExcelFile file = new ExcelFile(@"..\..\TestFiles\TestFile.xlsx");
                ExcelSheet sheet = file.getSheet(1);
                sheet.setCellText(1, 1, "PRUEBA");
                file.save();
            }

            {
                ExcelFile secondFile = new ExcelFile(@"..\..\TestFiles\TestFile.xlsx");
                ExcelSheet resultSheet = secondFile.getSheet(1);
                resultSheet.setCellText(1, 1, "PRUEBA");
                Assert.AreEqual("PRUEBA", resultSheet.getCellText(1, 1));
            }            


            //PROBLEMA: SI HAGO EL CLOSE, DESPUES EXPLOTA EN EL DESTRUCTOR
            //file.close();
            //file.delete();

            /*
            string fileName = @"LCDTMAB.txt";

            try
            {
                // Check if file already exists. If yes, delete it. 
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                // Create a new file 
                using (FileStream fs = File.Create(fileName))
                {
                    // Add some text to file
                    Byte[] title = new UTF8Encoding(true).GetBytes("New Text File");
                    fs.Write(title, 0, title.Length);
                    byte[] author = new UTF8Encoding(true).GetBytes("Mahesh Chand");
                    fs.Write(author, 0, author.Length);
                }

                // Open the stream and read it back.
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
            */
        }
    }
    
}
