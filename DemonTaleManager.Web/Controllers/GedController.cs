using System.Threading.Tasks;
using Autofac;
using DTM.Core.Mvc;
using DTM.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using RpgManager.Ged.Contracts;
using RpgManager.Ged.Models;

namespace DemonTaleManager.Web.Controllers
{
    public class GedController : DtmControllerBase
    {
        public GedController(ILifetimeScope scope) : base(scope)
        {
        }

        private IGedService GedService => Scope.Resolve<IGedService>();

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var files = await GedService.GetAllFiles();

            return View(new GedViewModel
            {
                GedDocList = files
            });
        }

        [HttpPost]
        public IActionResult Index(GedViewModel gvm)
        {
            return View();
        }

        public IActionResult RechercheGed()
        {
            throw new System.NotImplementedException();
        }

        public IActionResult DownloadFile()
        {
            throw new System.NotImplementedException();
        }

        public IActionResult SuppressFile()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IActionResult> AddFiles(GedViewModel gvm)
        {
            if (gvm.File != null)
            {
                var doc = new CreateDocumentRequest(gvm.File)
                {
                    RealDirectory = gvm.Meta.RealDirectory
                };

                await GedService.Create(doc);
            }

            return RedirectToAction("Index");
        }
    }
}