using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Trabalho.DAL;
using Trabalho.Models;

namespace ecommerce.DAL
{
    public class ProdutoDAL
    {
        MySQLPersistence _bd = new MySQLPersistence();

        public (int,string) Gravar(Produto produto)
        {
            string msg = "Falha ao Gravar Produto";
            string sql = "";
            _bd.LimparParametros();
            if (produto.Id == 0)
            {
                sql = "INSERT INTO produto (nome,categoriaId) VALUES (@nome,@categoriaId);";
            }
            else
            {
                sql = "UPDATE produto SET nome = @nome, categoriaId = @categoriaId WHERE produtoId = @id";
                _bd.AdicionarParametro("@id", produto.Id.ToString());
            }
            _bd.AdicionarParametro("@nome", produto.Nome);
            _bd.AdicionarParametro("@categoriaId", produto.Categoria.Id.ToString());
            _bd.AbrirConexao();
            if(_bd.ExecutarNonQuery(sql) > 0)
            {
                if (produto.Id == 0)
                    msg = "Gravado";
                else
                    msg = "Atualizado";
            }
            int idret = obterId(produto.Nome);
            _bd.FecharConexao();
            return (idret,msg);
        }

        public int obterId(string nome)
        {
            int i = 0;
            string sql = "SELECT produtoId FROM produto WHERE nome = @nome";
            _bd.LimparParametros();
            _bd.AdicionarParametro("@nome", nome);
            _bd.AbrirConexao();
            i = Convert.ToInt32(_bd.ExecutarConsultaSimples(sql));
            return i;
            
        }

        public List<Produto> ObterTodos()
        {
            List<Produto> produtos = new List<Produto>();
            string select = "select * from produto inner join categoria on produto.categoriaId = categoria.categoriaId";
            _bd.AbrirConexao();
            DataTable dt = _bd.ExecutarSelect(select);
            _bd.FecharConexao();

            foreach (DataRow row in dt.Rows)
            {
                var prod = new Produto()
                {
                    Id = Convert.ToInt32(row[0]),
                    Nome = row[1].ToString(),
                    Categoria = new Categoria()
                    {
                        Id = Convert.ToInt32(row[2]),
                        Nome = row[4].ToString()
                    }
                };

                produtos.Add(prod);
            }

            return produtos;
        }
    }
}
