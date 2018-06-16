using System;
using System.Collections.Generic;

namespace DTM.Core.Models
{
    public partial class Metier
    {
        public Metier()
        {
            MetierPerso = new HashSet<MetierPerso>();
        }

        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Description { get; set; }

        public ICollection<MetierPerso> MetierPerso { get; set; }
    }
}
