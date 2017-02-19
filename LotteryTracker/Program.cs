using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using HtmlAgilityPack;

namespace LotteryTracker
{
    class HttpWebRequest_Connection
    {        
        static void Main() {

            Console.WriteLine("Seleccionar loteria");


            //StringDate initialDate = new StringDate(10, 2, 2017);
            //StringDate initialDate = new StringDate(1, 11, 2016);
            //StringDate initialDate = new StringDate(2, 2, 2015);
            StringDate initialDate = new StringDate(16, 2, 2017);

            QuinielaLottery lottery = new QuinielaLottery();
            //TrackerFile trackerFile = new TrackerFile(@"..\..\Files\LotteryTrackerFile2.xlsx");
            TrackerFile trackerFile = new TrackerFile(@"..\..\Files\Nac_Mat_1ro.xlsx");
            //trackerFile.initializeFile();

            //TODO: while (date is before date)
            //while (!initialDate.getDate().Equals("13022017"))
            while (!initialDate.getDate().Equals("19022017"))
            {
                Console.WriteLine(initialDate.getDate());                
                string winningLastDigit = lottery.getFirstNumberOn(initialDate.getDate(), 1);

                int day = initialDate.getDayNumber();
                int month = initialDate.getMonthNumber();
                int year = 2017;

                if ( !winningLastDigit.Equals("") )
                {                    
                    trackerFile.addEntryForWinningNumber(day, month, year, winningLastDigit);
                }
                else
                {
                    trackerFile.addEmptyEntry(day, month, year);
                }

                initialDate.nextDay();
            }
        }

    }
}
