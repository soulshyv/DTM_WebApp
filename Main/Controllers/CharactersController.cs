using System.Threading.Tasks;
using DTM.DbManager.Contracts;
using DTM.DbManager.Models;
using DTM.DbManager.ViewModels;
using Microsoft.AspNetCore.Mvc;
using UserManager.Contracts;

namespace Main.Controllers
{
    public class CharactersController : Controller
    {
        public CharactersController(IUserManager userManager, IDtmRepositorySelect dtmRepositorySelect,
            IDtmRepositoryUpdate dtmRepositoryUpdate, ICharacPicSearcher characPicSearcher)
        {
            UserManager = userManager;
            DtmRepositorySelect = dtmRepositorySelect;
            DtmRepositoryUpdate = dtmRepositoryUpdate;
            CharacPicSearcher = characPicSearcher;
        }

        private IUserManager UserManager { get; }
        private IDtmRepositorySelect DtmRepositorySelect { get; }
        private IDtmRepositoryUpdate DtmRepositoryUpdate { get; }
        private ICharacPicSearcher CharacPicSearcher { get; }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allPersos = await DtmRepositorySelect.GetAllPerso();

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
                return PartialView("Details");

            var perso = await DtmRepositorySelect.GetFullPersoByName(nomPerso);
            var characPic = CharacPicSearcher.GetPicture(nomPerso);

            return PartialView("Details", new CharactersViewModel
            {
                DetailsPerso = perso,
                CharacterPicture = characPic
            });
        }

        [HttpPost]
        public async Task UpdateCaracs(CharacterFull detailsPerso)
        {
            if (detailsPerso?.Caracs != null && string.IsNullOrWhiteSpace(detailsPerso.Charac.Nom))
                await DtmRepositoryUpdate.UpdateCaracsPerso(detailsPerso.Caracs, detailsPerso.Charac.Nom);

            RedirectToAction("GetDetails", detailsPerso?.Charac?.Nom);
        }
    }
}