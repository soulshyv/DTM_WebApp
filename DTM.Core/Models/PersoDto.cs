using System.Collections.Generic;
using Newtonsoft.Json;

namespace DTM.Core.Models
{
    public class PersoDto
    {
        public PersoDto(Charac charac,
            string caracs,
            string jauges,
            string stats,
            List<ElementPerso> elements,
            List<SkillPerso> skills,
            List<DonPerso> dons,
            List<DemonPerso> demons,
            List<Inventaire> inventaire,
            List<MetierPerso> metiers,
            List<PassifPerso> passifs)
        {
            Charac = charac;
            Caracs = caracs != null ? JsonConvert.DeserializeObject<Carac>(caracs) : new Carac();
            Jauges = jauges != null ? JsonConvert.DeserializeObject<Jauge>(jauges) : new Jauge();
            Stats = stats != null ? JsonConvert.DeserializeObject<Stat>(stats) : new Stat();
            Elements = elements;
            Skills = skills;
            Dons = dons;
            Demons = demons;
            Inventaire = inventaire;
            Metiers = metiers;
            Passifs = passifs;
        }

        public PersoDto(){}

        public Charac Charac { get; set; }
        public Carac Caracs { get; set; }
        public Jauge Jauges { get; set; }
        public Stat Stats { get; set; }
        public List<ElementPerso> Elements { get; set; }
        public List<SkillPerso> Skills { get; set; }
        public List<DonPerso> Dons { get; set; }
        public List<DemonPerso> Demons { get; set; }
        public List<Inventaire> Inventaire { get; set; }
        public List<MetierPerso> Metiers { get; set; }
        public List<PassifPerso> Passifs { get; set; }
    }
}