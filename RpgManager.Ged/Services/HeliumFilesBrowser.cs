using System.IO;
using RpgManager.Ged.Contracts;

namespace RpgManager.Ged.Services
{
    public class HeliumFilesBrowser : IHeliumFilesBrowser
    {
        public HeliumFilesBrowser(string pathBaseDirectory)
        {
            PathBaseDirectory = pathBaseDirectory;

            /* Liaison à l'arborescence */
        }

        public string PathBaseDirectory { get; }
        private string Filtre { get; set; }

        public FileStream SearchFile(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new System.ArgumentException("File name is null or empty");
            }

            var res = RechercheInterne(name, PathBaseDirectory);

            return res != null ? new FileStream(res, FileMode.Open) : null;
        }
        /*
        public DirectoryInfo SearchDir(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new System.ArgumentException("File name is null or empty");
            }

            var res = RechercheInterne(name, PathBaseDirectory);
            if (res != null)
                return new DirectoryInfo(res);

            return null;
        }
        */
        private string RechercheInterne(string nameSearched, string dirPath)
        {
            foreach (var f in new DirectoryInfo(dirPath).GetFiles())
            {
                if (f.Name == nameSearched)
                    return f.FullName;
            }

            foreach (var d in Directory.GetDirectories(dirPath))
            {
                var dir = new DirectoryInfo(d);
                if (dir.Name == nameSearched)
                    return dir.FullName;

                foreach (var f in dir.GetFiles())
                {
                    if (f.Name == nameSearched)
                        return f.FullName;
                }

                var res = RechercheInterne(nameSearched, d);
                if (res != null)
                    return res;
            }

            return null;
        }
    }
}