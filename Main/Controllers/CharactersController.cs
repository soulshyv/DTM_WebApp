using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserManager.Contracts;
using DTM.DbManager.Contracts;
using Main.ViewModels;

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

        public string Details(string nomPerso)
        {
           var perso = DtmRepository.GetPersoByNom(nomPerso);

            var ret = "<div id=\"DetailsPerso\" class=\"modal fade\" role=\"dialog\">" +
                                   "< div class=\"modal-dialog\">" +

                                       "<div class=\"modal-content\">" +
                                           "<div class=\"modal-header\">" +
                                                $"<p>Détails de {nomPerso}</p>" +
                                           "</div>" +
                                           "<div class=\"modal-body\">" +

                                           "</div>" +
                                           "<div class=\"modal-footer\">" +

                                           "</div>" +
                                       "</div>" +

                                   "</div>" +
                               "</div>";

            return ret;
        }
    }
}