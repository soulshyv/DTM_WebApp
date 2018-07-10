using System;
using System.Collections.Generic;

namespace DTM.Core.Models
{
    public partial class Passif
    {
        public Passif(PassifForm pf)
        {
            Libelle = pf.Libelle;
            Description = pf.Description;
        }

        public PassifForm GetForm()
        {
            return new PassifForm();
        }

        public class PassifForm
        {
            public string Libelle { get; set; }
            public string Description { get; set; }

            public PassifForm()
            {
            }

            public PassifForm(Passif p)
            {
                Libelle = p.Libelle;
                Description = p.Description;
            }
        }
    }
}
