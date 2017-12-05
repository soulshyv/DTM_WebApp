using System.Collections.Generic;

namespace DTM.DbManager.Models
{
    public class CharacterFull
    {
        public string NomPerso { get; set; }
        public int Xp { get; set; }
        public int Lvl { get; set; }
        public int Po { get; set; }
        public string Race { get; set; }
        public string TypePerso { get; set; }
        public int Attaque { get; set; }
        public int Defense { get; set; }
        public int Rapidite { get; set; }
        public int Pv { get; set; }
        public int PvMax { get; set; }
        public int Psy { get; set; }
        public int PsyMax { get; set; }
        public int Synchro { get; set; }
        public int SynchroMax { get; set; }
        public int Physique { get; set; }
        public int Mental { get; set; }
        public int Social { get; set; }
        public List<Element> Elements;
    }
}
