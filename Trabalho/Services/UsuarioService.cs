using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Services
{
    public class UsuarioService
    {
        DAL.UsuarioDAL usuarioDAL = new DAL.UsuarioDAL();
        public (string, bool) Autenticar(string usuario, string senha)
        {
            string msg = "Falha na Autenticacao";
            bool sucesso = false;
            ViewModel.Login.UsuarioLogin usuarioLogin = new ViewModel.Login.UsuarioLogin();
            usuarioLogin.Usuario = usuario;
            usuarioLogin.Senha = senha;
            if (usuario.Length > 0 && usuario.Length < 50 && senha.Length > 0 && senha.Length < 50)
            {
                if (usuarioDAL.Autenticar(usuario, senha) != null)
                {
                    msg = "Autenticado com Sucesso!";
                    sucesso = true;
                }
            }

            return (msg, sucesso);
        }
    }
}
