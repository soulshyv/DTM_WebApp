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
        public async Task<IActionResult> UpdateCharac(CharacterDetailsViewModel details)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            if (details == null)
            {
                return NotFound();
            }

            if (details.Charac.IsAnyNullOrEmpty() || string.IsNullOrWhiteSpace(details.Charac.Nom))
            {
                return NotFound();
            }

            await DtmRepositoryUpdate.UpdatePerso(details.Charac);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCaracs(CharacterDetailsViewModel details)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            if (details == null)
            {
                return NotFound();
            }

            if (details.Caracs.IsAnyNullOrEmpty() || string.IsNullOrWhiteSpace(details.Charac.Nom))
            {
                return NotFound();
            }

            await DtmRepositoryUpdate.UpdateCaracsPerso(details.Caracs, details.Charac.Nom);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateJauges(CharacterDetailsViewModel details)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            if (details == null)
            {
                return NotFound();
            }

            if (details.Jauges.IsAnyNullOrEmpty() || string.IsNullOrWhiteSpace(details.Charac.Nom))
            {
                return NotFound();
            }

            await DtmRepositoryUpdate.UpdateJaugesPerso(details.Jauges, details.Charac.Nom);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStats(CharacterDetailsViewModel details)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            if (details == null)
            {
                return NotFound();
            }

            if (details.Stats.IsAnyNullOrEmpty() || string.IsNullOrWhiteSpace(details.Charac.Nom))
            {
                return NotFound();
            }

            await DtmRepositoryUpdate.UpdateStatsPerso(details.Stats, details.Charac.Nom);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateElements(CharacterDetailsViewModel details)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            if (details == null)
            {
                return NotFound();
            }

            if (details.Elements.IsAnyNullOrEmpty() || string.IsNullOrWhiteSpace(details.Charac.Nom))
            {
                return NotFound();
            }

            await DtmRepositoryUpdate.UpdateElementPerso(details.Elements, details.Charac.Nom);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSkills(CharacterDetailsViewModel details)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            if (details == null)
            {
                return NotFound();
            }

            if (details.Skills.IsAnyNullOrEmpty() || string.IsNullOrWhiteSpace(details.Charac.Nom))
            {
                return NotFound();
            }

            await DtmRepositoryUpdate.UpdateSkillsPerso(details.Skills, details.Charac.Nom);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDonsPerso(CharacterDetailsViewModel details)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            if (details == null)
            {
                return NotFound();
            }

            if (details.Dons.IsAnyNullOrEmpty() || string.IsNullOrWhiteSpace(details.Charac.Nom))
            {
                return NotFound();
            }

            await DtmRepositoryUpdate.UpdateDonsPerso(details.Dons, details.Charac.Nom);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDemons(CharacterDetailsViewModel details)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            if (details == null)
            {
                return NotFound();
            }

            if (details.Demons.IsAnyNullOrEmpty() || string.IsNullOrWhiteSpace(details.Charac.Nom))
            {
                return NotFound();
            }

            await DtmRepositoryUpdate.UpdateDemonsPerso(details.Demons, details.Charac.Nom);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateInventaire(CharacterDetailsViewModel details)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            if (details == null)
            {
                return NotFound();
            }

            if (details.Inventaire.IsAnyNullOrEmpty() || string.IsNullOrWhiteSpace(details.Charac.Nom))
            {
                return NotFound();
            }

            await DtmRepositoryUpdate.UpdateInventairePerso(details.Inventaire, details.Charac.Nom);

            return Ok();
        }
    }
}