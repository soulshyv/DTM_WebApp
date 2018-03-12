using System;
using System.Collections.Generic;

namespace Main
{
    public partial class Element
    {
        public Element()
        {
            ElementPerso = new HashSet<ElementPerso>();
        }

        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Description { get; set; }

        public ICollection<ElementPerso> ElementPerso { get; set; }
    }
}
