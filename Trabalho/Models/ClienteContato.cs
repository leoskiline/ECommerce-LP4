using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class ClienteContato
    {
        int _id;
        string _contato;
        string _tipo;

        public ClienteContato()
        {
            _id = 0;
            _contato = "";
            _tipo = "";
        }
    }
}
