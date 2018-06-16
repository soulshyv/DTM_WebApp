using System;
using System.Collections.Generic;

namespace DTM.Core.Models
{
    public partial class DonPerso
    {
        public int Id { get; set; }
        public int DonId { get; set; }
        public int PersoId { get; set; }
        public int Taux { get; set; }

        public Don Don { get; set; }
        public Perso Perso { get; set; }
    }
}
