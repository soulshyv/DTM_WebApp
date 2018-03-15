using System.Collections.Generic;

namespace DTM.Core.Models
{
    public class CharacterFull
    {
        public CharacterFull(Perso charac,
            Carac caracs,
            Jauge jauges,
            Stat stats,
            List<Element> elements,
            List<Skill> skills,
            List<DonPerso> dons,
            List<Demon> demons,
            Inventaire inventaire)
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

        public CharacterFull(){}

        public Perso Charac;
        public Carac Caracs;
        public Jauge Jauges;
        public Stat Stats;
        public List<Element> Elements;
        public List<Skill> Skills;
        public List<DonPerso> Dons;
        public List<Demon> Demons;
        public Inventaire Inventaire;
        }
}