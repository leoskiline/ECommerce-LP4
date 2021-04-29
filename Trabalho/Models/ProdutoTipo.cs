using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class ProdutoTipo
    {
        private int _id;
        private string _nome;

        public ProdutoTipo(int id, string nome)
        {
            _id = id;
            _nome = nome;
        }

        public ProdutoTipo()
        {
            _id = 0;
            _nome = "";
        }

        public bool Gravar()
        {
            bool ok = true;
            return ok;
        }
    }
}
