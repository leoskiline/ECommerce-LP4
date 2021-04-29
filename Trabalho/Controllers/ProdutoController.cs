using ecommerce.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabalho.Services;

namespace Trabalho.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Gravar([FromBody] System.Text.Json.JsonElement dados)
        {
            string msg = "Falha ao Gravar Produto!";
            ProdutoDAL proDal = new ProdutoDAL();
            string nome = dados.GetProperty("nome").ToString();
            string categoria = dados.GetProperty("categoria").ToString();
            if(nome.Length > 0 && categoria.Length>0 && nome.Length < 45)
                msg = proDal.Gravar(nome,categoria);
            return Json(new
            {
                msg
            });

        }

        [HttpGet]
        public IActionResult ObterCategorias()
        {
            //System.Threading.Thread.Sleep(5000);

            CategoriaService cs = new CategoriaService();
            return Json(cs.ObterTodos());
        }

    }
}
