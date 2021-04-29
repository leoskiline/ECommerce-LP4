using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class Cidade
    {
        int _id;
        string _nome;
        string _uf;

        //public int IBGE { get; set; }
       
        public Cidade()
        {
            _id = 0;
            _nome = "";
            _uf = "";
        }


        public string Uf { get => _uf; set => _uf = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public int Id { get => _id; set => _id = value; }
    
        //Validacao de Dados
        public (bool,string) Validar()
        {
            string msg = "";
            if(Nome.Trim().Length > 45)
            {
                msg = "Nome muito grande. Limite em 45 caracteres.";
            }
            else if(Uf.Trim().Length > 2)
            {
                msg = "UF muito grandoe. Limite em 2 caracteres.";
            }
            return (msg == "",msg);
        }

    }
}
