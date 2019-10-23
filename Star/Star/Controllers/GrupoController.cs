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
        public GrupoController(AppContext appContext)
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
            ViewBag.Grupo = Ctx.Grupos;
            bool[] dias = new bool[]
            {
                Grupo.Segunda,
                Grupo.Terca,
                Grupo.Quarta,
                Grupo.Quinta,
                Grupo.Sexta,
                Grupo.Sabado,
                Grupo.Domingo,


            };
            ViewBag.Componente = Ctx.Componentes;
            if (ModelState.IsValid)
            {
                if (Array.IndexOf(dias, true) == -1)
                {
                    ViewBag.select = "Selecione um ou mais dias!";
                    return View("Form", Grupo);
                }

                if (Grupo.Componentes == null || Grupo.Componentes.Count() == 0)
                {
                    ViewBag.select = "Selecione um ou mais componentes!";
                    return View("Form", Grupo);
                }
                if(Grupo.HorarioInicial > Grupo.HorarioFinal)
                {
                    ViewBag.Horario = "Horário incorreto!";
                    return View("Form",Grupo);
                }


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
            

            return View("index");
        }
        public IActionResult Editar(int id)
        {
            Grupo grupo = Ctx.Grupos.Find(id);
            if (grupo == null)
            {
                return RedirectToAction("index");
            }
            ViewBag.Componente = Ctx.Componentes;

            return View("Form", grupo);
        }

        [HttpPost]
        public IActionResult Editar(Grupo grupo)
        {
            bool[] dias = new bool[]
            {
                grupo.Segunda,
                grupo.Terca,
                grupo.Quarta,
                grupo.Quinta,
                grupo.Sexta,
                grupo.Sabado,
                grupo.Domingo,


            };
            ViewBag.Componente = Ctx.Componentes;
            if (ModelState.IsValid)
            {
                if (Array.IndexOf(dias, true) == -1)
                {
                    ViewBag.select = "Selecione um ou mais dias!";
                    return View("Form", grupo);
                }

                if (grupo.Componentes == null || grupo.Componentes.Count() == 0)
                {
                    ViewBag.select = "Selecione um ou mais componentes!";
                    return View("Form", grupo);
                }



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

            return View("index");
        }
        public IActionResult Excluir(int id)
        {
            Grupo grupo = Ctx.Grupos.Find(id);
            if (grupo != null)
            {
                IEnumerable<ComponenteGrupo> cg = Ctx.ComponenteGrupos.Where(a => a.GrupoId == id);

                foreach (ComponenteGrupo componenteg in cg)
                {
                    Ctx.ComponenteGrupos.Remove(componenteg);
                    
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