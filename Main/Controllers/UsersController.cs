using Autofac;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{
    public class UsersController : Controller
    {
        public ILifetimeScope Scope { get; }

        public UsersController(ILifetimeScope scope)
        {
            Scope = scope;
        }

        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}