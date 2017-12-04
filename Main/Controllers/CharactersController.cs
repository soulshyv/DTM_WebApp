using Microsoft.AspNetCore.Mvc;
using UserManager.Contracts;
using Dapper;
using DTM.DbManager.Contracts;

namespace Main.Controllers
{
    public class CharactersController : Controller
    {
        public CharactersController(IUserManager userManager, IDtmRepository dtmRepository)
        {
            UserManager = userManager;
            DtmRepository = dtmRepository;
        }

        private IUserManager UserManager { get; }
        private IDtmRepository DtmRepository { get; }

        public async System.Threading.Tasks.Task<IActionResult> PlayableCharactersAsync()
        {
            var allPersos = await DtmRepository.GetAllPerso();
            return View();
        }
    }
}