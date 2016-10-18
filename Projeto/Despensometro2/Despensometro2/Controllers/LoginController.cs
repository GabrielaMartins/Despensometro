using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Despensometro2.Repositories;
using Despensometro2.Models;

namespace Despensometro2.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Index()
        {
            return View("~/Views/Login/Login.cshtml");
        }

        public ActionResult Entrar(string login, string senha)
        {
            if (ModelState.IsValid){
                AutenticaSenhaLogin autenticaUser = new AutenticaSenhaLogin(senha, login);

                usuario autenticaUsuario = autenticaUser.Autentica();

                if (autenticaUsuario != null)
                {
                    Session["usuarioId"] = autenticaUsuario.usuario_id.ToString();
                    Session["usuarioNome"] = autenticaUsuario.nome_usuario.ToString();
                    Session["usuarioLogin"] = autenticaUsuario.login_usuario.ToString();
                    Session["usuarioSenha"] = autenticaUsuario.senha.ToString();
                    Session["usuarioLogado"] = true;

                    return RedirectToAction("Index", "Estoque");
                }
                else
                {
                    Session["usuarioLogado"] = false;
                }

            }

            return RedirectToAction("Index", "Login");
        }

        public ActionResult CreateLogin(string nome, string login, string senha)
        {
            Repository<usuario> adicionaUsuario = new Repository<usuario>();
            AutenticaSenhaLogin verificaUser = new AutenticaSenhaLogin(login);

            if (verificaUser.verificaLogin())
                return View();
            else
            {
                usuario usuario = new usuario();


                usuario.nome_usuario = nome;
                usuario.login_usuario = login;
                usuario.senha = senha;

                adicionaUsuario.AddElement(usuario);

                return View();
            }
        }

        //public ActionResult ForgotPassword()
        //{

        //}

       
    }
}
