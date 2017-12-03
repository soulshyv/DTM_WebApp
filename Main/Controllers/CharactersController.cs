using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbManager.Contracts;
using Microsoft.AspNetCore.Mvc;
using UserManager.Contracts;

namespace Main.Controllers
{
    public class CharactersController : Controller
    {
        protected CharactersController(IUserManager userManager, IDtmRepository dtmRepository)
        {
            UserManager = userManager;
            DtmRepository = dtmRepository;
        }

        public IUserManager UserManager { get; }
        public IDtmRepository DtmRepository { get; }

        public IActionResult PlayableCharacters()
        {
            return View();
        }
    }
}