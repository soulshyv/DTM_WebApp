using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RpgManager.Ged.Models
{
    public class GedDocumentResult
    {
        public GedDocumentResult(FileStream stream, string mimeType, string fileName)
        {
            Stream = stream;
            MimeType = mimeType;
            FileName = fileName;
        }

        public FileStream Stream { get; }
        public string MimeType { get; }
        public string FileName { get; }
    }
}
