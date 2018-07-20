using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RpgManager.Ged.Models;

namespace RpgManager.Ged.Contracts
{
    public interface IGedService
    {
        /// <summary>
        /// Enregistrement d'un nouveau fichier depuis un formulaire
        /// </summary>
        /// <param name="file">Nouveau document créé à partir d'un formulaire</param>
        /// <param name="ctk"></param>
        /// <returns>Document</returns>
        Task<GedDocument> Create(ICreateDocumentRequest file, CancellationToken ctk = default(CancellationToken));

        /// <summary>
        /// Recherche tous les documents enregistrés dans la GED
        /// </summary>
        /// <param name="ctk"></param>
        /// <returns>Document</returns>
        Task<IReadOnlyList<GedDocument>> GetAllFiles(CancellationToken ctk = default(CancellationToken));

        /// <summary>
        /// Supprime un document à partir de son ID publique
        /// </summary>
        /// <param name="publicId">ID publique</param>
        /// <param name="ctk"></param>
        /// <returns>Document</returns>
        Task DeleteByPublicId(Guid publicId, CancellationToken ctk = default(CancellationToken));

        /// <summary>
        /// Cherche un document par son ID publique
        /// </summary>
        /// <param name="publicId">ID publique</param>
        /// <param name="ctk"></param>
        /// <returns>Résultat de document, utile surtout pour télécharger</returns>
        Task<GedDocumentResult> FindByPublicId(Guid publicId, CancellationToken ctk = default(CancellationToken));

        /// <summary>
        /// Cherche un document par son ID publique
        /// </summary>
        /// <param name="publicId">ID publique</param>
        /// <param name="ctk"></param>
        /// <returns>Document</returns>
        Task<GedDocument> GetMetadataByPublicId(Guid publicId, CancellationToken ctk = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        GedDocumentResult MakeDocumentResult(GedDocument document);

        /// <summary>
        /// Récupère le type mime du document
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        string GetMimeType(GedDocument document);
    }
}
