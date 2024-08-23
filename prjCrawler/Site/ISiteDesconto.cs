using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjCrawler.Site
{
    public interface ISiteDesconto
    {
        string Nome { get; }
        string URL { get; }
        bool UsesJavaScript { get; }
        EstruturaHtml EstruturaHtml { get; }
    }
}
