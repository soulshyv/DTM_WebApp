using System;
using System.Collections.Generic;

namespace Main
{
    public partial class PassifPerso
    {
        public int Id { get; set; }
        public int PassifId { get; set; }
        public int PersoId { get; set; }

        public Passif Passif { get; set; }
        public Perso Perso { get; set; }
    }
}
