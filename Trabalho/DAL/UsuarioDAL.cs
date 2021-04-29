using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.DAL
{
    public class UsuarioDAL
    {
        MySQLPersistence _bd = new MySQLPersistence();

        public ViewModel.Login.UsuarioLogin Autenticar(string usuario,string senha)
        {
            ViewModel.Login.UsuarioLogin usuarioLogin = null;
            DataTable dt = new DataTable();
            string sql = "SELECT usuario,senha FROM usuario WHERE usuario = @usuario AND senha = @senha;";
            _bd.LimparParametros();
            Dictionary<string, object> ps = new Dictionary<string, object>();
            ps.Add("@usuario", usuario);
            ps.Add("@senha", senha);
            _bd.AbrirConexao();
            dt = _bd.ExecutarSelect(sql, ps);
            if (dt.Rows.Count > 0)
            {
                usuarioLogin = new ViewModel.Login.UsuarioLogin()
                {
                    Usuario = dt.Rows[0]["usuario"].ToString(),
                    Senha = dt.Rows[0]["senha"].ToString(),
                };
            }
            _bd.FecharConexao();
            return usuarioLogin;
        }
    }
}
