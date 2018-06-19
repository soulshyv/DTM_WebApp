using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using DemonTaleManager.Web.ViewModels;
using DTM.Core.Models;
using DTM.Core.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemonTaleManager.Web.Controllers
{
    public class DemonController : DtmControllerBase
    {
        public DemonController(ILifetimeScope scope) : base(scope)
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
            return View("Crud/Create", new CrudCreateViewModel
            {
                EntityType = typeof(Demon),
                Entity = new Demon().GetForm()
            });
        }

        // POST: Demon/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Demon.DemonForm df)
        {
            try
            {
                if (df != null)
                {
                    await DemonRepository.Insert(new Demon(df));
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Crud/Create");
            }
        }

        // GET: Demon/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Demon/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Demon/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Demon/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}