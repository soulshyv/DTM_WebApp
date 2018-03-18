using System;
using System.Collections.Generic;

namespace DTM.Core.Models
{
    public partial class Inventaire
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int PersoId { get; set; }
        public int? Quantite { get; set; }

        public Item Item { get; set; }
        public Perso Perso { get; set; }
    }
}
