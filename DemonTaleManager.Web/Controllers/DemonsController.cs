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
    public class DemonsController : DtmControllerBase
    {
        public DemonsController(ILifetimeScope scope) : base(scope)
        {
        }

        // GET: Demon
        public async Task<ActionResult> Index()
        {
            var demons = await DemonRepository.GetAll();
            var propertiesValues = new List<Dictionary<int, List<object>>>();
            foreach (var demon in demons)
            {
                var dico = new Dictionary<int, List<object>>();
                var values = new List<object>{demon.Id, demon.Nom};
                dico.Add(demon.Id, values);
                propertiesValues.Add(dico);
            }
            var entityPropertiesName = new List<string>{ nameof(Demon.Id), nameof(Demon.Nom) };
            var cvm = new CrudViewModel
            {
                EntityType = typeof(Demon),
                EntitesPropertiesValues = propertiesValues,
                EntityPropertiesName = entityPropertiesName
            };

            return View("Crud/Index", cvm);
        }

        // GET: Demon/Details/5
        public ActionResult Details(int id)
        {
            return View("Crud/Details");
        }

        // GET: Demon/Create
        public ActionResult Create()
        {
            return View("Crud/Create", new CreateViewModel
            {
                EntityType = typeof(Demon),
                Entity = new Demon().GetForm()
            });
        }

        // POST: Demon/Create
        [HttpPost]
        public async Task<ActionResult> Create(Demon.DemonForm entity)
        {
            try
            {
                if (!entity.IsAnyNullOrEmpty())
                {
                    await DemonRepository.Insert(new Demon(entity));
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Create));
            }
        }

        // GET: Demon/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var demon = await DemonRepository.GetById(id);
            return View("Crud/Edit" ,new EditViewModel
            {
                EntityType = typeof(Demon),
                Entity = new Demon.DemonForm(demon),
                Id = id
            });
        }

        // POST: Demon/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Demon.DemonForm entity)
        {
            try
            {
                if (!entity.IsAnyNullOrEmpty())
                {
                    await DemonRepository.Update(new Demon(entity)
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

        // POST: Demon/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (id != 0)
                {
                    await DemonRepository.DeleteById(id);
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