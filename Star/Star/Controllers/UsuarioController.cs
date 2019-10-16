using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Star.Models;

namespace Star.Controllers
{
    public class UsuarioController : Controller
    {
        private AppContext _Ctx;
        public UsuarioController(AppContext bancoContext)
        {
            _Ctx = bancoContext;
        }

        public IActionResult Cadastro()
        {
            HttpContext.Session.SetString("qwe", "asd");
            
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Usuario u)
        {
            if(u.ConfirmaSenha == u.Senha)
            {
                Cadastro c = new Cadastro();
                c.Nome = u.NomeCadastro;
                _Ctx.Cadastros.Add(c);
                _Ctx.SaveChanges();

                u.TipoUsuarioId = 1;
                u.CadastroId = c.Id;
                _Ctx.Usuarios.Add(u);
                _Ctx.SaveChanges();
            }

            return RedirectToAction("Cadastro");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario u)
        {
            Usuario usuario = _Ctx.Usuarios.Where(a => a.Email == u.Email && a.Senha == u.Senha).FirstOrDefault();

            if(usuario != null)
            {
                HttpContext.Session.SetInt32("Id", usuario.Id);
                HttpContext.Session.SetString("Nome", usuario.Nome);

                if(usuario.TipoUsuarioId == 1)
                {
                    HttpContext.Session.SetInt32("Adm", 1);
                }
                else
                {
                    HttpContext.Session.SetInt32("Adm", 0);
                }
            }

            return View("Login", usuario);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}