using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabalho.Services;

namespace Trabalho.Controllers
{
    public class CategoriaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            Services.CategoriaService cs = new Services.CategoriaService();

            return Json(cs.ObterTodos());
        }

        [HttpDelete]
        public IActionResult Excluir(int id)
        {
            bool sucesso = false;
            CategoriaService ctgs = new CategoriaService();
            sucesso = ctgs.Excluir(id);

            return Json(new
            {
                sucesso
            });
        }
    }
}
