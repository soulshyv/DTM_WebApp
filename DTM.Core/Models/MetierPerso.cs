using System;
using System.Collections.Generic;

namespace DTM.Core.Models
{
    public partial class MetierPerso
    {
        public int Id { get; set; }
        public int MetierId { get; set; }
        public int PersoId { get; set; }
        public int? Lvl { get; set; }

        public Metier Metier { get; set; }
        public Perso Perso { get; set; }
    }
}
