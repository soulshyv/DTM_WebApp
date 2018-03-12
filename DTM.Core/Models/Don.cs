using System;
using System.Collections.Generic;

namespace DTM.Core.Models
{
    public partial class Don
    {
        public Don()
        {
            DonPerso = new HashSet<DonPerso>();
        }

        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Description { get; set; }

        public ICollection<DonPerso> DonPerso { get; set; }
    }
}
