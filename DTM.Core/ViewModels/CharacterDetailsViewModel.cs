using DTM.Core.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace DTM.Core.ViewModels
{
    public class CharacterDetailsViewModel
    {
        public string CharacterPicture { get; set; }
        public Perso Perso{ get; set; }
        public Carac Caracs { get; set; }
        public Jauge Jauges { get; set; }
        public Stat Stats { get; set; }
        public List<ElementPerso> ElementsPerso { get; set; }
        public List<SkillPerso> SkillsPerso { get; set; }
        public List<DonPerso> DonsPerso { get; set; }
        public List<DemonPerso> DemonsPerso { get; set; }
        public List<Inventaire> Inventaire { get; set; }
        public List<MetierPerso> MetiersPerso { get; set; }
        public List<PassifPerso> PassifsPerso { get; set; }
        public IFormFile UploadedPic { get; set; }
        public IEnumerable<Don> Dons { get; set; }
        public IEnumerable<Element> Elements { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}