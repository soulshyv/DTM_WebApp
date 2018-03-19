using Autofac;
using DTM.Core.Extensions;
using DTM.Core.Repositories;
using DTM.Core.ViewModels;
using DTM.DbManager.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DemonTaleManager.Web.Views.Characters;
using DTM.Core.Models;

namespace DemonTaleManager.Web.Controllers
{
    public class CharactersController : DtmControllerBase
    {
        public CharactersController(ILifetimeScope scope) : base(scope)
        {
        }

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
            var persos = await DtmRepositories.PersoRepository.GetAll();

            if (persos != null)
                return View(new CharactersViewModel
                {
                    Persos = persos
                });

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetDetails(int idPerso)
        {
            Perso perso;
            try
            {
                perso = await DtmRepositories.PersoRepository.GetFullPersoById(idPerso);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            
            var pic = GetPicture(perso.Nom) + "?" + new DateTime().TimeOfDay.Ticks;

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
                Inventaire = perso.Inventaire.ToList(),
                Metiers = perso.MetierPerso.ToList(),
                Passifs = perso.PassifPerso.ToList(),
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
            // TODO stocker le perso dans un champ liste et envoyer ce champ à la méthode d'update perso en plaçant l'objet à update
            //if (!ModelState.IsValid)
            //    return RedirectToAction("Index");

            if (details == null)
                return NotFound();

            var idPerso = details.Perso.Id;
            Perso persoToUpdate = null;

            if (details.Caracs != null)
            {
                await DtmRepositories.CaracRepository.Update(details.Caracs);
            }
            else
            {
                if (details.Stats != null)
                {
                    await DtmRepositories.StatRepository.Update(details.Stats);
                }
                else
                {
                    if (details.Jauges != null)
                    {
                        await DtmRepositories.JaugeRepository.Update(details.Jauges);
                    }
                    else
                    {
                        if (details.DonsPerso != null)
                        {
                            foreach (var dp in details.DonsPerso)
                            {
                                await DtmRepositories.DonPersoRepository.Update(dp);
                            }
                        }
                        else
                        {
                            if (details.Elements != null)
                            {
                                persoToUpdate = await DtmRepositories.PersoRepository.GetFullPersoById(idPerso);
                                if (persoToUpdate == null)
                                {
                                    return NotFound();
                                } 

                                foreach (var e in details.Elements)
                                {
                                    e.Perso = persoToUpdate;
                                }

                                persoToUpdate.ElementPerso = details.Elements;
                            }
                            else
                            {
                                if (details.Inventaire != null)
                                {
                                    persoToUpdate = await DtmRepositories.PersoRepository.GetFullPersoById(idPerso);
                                    if (persoToUpdate == null)
                                    {
                                        return NotFound();
                                    }

                                    foreach (var inv in details.Inventaire)
                                    {
                                        inv.Perso = persoToUpdate;
                                    }

                                    persoToUpdate.Inventaire = details.Inventaire;
                                }
                                else
                                {
                                    if (details.DemonsPerso != null)
                                    {
                                        persoToUpdate = await DtmRepositories.PersoRepository.GetFullPersoById(idPerso);
                                        if (persoToUpdate == null)
                                        {
                                            return NotFound();
                                        }

                                        foreach (var dp in details.DemonsPerso)
                                        {
                                            dp.Perso = persoToUpdate;
                                        }

                                        persoToUpdate.DemonPerso = details.DemonsPerso;
                                    }
                                    else
                                    {
                                        if (details.Skills != null)
                                        {
                                            persoToUpdate = await DtmRepositories.PersoRepository.GetFullPersoById(idPerso);
                                            if (persoToUpdate == null)
                                            {
                                                return NotFound();
                                            }

                                            foreach (var sk in details.Skills)
                                            {
                                                sk.Perso = persoToUpdate;
                                            }

                                            persoToUpdate.SkillPerso = details.Skills;
                                        }
                                        else
                                        {
                                            if (details.Perso.Lvl == 0 ||
                                                !string.IsNullOrWhiteSpace(details.Perso.Nom) ||
                                                !string.IsNullOrWhiteSpace(details.Perso.Race))
                                            {
                                                return NotFound();
                                            }
                                            persoToUpdate = await DtmRepositories.PersoRepository.GetFullPersoById(idPerso);
                                            persoToUpdate.Lvl = details.Perso.Lvl;
                                            persoToUpdate.Nom = details.Perso.Nom;
                                            persoToUpdate.Po = details.Perso.Po;
                                            persoToUpdate.Race = details.Perso.Race;
                                            persoToUpdate.TypePerso = details.Perso.TypePerso;
                                            persoToUpdate.Xp = details.Perso.Xp;

                                            await PersoRepository.Update(persoToUpdate);
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