using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Star.Models;

namespace Star.Controllers
{
    public class LoginController : Controller
    {
        private AppContext _Ctx;
        public LoginController(AppContext bancoContext)
        {
            _Ctx = bancoContext;
        }

        public IActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            Usuario usuarioLogado = _Ctx.Usuarios.Where(u => u.Email == usuario.Email && u.Senha == usuario.Senha).FirstOrDefault();
            bool admin;
            if (usuarioLogado != null)

            {

                HttpContext.Session.SetInt32("Id", usuarioLogado.Id);

                HttpContext.Session.SetString("Nome", usuarioLogado.Nome);

                HttpContext.Session.SetString("Email", usuarioLogado.Email);
                if (usuarioLogado.TipoUsuarioId == 1)
                {
                    admin = true;
                }
                else
                {
                    admin = false;
                }
 
                HttpContext.Session.SetInt32("Administrador",  admin ? 1 : 0);

                return RedirectToAction("index", "home");
            }
            else
            {
                ViewBag.Mensagem = "Usuário não encontrado";
            }

            return View(usuario);
        }



        public string Negado()
        {
            return "Acesso negado!";//Colocar uma tela aqui!!!!
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("login");
        }
    }
}