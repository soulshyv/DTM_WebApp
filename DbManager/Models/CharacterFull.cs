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

        private Character Charac { get; set; }
        private Caracs Caracs { get; set; }
        private Jauges Jauges { get; set; }
        private Stats Stats { get; set; }
        private List<Element> Elements { get; set; }
        private List<Skill> Skills { get; set; }
        private List<DonPerso> Dons { get; set; }
        private List<Demon> Demons { get; set; }
        private Inventaire Inventaire { get; set; }
    }
}