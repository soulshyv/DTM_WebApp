using System.Collections.Generic;
using DTM.Core.Models;
using Microsoft.AspNetCore.Http;

namespace DTM.Core.ViewModels
{
    public class CharacterDetailsViewModel
    {
        public string CharacterPicture { get; set; }
        public Perso Perso{ get; set; }
        public Carac Caracs { get; set; }
        public Jauge Jauges { get; set; }
        public Stat Stats { get; set; }
        public List<ElementPerso> Elements { get; set; }
        public List<SkillPerso> Skills { get; set; }
        public List<DonPerso> DonsPerso { get; set; }
        public List<DemonPerso> DemonsPerso { get; set; }
        public Inventaire Inventaire { get; set; }
        public IFormFile UploadedPic { get; set; }
    }
}