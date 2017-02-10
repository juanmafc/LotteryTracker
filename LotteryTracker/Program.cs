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
            
        }
    }




    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine("LCDTMALLBOYS");


    //        Excel.Application MyApp = null;
    //        Excel.Workbook MyBook = null;
    //        Excel.Worksheet MySheet = null;

    //        MyApp = new Excel.Application();
    //        MyApp.Visible = false;
    //        MyBook = MyApp.Workbooks.Open("C:/Users/User/Documents/C++/ConsoleApplication1/LCDTMAB.xlsx");
    //        MySheet = MyBook.Sheets[1];

    //        int lastRow = MySheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;

    //        Console.WriteLine(lastRow);


    //        /*
    //        for (int i = 1; i <= 5000; i++) {
    //            lastRow += 1;
    //            MySheet.Cells[lastRow, 1] = "LCDTM";
    //            MySheet.Cells[lastRow, 2] = "AB";

    //        }
    //        */
    //lastRow += 1;
    //        MySheet.Range["A1:J10"].Interior.Color = Excel.XlRgbColor.rgbRed;



    //        //Para sacar el valor de la Celda
    //        Console.WriteLine( MySheet.Cells[150, 1].Value.ToString() );
    //        Console.WriteLine(MySheet.Cells[150, 2].Value.ToString());
    //        Console.WriteLine(MySheet.Cells[150, 3].Value.ToString());
    //        Console.WriteLine(MySheet.Cells[150, 4].Value.ToString());
    //        Console.WriteLine(MySheet.Cells[150, 5].Value.ToString());
    //        Console.WriteLine(MySheet.Cells[150, 6].Value.ToString());
    //        Console.WriteLine(MySheet.Cells[150, 7].Value.ToString());
    //        Console.WriteLine(MySheet.Cells[150, 7].Value.ToString());


    //        int cantidadDeDias = Int32.Parse(MySheet.Cells[1, 1].Value.ToString());
    //        cantidadDeDias++;
    //        Console.WriteLine( cantidadDeDias );




    //        MyBook.Save();

    //        MyBook.Close();



    //        Console.ReadLine();
    //        MyApp.Quit();

    //        //IMORTANTE, TENER EN CUENTA EL DELETE DE LOS new

    //    }
    //}


}



/*
    -Pedir la fecha y el tipo
    -Sacar el numero de esa fecha y tipo
    -Truncar al ultimo digito
    -Abrir el excel
    -Buscar la ultima fila escrita
    -Escribir dia, mes, DOMINGO - si salio vacio, sino el numero truncado. Fijarme el primer dia anterior que haya habido sorteo
    -Escribir y pintar
    -Parsear 

*/
