using Autofac;
using DemonTaleManager.Web.Views.Characters;
using DTM.Core.Extensions;
using DTM.Core.Models;
using DTM.Core.Repositories;
using DTM.Core.ViewModels;
using DTM.DbManager.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DemonTaleManager.Web.Controllers
{
    public class CharactersController : DtmControllerBase
    {
        public CharactersController(ILifetimeScope scope) : base(scope)
        {
        }

        private ICharacPicSearcher _characPicSearcher;
        protected ICharacPicSearcher CharacPicSearcher => _characPicSearcher ?? (_characPicSearcher = Scope.Resolve<ICharacPicSearcher>());

        private DtmRepositories _dtmRepositories;
        protected DtmRepositories DtmRepositories => _dtmRepositories ?? (_dtmRepositories = Scope.Resolve<DtmRepositories>());

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
            PersoDto perso;
            try
            {
                perso = await DtmRepositories.PersoRepository.GetFullPersoById(idPerso);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            
            var pic = GetPicture(perso.Charac.Nom) + "?" + new DateTime().TimeOfDay.Ticks;
            var dons = await DtmRepositories.DonRepository.GetAll();
            var demons = await DtmRepositories.DemonRepository.GetAll();
            var elements = await DtmRepositories.ElementRepository.GetAll();
            var skills = await DtmRepositories.SkillRepository.GetAll();
            var items = await DtmRepositories.ItemRepository.GetAll();

            return PartialView("Details", new CharacterDetailsViewModel
            {
                Perso = perso,
                Caracs = perso.Caracs,
                Jauges = perso.Jauges,
                Stats = perso.Stats,
                ElementsPerso = perso.Elements,
                SkillsPerso = perso.Skills,
                DonsPerso = perso.Dons,
                DemonsPerso = perso.Demons,
                Inventaire = perso.Inventaire,
                MetiersPerso = perso.Metiers,
                PassifsPerso = perso.Passifs,
                CharacterPicture = pic,
                Dons = dons,
                Demons = demons,
                Elements = elements,
                Skills = skills,
                Items = items
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
            if (details == null)
                return NotFound();
             
            //var idPerso = details.Perso.Charac.Id;

            //if (details.Caracs != null)
            //{
            //    //await DtmRepositories.CaracRepository.Update(details.Caracs);
            //}
            //else
            //{
            //    if (details.Stats != null)
            //    {
            //        //await DtmRepositories.StatRepository.Update(details.Stats);
            //    }
            //    else
            //    {
            //        if (details.Jauges != null)
            //        {
            //            //await DtmRepositories.JaugeRepository.Update(details.Jauges);
            //        }
            //        else
            //        {
            //            if (details.DonsPerso != null)
            //            {
            //                var taux10 = 0;
            //                var taux15 = 0;
            //                var taux20 = 0;

            //                foreach (var dp in details.DonsPerso)
            //                {
            //                    switch (dp.Taux)
            //                    {
            //                        case 10:
            //                            taux10 += 1;
            //                            break;
            //                        case 15:
            //                            taux15 += 1;
            //                            break;
            //                        case 20:
            //                            taux20 += 1;
            //                            break;
            //                    }
            //                }

            //                if (taux10 != 1 || taux15 != 2 || taux20 == 1)
            //                {
            //                    return Forbid();
            //                }

            //                foreach (var dp in details.DonsPerso)
            //                {
            //                    await DtmRepositories.DonPersoRepository.Update(dp);
            //                }
            //            }
            //            else
            //            {
            //                if (details.ElementsPerso != null)
            //                {
            //                    foreach (var e in details.ElementsPerso)
            //                    {
            //                        await DtmRepositories.ElementPersoRepository.Update(e);
            //                    }
            //                }
            //                else
            //                {
            //                    if (details.Inventaire != null)
            //                    {
            //                        foreach (var inv in details.Inventaire)
            //                        {
            //                            await DtmRepositories.InventaireRepository.Update(inv);
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (details.DemonsPerso != null)
            //                        {
            //                            foreach (var dp in details.DemonsPerso)
            //                            {
            //                                await DtmRepositories.DemonPersoRepository.Update(dp);
            //                            }
            //                        }
            //                        else
            //                        {
            //                            if (details.SkillsPerso != null)
            //                            {
            //                                foreach (var sk in details.SkillsPerso)
            //                                {
            //                                    await DtmRepositories.SkillPersoRepository.Update(sk);
            //                                }
            //                            }
            //                            else
            //                            {
            //                                if (details.Perso.Charac.Lvl == 0 ||
            //                                    !string.IsNullOrWhiteSpace(details.Perso.Charac.Nom) ||
            //                                    !string.IsNullOrWhiteSpace(details.Perso.Charac.Race))
            //                                {
            //                                    return NotFound();
            //                                }
            //                                var persoToUpdate = await DtmRepositories.PersoRepository.GetFullPersoById(idPerso);
            //                                persoToUpdate.Charac.Lvl = details.Perso.Charac.Lvl;
            //                                persoToUpdate.Charac.Nom = details.Perso.Charac.Nom;
            //                                persoToUpdate.Charac.Po = details.Perso.Charac.Po;
            //                                persoToUpdate.Charac.Race = details.Perso.Charac.Race;
            //                                persoToUpdate.Charac.TypePerso = details.Perso.Charac.TypePerso;
            //                                persoToUpdate.Charac.Xp = details.Perso.Charac.Xp;

            //                                //TODO
            //                                //await PersoRepository.Update(persoToUpdate);
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}

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

        [HttpPost]
        public async Task<string> GetDonByLibelle(string libelle)
        {
            if (string.IsNullOrWhiteSpace(libelle))
            {
                return string.Empty;
            }

            var don = await DtmRepositories.DonRepository.GetByLibelle(libelle);

            return don == null ? string.Empty : don.Description;
        }

        [HttpPost]
        public async Task<string> GetPassifDemonByNomDemon(string nom)
        {
            if (string.IsNullOrWhiteSpace(nom))
            {
                return string.Empty;
            }

            var demon = await DtmRepositories.DemonRepository.GetByNom(nom);

            var passifsDemon = demon.PassifDemon.ToArray();
            var libelle = string.Empty;
            var desc = string.Empty;
            var passifDetails = string.Empty;

            for(var i = 0; i < passifsDemon.Length; i++)
            {
                libelle += passifsDemon[i].Passif.Libelle ?? string.Empty;
                desc += string.IsNullOrWhiteSpace(passifsDemon[i].Passif.Description) ? $" : {passifsDemon[i].Passif.Description}" : string.Empty;
                passifDetails = libelle + desc;

                if (i != passifsDemon.Length - 1)
                {
                    passifDetails += "\r";
                }
            }

            return passifDetails;
        }

        [HttpPost]
        public async Task<string> GetElementByLibelle(string libelle)
        {
            if (string.IsNullOrWhiteSpace(libelle))
            {
                return string.Empty;
            }

            var element = await DtmRepositories.ElementRepository.GetByLibelle(libelle);

            return element == null ? string.Empty : element.Description;
        }

        [HttpPost]
        public async Task<string> GetSkillByLibelle(string libelle)
        {
            if (string.IsNullOrWhiteSpace(libelle))
            {
                return string.Empty;
            }

            var skill = await DtmRepositories.SkillRepository.GetByLibelle(libelle);

            return skill == null ? string.Empty : skill.Description;
        }

        [HttpPost]
        public async Task<string> GetItemByLibelle(string libelle)
        {
            if (string.IsNullOrWhiteSpace(libelle))
            {
                return string.Empty;
            }

            var item = await DtmRepositories.ItemRepository.GetByLibelle(libelle);

            return item == null ? string.Empty : item.Description;
        }
    }
}