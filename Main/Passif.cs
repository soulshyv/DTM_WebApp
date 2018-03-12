using System;
using System.Collections.Generic;

namespace Main
{
    public partial class Passif
    {
        public Passif()
        {
            PassifDemon = new HashSet<PassifDemon>();
            PassifPerso = new HashSet<PassifPerso>();
        }

        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Description { get; set; }

        public ICollection<PassifDemon> PassifDemon { get; set; }
        public ICollection<PassifPerso> PassifPerso { get; set; }
    }
}
