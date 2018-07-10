using System.Collections.Generic;
using DTM.Core.Models;

namespace DemonTaleManager.Web.ViewModels
{
    public class ItemViewModel
    {
        public IEnumerable<Item> Items { get; set; }
        public Item.ItemForm Item { get; set; }
    }
}