using System;
using System.Collections.Generic;
using System.Text;

namespace DTM.Core.Models
{
    public class Charac
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int? Xp { get; set; }
        public int Lvl { get; set; }
        public int? Po { get; set; }
        public string Race { get; set; }
        public int? TypePerso { get; set; }

        public Charac(Perso perso)
        {
            Id = perso.Id;
            Nom = perso.Nom;
            Xp = perso.Xp;
            Lvl = perso.Lvl;
            Po = perso.Po;
            Race = perso.Race;
            TypePerso = perso.TypePerso;
        }
    }
}
