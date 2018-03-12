using System;
using System.Collections.Generic;

namespace DTM.Core.Models
{
    public partial class Perso
    {
        public Perso()
        {
            Carac = new HashSet<Carac>();
            DemonPerso = new HashSet<DemonPerso>();
            DonPerso = new HashSet<DonPerso>();
            ElementPerso = new HashSet<ElementPerso>();
            Inventaire = new HashSet<Inventaire>();
            Jauge = new HashSet<Jauge>();
            MetierPerso = new HashSet<MetierPerso>();
            PassifPerso = new HashSet<PassifPerso>();
            SkillPerso = new HashSet<SkillPerso>();
            Stat = new HashSet<Stat>();
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public int? Xp { get; set; }
        public int Lvl { get; set; }
        public int? Po { get; set; }
        public string Race { get; set; }
        public int? TypePerso { get; set; }

        public ICollection<Carac> Carac { get; set; }
        public ICollection<DemonPerso> DemonPerso { get; set; }
        public ICollection<DonPerso> DonPerso { get; set; }
        public ICollection<ElementPerso> ElementPerso { get; set; }
        public ICollection<Inventaire> Inventaire { get; set; }
        public ICollection<Jauge> Jauge { get; set; }
        public ICollection<MetierPerso> MetierPerso { get; set; }
        public ICollection<PassifPerso> PassifPerso { get; set; }
        public ICollection<SkillPerso> SkillPerso { get; set; }
        public ICollection<Stat> Stat { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}
