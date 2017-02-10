using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LotteryTracker
{
    public class QuinielaLottery : Lottery
    {
        public override int getFirstNumberOn(int day, int month, int year)
        {

            int firstNumber = -1;

            try
            {

                //Get winner numbers
                HttpWebRequest myHttpWebRequest1 = (HttpWebRequest)WebRequest.Create("http://www.loteria-nacional.gob.ar/Internet/Extractos/resultados_i.php?juego=quiniela&fechasorteo=10022017&tiposorteo=mat");
                myHttpWebRequest1.KeepAlive = false;
                HttpWebResponse myHttpWebResponse1 = (HttpWebResponse)myHttpWebRequest1.GetResponse();
                HtmlDocument cuerpo = new HtmlDocument();
                cuerpo.Load(myHttpWebResponse1.GetResponseStream());


                //Get Winner Number
                HtmlNode primeraColumna = cuerpo.GetElementbyId("Columna1Quiniela");
                List<HtmlNode> listaNumeros = primeraColumna.ChildNodes.Where(nodo => (nodo.Attributes["class"] != null && nodo.Attributes["class"].Value.Equals("BolillaVertical"))).ToList();
                HtmlNode primerNumero = listaNumeros.ElementAt(0);
                firstNumber = Int32.Parse(primerNumero.InnerText);
                Console.WriteLine("Numero ganador: " + firstNumber);
                Console.ReadLine();

                myHttpWebResponse1.Close();
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

            return firstNumber;
            
        }
    }
}
