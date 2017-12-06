using System.Collections.Generic;

namespace DTM.DbManager.Models
{
    public class CharacterFull
    {
        public CharacterFull(Character charac,
            CaracsPerso caracs,
            JaugesPerso jauges,
            StatsPerso stats,
            List<Element> elements,
            List<Skill> skills,
            List<Don> dons,
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
        private CaracsPerso Caracs { get; set; }
        private JaugesPerso Jauges { get; set; }
        private StatsPerso Stats { get; set; }
        private List<Element> Elements { get; set; }
        private List<Skill> Skills { get; set; }
        private List<Don> Dons { get; set; }
        private List<Demon> Demons { get; set; }
        private Inventaire Inventaire { get; set; }
    }
}