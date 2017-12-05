using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserManager.Contracts;
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

        public async Task<IActionResult> PlayableCharacters()
        {
            var allPersos = await DtmRepository.GetAllPerso();
            return View();
        }
    }
}