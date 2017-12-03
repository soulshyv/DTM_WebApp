using Microsoft.AspNetCore.Mvc;
using UserManager.Contracts;

namespace Main.Controllers
{
    public class UsersController : Controller
    {
        public IUserManager UserManager { get; }

        protected UsersController(IUserManager userManager)
        {
            UserManager = userManager;
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