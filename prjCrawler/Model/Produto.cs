using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjCrawler.Model
{
    public class Produto
    {
        public string Nome { get; set; }
        public string Descricao { get; set;}
        public double Preco { get; set;}

        public Produto(string nome, double preco)
        {
            Nome = nome;
            Preco = preco;
        }

        public override string ToString()
        {
            return $"Nome: {Nome}\r\nPreço: {Preco}";
        }
    }
}
