using RpgManager.Ged.Contracts;

namespace RpgManager.Ged.Services
{
    public class GedConfiguration : IGedConfiguration
    {
        public string BaseDirectory { get; set; }
    }
}