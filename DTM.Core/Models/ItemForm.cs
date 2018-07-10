using System;
using System.Collections.Generic;

namespace DTM.Core.Models
{
    public partial class Item
    {
        public Item(ItemForm i)
        {
            Nom = i.Nom;
            Description = i.Description;
            Commentaire = i.Commentaire;
            Prix = i.Prix;
            TypeItem = i.TypeItem;
        }

        public ItemForm GetForm()
        {
            return new ItemForm();
        }

        public class ItemForm
        {
            public string Nom { get; set; }
            public string Description { get; set; }
            public string Commentaire { get; set; }
            public int? Prix { get; set; }
            public int TypeItem { get; set; }

            public ItemForm()
            {
            }

            public ItemForm(Item i)
            {
                Nom = i.Nom;
                Description = i.Description;
                Commentaire = i.Commentaire;
                Prix = i.Prix;
                TypeItem = i.TypeItem;
            }
        }
    }
}
