using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjCrawler.Site
{
    public class MercadoLivre : ISiteDesconto
    {
        public string Nome => "Mercado Livre";
        public string URL => "https://www.mercadolivre.com.br/ofertas";
        public bool UsesJavaScript => false;
        public EstruturaHtml EstruturaHtml => new EstruturaHtml
        { 
            Lista = "li.promotion-item",
            Nome = "p.promotion-item__title",
            Preco = "span.andes-money-amount__fraction"
        };
    }
}
