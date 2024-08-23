using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjCrawler.Site
{
    public class Magalu : ISiteDesconto
    {
        public string Nome => "Magalu";
        public string URL => "https://www.magazineluiza.com.br/selecao/ofertasdodia/";
        public bool UsesJavaScript => false;
        public EstruturaHtml EstruturaHtml => new EstruturaHtml
        { 
            Lista = "li.sc-eCihoo BCSuy",
            Nome = "h2.sc-kOjCZu enKhKW",
            Preco = "p.sc-kDvujY jDmBNY sc-ehkVkK kPMBBS"
        };

    }
}
