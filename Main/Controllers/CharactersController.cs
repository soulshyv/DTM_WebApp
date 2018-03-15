using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using DemonTaleManager.Web.Views.Characters;
using DTM.Core.Extensions;
using DTM.Core.Repositories;
using DTM.Core.ViewModels;
using DTM.DbManager.Contracts;
using DTM.UserManager.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace DemonTaleManager.Web.Controllers
{
    public class CharactersController : DtmControllerBase
    {
        public CharactersController(ILifetimeScope scope) : base(scope)
        {
        }

        private IUserManager _userManager;
        protected IUserManager UserManager => _userManager ?? (_userManager = Scope.Resolve<IUserManager>());

        private ICharacPicSearcher _characPicSearcher;

        protected ICharacPicSearcher CharacPicSearcher =>
            _characPicSearcher ?? (_characPicSearcher = Scope.Resolve<ICharacPicSearcher>());

        private DtmRepositories _dtmRepositories;

        protected DtmRepositories DtmRepositories =>
            _dtmRepositories ?? (_dtmRepositories = Scope.Resolve<DtmRepositories>());

        private IHostingEnvironment _hostingEnv;
        protected IHostingEnvironment HostingEnv => _hostingEnv ?? (_hostingEnv = Scope.Resolve<IHostingEnvironment>());

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allPersos = await DtmRepositories.PersoRepository.GetAll();

            if (allPersos != null)
                return View(new CharactersViewModel
                {
                    Persos = allPersos
                });

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetDetails(string nomPerso)
        {
            if (nomPerso == null)
                return PartialView("Details");

            var perso = await DtmRepositories.PersoRepository.GetFullPersoByName(nomPerso);
            var pic = GetPicture(nomPerso) + "?" + new DateTime().TimeOfDay.Ticks;

            return PartialView("Details", new CharacterDetailsViewModel
            {
                Perso = perso,
                Caracs = perso.Carac.FirstOrDefault(),
                Jauges = perso.Jauge.FirstOrDefault(),
                Stats = perso.Stat.FirstOrDefault(),
                Elements = perso.ElementPerso.ToList(),
                Skills = perso.SkillPerso.ToList(),
                DonsPerso = perso.DonPerso.ToList(),
                DemonsPerso = perso.DemonPerso.ToList(),
                Inventaire = perso.Inventaire.FirstOrDefault(),
                CharacterPicture = pic
            });
        }

        [HttpPost]
        public string GetPicture(string nomPerso)
        {
            if (nomPerso == null)
                return string.Empty;

            var characPic = CharacPicSearcher.GetPicture(nomPerso, true);

            return characPic;
        }

        [HttpPost]
        public async Task<IActionResult> Update(CharacterDetailsViewModel details)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            if (details == null)
                return NotFound();

            if (!details.Caracs.IsAnyNullOrEmpty())
            {
                await DtmRepositories.CaracRepository.Update(details.Caracs);
            }
            else
            {
                if (!details.Perso.IsAnyNullOrEmpty())
                {
                    await DtmRepositories.PersoRepository.Update(details.Perso);
                }
                else
                {
                    if (!details.DemonsPerso.IsAnyNullOrEmpty())
                    {
                        foreach (var dp in details.DemonsPerso)
                        {
                            await DtmRepositories.DemonPersoRepository.Update(dp);
                        }
                    }
                    else
                    {
                        if (!details.DonsPerso.IsAnyNullOrEmpty())
                        {
                            foreach (var dp in details.DonsPerso)
                            {
                                await DtmRepositories.DonPersoRepository.Update(dp);
                            }
                        }
                        else
                        {
                            if (!details.Elements.IsAnyNullOrEmpty())
                            {
                                foreach (var e in details.Elements)
                                {
                                    await DtmRepositories.ElementPersoRepository.Update(e);
                                }
                            }
                            else
                            {
                                if (!details.Inventaire.IsAnyNullOrEmpty())
                                {
                                    await DtmRepositories.InventaireRepository.Update(details.Inventaire);
                                }
                                else
                                {
                                    if (!details.Jauges.IsAnyNullOrEmpty())
                                    {
                                        await DtmRepositories.JaugeRepository.Update(details.Jauges);
                                    }
                                    else
                                    {
                                        if (!details.Skills.IsAnyNullOrEmpty())
                                        {
                                            foreach (var sp in details.Skills)
                                            {
                                                await DtmRepositories.SkillPersoRepository.Update(sp);
                                            }
                                        }
                                        else
                                        {
                                            if (!details.Stats.IsAnyNullOrEmpty())
                                            {
                                                await DtmRepositories.StatRepository.Update(details.Stats);
                                            }
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

        [HttpPost]
        public async Task<IActionResult> UpdatePic(string nomPerso)
        {
            foreach (var file in Request.Form.Files)
            {
                var directorypath = HostingEnv.WebRootPath + @"\images\CharacPictures\";
                var strings = ContentDispositionHeaderValue.Parse(file.ContentDisposition).Name.Trim().ToString()
                    .Split(".");
                var ext = strings.LastOrDefault()?.ToLower();
                var filename = "CharacterPicture_" + nomPerso + "_" + DateTime.Now.ToUnixTimeStamp() + "." + ext;

                var invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
                filename = invalid.Aggregate(filename, (current, c) => current.Replace(c.ToString(), ""));

                var filepath = directorypath + filename;

                if (!Directory.Exists(directorypath))
                    Directory.CreateDirectory(directorypath);

                foreach (var f in Directory.GetFiles(directorypath))
                {
                    var fname = Path.GetFileName(f).Split(".")[0].Split(@"\")[0];
                    if (fname.Contains(nomPerso))
                        System.IO.File.Delete(f);
                }

                try
                {
                    using (var fs = System.IO.File.Create(filepath))
                    {
                        await file.CopyToAsync(fs);
                        fs.Flush();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                return Ok();
            }

            return NotFound();
        }

        //[HttpPost]
        //public async void PostDonsPerso(List<DTM.DbManager.Models.DonPerso> dons, string nomPerso)
        //{
        //    await Update(new CharacterDetailsViewModel
        //    {
        //        DonsPerso = dons
        //    }, nomPerso);
        //}
    }
}