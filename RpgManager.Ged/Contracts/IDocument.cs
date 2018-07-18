using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace RpgManager.Ged.Contracts
{
    public interface IDocument
    {
        /// <summary>
        ///     Le content-type au sens HTTP du document à ajouter dans la GED
        /// </summary>
        string ContentType { get; }

        /// <summary>
        ///     La taille du fichier à ajouter
        /// </summary>
        long Length { get; }

        /// <summary>
        ///     Nom du fichier à ajouter
        /// </summary>
        string FileName { get; }

        /// <summary>
        ///     Copie de façon async le contenu du fichier uploader dans le stream distant
        /// </summary>
        /// <param name="target">Stream vers le quel copier</param>
        /// <param name="cancellationToken"></param>
        Task CopyToAsync(Stream target, CancellationToken cancellationToken = default(CancellationToken));
    }
}