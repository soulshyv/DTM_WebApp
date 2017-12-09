using System.Collections.Generic;
using DTM.DbManager.Models;

namespace DTM.DbManager.ViewModels
{
    public class CharactersViewModel
    {
        public List<Character> Characters { get; set; }
        public CharacterFull DetailsPerso { get; set; }
    }
}