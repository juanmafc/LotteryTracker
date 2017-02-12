using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Excel = Microsoft.Office.Interop.Excel;


namespace LotteryTracker
{
    /* TODO: extract this as a class
    public class ExcelApplication
    {
        static private Excel.Application application;

        private ExcelApplication() { }
                 
        static public ExcelFile openExcelFile(string path)
        {

            return new ExcelFile(path);
        }

    }
    */

        public class ExcelFile
    {

        private Excel.Application application;

        private Excel.Workbook file;

        private string path;
       

        public ExcelFile(string path)
        {
            //TODO: release resources and extract this to a singleton class
            this.application = new Excel.Application();
            this.application.Visible = false;
            if (this.application == null)
            {
                Console.WriteLine("Excel is not properly installed!!");
                return;
            }
            //////////////////////////////////////////////////////////////


            this.file= null;
            this.path = System.IO.Path.GetFullPath(path);
            this.file = this.application.Workbooks.Open(this.path);
            /*
            Excel.Worksheet MySheet = null;
            MySheet = MyBook.Sheets[1];
            MySheet.Range["A1:J10"].Interior.Color = "0xFF0000";            
            */
                        
        }

        public void close()
        {
            //TODO: rethink this method
            //this.file.Close(false);
            //Marshal.ReleaseComObject(this.file);
        }

        public void save()
        {
            this.file.Save();
        }

        public ExcelSheet getSheet(int sheetNumber)
        {
            return new ExcelSheet(this.file.Sheets[sheetNumber]);
        }

        ~ExcelFile()
        {
            this.file.Close(false);
            this.application.Quit();

            Marshal.ReleaseComObject(this.file);
            Marshal.ReleaseComObject(this.application);
        }

    }

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
            if (color.Equals("red") )
            {
                this.sheet.Cells[row, column].Interior.Color = Excel.XlRgbColor.rgbRed;
            }
        }

        //        int lastRow = MySheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;
        //        Console.WriteLine(lastRow);
        //        lastRow += 1;
        //        MySheet.Range["A1:J10"].Interior.Color = Excel.XlRgbColor.rgbRed;
        //        //Para sacar el valor de la Celda
        //        Console.WriteLine( MySheet.Cells[150, 1].Value.ToString() );
        //        int cantidadDeDias = Int32.Parse(MySheet.Cells[1, 1].Value.ToString());
        //        cantidadDeDias++;
        //        Console.WriteLine( cantidadDeDias );

        //        MyBook.Save();
        //        MyBook.Close();

    }
}
