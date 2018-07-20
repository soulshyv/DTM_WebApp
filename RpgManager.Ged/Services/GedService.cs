using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using RpgManager.Ged.Contracts;
using RpgManager.Ged.Exceptions;
using RpgManager.Ged.Models;

namespace RpgManager.Ged.Services
{
    public class GedService : IGedService
    {
        public GedService(
            IGedDocumentRepository repo,
            IMimeTypeResolver mimeType,
            IFileExtensionValidator extValid,
            IFilePathGenerator filePathGene
        )
        {
            GedDocRepo = repo;
            Mime = mimeType;
            ExtValid = extValid;
            FilePathGene = filePathGene;
        }

        protected IGedDocumentRepository GedDocRepo { get; }
        protected IMimeTypeResolver Mime { get; }
        protected IFileExtensionValidator ExtValid { get; }
        protected IFilePathGenerator FilePathGene { get; }

        /// <inheritdoc/>
        public async Task<GedDocument> Create(ICreateDocumentRequest request,
            CancellationToken ctk = default(CancellationToken))
        {
            // Vérifie que l'extension est valide
            if (request == null)
            {
                throw new ArgumentException("Aucune requête n'a été reçue");
            }

            var document = request.Document;

            if (ExtValid.IsAuthorized(Path.GetExtension(document.FileName)) == false)
            {
                throw new InvalidFileExtensionException("Extension de fichier non autorisée");
            }

            var fileName = Path.GetFileName(document.FileName);
            var finalPath = FilePathGene.Generate(request.RealDirectory, fileName);

            var gedDoc = new GedDocument
            {
                PublicId = Guid.NewGuid(),
                FileName = fileName,
                FilePath = finalPath,
                FileSize = document.Length,
                Created = DateTime.Now
            };

            var directoryName = Path.GetDirectoryName(finalPath);

            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }

            //Enregistrement sur le disque
            using (var stream = File.OpenWrite(gedDoc.FilePath))
            {
                await document.CopyToAsync(stream, ctk).ConfigureAwait(false);
            }

            //Enregistrer en bd
            gedDoc = await GedDocRepo.Create(gedDoc, ctk).ConfigureAwait(false);

            return gedDoc;
        }

        public async Task<IReadOnlyList<GedDocument>> GetAllFiles(CancellationToken ctk = default(CancellationToken))
        {
            return await GedDocRepo.GetAllFiles(ctk);
        }

        /// <inheritdoc/>
        public async Task<GedDocumentResult> FindByPublicId(Guid publicId,
            CancellationToken ctk = default(CancellationToken))
        {
            if (publicId == Guid.Empty)
            {
                throw new ArgumentException("PublicId is null");
            }

            //Récupérer le fichier
            var fileToDl = await GedDocRepo.GetByPublicId(publicId, ctk);

            if (fileToDl == null)
            {
                return null;
            }

            return MakeDocumentResult(fileToDl);
        }

        /// <inheritdoc/>
        public async Task<GedDocument> GetMetadataByPublicId(Guid publicId,
            CancellationToken ctk = default(CancellationToken))
        {
            if (publicId == Guid.Empty)
            {
                throw new ArgumentException("PublicId is null");
            }

            return await GedDocRepo.GetByPublicId(publicId, ctk);
        }

        /// <inheritdoc/>
        public async Task DeleteByPublicId(Guid publicId,
            CancellationToken ctk = default(CancellationToken))
        {
            if (publicId == Guid.Empty)
            {
                throw new ArgumentException("PublicId is null");
            }

            var fileToDel = await GedDocRepo.GetByPublicId(publicId, ctk).ConfigureAwait(false);

            if (fileToDel != null)
            {
                // Suppression en bd
                await GedDocRepo.Delete(fileToDel, ctk);
            }
        }

        /// <inheritdoc/>
        public GedDocumentResult MakeDocumentResult(GedDocument document)
        {
            //Renvoyer le fichier
            var stream = File.OpenRead(document.FilePath);

            return new GedDocumentResult(stream, GetMimeType(document), document.FileName);
        }

        /// <inheritdoc/>
        public string GetMimeType(GedDocument document)
        {
            var ext = Path.GetExtension(document.FilePath);

            return Mime.GetMimeType(ext);
        }
    }
}