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
    public class PassifController : DtmControllerBase
    {
        public PassifController(ILifetimeScope scope) : base(scope)
        {
        }

        public async Task<ActionResult> Index()
        {
            var passifs = await PassifRepository.GetAll();
            var propertiesValues = new List<Dictionary<int, List<object>>>();
            foreach (var passif in passifs)
            {
                var dico = new Dictionary<int, List<object>>();
                var values = new List<object>{passif.Id, passif.Libelle, passif.Description};
                dico.Add(passif.Id, values);
                propertiesValues.Add(dico);
            }
            var entityPropertiesName = new List<string>{ nameof(Passif.Id), nameof(Passif.Libelle), nameof(Passif.Description) };
            var cvm = new CrudViewModel
            {
                EntityType = typeof(Passif),
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
                EntityType = typeof(Passif),
                Entity = new Passif().GetForm()
            });
        }

        [HttpPost]
        public async Task<ActionResult> Create(Passif.PassifForm entity)
        {
            try
            {
                if (!entity.IsAnyNullOrEmpty())
                {
                    await PassifRepository.Insert(new Passif(entity));
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
            var passif = await PassifRepository.GetById(id);
            return View("Crud/Edit" ,new EditViewModel
            {
                EntityType = typeof(Metier),
                Entity = new Passif.PassifForm(passif),
                Id = id
            });
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, Passif.PassifForm entity)
        {
            try
            {
                if (!entity.IsAnyNullOrEmpty())
                {
                    await PassifRepository.Update(new Passif(entity)
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
                    await PassifRepository.DeleteById(id);
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