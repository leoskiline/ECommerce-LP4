using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabalho.DAL;

namespace ecommerce.DAL
{
    public class ProdutoDAL
    {
        MySQLPersistence _bd = new MySQLPersistence();

        public string Gravar(string nome,string id)
        {
            string msg = "Falha ao Gravar Produto";
            string sql = "INSERT INTO produto (nome,categoriaId) VALUES (@nome,@categoriaId);";
            _bd.LimparParametros();
            _bd.AdicionarParametro("@nome", nome);
            _bd.AdicionarParametro("@categoriaId", id);
            _bd.AbrirConexao();
            if(_bd.ExecutarNonQuery(sql) > 0)
            {
                msg = "Produto Gravado com Sucesso!!!";
            }
            return msg;
        }
    }
}
