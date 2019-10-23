using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult CadastroNormal()
        {
            ViewBag.TipoUsuario = _Ctx.TipoUsuarios.OrderBy(tc => tc.Nome).Select(tc => new SelectListItem
            {
                Text = tc.Nome,
                Value = tc.Id.ToString()
            });
            return View();
        }

        [HttpPost]
        public IActionResult CadastroNormal(Usuario u)
        {
            Usuario valida = _Ctx.Usuarios.Where(a => a.Email == u.Email).FirstOrDefault();
            if (valida != null)
            {
                if (u.ConfirmaSenha == u.Senha)
                {
                    u.CadastroId = HttpContext.Session.GetInt32("CadastroId") ?? 0;
                    _Ctx.Usuarios.Add(u);
                    _Ctx.SaveChanges();
                    ViewBag.Validou = "Usuário criado com sucesso!";
                    return View("CadastroNormal");
                }
                else
                {
                    ViewBag.TipoUsuario = _Ctx.TipoUsuarios.OrderBy(tc => tc.Nome).Select(tc => new SelectListItem
                    {
                        Text = tc.Nome,
                        Value = tc.Id.ToString()
                    });
                    ViewBag.erro = "Senhas não coincidem";
                    return View("CadastroNormal", u);
                }
            }

            ViewBag.Erro = "Esse usuário já existe!";
            return View("CadastroNormal", u);
        }



        public IActionResult Cadastro()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Usuario u)
        {
            if (u.ConfirmaSenha == u.Senha)
            {
                Cadastro c = new Cadastro();
                c.Nome = u.NomeCadastro;
                _Ctx.Cadastros.Add(c);
                _Ctx.SaveChanges();

                u.TipoUsuarioId = 1;
                u.CadastroId = c.Id;
                _Ctx.Usuarios.Add(u);
                _Ctx.SaveChanges();
                return RedirectToAction("Cadastro");
            }
            ViewBag.erro = "deu erro";
            return View("Cadastro", u);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario u)
        {
            Usuario usuario = _Ctx.Usuarios.Where(a => a.Email == u.Email && a.Senha == u.Senha).FirstOrDefault();

            if (usuario != null)
            {

                HttpContext.Session.SetInt32("Id", usuario.Id);
                HttpContext.Session.SetInt32("CadastroId", usuario.CadastroId);
                HttpContext.Session.SetString("Nome", usuario.Nome);

                if (usuario.TipoUsuarioId == 1)
                {
                    HttpContext.Session.SetInt32("Adm", 1);
                }
                else
                {
                    HttpContext.Session.SetInt32("Adm", 0);
                }
                return RedirectToAction("Inicio", "Home");
            }
            else
            {
                ViewBag.Mensagem = "Usuário não encontrado";
            }


            return View("Login");
        }

        [HttpGet]
        public string LoginMobile(string email, string senha)
        {
            Usuario usuario = _Ctx.Usuarios.Where(a => a.Email == email && a.Senha == senha).FirstOrDefault();

            if (usuario != null)
            {
                HttpContext.Session.SetInt32("Id", usuario.Id);
                HttpContext.Session.SetInt32("CadastroId", usuario.CadastroId);
                HttpContext.Session.SetString("Nome", usuario.Nome);

                if (usuario.TipoUsuarioId == 1)
                {
                    HttpContext.Session.SetInt32("Adm", 1);
                }
                else
                {
                    HttpContext.Session.SetInt32("Adm", 0);
                }
                return "OK";
            }
            else
            {
                return "Error";
            }


        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}