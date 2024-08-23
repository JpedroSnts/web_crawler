using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prjCrawler;
using prjCrawler.Site;

namespace teste
{
    internal class Program
    {
        static void Main()
        {
            var r = Crawler.StartCrawlerAsync<Nike>().Result;
            foreach (var item in r)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Fim");
            Console.ReadKey();
        }
    }
}
