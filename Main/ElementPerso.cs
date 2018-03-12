using System;
using System.Collections.Generic;

namespace Main
{
    public partial class ElementPerso
    {
        public int Id { get; set; }
        public int ElementId { get; set; }
        public int PersoId { get; set; }

        public Element Element { get; set; }
        public Perso Perso { get; set; }
    }
}
