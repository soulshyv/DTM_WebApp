using System;
using System.Collections.Generic;

namespace DTM.Core.Models
{
    public partial class Jauge
    {
        public int Id { get; set; }
        public int? PersoId { get; set; }
        public int? Vie { get; set; }
        public int VieMax { get; set; }
        public int? Psy { get; set; }
        public int PsyMax { get; set; }
        public int? Sync { get; set; }
        public int SyncMax { get; set; }

        public Perso Perso { get; set; }
    }
}
