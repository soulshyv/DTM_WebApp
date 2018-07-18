using System.Collections.Generic;
using RpgManager.Ged.Contracts;

namespace RpgManager.Ged.Services
{
    public class DefaultMimeTypeResolver : IMimeTypeResolver
    {
        public static Dictionary<string, string> AllMimeTypes = new Dictionary<string, string>
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