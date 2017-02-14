using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing;

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
            if (this.sheet.Cells[row, column].Value != null)
            {
                return this.sheet.Cells[row, column].Value.ToString();
            }
            else
            {
                return "";
            }
            
        }

        public void setCellText(int row, int column, string text)
        {
            this.sheet.Cells[row, column] = text;
        }



        public void setCellColor(int row, int column, int red, int green, int blue)
        {
            this.sheet.Cells[row, column].Interior.Color = Color.FromArgb(red, green, blue);
        }


        public int getLastUsedRowNumber()
        {
            return this.sheet.Cells.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;
        }

    }
}
