using ecommerce.DAL;
using System;
using System.Collections.Generic;
using System.IO;
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
            if(produto != null)
                if (produto.Nome.Length > 0 && produto.Categoria.Id != 0)
                    (id,msg) = proDal.Gravar(produto);
            return (id,msg);
        }

        public (bool,string) GravarImagem(byte[] binario,string tipoMime,string extensao,int id)
        {
            bool sucesso = false;
            string msg = "";
            if (binario == null)
            {
                msg = "Arquivo obrigatorio.";
            }
            else if (binario.Length > 153600)
            {
                msg = "Imagem muito grande.";
            }
            else
            {
                if (tipoMime == "image/jpg" || tipoMime == "image/jpeg" || tipoMime == "image/png")
                {
                    string nomeArquivo = id + extensao;
                    //string nomeArquivo = Guid.NewGuid().ToString() + extensao;
                    File.WriteAllBytes($@"C:\ProdutosImagens\{nomeArquivo}", binario);
                    sucesso = true;
                }
                else
                {
                    msg = "Formato de arquivo nao suportado.";
                }
            }
            return (sucesso, msg);
        }

        public IEnumerable<Models.Produto> ObterTodos()
        {
            ProdutoDAL prod = new ProdutoDAL();

            List<Models.Produto> prods = prod.ObterTodos();

            return prods.AsEnumerable();
        }
    }
}
