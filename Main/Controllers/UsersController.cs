using DTM.UserManager.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{
    public class UsersController : Controller
    {
        public IUserManager UserManager { get; }

        public UsersController(IUserManager userManager)
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