using System.Collections.Generic;
using DTM.DbManager.Models;

namespace Main.ViewModels
{
    public class CharactersViewModel
    {
        public List<Character> Characters { get; set; }
        public CharacterFull DetailsPerso { get; set; }
    }
}