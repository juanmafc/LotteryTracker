using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LotteryTracker
{
    public class QuinielaLottery : Lottery
    {
        private string selectedLottery;

        public QuinielaLottery()
        {
            this.selectedLottery = "mat";
        }

        public QuinielaLottery(string selectedLottery)
        {
            this.selectedLottery = selectedLottery;
        }

        public override string getFirstNumberOn(string date)
        {

            string firstNumber = "";

            try
            {

                //TODO: refactor this and allow to select pri/mat/ves/noc
                //Get winner numbers
                //string url = "http://www.loteria-nacional.gob.ar/Internet/Extractos/resultados_i.php?juego=quiniela&fechasorteo=" + date + "&tiposorteo=mat";
                string url = "http://www.loteria-nacional.gob.ar/Internet/Extractos/resultados_i.php?juego=quiniela&fechasorteo=" + date + "&tiposorteo=" + this.selectedLottery;
                HttpWebRequest myHttpWebRequest1 = (HttpWebRequest)WebRequest.Create(url);
                myHttpWebRequest1.KeepAlive = false;
                HttpWebResponse myHttpWebResponse1 = (HttpWebResponse)myHttpWebRequest1.GetResponse();
                HtmlDocument cuerpo = new HtmlDocument();
                cuerpo.Load(myHttpWebResponse1.GetResponseStream());


                //Get Winner Number
                HtmlNode primeraColumna = cuerpo.GetElementbyId("Columna1Quiniela");
                List<HtmlNode> listaNumeros = primeraColumna.ChildNodes.Where(nodo => (nodo.Attributes["class"] != null && nodo.Attributes["class"].Value.Equals("BolillaVertical"))).ToList();
                HtmlNode primerNumero = listaNumeros.ElementAt(0);

                firstNumber = primerNumero.InnerText;

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

            firstNumber = Regex.Replace(firstNumber, @"\t|\n|\r", "");
            return firstNumber;
            
        }

        public override string getFirstNumberOn(string date, int numberOfDigits)
        {
            string firstNumber = this.getFirstNumberOn(date);

            if (firstNumber.Length > 0)
            {
                firstNumber = firstNumber.Substring(firstNumber.Length - numberOfDigits);
            }            
            return firstNumber;
        }
    }
}
