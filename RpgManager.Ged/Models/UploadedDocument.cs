using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RpgManager.Ged.Contracts;

namespace RpgManager.Ged.Models
{
    public class UploadedDocument : IDocument
    {
        private readonly IFormFile _file;

        /// <inheritdoc />
        public UploadedDocument(IFormFile file)
        {
            _file = file;
        }

        /// <inheritdoc />
        public string ContentType => _file.ContentType;

        /// <inheritdoc />
        public long Length => _file.Length;

        /// <inheritdoc />
        public string FileName => _file.FileName;

        /// <inheritdoc />
        public bool NeedsLocalCopy => true;

        /// <inheritdoc />
        public Task CopyToAsync(Stream target, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _file.CopyToAsync(target, cancellationToken);
        }
    }
}