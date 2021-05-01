using ecommerce.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabalho.Models;

namespace Trabalho.Services
{
    public class ProdutoService
    {
        ProdutoDAL pdal = new ProdutoDAL();
        public (int,string) Gravar(Produto produto)
        {
            string msg = "Falha ao Gravar Produto!";
            int id = 0;
            ProdutoDAL proDal = new ProdutoDAL();
            if (produto.Nome.Length > 0 && produto.Categoria.Id != 0)
                (id,msg) = proDal.Gravar(produto);
            return (id,msg);
        }
    }
}
