using System.Collections.Generic;
using System.Threading.Tasks;
using DTM.Core.Extensions;
using DTM.DbManager.Contracts;
using DTM.DbManager.Models;
using DTM.DbManager.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

            return PartialView("Details", new CharacterDetailsViewModel
            {
                DetailsPerso = perso,
                CharacterPicture = characPic
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCaracs([FromBody]string data)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }


            if (data.IsAnyNullOrEmpty())
            {
                return NotFound();
            }

            var dico = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
            Caracs caracs = null;
            string nom = null;

            if (dico.ContainsKey("Attaque") && dico.ContainsKey("Defense") && dico.ContainsKey("Rapidite") && dico.ContainsKey("Name"))
            {
                if (!dico.TryGetValue("Attaque", out var atk) || !dico.TryGetValue("Defense", out var def) ||
                    !dico.TryGetValue("Rapidite", out var rpt) || !dico.TryGetValue("Defense", out nom))
                {
                    return NotFound();
                }

                if (!int.TryParse(atk, out var attaque) || !int.TryParse(def, out var defense) ||
                    !int.TryParse(rpt, out var rapidite))
                {
                    return NotFound();
                }

                caracs = new Caracs
                {
                    Attaque = attaque,
                    Defense = defense,
                    Rapidite = rapidite
                };

                await DtmRepositoryUpdate.UpdateCaracsPerso(caracs, nom);
            }

            return Ok();

        }
    }
}