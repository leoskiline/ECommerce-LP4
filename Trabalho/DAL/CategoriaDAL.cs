using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.DAL
{
    public class CategoriaDAL
    {
        MySQLPersistence _bd = new MySQLPersistence();
        public List<Models.Categoria> ObterTodos()
        {
            List<Models.Categoria> categorias = new List<Models.Categoria>();
            string select = "select * from categoria;";
            _bd.AbrirConexao();
            DataTable dt = _bd.ExecutarSelect(select);
            _bd.FecharConexao();

            foreach (DataRow row in dt.Rows)
            {
                var c = new Models.Categoria()
                {
                    Id = Convert.ToInt32(row["categoriaId"]),
                    Nome = row["nome"].ToString(),
                };

                categorias.Add(c);
            }

            return categorias;
        }
    }
}
