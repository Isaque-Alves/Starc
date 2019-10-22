using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Star.Filters;
using Star.Models;

namespace Star.Controllers
{
    public class GrupoController : Controller
    {
        private AppContext Ctx;
        public GrupoController (AppContext appContext)
        {
            Ctx = appContext;
        }
        public IActionResult Index()
        {
            ViewBag.Grupo = Ctx.Grupos;
            return View();
        }

        public IActionResult Novo()
        {
            ViewBag.Componente = Ctx.Componentes;
            return View("Form");
        }
        [HttpPost]
        public IActionResult Novo(Grupo Grupo)
        {
            if (ModelState.IsValid)
            {
                
                Ctx.Grupos.Add(Grupo);
                Ctx.SaveChanges();
                foreach (int idComponente in Grupo.Componentes)
                {
                    ComponenteGrupo cg = new ComponenteGrupo();

                    cg.GrupoId = Grupo.Id;
                    cg.ComponenteId = idComponente;
                    cg.Ativo = true;

                    Ctx.ComponenteGrupos.Add(cg);

                }
                
                Ctx.SaveChanges();
            }
            else
            {
                return View("Form", Grupo);
            }
                if (Grupo.Segunda == true)
                {
                    ViewData["Grupo"] += "Segunda";
                }
                if (Grupo.Segunda == true)
                {
                    ViewData["Grupo"] += "Terça";
                }
                if (Grupo.Segunda == true)
                {
                    ViewData["Grupo"] += "Quarta";
                }
                if (Grupo.Segunda == true)
                {
                    ViewData["Grupo"] += "Quinta";
                }
                if (Grupo.Segunda == true)
                {
                    ViewData["Grupo"] += "Sexta";
                }
                if (Grupo.Segunda == true)
                {
                    ViewData["Grupo"] += "Sábado";
                }
                if (Grupo.Segunda == true)
                {
                    ViewData["Grupo"] += "Domingo";
                }
            
            return RedirectToAction("index");
        }
        public IActionResult Editar(int id)
        {
            Grupo grupo = Ctx.Grupos.Find(id);
            if(grupo == null)
            {
                return RedirectToAction("index");
            }
            ViewBag.Componente = Ctx.Componentes;
            
            return View("Form", grupo);
        }
        [HttpPost]
        public IActionResult Editar(Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                Ctx.Grupos.Update(grupo);
                Ctx.SaveChanges();

                IEnumerable<ComponenteGrupo> cg = Ctx.ComponenteGrupos.Where(a => a.GrupoId == grupo.Id);

                foreach (ComponenteGrupo componenteg in cg)
                {
                    Ctx.ComponenteGrupos.Remove(componenteg);
                }

                Ctx.SaveChanges();

                foreach (int idComponente in grupo.Componentes)
                {
                    ComponenteGrupo cgg = new ComponenteGrupo();

                    cgg.GrupoId = grupo.Id;
                    cgg.ComponenteId = idComponente;
                    cgg.Ativo = true;

                    Ctx.ComponenteGrupos.Add(cgg);

                }

                Ctx.SaveChanges();
            }
            else
            {
                return View("Form", grupo);
            }
            return RedirectToAction("index");
        }
        public IActionResult Excluir (int id)
        {
            Grupo grupo = Ctx.Grupos.Find(id);
            if (grupo!= null)
            {
                IEnumerable<ComponenteGrupo> cg = Ctx.ComponenteGrupos.Where(a => a.GrupoId == id);

                foreach (ComponenteGrupo componenteg in cg)
                {
                    Ctx.ComponenteGrupos.Remove(componenteg);
                    Ctx.SaveChanges();
                }
                Ctx.Grupos.Remove(grupo);
                Ctx.SaveChanges();
            }
            return RedirectToAction("index");
        }
        public IActionResult Visualizar(int id)
        {
            ViewBag.Componentes = Ctx.ComponenteGrupos.Where(cg => cg.GrupoId == id && cg.Ativo == true).Include(c => c.Componente);

            return View();
        }
    }
}