using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Star.Models;

namespace Star.Controllers
{
    public class CadastroController : Controller
    {
        private AppContext Ctx;
        public CadastroController(AppContext appContext)
        {
            Ctx = appContext;
        }

        public IActionResult Index()
        {
            ViewBag.Usuario = Ctx.Usuarios.OrderBy(c => c.Nome);
            return View();
        }
        public IActionResult Novo()
        {
            return View("Form");
        }

        [HttpPost]
        public IActionResult Novo(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                Ctx.Usuarios.Add(usuario);
                Ctx.SaveChanges();
            }
            else
            {
                return View("form", usuario);
            }

            return RedirectToAction("index");
        }

        public IActionResult Editar(int id)
        {
            Usuario usuario = Ctx.Usuarios.Find(id);

            if (usuario == null)
            {
                return RedirectToAction("index");
            }

            return View("Form",usuario);
        }

        [HttpPost]
        public IActionResult Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                Ctx.Usuarios.Update(usuario);
                Ctx.SaveChanges();
            }
            else
            {
                return View("Form", usuario);
            }


            return RedirectToAction("index");
        }

        public IActionResult Excluir(int id)
        {
            Usuario usuario = Ctx.Usuarios.Find(id);

            if (usuario != null)
            {
                Ctx.Usuarios.Remove(usuario);
                Ctx.SaveChanges();
            }

            return RedirectToAction("index");
        }
        
    }
}