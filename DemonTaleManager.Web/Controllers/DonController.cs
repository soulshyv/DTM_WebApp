using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using DemonTaleManager.Web.ViewModels;
using DTM.Core.Extensions;
using DTM.Core.Models;
using DTM.Core.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemonTaleManager.Web.Controllers
{
    public class DonController : DtmControllerBase
    {
        public DonController(ILifetimeScope scope) : base(scope)
        {
        }

        public async Task<ActionResult> Index()
        {
            var dons = await DonRepository.GetAll();
            var propertiesValues = new List<Dictionary<int, List<object>>>();
            foreach (var don in dons)
            {
                var dico = new Dictionary<int, List<object>>();
                var values = new List<object>{don.Id, don.Libelle, don.Description};
                dico.Add(don.Id, values);
                propertiesValues.Add(dico);
            }
            var entityPropertiesName = new List<string>{ nameof(Don.Id), nameof(Don.Libelle), nameof(Don.Description) };
            var cvm = new CrudViewModel
            {
                EntityType = typeof(Don),
                EntitesPropertiesValues = propertiesValues,
                EntityPropertiesName = entityPropertiesName
            };

            return View("Crud/Index", cvm);
        }

        public ActionResult Details(int id)
        {
            return View("Crud/Details");
        }

        public ActionResult Create()
        {
            return View("Crud/Create", new CreateViewModel
            {
                EntityType = typeof(Element),
                Entity = new Element().GetForm()
            });
        }

        [HttpPost]
        public async Task<ActionResult> Create(Don.DonForm entity)
        {
            try
            {
                if (!entity.IsAnyNullOrEmpty())
                {
                    await DonRepository.Insert(new Don(entity));
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Create));
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            var don = await DonRepository.GetById(id);
            return View("Crud/Edit" ,new EditViewModel
            {
                EntityType = typeof(Don),
                Entity = new Don.DonForm(don),
                Id = id
            });
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, Don.DonForm entity)
        {
            try
            {
                if (!entity.IsAnyNullOrEmpty())
                {
                    await DonRepository.Update(new Don(entity)
                    {
                        Id = id
                    });
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Edit));
            }
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (id != 0)
                {
                    await DonRepository.DeleteById(id);
                }
            }
            catch
            {
                // TODO : Ecrire dans le fichier de logs
            }

            return RedirectToAction(nameof(Index));
        }
    }
}