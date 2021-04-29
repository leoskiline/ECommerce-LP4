using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Trabalho.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Logar([FromBody] ViewModel.Login.UsuarioLogin usuario)
        { 
            bool sucesso = false;
            string msg = "";
            Services.UsuarioService userService = new Services.UsuarioService();
            (msg,sucesso) = userService.Autenticar(usuario.Usuario, usuario.Senha);
            // Objeto anonimo (equivalente ao obj. literal do JS)
            var retorno = new
            {
                sucesso = sucesso,
                msg = msg
            };

            return Json(retorno);
        }

        [HttpGet]
        public ActionResult Obter(int id)
        {
            return Json(new
            {
                id
            });
        }

        public ActionResult Consultar(string nome)
        {
            return Json(new
            {
                nome
            });
        }
        [HttpPut]
        public ActionResult Alterar(int id, [FromBody] ViewModel.Login.UsuarioLogin usuario)
        {
            return Json(new
            {
                id,
                usuario
            });
        }

        [HttpDelete]
        public ActionResult Excluir(int id)
        {
            return Json(new
            {
                id
            });
        }

    }
}