using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Despensometro2.Models;
using Despensometro2.Repositories;

namespace Despensometro2.Controllers
{
    public class EstoqueController : Controller
    {
        public ActionResult Index()
        {
            if (Convert.ToBoolean(Session["usuarioLogado"]) == true)
            {
                usuario u = new usuario();
                u.usuario_id = Convert.ToInt32(Session["usuarioId"]);
                u.login_usuario = Session["usuarioLogin"].ToString();
                u.nome_usuario = Session["usuarioNome"].ToString();
                u.senha = Session["usuarioSenha"].ToString();

                EstoqueRepository estoque = new EstoqueRepository(u);

                ProdutoVencendoList pVencendo = estoque.ProdutoVencendo();
                ProdutoVencendoList pVencido = estoque.ProdutoVencido();

                ViewBag.produtosVencendo = pVencendo;
                ViewBag.ProdutosVencido = pVencido;

                return View("~/Views/Estoque/Estoque.cshtml");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
	}
}