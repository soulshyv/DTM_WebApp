using System.IO;

namespace RpgManager.Ged.Contracts
{
    public interface IFilesBrowser
    {
        string PathBaseDirectory { get; }
        FileStream SearchFile(string name);
    }
}