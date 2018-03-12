using System;
using System.Collections.Generic;

namespace DTM.Core.Models
{
    public partial class Item
    {
        public Item()
        {
            Inventaire = new HashSet<Inventaire>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public int TypeItem { get; set; }
        public int? Prix { get; set; }
        public string Commentaire { get; set; }
        public int? Quantite { get; set; }

        public ICollection<Inventaire> Inventaire { get; set; }
    }
}
