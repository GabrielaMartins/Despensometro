using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Despensometro2.Repositories;
using Despensometro2.Models;


namespace Despensometro2.Controllers
{
    public class ProdutoController : Controller
    {
        private Repository<produto> repository;

        public ProdutoController(){
            repository = new Repository<produto>();    
        }

        public ActionResult Index()
        {
            List<produto> list = repository.ListAll().OrderBy(p => p.produto_nome).ToList();

            return View("~/Views/Produto/Produto.cshtml", list);
        }

        public JsonResult PesquisaProduto(string valor)
        {
            ProdutoRepository listaProdutos = new ProdutoRepository();

            var lista = listaProdutos.FiltraProduto(valor);

            return Json(lista, JsonRequestBehavior.AllowGet);
        }

       
        [HttpGet]
        public ActionResult AdicionarProduto()
        {
            Repository<tipo> repTipo = new Repository<tipo>();

            ViewBag.categorias = repTipo.ListAll();

            return View();
        }

        [HttpPost]
        public JsonResult AdicionarProduto(ProdutoSimplificado objeto)
        {
            bool resposta = false;

            if (objeto.produto_nome != null && objeto.produto_categoria != null && objeto.produto_fabricante != null)
            {
                Repository<tipo> repTipo = new Repository<tipo>();

                tipo tipoProd = null;

                foreach (var t in repTipo.ListAll())
                {
                    if (t.categoria_produto.Equals(objeto.produto_categoria.Replace(" ", "")))
                    {
                        tipoProd = t;
                        break;
                    }
                }

                produto p = new produto();

                p.produto_nome = objeto.produto_nome;
                p.produto_peso = objeto.produto_peso;
                p.sabor = objeto.sabor;
                p.tipo_id = tipoProd.tipo_id;
                p.numero_ean = objeto.numero_ean;
                p.fabricante = new fabricante() { nome_fabricante = objeto.produto_fabricante };

                repository.AddElement(p);

                resposta = true;
            }
            else
            {
                resposta = false;
            }

            

            return Json(resposta, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult EditarProduto(int id)
        {
            produto p = repository.GetById(id);
            Repository<tipo> repTipo = new Repository<tipo>();
            List<SelectListItem> types = new List<SelectListItem>();

            types.Add(new SelectListItem() { Value = p.tipo.tipo_id.ToString(), Text = p.tipo.categoria_produto });

            foreach (tipo t in repTipo.ListAll().OrderBy(obj => obj.categoria_produto))
            {
               if(t.categoria_produto != p.tipo.categoria_produto)
                {
                    types.Add(new SelectListItem() { Value = t.tipo_id.ToString(), Text = t.categoria_produto});
                }
                
            }

            ViewBag.categorias = types;

            return View("~/Views/Produto/EditarProduto.cshtml", p);
            
        }

        [HttpPost]
        public ActionResult EditarProduto(produto objeto)
        {
            var result = false;
            
            if (objeto.produto_nome != null && objeto.tipo_id != null && objeto.fabricante.nome_fabricante != null)
            {
                repository.UpdateElement(objeto);
                ViewBag.resposta = true;
                result = true;
            }
            else
            {
                ViewBag.resposta = false;
                result = false;
            }

            produto p = repository.GetById(objeto.produto_id);
            Repository<tipo> repTipo = new Repository<tipo>();
            List<SelectListItem> types = new List<SelectListItem>();

            foreach (tipo t in repTipo.ListAll().OrderBy(obj => obj.categoria_produto))
            {
                types.Add(new SelectListItem() { Value = t.tipo_id.ToString(), Text = t.categoria_produto });

            }

            ViewBag.categorias = types;

            var resultado = new { Success = result};

            return View(); /* Json(resultado, JsonRequestBehavior.AllowGet);*/

        }

        public ActionResult ConfirmaDeletar(int id)
        {
            produto produto =  repository.GetById(id);

            return View();
        }

        public ActionResult DeletarProduto(int id)
        {
            Boolean sucesso = repository.Delete(id);

            if (sucesso)
            {
                return View();
            }
            else
            {
                //TODO
                return View();
            }
            
        }
    }
}
