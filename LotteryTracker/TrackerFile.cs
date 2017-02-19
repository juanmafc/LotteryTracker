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
        private SortedDictionary<int, string> columnsToNumbersMap;

        private SortedDictionary<int, bool> drawnNumbers;

        public TrackerFile(string path)
        {
            this.file = new ExcelFile(path);
            this.monthsMap = new SortedDictionary<int, string>();
            this.monthsMap[1] = "Enero";
            this.monthsMap[2] = "Febrero";
            this.monthsMap[3] = "Marzo";
            this.monthsMap[4] = "Abril";
            this.monthsMap[5] = "Mayo";
            this.monthsMap[6] = "Junio";
            this.monthsMap[7] = "Julio";
            this.monthsMap[8] = "Agosto";
            this.monthsMap[9] = "Septiembre";
            this.monthsMap[10] = "Octubre";
            this.monthsMap[11] = "Noviembre";
            this.monthsMap[12] = "Diciembre";

            //TODO: refactor and constants
            this.columnsToNumbersMap = new SortedDictionary<int, string>();
            this.columnsToNumbersMap[4] = "0";
            this.columnsToNumbersMap[5] = "1";
            this.columnsToNumbersMap[6] = "2";
            this.columnsToNumbersMap[7] = "3";
            this.columnsToNumbersMap[8] = "4";
            this.columnsToNumbersMap[9] = "5";
            this.columnsToNumbersMap[10] = "6";
            this.columnsToNumbersMap[11] = "7";
            this.columnsToNumbersMap[12] = "8";
            this.columnsToNumbersMap[13] = "9";


            this.drawnNumbers = new SortedDictionary<int, bool>();
            this.findDrawnNumbers();
        }

        private void findDrawnNumbers()
        {
            for (int i = 0; i < 10; i++)
            {
                this.drawnNumbers[i] = false;
            }

            ExcelSheet sheet = this.file.getSheet(1);
            int lastRow = sheet.getLastUsedRowNumber();
            
            while (lastRow > 1)
            {
                for (int i = 0; i < 10; i++)
                {
                    if ( !this.numberHasBeenDrawn(i) )
                    {
                        if ( !sheet.getCellText(lastRow, i + 4 ).Equals("") )
                        {
                            this.drawnNumbers[i] = true;
                        }
                    }
                }
                lastRow--;
            }
                
            
        }

        //TODO: add it for a Lottery name, if it doesn't exists, create and initialize it (write the header)
        public void addEntryForWinningNumber(int day, int month, int year, string winningNumber)
        {
            ExcelSheet sheet = this.file.getSheet(1);
            int lastRow = sheet.getLastUsedRowNumber();
            int newRow =  lastRow + 1;
            
            sheet.setCellText(newRow, 1, day.ToString());
            sheet.setCellText(newRow, 2, this.getMonthAsString(month) + "-" + year.ToString());
            sheet.setCellText(newRow, 3, winningNumber);
            
            while ( this.isRowAnEmptyEntry(sheet, lastRow) && lastRow > 1)
            {
                lastRow--;
            }

            for (int i = 4; i <= 13; i++)
            {
                if (this.columnsToNumbersMap[i].Equals(winningNumber))
                {
                    sheet.setCellText(newRow, i, "SALIO");
                    sheet.setCellColor(newRow, i, 0, 255, 255);
                    this.drawnNumbers[i - 4] = true;
                }
                else
                {
                    if (this.numberHasBeenDrawn(i - 4))
                    {
                        this.addNonWinningEntry(lastRow, i, newRow, sheet);
                    }
                    else
                    {
                        sheet.setCellColor(newRow, i, 0, 0, 0);
                    }                    
                }
            }
            this.file.save();

        }

        private bool numberHasBeenDrawn(int number)
        {
            return this.drawnNumbers[number];
        }

        private void addNonWinningEntry(int lastRow, int column, int newRow, ExcelSheet sheet )
        {
            string days = sheet.getCellText(lastRow, column);

            if (days.Equals("SALIO"))
            {
                sheet.setCellText(newRow, column, "1 DIA");
                this.colorizeCellAccordingToDaysPassed(newRow, column, 1, sheet);
            }
            else if (days.Equals("1 DIA"))
            {
                sheet.setCellText(newRow, column, "2 DIAS");
                this.colorizeCellAccordingToDaysPassed(newRow, column, 2, sheet);
            }
            else
            {
                days = days.Replace(" DIAS", "");
                int numberOfDays = Int32.Parse(days);                
                numberOfDays++;

                this.colorizeCellAccordingToDaysPassed(newRow, column, numberOfDays, sheet);
                days = numberOfDays.ToString() + " DIAS";
                sheet.setCellText(newRow, column, days);
            }
        }

        private void colorizeCellAccordingToDaysPassed(int row, int column, int numberOfDays, ExcelSheet sheet)
        {            
            if( this.numberIsInBetween(numberOfDays, 1, 7) )
            {               
               sheet.setCellColor(row, column, 153, 255, 102);
            }
            else if (this.numberIsInBetween(numberOfDays, 8, 14))
            {
                sheet.setCellColor(row, column, 255, 255, 102);
            }
            else if (this.numberIsInBetween(numberOfDays, 15, 28))
            {
                sheet.setCellColor(row, column, 83, 142,213);                
            }
            else if ( 28 <= numberOfDays)
            {
                sheet.setCellColor(row, column, 255, 0, 0);                
            }            

        }

        private bool numberIsInBetween(int numberOfDays, int num1, int num2)
        {
            return ( (num1 <= numberOfDays) && (numberOfDays <= num2) );
        }

        private bool isRowAnEmptyEntry(ExcelSheet sheet, int row)
        {
            return ((sheet.getCellText(row, 3).Equals("")) || (sheet.getCellText(row, 3).Equals("DOMINGO")));
        }


        ~TrackerFile()
        {
            //TODO: For some reason saving in destructor doesn't work
            //this.file.save();
        }


        public void addEmptyEntry(int day, int month, int year)
        {
            ExcelSheet sheet = this.file.getSheet(1);
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
