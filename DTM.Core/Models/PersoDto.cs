using System.Collections.Generic;

namespace DTM.Core.Models
{
    public class PersoDto
    {
        public PersoDto(Perso charac,
            Carac caracs,
            Jauge jauges,
            Stat stats,
            List<ElementPerso> elements,
            List<SkillPerso> skills,
            List<DonPerso> dons,
            List<DemonPerso> demons,
            List<Inventaire> inventaire)
        {
            Charac = charac;
            Caracs = caracs;
            Jauges = jauges;
            Stats = stats;
            Elements = elements;
            Skills = skills;
            Dons = dons;
            Demons = demons;
            Inventaire = inventaire;
        }

        public PersoDto(){}

        public Perso Charac;
        public Carac Caracs;
        public Jauge Jauges;
        public Stat Stats;
        public List<ElementPerso> Elements;
        public List<SkillPerso> Skills;
        public List<DonPerso> Dons;
        public List<DemonPerso> Demons;
        public List<Inventaire> Inventaire;
        public List<MetierPerso> Metiers;
        public List<PassifPerso> Passifs;
    }
}