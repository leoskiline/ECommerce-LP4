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
        decimal _precoVenda;
        Categoria _categoria;

        public int Id { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public int Quantidade { get => _quantidade; set => _quantidade = value; }
        public decimal PrecoVenda { get => _precoVenda; set => _precoVenda = value; }
        public Categoria Categoria { get => _categoria; set => _categoria = value; }

        public Produto(int id, string nome, int quantidade, decimal precoVenda, Categoria tipo)
        {
            Id = id;
            Nome = nome;
            Quantidade = quantidade;
            PrecoVenda = precoVenda;
            Categoria = new Categoria();
        }

        public Produto()
        {
            Id = 0;
            Nome = "";
            Quantidade = 0;
            PrecoVenda = 0;
            Categoria = new Categoria();
        }
    }
}
