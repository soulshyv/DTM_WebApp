using Autofac;
using DTM.Core.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace DemonTaleManager.Web.Controllers
{
    public class UsersController : DtmControllerBase
    {
        public UsersController(ILifetimeScope scope) : base(scope)
        {
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