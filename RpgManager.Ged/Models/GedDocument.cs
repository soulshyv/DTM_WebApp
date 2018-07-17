using System;

namespace RpgManager.Ged.Models
{
    public class GedDocument
    {
        public int Id { get; set; }
        public Guid? PublicId { get; set; }
        public string FileName { get; set; }
        public int FileSize { get; set; }
        public string FilePath { get; set; }
        public DateTime Created { get; set; }
    }
}