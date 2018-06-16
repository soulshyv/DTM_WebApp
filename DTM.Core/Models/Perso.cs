using System;
using System.Collections.Generic;

namespace DTM.Core.Models
{
    public partial class Perso
    {
        public Perso()
        {
            DemonPerso = new HashSet<DemonPerso>();
            DonPerso = new HashSet<DonPerso>();
            ElementPerso = new HashSet<ElementPerso>();
            Inventaire = new HashSet<Inventaire>();
            MetierPerso = new HashSet<MetierPerso>();
            PassifPerso = new HashSet<PassifPerso>();
            SkillPerso = new HashSet<SkillPerso>();
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public int? Xp { get; set; }
        public int Lvl { get; set; }
        public int? Po { get; set; }
        public string Race { get; set; }
        public int? TypePerso { get; set; }
        public string Caracs { get; set; }
        public string Jauges { get; set; }
        public string Stats { get; set; }

        public ICollection<DemonPerso> DemonPerso { get; set; }
        public ICollection<DonPerso> DonPerso { get; set; }
        public ICollection<ElementPerso> ElementPerso { get; set; }
        public ICollection<Inventaire> Inventaire { get; set; }
        public ICollection<MetierPerso> MetierPerso { get; set; }
        public ICollection<PassifPerso> PassifPerso { get; set; }
        public ICollection<SkillPerso> SkillPerso { get; set; }
        public ICollection<User> User { get; set; }
    }
}
