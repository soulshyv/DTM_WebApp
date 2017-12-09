using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserManager.Contracts;
using DTM.DbManager.Contracts;
using DTM.DbManager.ViewModels;

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

        public async Task<IActionResult> Index()
        {
            var allPersos = await DtmRepository.GetAllPerso();

            if (allPersos != null)
                return View(new CharactersViewModel
                {
                    Characters = allPersos
                });

            return View();
        }

        [HttpPost]
        public async Task<CharactersViewModel> Details([FromForm]string nomPerso)
        {
            var perso = await DtmRepository.GetFullPersoByName(nomPerso);

            return new CharactersViewModel
            {
                DetailsPerso = perso
            };
        }
    }
}