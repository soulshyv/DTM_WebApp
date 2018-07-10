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
    public class ItemController : DtmControllerBase
    {
        public ItemController(ILifetimeScope scope) : base(scope)
        {
        }

        public async Task<ActionResult> Index()
        {
            var items = await ItemRepository.GetAll();
            var ivm = new ItemViewModel
            {
                Items = items
            };

            return View("Index", ivm);
        }

        public ActionResult Details(int id)
        {
            return View("Details");
        }

        public ActionResult Create()
        {
            return View("Create", new ItemViewModel
            {
                Item = new Item().GetForm()
            });
        }

        [HttpPost]
        public async Task<ActionResult> Create(Item.ItemForm entity)
        {
            try
            {
                if (!entity.IsAnyNullOrEmpty())
                {
                    await ItemRepository.Insert(new Item(entity));
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
            var item = await ItemRepository.GetById(id);
            return View("Edit" ,new ItemViewModel
            {
                Item = new Item.ItemForm(item)
            });
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, Item.ItemForm entity)
        {
            try
            {
                if (!entity.IsAnyNullOrEmpty())
                {
                    await ItemRepository.Update(new Item(entity)
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
                    await ItemRepository.DeleteById(id);
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