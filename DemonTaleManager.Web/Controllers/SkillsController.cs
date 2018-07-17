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
    public class SkillsController : DtmControllerBase
    {
        public SkillsController(ILifetimeScope scope) : base(scope)
        {
        }

        public async Task<ActionResult> Index()
        {
            var skills = await SkillRepository.GetAll();
            var propertiesValues = new List<Dictionary<int, List<object>>>();
            foreach (var skill in skills)
            {
                var dico = new Dictionary<int, List<object>>();
                var values = new List<object>{skill.Id, skill.Libelle, skill.Description, skill.Taux, skill.Degats};
                dico.Add(skill.Id, values);
                propertiesValues.Add(dico);
            }
            var entityPropertiesName = new List<string>{ nameof(Skill.Id), nameof(Skill.Libelle), nameof(Skill.Description), nameof(Skill.Taux), nameof(Skill.Degats) };
            var cvm = new CrudViewModel
            {
                EntityType = typeof(Skill),
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
                EntityType = typeof(Skill),
                Entity = new Skill().GetForm()
            });
        }

        [HttpPost]
        public async Task<ActionResult> Create(Skill.SkillForm entity)
        {
            try
            {
                if (!entity.IsAnyNullOrEmpty())
                {
                    await SkillRepository.Insert(new Skill(entity));
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
            var skill = await SkillRepository.GetById(id);
            return View("Crud/Edit" ,new EditViewModel
            {
                EntityType = typeof(Skill),
                Entity = new Skill.SkillForm(skill),
                Id = id
            });
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, Skill.SkillForm entity)
        {
            try
            {
                if (!entity.IsAnyNullOrEmpty())
                {
                    await SkillRepository.Update(new Skill(entity)
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
                    await SkillRepository.DeleteById(id);
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