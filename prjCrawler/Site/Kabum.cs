using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjCrawler.Site
{
    public class Kabum : ISiteDesconto
    {
        public string Nome => "Kabum";
        public string URL => "https://www.kabum.com.br/ofertas/ofertadodia";
        public bool UsesJavaScript => false;
        public EstruturaHtml EstruturaHtml => new EstruturaHtml
        { 
            Lista = "div.sc-ff8a9791-7 hDHAaY productCard",
            Nome = "span.sc-d99ca57-0 cpPIRA sc-ff8a9791-16 dubjqF nameCard",
            Preco = "span.sc-3b515ca1-2 eqqhbT priceCard"
        };
    }
}
