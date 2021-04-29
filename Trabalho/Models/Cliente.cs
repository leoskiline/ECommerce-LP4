using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class Cliente
    {
        int _id;
        string _nome;
        string _cpf;
        string _email;
        string _senha;
        Cidade _cidade;
        List<ClienteContato> _contatos;

        public Cliente()
        {
            _id = 0;
            _nome = "";
            _cpf = "";
            _email = "";
            _senha = "";
            _cidade = new Cidade();
            _contatos = new List<ClienteContato>();
        }

        public int Id { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Cpf { get => _cpf; set => _cpf = value; }
        public string Email { get => _email; set => _email = value; }
        public string Senha { get => _senha; set => _senha = value; }
        public Cidade Cidade { get => _cidade; set => _cidade = value; }
        public List<ClienteContato> Contatos { get => _contatos; set => _contatos = value; }

        public string Validar()
        {
            string msg = "";
            if(Email.Trim().Length > 45)
            {
                msg = "E-mail excede 45 caracteres.";
            }
            else if(Senha.Trim().Length > 45)
            {
                msg = "Senha excede os 45 caracteres.";
            }
            return msg;
        }
    }
}
