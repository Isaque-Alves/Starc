using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Star.Filters;
using Star.Models;

namespace Star.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Inicio()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
