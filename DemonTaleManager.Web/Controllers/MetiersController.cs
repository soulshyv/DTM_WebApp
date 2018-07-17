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
    public class MetiersController : DtmControllerBase
    {
        public MetiersController(ILifetimeScope scope) : base(scope)
        {
        }

        public async Task<ActionResult> Index()
        {
            var metiers = await MetierRepository.GetAll();
            var propertiesValues = new List<Dictionary<int, List<object>>>();
            foreach (var metier in metiers)
            {
                var dico = new Dictionary<int, List<object>>();
                var values = new List<object>{metier.Id, metier.Libelle, metier.Description};
                dico.Add(metier.Id, values);
                propertiesValues.Add(dico);
            }
            var entityPropertiesName = new List<string>{ nameof(Metier.Id), nameof(Metier.Libelle), nameof(Metier.Description) };
            var cvm = new CrudViewModel
            {
                EntityType = typeof(Metier),
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
                EntityType = typeof(Metier),
                Entity = new Metier().GetForm()
            });
        }

        [HttpPost]
        public async Task<ActionResult> Create(Metier.MetierForm entity)
        {
            try
            {
                if (!entity.IsAnyNullOrEmpty())
                {
                    await MetierRepository.Insert(new Metier(entity));
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
            var metier = await MetierRepository.GetById(id);
            return View("Crud/Edit" ,new EditViewModel
            {
                EntityType = typeof(Metier),
                Entity = new Metier.MetierForm(metier),
                Id = id
            });
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, Metier.MetierForm entity)
        {
            try
            {
                if (!entity.IsAnyNullOrEmpty())
                {
                    await MetierRepository.Update(new Metier(entity)
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
                    await MetierRepository.DeleteById(id);
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