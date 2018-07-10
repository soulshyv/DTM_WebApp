using System;
using System.Collections.Generic;

namespace DTM.Core.Models
{
    public partial class Don
    {
        public Don(DonForm df)
        {
            Libelle = df.Libelle;
            Description = df.Description;
        }

        public DonForm GetForm()
        {
            return new DonForm();
        }

        public class DonForm
        {
            public string Libelle { get; set; }
            public string Description { get; set; }

            public DonForm()
            {
            }

            public DonForm(Don df)
            {
                Libelle = df.Libelle;
                Description = df.Description;
            }
        }
    }
}
