using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using RpgManager.Ged.Contracts;

namespace RpgManager.Ged.Models
{
    public class CreateDocumentRequest : ICreateDocumentRequest
    {
        /// <inheritdoc />
        public CreateDocumentRequest(IFormFile file) : this(new UploadedDocument(file))
        {
        }

        /// <inheritdoc />
        public CreateDocumentRequest(IDocument document)
        {
            Document = document;
        }

        /// <inheritdoc />
        public Guid Case { get; set; }

        /// <inheritdoc />
        public string FilePath { get; set; } = "/";

        /// <inheritdoc />
        public int? FileType { get; set; }

        /// <inheritdoc />
        public IDocument Document { get; }

        /// <inheritdoc />
        public string RealDirectory { get; }
    }
}