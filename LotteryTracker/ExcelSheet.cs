using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace LotteryTracker
{
    public class ExcelSheet
    {
        private Excel.Worksheet sheet;

        public ExcelSheet(Excel.Worksheet sheet)
        {
            this.sheet = sheet;
        }

        ~ExcelSheet()
        {
            Marshal.ReleaseComObject(this.sheet);
        }

        public string getCellText(int row, int column)
        {
            return this.sheet.Cells[row, column].Value.ToString();
        }

        public void setCellText(int row, int column, string text)
        {
            this.sheet.Cells[row, column] = text;
        }

        public void setCellColor(int row, int column, string color)
        {
            if (color.Equals("red"))
            {
                this.sheet.Cells[row, column].Interior.Color = Excel.XlRgbColor.rgbRed;
            }
        }

        public int getLastUsedRowNumber()
        {
            return this.sheet.Cells.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;
        }

    }
}
