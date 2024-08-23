using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjCrawler.Site
{
    public class TesteLoja : ISiteDesconto
    {
        public string Nome => "TesteLoja";
        public string URL => "http://127.0.0.1:3000";
        public bool UsesJavaScript => true;
        public EstruturaHtml EstruturaHtml => new EstruturaHtml
        { 
            Lista = "li.produto",
            Nome = "div#nome",
            Preco = "div#preco"
        };
    }
}
