using System.Collections.Generic;
using DTM.Core.Models;
using DTM.DbManager.Models;
using Microsoft.AspNetCore.Http;
using Demon = DTM.DbManager.Models.Demon;
using DonPerso = DTM.DbManager.Models.DonPerso;
using Element = DTM.DbManager.Models.Element;
using Inventaire = DTM.DbManager.Models.Inventaire;
using Skill = DTM.DbManager.Models.Skill;

namespace DTM.DbManager.ViewModels
{
    public class CharacterDetailsViewModel
    {
        public Perso DetailsPerso { get; set; }
        public string CharacterPicture { get; set; }
        public Perso Perso{ get; set; }
        public Carac Caracs { get; set; }
        public Jauge Jauges { get; set; }
        public Stat Stats { get; set; }
        public List<Element> Elements { get; set; }
        public List<Skill> Skills { get; set; }
        public List<DonPerso> Dons { get; set; }
        public List<Demon> Demons { get; set; }
        public Inventaire Inventaire { get; set; }
        public IFormFile UploadedPic { get; set; }
        public string NomPerso { get; set; }
    }
}