using System;
using System.Collections.Generic;

namespace Main
{
    public partial class DemonPerso
    {
        public int Id { get; set; }
        public int DemonId { get; set; }
        public int PersoId { get; set; }

        public Demon Demon { get; set; }
        public Perso Perso { get; set; }
    }
}
