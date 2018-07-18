using System.Collections.Generic;

namespace RpgManager.Ged.Contracts
{
    public class DefaultMimeTypeResolver
    {
        public Dictionary<string, string> AllMimeTypes;

        public DefaultMimeTypeResolver()
        {
            AllMimeTypes = new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }

        public string GetMimeType(string ext)
        {
            if (string.IsNullOrWhiteSpace(ext))
            {
                throw new System.ArgumentException("Extension is null");
            }

            return AllMimeTypes.ContainsKey(ext) ? AllMimeTypes[ext] : "application/octet-stream";
        }
    }
}