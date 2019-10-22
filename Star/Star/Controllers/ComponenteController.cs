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

        public bool TemGrupo(Componente c, bool chamar)
        {
            IEnumerable<ComponenteGrupo> cg = Ctx.ComponenteGrupos.Include(b => b.Grupo).Where(a => a.ComponenteId == c.Id && a.Ativo == true);
            if (cg.Count() == 0)
            {
                return false;
            }
            else
            {
                if (chamar)
                {
                    AlteraStatusDoGrupo(cg, c);
                }
                return true;
            }
        }

        public void AlteraStatusDoGrupo(IEnumerable<ComponenteGrupo> cg, Componente c)
        {
            int hi = 0;
            int hf = 0;
            int atual = 0;

            foreach (ComponenteGrupo cgAtual in cg)
            {
                hi = (cgAtual.Grupo.HorarioInicial.Hour * 60) + cgAtual.Grupo.HorarioInicial.Minute;
                hf = (cgAtual.Grupo.HorarioFinal.Hour * 60) + cgAtual.Grupo.HorarioFinal.Minute;
                atual = (DateTime.Now.Hour * 60) + DateTime.Now.Minute;
                if(
                    (DateTime.Now.DayOfWeek == DayOfWeek.Monday && cgAtual.Grupo.Segunda == true) ||
                    (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday && cgAtual.Grupo.Terca == true) ||
                    (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday && cgAtual.Grupo.Quarta == true) ||
                    (DateTime.Now.DayOfWeek == DayOfWeek.Thursday && cgAtual.Grupo.Quinta == true) ||
                    (DateTime.Now.DayOfWeek == DayOfWeek.Friday && cgAtual.Grupo.Sexta == true) ||
                    (DateTime.Now.DayOfWeek == DayOfWeek.Saturday && cgAtual.Grupo.Sabado == true) ||
                    (DateTime.Now.DayOfWeek == DayOfWeek.Sunday && cgAtual.Grupo.Domingo == true)
                    )
                {
                    if (atual >= hi && atual <= hf)
                    {
                        c.Status = true;
                    }
                    else
                    {
                        c.Status = false;
                    }
                }
            }

            Ctx.Componentes.Update(c);
            Ctx.SaveChanges();
        }

        [LoginFilter]
        public IActionResult Index()
        {
            ViewBag.Dados = Ctx.Componentes.Include(c => c.Cadastro).Include(tp => tp.TipoComponente).Include(d => d.ComponenteGrupos).Where(a => a.CadastroId == HttpContext.Session.GetInt32("CadastroId")).OrderBy(c => c.Nome);


            return View();
        }

        [LoginFilter]
        public IActionResult Adicionar()
        {
            return View();
        }

        [LoginFilter]
        [HttpPost]
        public IActionResult Adicionar(int id) 
        {
            Componente c = Ctx.Componentes.Where(a => a.Id == id && a.Cadastro == null).FirstOrDefault();
            if (c == null)
            {
                ViewBag.Mensagem = "Componente não existe, ou já possui um usuario!";
            }
            else
            {
                ViewBag.Mensagem = "Componente adicionado com sucesso!";
                c.CadastroId = HttpContext.Session.GetInt32("CadastroId") ?? default(int);
                Ctx.SaveChanges();
            }
            return RedirectToAction("index");
        }

        [LoginFilter]
        public IActionResult Palavra()
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

        [LoginFilter]
        [HttpPost]
        public IActionResult Palavra(Componente componente)
        {
            Ctx.Componentes.Add(componente);
            Ctx.SaveChanges();

            return RedirectToAction("index");
        }

        [LoginFilter(Adm = true)]
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

        [LoginFilter(Adm = true)]
        [HttpPost]
        public IActionResult Editar(Componente componente)
        {
            Ctx.Componentes.Update(componente);
            Ctx.SaveChanges();

            return RedirectToAction("index");
        }

        [LoginFilter(Adm = true)]
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


        public IActionResult AlteraStatus(int id)
        {
            Componente c = Ctx.Componentes.Find(id);

            if(TemGrupo(c, true))
            {
                Ctx.ComponenteGrupos.Where(a => a.ComponenteId == c.Id).FirstOrDefault().Ativo = false;
            }

            if (c.Status == false)
            {
                c.Status = true;
            }
            else
            {
                c.Status = false;
            }

            Ctx.SaveChanges();
            return RedirectToAction("index");
        }


        [LoginFilter]
        public String AlteraStatusMobile(int id)
        {
            Componente componente = Ctx.Componentes.Where(a => a.Id == id && a.CadastroId == HttpContext.Session.GetInt32("CadastroId")).FirstOrDefault();


            if (componente.Status == false)
            {
                componente.Status = true;
                Ctx.Componentes.Update(componente);
                Ctx.SaveChanges();
                return "True";
            }
            else
            {
                componente.Status = false;
                Ctx.Componentes.Update(componente);
                Ctx.SaveChanges();
                return "False";
            }
        }

        [HttpGet]
        public String Consulta (int id)
        {
            Componente componente = Ctx.Componentes.Find(id);
            TemGrupo(componente, true);

            return "rec" + (componente.Status ? 1 : 0);
        }

        [LoginFilter]
        public JsonResult Lista()
        {
            IEnumerable<Componente> c = Ctx.Componentes.Where(a => a.CadastroId == HttpContext.Session.GetInt32("CadastroId"));

            return Json(c);
        }
    }
}