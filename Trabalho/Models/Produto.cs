using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class Produto
    {
        int _id;
        string _nome;
        int _quantidade;
        ProdutoTipo _tipo;
        decimal _precoVenda;

        public Produto(int id, string nome, int quantidade, ProdutoTipo tipo, decimal precoVenda)
        {
            _id = id;
            _nome = nome;
            _quantidade = quantidade;
            _tipo = new ProdutoTipo();
            _precoVenda = precoVenda;
        }

        public Produto()
        {
            _id = 0;
            _nome = "";
            _quantidade = 0;
            _tipo = new ProdutoTipo();
            _precoVenda = 0;
        }
    }
}
