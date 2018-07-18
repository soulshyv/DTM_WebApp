using System.IO;

namespace RpgManager.Ged.Contracts
{
    public interface IHeliumFilesBrowser
    {
        string PathBaseDirectory { get; }
        FileStream SearchFile(string name);
    }
}