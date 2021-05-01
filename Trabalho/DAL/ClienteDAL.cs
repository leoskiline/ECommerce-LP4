using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.DAL
{
    public class ClienteDAL
    {
        MySQLPersistence _bd = new MySQLPersistence();

        public Models.Cliente Autenticar(string email,string senha)        
        {
            Models.Cliente cli = null;
            DataTable dt = new DataTable();
            string sql = "SELECT Email,Senha FROM cliente WHERE Email = @email AND Senha = @senha;";
            _bd.LimparParametros();
            Dictionary<string, object> ps = new Dictionary<string, object>();
            ps.Add("@email", email);
            ps.Add("@senha", senha);
            _bd.AbrirConexao();
            dt = _bd.ExecutarSelect(sql, ps);
            _bd.FecharConexao();
            if (dt.Rows.Count > 0)
            {
                cli = new Models.Cliente()
                {
                    Email = dt.Rows[0]["Email"].ToString(),
                    Senha = dt.Rows[0]["Senha"].ToString(),
                };
            }
            return cli;
        }
    }
}
