using System;
using System.Collections.Generic;

namespace DTM.Core.Models
{
    public partial class Element
    {
        public Element(ElementForm ef)
        {
            Libelle = ef.Libelle;
            Description = ef.Description;
        }

        public ElementForm GetForm()
        {
            return new ElementForm();
        }

        public class ElementForm
        {
            public string Libelle { get; set; }
            public string Description { get; set; }

            public ElementForm()
            {
            }

            public ElementForm(Element e)
            {
                Libelle = e.Libelle;
                Description = e.Description;
            }
        }
    }
}
