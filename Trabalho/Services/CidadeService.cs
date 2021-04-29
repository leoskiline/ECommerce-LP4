using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Services
{
    public class CidadeService
    {
        DAL.CidadeDAL cidadeDAL = new DAL.CidadeDAL();
        public (bool, string) Gravar(Models.Cidade cidade)
        {
            bool sucesso = false;
            bool valido = true;
            valido = ValidarCidadeUnicaPorUF(cidade);
            string msg = "";
            if (!valido)
            {
                msg = "Cidade repetida neste UF.";
            }

            (sucesso, msg) = cidade.Validar();
            if (sucesso)
            {
                sucesso = false;
                int linhas = 0;
                // regra negocios
                (linhas, msg) = cidadeDAL.Gravar(cidade);
                if (linhas > 0)
                {
                    msg = $"{linhas} salvas com sucesso.";
                    sucesso = true;
                }
            }

            return (sucesso, msg);
        }
        public bool ValidarCidadeUnicaPorUF(Models.Cidade cidade)
        {
            var cidadesCadastradas = cidadeDAL.ObterPorNome(cidade.Nome);

            foreach (var c in cidadesCadastradas)
            {
                if (c.Id != cidade.Id && c.Uf == cidade.Uf)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
