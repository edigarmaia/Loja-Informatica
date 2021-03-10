using LojaInformatica.Models;
using LojaInformatica.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LojaInformatica.Controllers
{
    public class LoginController : Controller
    {
        //instanciando a classe para usar em todo projeto
        Acoes acoes = new Acoes();

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VerificarUser(Usuario user)
        {
            acoes.TestarUsuario(user);

            //Se o nome do usuario e a senha do usuario forem preenchidas...
            if(user.NomeUsuario != null && user.SenhaUsuario != null)
            {
                //validar a autenticação
                FormsAuthentication.SetAuthCookie(user.NomeUsuario, false);
                Session["usuarioLogado"] = user.NomeUsuario.ToString();
                Session["senhaLogado"] = user.SenhaUsuario.ToString();

                //Se os dados estiverem corretos, carrega a pagina Index
                return RedirectToAction("Index", "Home");
            }
            //Se não,
            else
            {
                //Volta para a página Login
                RedirectToAction("Login", "Login");
            }
            
        }
        //Criando logout
        public ActionResult Logout()
        {
            Session["usuarioLogado"] = null;
            //Usuario logado for nulo, carrega a página login
            return RedirectToAction("Login", "Login");
        }
    }
}