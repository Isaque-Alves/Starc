using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Star.Filters;
using Star.Models;

namespace Star.Controllers
{
    public class ComponenteController : Controller
    {
        private AppContext Ctx;

        public ComponenteController(AppContext appContext)
        {
            Ctx = appContext;
        }

        [LoginFilter(SomenteAdmin = true)]
        public IActionResult Index()
        {
            ViewBag.Dados = Ctx.Componentes.Include(c => c.Cadastro).Include(tp => tp.TipoComponente).OrderBy(c => c.Nome);

            
            return View();
        }

        [LoginFilter(SomenteAdmin = true)]
        public IActionResult Novo()
        {
            ViewBag.Cadastro = Ctx.Cadastros.OrderBy(c => c.Nome).Select(ca => new SelectListItem
            {
                Text = ca.Nome,
                Value = ca.Id.ToString()
            });

            

            ViewBag.TipoComponente = Ctx.TipoComponentes.OrderBy( tc => tc.Nome).Select(tc => new SelectListItem
            {
                Text = tc.Nome,
                Value = tc.Id.ToString()
            });

            return View("Form");
        }

        [HttpPost]
        [LoginFilter(SomenteAdmin = true)]
        public IActionResult Novo(Componente componente)
        {
            Ctx.Componentes.Add(componente);
            Ctx.SaveChanges();

            return RedirectToAction("index");
        }

        [LoginFilter(SomenteAdmin = true)]
        public IActionResult Editar(int id)
        {
            Componente componente = Ctx.Componentes.Find(id);

            if (componente == null)
            {
                return RedirectToAction("index");
            }

            ViewBag.Cadastro = Ctx.Cadastros.OrderBy(c => c.Nome).Select(ca => new SelectListItem
            {
                Text = ca.Nome,
                Value = ca.Id.ToString()
            });

            ViewBag.TipoComponente = Ctx.TipoComponentes.OrderBy(tc => tc.Nome).Select(tc => new SelectListItem
            {
                Text = tc.Nome,
                Value = tc.Id.ToString()
            });

            return View("Form", componente);
        }

        [HttpPost]
        [LoginFilter(SomenteAdmin = true)]
        public IActionResult Editar(Componente componente)
        {
            Ctx.Componentes.Update(componente);
            Ctx.SaveChanges();

            return RedirectToAction("index");
        }

        [LoginFilter(SomenteAdmin = true)]
        public IActionResult Excluir(int id)
        {
            Componente componente = Ctx.Componentes.Find(id);

            if (componente != null)
            {
                Ctx.Componentes.Remove(componente);
                Ctx.SaveChanges();
            }

            return RedirectToAction("index");
        }

        [LoginFilter(SomenteAdmin = true)]
        public IActionResult AlteraStatus(int id)
        {
            Componente componente = Ctx.Componentes.Find(id);


            if (componente.Status == false)
            {
                componente.Status = true;
                Ctx.Componentes.Update(componente);
                Ctx.SaveChanges();
                return RedirectToAction("index", ViewBag.Dados);
            }else
            {
                componente.Status = false;
                Ctx.Componentes.Update(componente);
                Ctx.SaveChanges();
                return RedirectToAction("index", ViewBag.Dados);
            }
        }

        [HttpGet]
        [LoginFilter(SomenteAdmin = true)]
        public String Consulta (int id)
        {
            Componente componente = Ctx.Componentes.Find(id);
            ViewBag.Consulta = componente;

            

            return "rec" + (componente.Status ? 1 : 0);
        }

        public JsonResult Lista()
        {
            //int cadastroId = Ctx.Usuarios.Find(HttpContext.Session.GetInt32("Id") ?? default(int)).CadastroId;
            int cadastroId = Ctx.Usuarios.Find(2).CadastroId;
            IEnumerable<Componente> c = Ctx.Componentes.Where(a => a.CadastroId == cadastroId);



            return Json(c);
        }
    }
}