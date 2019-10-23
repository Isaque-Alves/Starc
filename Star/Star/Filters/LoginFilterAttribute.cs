using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Star.Filters
{
    public class LoginFilterAttribute : Attribute, IActionFilter
    {
        public bool Adm { get; set; }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            int? idUsuario = context.HttpContext.Session.GetInt32("Id");

            if (idUsuario == null)
            {

                context.Result = new RedirectToRouteResult(new { controller = "home", action = "Index", });
            }
            else if (context.HttpContext.Session.GetInt32("Adm") != 1 && Adm)
            {
                context.Result = new RedirectToRouteResult(new
                {
                    controller = "home",
                    action = "error"
                });
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
        
    }
}
