using System;
using System.Collections.Generic;

namespace DTM.Core.Models
{
    public partial class Carac
    {
        public int Id { get; set; }
        public int? PersoId { get; set; }
        public int? Atk { get; set; }
        public int? Def { get; set; }
        public int? Rap { get; set; }

        public Perso Perso { get; set; }
    }
}
