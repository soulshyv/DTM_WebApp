using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using RpgManager.Ged.Models;

namespace DTM.Core.ViewModels
{
    public class GedViewModel
    {
        public IReadOnlyCollection<GedDocument> GedDocList { get; set; }
        public IFormFile File { get; set; }
        public DocumentMetadataDto Meta { get; set; }
        public bool IsDebug { get; set; }
    }
}