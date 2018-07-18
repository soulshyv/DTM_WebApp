using System;
using System.Collections.Generic;
using System.Text;

namespace RpgManager.Ged.Contracts
{
    public interface IFilePathGenerator
    {
        string Generate(string realDirectory, string filename);
    }
}
