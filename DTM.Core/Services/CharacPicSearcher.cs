using System.IO;
using System.Linq;
using DTM.DbManager.Contracts;

namespace DTM.DbManager.Services
{
    public class CharacPicSearcher : ICharacPicSearcher
    {
        public CharacPicSearcher(string characPicPath, string characPicPathAlt)
        {
            CharacPicPath = characPicPath;
            CharacPicPathAlt = characPicPathAlt;
        }

        private string CharacPicPath { get; }
        public string CharacPicPathAlt { get; }

        public string GetPicture(string nomPerso, bool displayed = false)
        {
            var files = new DirectoryInfo(CharacPicPath).GetFiles();
            var firstOrDefault = (from file in files where file.Name.Contains(nomPerso) select file.Name).FirstOrDefault();

            if (displayed)
            {
                return CharacPicPathAlt + firstOrDefault;
            }

            return CharacPicPath + firstOrDefault;
        }
    }
}
