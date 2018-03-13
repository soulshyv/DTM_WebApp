using System.Collections.Generic;

namespace DTM.DbManager.Models
{
    public class CharacterFull
    {
        public CharacterFull(Character charac,
            Caracs caracs,
            Jauges jauges,
            Stats stats,
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

        public Character Charac;
        public Caracs Caracs;
        public Jauges Jauges;
        public Stats Stats;
        public List<Element> Elements;
        public List<Skill> Skills;
        public List<DonPerso> Dons;
        public List<Demon> Demons;
        public Inventaire Inventaire;
        }
}