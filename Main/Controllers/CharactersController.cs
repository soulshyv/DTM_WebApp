using Autofac;
using DTM.Core.Extensions;
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
using DTM.Core.Models;

namespace DemonTaleManager.Web.Controllers
{
    public class CharactersController : Controller/* : DtmControllerBase*/
    {
        public CharactersController(ILifetimeScope scope, CaracRepository carac)/* : base(scope)*/
        {
            Scope = scope;
            CaracRepository = carac;
        }

        private ICharacPicSearcher _characPicSearcher;
        protected ICharacPicSearcher CharacPicSearcher => _characPicSearcher ?? (_characPicSearcher = Scope.Resolve<ICharacPicSearcher>());

        private DtmRepositories _dtmRepositories;
        protected DtmRepositories DtmRepositories => _dtmRepositories ?? (_dtmRepositories = Scope.Resolve<DtmRepositories>());

        private IHostingEnvironment _hostingEnv;
        protected IHostingEnvironment HostingEnv => _hostingEnv ?? (_hostingEnv = Scope.Resolve<IHostingEnvironment>());

        public ILifetimeScope Scope { get; }

        //private CaracRepository _caracRepository;
        //public CaracRepository CaracRepository => _caracRepository ?? (_caracRepository = Scope.Resolve<CaracRepository>());

        private CaracRepository CaracRepository { get; }

        private DemonRepository _demonRepository;
        public DemonRepository DemonRepository => _demonRepository ?? (_demonRepository = Scope.Resolve<DemonRepository>());

        private DemonPersoRepository _demonPersoRepository;
        public DemonPersoRepository DemonPersoRepository => _demonPersoRepository ?? (_demonPersoRepository = Scope.Resolve<DemonPersoRepository>());

        private DonRepository _donRepository;
        public DonRepository DonRepository => _donRepository ?? (_donRepository = Scope.Resolve<DonRepository>());

        private DonPersoRepository _donPersoRepository;
        public DonPersoRepository DonPersoRepository => _donPersoRepository ?? (_donPersoRepository = Scope.Resolve<DonPersoRepository>());

        private ElementRepository _elementRepository;
        public ElementRepository ElementRepository => _elementRepository ?? (_elementRepository = Scope.Resolve<ElementRepository>());

        private ElementPersoRepository _elementPersoRepository;
        public ElementPersoRepository ElementPersoRepository => _elementPersoRepository ?? (_elementPersoRepository = Scope.Resolve<ElementPersoRepository>());

        private InventaireRepository _inventaireRepository;
        public InventaireRepository InventaireRepository => _inventaireRepository ?? (_inventaireRepository = Scope.Resolve<InventaireRepository>());

        private ItemRepository _itemRepository;
        public ItemRepository ItemRepository => _itemRepository ?? (_itemRepository = Scope.Resolve<ItemRepository>());

        private JaugeRepository _jaugeRepository;
        public JaugeRepository JaugeRepository => _jaugeRepository ?? (_jaugeRepository = Scope.Resolve<JaugeRepository>());

        private MetierRepository _metierRepository;
        public MetierRepository MetierRepository => _metierRepository ?? (_metierRepository = Scope.Resolve<MetierRepository>());

        private MetierPersoRepository _metierPersoRepository;
        public MetierPersoRepository MetierPersoRepository => _metierPersoRepository ?? (_metierPersoRepository = Scope.Resolve<MetierPersoRepository>());

        private PassifRepository _passifcRepository;
        public PassifRepository PassifRepository => _passifcRepository ?? (_passifcRepository = Scope.Resolve<PassifRepository>());

        private PassifPersoRepository _passifPersoRepository;
        public PassifPersoRepository PassifPersoRepository => _passifPersoRepository ?? (_passifPersoRepository = Scope.Resolve<PassifPersoRepository>());

        private PassifDemonRepository _passifDemonRepository;
        public PassifDemonRepository PassifDemonRepository => _passifDemonRepository ?? (_passifDemonRepository = Scope.Resolve<PassifDemonRepository>());

        private PersoRepository _persoRepository;
        public PersoRepository PersoRepository => _persoRepository ?? (_persoRepository = Scope.Resolve<PersoRepository>());

        private SkillRepository _skillRepository;
        public SkillRepository SkillRepository => _skillRepository ?? (_skillRepository = Scope.Resolve<SkillRepository>());

        private SkillPersoRepository _skillPersoRepository;
        public SkillPersoRepository SkillPersoRepository => _skillPersoRepository ?? (_skillPersoRepository = Scope.Resolve<SkillPersoRepository>());

        private StatRepository _statRepository;
        public StatRepository StatRepository => _statRepository ?? (_statRepository = Scope.Resolve<StatRepository>());

        private UserRepository _userRepository;
        public UserRepository UserRepository => _userRepository ?? (_userRepository = Scope.Resolve<UserRepository>());

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allPersos = await /*DtmRepositories.*/PersoRepository.GetAll();

            if (allPersos != null)
                return View(new CharactersViewModel
                {
                    Persos = allPersos
                });

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetDetails(int idPerso)
        {
            Perso perso;
            try
            {
                //var perso = await DtmRepositories.PersoRepository.GetFullPersoById(idPerso);
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