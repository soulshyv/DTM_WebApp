using System;
using System.Collections.Generic;

namespace DTM.Core.Models
{
    public partial class Metier
    {
        public Metier(MetierForm mf)
        {
            Libelle = mf.Libelle;
            Description = mf.Description;
        }

        public MetierForm GetForm()
        {
            return new MetierForm();
        }

        public class MetierForm
        {
            public string Libelle { get; set; }
            public string Description { get; set; }

            public MetierForm()
            {
            }

            public MetierForm(Metier m)
            {
                Libelle = m.Libelle;
                Description = m.Description;
            }
        }
    }
}
