
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Services
{
    public class ClienteService
    {
        DAL.ClienteDAL clienteDAL = new DAL.ClienteDAL();
        public (string,bool) Autenticar(string email,string senha)
        {
            string msg = "Falha na Autenticacao";
            bool sucesso = false;
            Models.Cliente cli = new Models.Cliente();
            cli.Email = email;
            cli.Senha = senha;
            if(cli.Validar().Equals(""))
            {
                if (clienteDAL.Autenticar(email, senha) != null)
                {
                    msg = "Autenticado com Sucesso!";
                    sucesso = true;
                }
            }
            
            return (msg, sucesso);
        }
    }
}
