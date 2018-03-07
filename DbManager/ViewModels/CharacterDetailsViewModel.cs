using System.Collections.Generic;
using DTM.DbManager.Models;
using Microsoft.AspNetCore.Http;

namespace DTM.DbManager.ViewModels
{
    public class CharacterDetailsViewModel
    {
        public CharacterFull DetailsPerso { get; set; }
        public string CharacterPicture { get; set; }
        public Character Charac { get; set; }
        public Caracs Caracs { get; set; }
        public Jauges Jauges { get; set; }
        public Stats Stats { get; set; }
        public List<Element> Elements { get; set; }
        public List<Skill> Skills { get; set; }
        public List<DonPerso> Dons { get; set; }
        public List<Demon> Demons { get; set; }
        public Inventaire Inventaire { get; set; }
        public IFormFile UploadedPic { get; set; }
        public string NomPerso { get; set; }
    }
}