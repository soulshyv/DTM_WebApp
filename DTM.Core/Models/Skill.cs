using System;
using System.Collections.Generic;

namespace DTM.Core.Models
{
    public partial class Skill
    {
        public Skill()
        {
            SkillPerso = new HashSet<SkillPerso>();
        }

        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Description { get; set; }
        public int? Taux { get; set; }
        public string Degats { get; set; }

        public ICollection<SkillPerso> SkillPerso { get; set; }
    }
}
