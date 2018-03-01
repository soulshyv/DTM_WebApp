using System.IO;
using System.Linq;
using DTM.DbManager.Contracts;

namespace DTM.DbManager.Services
{
    public class CharacPicSearcher : ICharacPicSearcher
    {
        public CharacPicSearcher(string path)
        {
            Path = path;
        }

        private string Path { get; }

        public string GetPicture(string nomPerso)
        {
            var files = new DirectoryInfo(Path).GetFiles();
            var firstOrDefault = (from file in files where file.Name.Contains(nomPerso) select file.Name).FirstOrDefault();
            return Path + firstOrDefault;
        }
    }
}
