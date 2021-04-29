using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabalho.DAL;

namespace Trabalho.Services
{
    public class CategoriaService
    {
        public IEnumerable<Models.Categoria> ObterTodos()
        {
            CategoriaDAL ctg = new CategoriaDAL();

            List<Models.Categoria> cats = ctg.ObterTodos();

            return cats.AsEnumerable();
        }
    }
}
