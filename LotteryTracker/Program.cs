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
        static void Main()
        {
            try
            {

                // Create a new HttpWebRequest object.Make sure that 
                // a default proxy is set if you are behind a firewall.

                //HttpWebRequest myHttpWebRequest1 = (HttpWebRequest)WebRequest.Create("http://www.contoso.com");
                //HttpWebRequest myHttpWebRequest1 = (HttpWebRequest)WebRequest.Create("http://www.loteria-nacional.gob.ar/gxpsites/hgxpp001");

                //HttpWebRequest myHttpWebRequest1 = (HttpWebRequest)WebRequest.Create("http://www.loteria-nacional.gob.ar/Internet/Extractos/resultados_i.php?juego=quiniela&fechasorteo=09022017&tiposorteo=pri");
                //HttpWebRequest myHttpWebRequest1 = (HttpWebRequest)WebRequest.Create("http://www.loteria-nacional.gob.ar/Internet/Extractos/resultados_i.php?juego=quiniela&fechasorteo=09022017&tiposorteo=mat");
                HttpWebRequest myHttpWebRequest1 = (HttpWebRequest)WebRequest.Create("http://www.loteria-nacional.gob.ar/Internet/Extractos/resultados_i.php?juego=quiniela&fechasorteo=03012017&tiposorteo=pri");

                myHttpWebRequest1.KeepAlive = false;
                // Assign the response object of HttpWebRequest to a HttpWebResponse variable.
                HttpWebResponse myHttpWebResponse1 = (HttpWebResponse)myHttpWebRequest1.GetResponse();

                Console.WriteLine("\nThe HTTP request Headers for the first request are: \n{0}", myHttpWebRequest1.Headers);
                Console.WriteLine("Press FAFAFA Enter Key to Continue..........");
                Console.ReadLine();


                Stream streamResponse = myHttpWebResponse1.GetResponseStream();

                Console.WriteLine("ACA EMPIEZA LO DE XML..........");

                HtmlDocument cuerpo = new HtmlDocument();
                Console.WriteLine("VA A HACER EL LOAD........");
                cuerpo.Load(streamResponse);

                HtmlNode primeraColumna = cuerpo.GetElementbyId("Columna1Quiniela");
                HtmlNodeCollection numeros = primeraColumna.ChildNodes;

                List<HtmlNode> listaNumeros = numeros.Where(nodo => (nodo.Attributes["class"] != null && nodo.Attributes["class"].Value.Equals("BolillaVertical"))).ToList();
                HtmlNode primerNumero = listaNumeros.ElementAt(0);


                Console.WriteLine("Numero ganador: " + primerNumero.InnerText);


                Console.WriteLine("ARCHIVO XML..........");

                Console.ReadLine();


                StreamReader streamRead = new StreamReader(streamResponse);
                Char[] readBuff = new Char[256];
                int count = streamRead.Read(readBuff, 0, 256);
                Console.WriteLine("The contents of the Html page are.......\n");


                while (count > 0)
                {
                    String outputData = new String(readBuff, 0, count);
                    Console.Write(outputData);
                    count = streamRead.Read(readBuff, 0, 256);
                }
                Console.WriteLine();

                // Close the Stream object.
                streamResponse.Close();
                streamRead.Close();
                // Release the resources held by response object.
                myHttpWebResponse1.Close();






                /*




                // Create a new HttpWebRequest object for the specified Uri.
                HttpWebRequest myHttpWebRequest2 = (HttpWebRequest)WebRequest.Create("http://www.contoso.com");
                myHttpWebRequest2.Connection = "Close";
                // Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
                HttpWebResponse myHttpWebResponse2 =
                  (HttpWebResponse)myHttpWebRequest2.GetResponse();
                // Release the resources held by response object.
                myHttpWebResponse2.Close();
                Console.WriteLine("\nThe Http RequestHeaders are \n{0}", myHttpWebRequest2.Headers);
                Console.WriteLine("\nPress 'Enter' Key to Continue.........");
                Console.ReadLine();     
                */

            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Press ArgumentException Enter Key to Continue..........");
                Console.ReadLine();

                Console.WriteLine("\nThe second HttpWebRequest object has raised an Argument Exception as 'Connection' Property is set to 'Close'");
                Console.WriteLine("\n{0}", e.Message);


            }
            catch (WebException e)
            {

                Console.WriteLine("Press WebException Enter Key to Continue..........");
                Console.ReadLine();

                Console.WriteLine("WebException raised!");
                Console.WriteLine("\n{0}", e.Message);
                Console.WriteLine("\n{0}", e.Status);
            }
            catch (Exception e)
            {

                Console.WriteLine("Press Exception Enter Key to Continue..........");


                Console.WriteLine("Exception raised!");
                Console.WriteLine("Source :{0} ", e.Source);
                Console.WriteLine("Message :{0} ", e.Message);

                Console.ReadLine();
            }
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
