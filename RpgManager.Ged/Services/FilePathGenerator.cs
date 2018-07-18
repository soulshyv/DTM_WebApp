using RpgManager.Ged.Contracts;
using System;
using System.IO;
using System.Linq;

namespace RpgManager.Ged.Services
{
    public class FilePathGenerator : IFilePathGenerator
    {
        public FilePathGenerator(string baseDirectory)
        {
            BaseDirectory = baseDirectory;
        }

        /// <inheritdoc />
        public FilePathGenerator(IGedConfiguration configuration)
        {
            BaseDirectory = configuration.BaseDirectory;
        }

        public string BaseDirectory { get; }

        public string Generate(string realDirectory, string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentException("File name is null");
            }

            if (Path.GetExtension(filename) == string.Empty)
            {
                throw new ArgumentException("File name incorrect");
            }

            realDirectory = realDirectory ?? "";

            var dirParts = realDirectory
                .Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            dirParts.Insert(0, BaseDirectory);

            return Path.Combine(
                Path.Combine(dirParts.ToArray()),
                Guid.NewGuid() + Path.GetExtension(filename)
            );
        }
    }
}