using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryTracker
{
    public class TrackerFile
    {
        private readonly int COLUMNS_COUNT = 13;
        private ExcelFile file;

        private SortedDictionary<int, string> monthsMap;

        public TrackerFile(string path)
        {
            this.file = new ExcelFile(path);
            this.monthsMap = new SortedDictionary<int, string>();
            this.monthsMap[2] = "Febrero";
        }

        ~TrackerFile()
        {
            //TODO: For some reason saving in destructor doesn't work
            //this.file.save();
        }

        public void addEmptyEntry(int day, int month, int year)
        {
            ExcelSheet sheet = this.file.getSheet(3);
            int newRow = sheet.getLastUsedRowNumber() + 1;

            sheet.setCellText(newRow, 1, day.ToString() );
            sheet.setCellText(newRow, 2, this.getMonthAsString(month) );
            sheet.setCellText(newRow, 3, "" );

            for (int i = 1; i <= this.COLUMNS_COUNT; i++)
            {
                sheet.setCellColor(newRow, i, 148, 138, 84);
            }
            this.file.save();
        }

        private string getMonthAsString(int month)
        {
            return this.monthsMap[month];
        }
    }
}
