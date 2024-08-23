using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using prjCrawler.Model;
using prjCrawler.Site;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace prjCrawler
{
    public class Crawler
    {
        public static async Task<List<Produto>> StartCrawlerAsync<T>()
        {
            var instanceSite = Activator.CreateInstance<T>();
            var isSite = instanceSite.GetType().GetInterface(typeof(ISiteDesconto).Name) != null;
            if (!isSite) throw new InvalidCastException("Classe referenciada não implementa interface 'ISiteDesconto'!");
            var site = (ISiteDesconto)instanceSite;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            var htmlDoc = new HtmlDocument();
            string html;
            if (site.UsesJavaScript)
            {
                var driver = GetHtmlBySelenium(site);
                html = driver.PageSource;
                driver.Quit();
            }
            else
            {
                html = await client.GetStringAsync(site.URL);
            }
            htmlDoc.LoadHtml(html);

            var lis = GetList(site.EstruturaHtml, htmlDoc);

            var list = new List<Produto>();
            foreach (var li in lis) list.Add(GenerateProduto(site.EstruturaHtml, li));

            return list;
        }

        private static ChromeDriver GetHtmlBySelenium(ISiteDesconto site)
        {
            var options = new ChromeOptions();
            //options.AddArguments(new List<string>() { "headless", "disable-gpu" });
            var driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(site.URL);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            var element = wait.Until(drv =>
            {
                var els = drv.FindElements(By.CssSelector(site.EstruturaHtml.Lista));
                return els.Count != 0;
            });
            return driver;
        }

        private static Produto GenerateProduto(EstruturaHtml estrutura, HtmlNode li)
        {
            var selectorNome = GetSelector(estrutura.Nome);
            var selectorPreco = GetSelector(estrutura.Preco);
            var elNome = estrutura.Nome.Split(char.Parse(selectorNome[0]));
            var elPreco = estrutura.Preco.Split(char.Parse(selectorPreco[0]));

            var nome = li.Descendants(elNome[0]).Where(x => x.GetAttributeValue(selectorNome[1], "").Equals(elNome[1])).First().InnerText;
            Regex rgx = new Regex("[a-zA-Z\\$\\s]");
            var preco = li.Descendants(elPreco[0]).Where(x => x.GetAttributeValue(selectorPreco[1], "").Equals(elPreco[1])).First().InnerText.Replace(".", "").Replace(",", ".");
            var str = rgx.Replace(preco, "");
            var prod = new Produto(nome, Double.Parse(str));
            return prod;
        }

        private static List<HtmlNode> GetList(EstruturaHtml estrutura, HtmlDocument htmlDoc)
        {
            var selector = GetSelector(estrutura.Lista);
            var el = estrutura.Lista.Split(char.Parse(selector[0]));
            var list = htmlDoc.DocumentNode.Descendants(el[0]).ToList()
                        .Where(node => node.GetAttributeValue(selector[1], "").Contains(el[1])).ToList();
            return list;
        }

        private static string[] GetSelector(string estrutura)
        {
            string[] selector = new string[2];
            if (estrutura.Contains("."))
            {
                selector[0] = ".";
                selector[1] = "class";
            }
            if (estrutura.Contains("#"))
            {
                selector[0] = "#";
                selector[1] = "id";
            }
            return selector;
        }
    }
}
