using System;
using System.Collections.Generic;

namespace DTM.Core.Models
{
    public partial class Demon
    {
        public Demon()
        {
            DemonPerso = new HashSet<DemonPerso>();
            PassifDemon = new HashSet<PassifDemon>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }

        public ICollection<DemonPerso> DemonPerso { get; set; }
        public ICollection<PassifDemon> PassifDemon { get; set; }
    }
}
