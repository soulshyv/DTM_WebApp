using System;
using System.Collections.Generic;

namespace DTM.Core.Models
{
    public partial class Skill
    {
        public Skill(SkillForm sf)
        {
            Libelle = sf.Libelle;
            Description = sf.Description;
            Taux = sf.Taux;
            Degats = sf.Degats;
        }

        public SkillForm GetForm()
        {
            return new SkillForm();
        }

        public class SkillForm
        {
            public string Libelle { get; set; }
            public string Description { get; set; }
            public int? Taux { get; set; }
            public string Degats { get; set; }

            public SkillForm()
            {
            }

            public SkillForm(Skill s)
            {
                Libelle = s.Libelle;
                Description = s.Description;
                Taux = s.Taux;
                Degats = s.Degats;
            }
        }
    }
}
