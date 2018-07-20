using System.Diagnostics;
using Autofac;
using DemonTaleManager.Web.ViewModels;
using DTM.Core.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace DemonTaleManager.Web.Controllers
{
    public class HomeController : DtmControllerBase
    {
        public HomeController(ILifetimeScope scope) : base(scope)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
