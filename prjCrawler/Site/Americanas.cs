using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjCrawler.Site
{
    public class Americanas : ISiteDesconto
    {
        public string Nome => "Americanas";
        public string URL => "https://www.americanas.com.br/especial/oferta-do-dia";
        public bool UsesJavaScript => false;
        public EstruturaHtml EstruturaHtml => new EstruturaHtml
        { 
            Lista = "a.product__NavUI-sc-vep9u6-2 ijuCbP",
            Nome = "span.src__Text-sc-154pg0p-0 product__ProductName-sc-vep9u6-11 djqOl",
            Preco = "div.product__Price-sc-vep9u6-8 fKxMzl"
        };

    }
}
