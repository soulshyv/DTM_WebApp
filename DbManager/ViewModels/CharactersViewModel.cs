using System.Collections.Generic;
using DTM.Core.Models;
using DTM.DbManager.Models;

namespace DTM.DbManager.ViewModels
{
    public class CharactersViewModel
    {
        public IEnumerable<Perso> Persos { get; set; }
    }
}