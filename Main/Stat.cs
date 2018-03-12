using System;
using System.Collections.Generic;

namespace Main
{
    public partial class Stat
    {
        public int Id { get; set; }
        public int? PersoId { get; set; }
        public int Phy { get; set; }
        public int Mental { get; set; }
        public int Social { get; set; }

        public Perso Perso { get; set; }
    }
}
