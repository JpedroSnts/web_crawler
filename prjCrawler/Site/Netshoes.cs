using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjCrawler.Site
{
    public class Netshoes : ISiteDesconto
    {
        public string Nome => "Netshoes";
        public string URL => "https://www.netshoes.com.br/sub/ofertas";
        public bool UsesJavaScript => true;
        public EstruturaHtml EstruturaHtml => new EstruturaHtml
        { 
            Lista = "li.carousel-item",
            Nome = "a.details product-name",
            Preco = "span.haveInstallments"
        };
    }
}
