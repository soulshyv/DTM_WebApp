using System.Linq;
using RpgManager.Ged.Contracts;

namespace RpgManager.Ged.Services
{
    public class FileExtensionValidator : IFileExtensionValidator
    {
        private static readonly string[] ExtUnauthorized = { ".exe", ".bat" };

        public bool IsAuthorized(string ext)
        {
            if (string.IsNullOrWhiteSpace(ext) || ext == string.Empty)
            {
                throw new System.ArgumentException("Extension is null");
            }

            return !ExtUnauthorized.Contains(ext);
        }
    }
}