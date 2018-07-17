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
    public class ElementsController : DtmControllerBase
    {
        public ElementsController(ILifetimeScope scope) : base(scope)
        {
        }

        public async Task<ActionResult> Index()
        {
            var elements = await ElementRepository.GetAll();
            var propertiesValues = new List<Dictionary<int, List<object>>>();
            foreach (var element in elements)
            {
                var dico = new Dictionary<int, List<object>>();
                var values = new List<object>{element.Id, element.Libelle, element.Description};
                dico.Add(element.Id, values);
                propertiesValues.Add(dico);
            }
            var entityPropertiesName = new List<string>{ nameof(Element.Id), nameof(Element.Libelle), nameof(Element.Description) };
            var cvm = new CrudViewModel
            {
                EntityType = typeof(Element),
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
        public async Task<ActionResult> Create(Element.ElementForm entity)
        {
            try
            {
                if (!entity.IsAnyNullOrEmpty())
                {
                    await ElementRepository.Insert(new Element(entity));
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
            var element = await ElementRepository.GetById(id);
            return View("Crud/Edit" ,new EditViewModel
            {
                EntityType = typeof(Element),
                Entity = new Element.ElementForm(element),
                Id = id
            });
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, Element.ElementForm entity)
        {
            try
            {
                if (!entity.IsAnyNullOrEmpty())
                {
                    await ElementRepository.Update(new Element(entity)
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
                    await ElementRepository.DeleteById(id);
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