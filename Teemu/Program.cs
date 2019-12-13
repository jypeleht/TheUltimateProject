using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ikä
{
    class Program
    {
        public static void Aja()
        {
            Console.WriteLine("Anna syntymäpäiväsi pp.kk.yyyy");
            string spaivasi =Console.ReadLine();
            string[] parsittu = spaivasi.Split('.');
            DateTime syntynyt = DateTime.Parse(parsittu[0] + "." + parsittu[1] + "." + parsittu[2]);
            DateTime syntynyt2 = DateTime.Parse(spaivasi);
            int ikaV = DateTime.Today.Year - syntynyt.Year;
            int ikaKK = DateTime.Today.Month - syntynyt.Month;
            int ikaPv = DateTime.Today.Day - syntynyt.Day;

            Console.WriteLine("Syntynyt:"+syntynyt.Date.ToShortDateString());
            Console.WriteLine("Ikä:" + ikaV+ " vuotta "+ikaKK + " kk "+ ikaPv + " päivää");
            
        }
    }
}
