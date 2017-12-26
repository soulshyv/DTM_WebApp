using DTM.DbManager.Contracts;
using DTM.DbManager.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DTM.DbManager.Models;
using UserManager.Contracts;

namespace Main.Controllers
{
    public class CharactersController : Controller
    {
        public CharactersController(IUserManager userManager, IDtmRepositorySelect dtmRepository, ICharacPicSearcher characPicSearcher)
        {
            UserManager = userManager;
            DtmRepository = dtmRepository;
            CharacPicSearcher = characPicSearcher;
        }

        private IUserManager UserManager { get; }
        private IDtmRepositorySelect DtmRepository { get; }
        private ICharacPicSearcher CharacPicSearcher { get; }

        [HttpGet]
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

        [HttpGet]
        public async Task<IActionResult> GetDetails(string nomPerso)
        {
            if (nomPerso == null)
            {
                return PartialView("Details");
            }

            var perso = await DtmRepository.GetFullPersoByName(nomPerso);
            var characPic = CharacPicSearcher.GetPicture(nomPerso);

            return PartialView("Details", new CharactersViewModel
            {
                DetailsPerso = perso,
                CharacterPicture = characPic
            });
        }

        [HttpPost]
        public async Task UpdateCaracs(Caracs caracs)
        {
            if (caracs != null)
            {
                
            }
        }
    }
}