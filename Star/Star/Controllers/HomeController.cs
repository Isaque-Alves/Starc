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

        [LoginFilter(SomenteAdmin = true)]
        public IActionResult Index()
        {
            return View();
        }



        [LoginFilter(SomenteAdmin = true)]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [LoginFilter(SomenteAdmin = false)]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
