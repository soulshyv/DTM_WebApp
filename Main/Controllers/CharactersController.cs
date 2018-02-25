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
        public async Task<IActionResult> Update(CharacterDetailsViewModel details)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            if (details == null)
                return NotFound();

            var nomPerso = details.Charac.Nom;
            if (string.IsNullOrWhiteSpace(nomPerso))
                return NotFound();

            if (!details.Caracs.IsAnyNullOrEmpty())
            {
                await DtmRepositoryUpdate.UpdateCaracsPerso(details.Caracs, nomPerso);
            }
            else
            {
                if (!details.Charac.IsAnyNullOrEmpty())
                {
                    await DtmRepositoryUpdate.UpdatePerso(details.Charac);
                }
                else
                {
                    if (!details.Demons.IsAnyNullOrEmpty())
                    {
                        await DtmRepositoryUpdate.UpdateDemonsPerso(details.Demons, nomPerso);
                    }
                    else
                    {
                        if (!details.Dons.IsAnyNullOrEmpty())
                        {
                            await DtmRepositoryUpdate.UpdateDonsPerso(details.Dons, nomPerso);
                        }
                        else
                        {
                            if (!details.Elements.IsAnyNullOrEmpty())
                            {
                                await DtmRepositoryUpdate.UpdateElementPerso(details.Elements, nomPerso);
                            }
                            else
                            {
                                if (!details.Inventaire.IsAnyNullOrEmpty())
                                {
                                    await DtmRepositoryUpdate.UpdateInventairePerso(details.Inventaire, nomPerso);
                                }
                                else
                                {
                                    if (!details.Jauges.IsAnyNullOrEmpty())
                                    {
                                        await DtmRepositoryUpdate.UpdateJaugesPerso(details.Jauges, nomPerso);
                                    }
                                    else
                                    {
                                        if (!details.Skills.IsAnyNullOrEmpty())
                                        {
                                            await DtmRepositoryUpdate.UpdateSkillsPerso(details.Skills, nomPerso);
                                        }
                                        else
                                        {
                                            if (!details.Stats.IsAnyNullOrEmpty())
                                                await DtmRepositoryUpdate.UpdateStatsPerso(details.Stats, nomPerso);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return Ok();
        }
    }
}