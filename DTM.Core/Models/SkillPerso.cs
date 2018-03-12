using System;
using System.Collections.Generic;

namespace DTM.Core.Models
{
    public partial class SkillPerso
    {
        public int Id { get; set; }
        public int SkillId { get; set; }
        public int PersoId { get; set; }

        public Perso Perso { get; set; }
        public Skill Skill { get; set; }
    }
}
