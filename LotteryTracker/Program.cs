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

            SortedDictionary<string, string> lotteriesOptions = new SortedDictionary<string, string>();
            lotteriesOptions["1"] = "pri";
            lotteriesOptions["2"] = "mat";
            lotteriesOptions["3"] = "ves";
            lotteriesOptions["4"] = "noc";

            Console.WriteLine("Seleccionar loteria");
            Console.WriteLine("1-Primera");
            Console.WriteLine("2-Matutina");
            Console.WriteLine("3-Vespertina");
            Console.WriteLine("4-Nocturna");

            string selectedLottery = lotteriesOptions[Console.ReadLine()];

            Console.WriteLine("Desde 02022015");
            Console.Write("Hasta (formato DDMMAAAA): ");
            string limit = Console.ReadLine();

            



            //StringDate initialDate = new StringDate(10, 2, 2017);
            //StringDate initialDate = new StringDate(1, 11, 2016);
            StringDate initialDate = new StringDate(2, 2, 2015);

            //QuinielaLottery lottery = new QuinielaLottery();
            QuinielaLottery lottery = new QuinielaLottery(selectedLottery);
            //TrackerFile trackerFile = new TrackerFile(@"..\..\Files\LotteryTrackerFile2.xlsx");
            TrackerFile trackerFile = new TrackerFile(@"..\..\Files\LTF.xlsx");
            //trackerFile.initializeFile();

            //TODO: while (date is before date)
            //while (!initialDate.getDate().Equals("13022017"))
            //while (!initialDate.getDate().Equals("19022017"))
            while (!initialDate.getDate().Equals(limit)) 
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
