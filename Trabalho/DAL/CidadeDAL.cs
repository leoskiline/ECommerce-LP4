using Trabalho.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.DAL
{
    public class CidadeDAL
    {
        MySQLPersistence _bd = new MySQLPersistence();
        public (int,string) Gravar(Cidade cidade)
        {
            int rows = 0;
            string msg = "";
            try
            {
                string sql = "insert into cidade (nome,uf) values (@nome,@uf)";
                _bd.LimparParametros();
                Dictionary<string, object> ps = new Dictionary<string, object>();
                ps.Add("@nome", cidade.Nome);
                ps.Add("@uf", cidade.Uf);
                _bd.AbrirConexao();
                rows = _bd.ExecutarNonQuery(sql, ps);
                _bd.FecharConexao();
            }
            catch
            {
                msg = "Nao foi possivel gravar.";
            }
            return (rows,msg);
        }

        public Models.Cidade Obter(int id)
        {
            Models.Cidade c = null;
            string sql = $@"select * 
                            from cidade 
                            where id = {id};";
            _bd.AbrirConexao();
            DataTable dt = _bd.ExecutarSelect(sql);
            if(dt.Rows.Count > 0)
            {
                c = new Models.Cidade()
                {
                    Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                    Nome = Convert.ToString(dt.Rows[0]["Nome"]),
                    Uf = Convert.ToString(dt.Rows[0]["UF"])
                };
                /*c.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                c.Nome = Convert.ToString(dt.Rows[0]["Nome"]);
                c.Uf = Convert.ToString(dt.Rows[0]["UF"]);*/
            }
            _bd.FecharConexao();
            return c;
        }

        public IEnumerable<Models.Cidade> ObterPorUF(string uf)
        {
            List<Models.Cidade> cidades = new List<Models.Cidade>();
            string select = "select * from cidade where uf = @uf";
            _bd.LimparParametros();
            _bd.AdicionarParametro("@uf", uf);
            _bd.AbrirConexao();
            DataTable dt = _bd.ExecutarSelect(select);
            _bd.FecharConexao();

            foreach(DataRow row in dt.Rows)
            {
                var c = new Models.Cidade()
                {
                    Id = Convert.ToInt32(row["id"]),
                    Nome = row["nome"].ToString(),
                    Uf = row["uf"].ToString()
                };

                cidades.Add(c);
            }

            return cidades;
        }
        public int ContarPorUF(string uf)
        {
            int qtde = 0;
            string select = "select count(*) from cidade where uf = @uf";
            _bd.LimparParametros();
            _bd.AdicionarParametro("@uf", uf);
            _bd.AbrirConexao();
            qtde = Convert.ToInt32(_bd.ExecutarConsultaSimples(select));
            _bd.FecharConexao();
            return qtde;
        }
        public IEnumerable<Models.Cidade> ObterPorNome(string nome)
        {
            List<Models.Cidade> cidades = new List<Models.Cidade>();
            string select = "select * from cidade where nome = @nome";
            _bd.LimparParametros();
            _bd.AdicionarParametro("@nome", nome);
            _bd.AbrirConexao();
            DataTable dt = _bd.ExecutarSelect(select);
            _bd.FecharConexao();

            foreach (DataRow row in dt.Rows)
            {
                var c = new Models.Cidade()
                {
                    Id = Convert.ToInt32(row["id"]),
                    Nome = row["nome"].ToString(),
                    Uf = row["uf"].ToString()
                };

                cidades.Add(c);
            }

            return cidades;
        }

    }
}
