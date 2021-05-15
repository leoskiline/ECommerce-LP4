using ecommerce.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Trabalho.Models;
using Trabalho.Services;

namespace Trabalho.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listar()
        {
            return View();
        }

        public IActionResult Gravar()
        {
            string nome = Request.Form["nome"].ToString();
            int categoria = 0;
            int.TryParse(Request.Form["categoria"].ToString(), out categoria);
            int prodId = 0;
            int.TryParse(Request.Form["prodId"].ToString(),out prodId);
            var file = Request.Form.Files["file"];
            ProdutoService prodcs = new ProdutoService();
            Produto prod = null;
            string msg = "Falha ao Gravar Produto!";
            int id = 0;
            bool sucesso = false;
            if (categoria != 0 && file != null)
            {
                prod = new Produto();
                prod.Nome = nome;
                prod.Categoria = new Categoria
                {
                    Id = categoria
                };
                if (prodId != 0)
                    prod.Id = prodId;
                if (file.Length <= 153600)
                {
                    if (file.ContentType == "image/jpg" || file.ContentType == "image/jpeg" || file.ContentType == "image/png")
                    {
                        MemoryStream ms = new MemoryStream();
                        file.CopyTo(ms);
                        byte[] binario = ms.ToArray();
                        string ext = System.IO.Path.GetExtension(file.FileName);
                        if (prod != null)
                            (id, msg) = prodcs.Gravar(prod);
                        ProdutoService ps = new ProdutoService();
                        if(msg == "Gravado" && id != 0)
                            (sucesso, msg) = ps.GravarImagem(binario, file.ContentType, ext, id);
                        if (sucesso)
                            msg = "Gravado com Sucesso!";
                        if (msg == "Atualizado")
                            msg += " com Sucesso!";
                    }
                    else
                    {
                        msg = "Formato de arquivo nao suportado.";
                    }
                }
                else
                    msg = "Arquivo Muito Grande!";
            }
            
            return Json(new 
            {
                msg,
                nome,
                id
            });
            /*if (dados.GetProperty("categoria").ToString() != "" && dados.GetProperty("categoria").ToString() != "Carregando...")
            {
                prod.Nome = dados.GetProperty("nome").ToString();
                prod.Categoria = new Categoria
                {
                    Id = Convert.ToInt32(dados.GetProperty("categoria").ToString())
                };
                if (dados.GetProperty("prodId").ToString() != "")
                    prod.Id = Convert.ToInt32(dados.GetProperty("prodId").ToString());
            }
            string msg;
            int id;
            (id, msg) = prodcs.Gravar(prod);
            string nome = prod.Nome;
            return Json(new
            {
                msg,
                nome,
                id
            });*/

        }

        /*public IActionResult Gravar([FromBody] System.Text.Json.JsonElement dados)
        {
            ProdutoService prodcs = new ProdutoService();
            Produto prod = new Produto();
            if (dados.GetProperty("categoria").ToString() != "" && dados.GetProperty("categoria").ToString() != "Carregando...")
            {
                prod.Nome = dados.GetProperty("nome").ToString();
                prod.Categoria = new Categoria
                {
                    Id = Convert.ToInt32(dados.GetProperty("categoria").ToString())
                };
                if(dados.GetProperty("prodId").ToString() != "")
                    prod.Id = Convert.ToInt32(dados.GetProperty("prodId").ToString());
            }
            string msg;
            int id;
            (id,msg) = prodcs.Gravar(prod);
            string nome = prod.Nome;
            return Json(new
            {
                msg,
                nome,
                id
            });

        }*/

        public IActionResult GravarImagem()
        {
            string msg = "";
            var file = Request.Form.Files["imagem"];
            int id = Convert.ToInt32(Request.Form["id"]);
            bool sucesso = false;
            if(file == null)
            {
                msg = "Arquivo obrigatorio.";
            }
            else if(file.Length > 153600)
            {
                msg = "Imagem muito grande.";
            }
            else
            {
                if(file.ContentType == "image/jpg" || file.ContentType == "image/jpeg" || file.ContentType == "image/png")
                {
                    MemoryStream ms = new MemoryStream();
                    file.CopyTo(ms);
                    byte[] binario = ms.ToArray();
                    string ext = System.IO.Path.GetExtension(file.FileName);

                    ProdutoService ps = new ProdutoService();
                    (sucesso,msg) = ps.GravarImagem(binario,file.ContentType,ext,id);
                }
                else
                {
                    msg = "Formato de arquivo nao suportado.";
                }
            }
            return Json(new
            {
                msg,
                sucesso
            });
        }
        [HttpGet]
        public IActionResult ObterImagem(string id)
        {
            string arq = $@"C:\ProdutosImagens\{id}.jpg";
            if (System.IO.File.Exists(arq))
            {
                return File(System.IO.File.ReadAllBytes(arq),"image/jpeg");
            }
            else return Content("Arquivo nao Encontrado");
        }

        [HttpGet]
        public IActionResult ObterCategorias()
        {
            //System.Threading.Thread.Sleep(5000);

            CategoriaService cs = new CategoriaService();
            return Json(cs.ObterTodos());
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            ProdutoService pcs = new ProdutoService();
            return Json(pcs.ObterTodos());
        }

    }
}
