using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RpgManager.Ged.Models;

namespace RpgManager.Ged.Contracts
{
    public interface IGedDocumentRepository
    {
        // CRUD
        Task<GedDocument> Create(GedDocument file, CancellationToken ctk = default(CancellationToken));
        Task Delete(GedDocument file, CancellationToken ctk = default(CancellationToken));
        Task<GedDocument> Update(GedDocument file, CancellationToken ctk = default(CancellationToken));

        // Recherche
        Task<IReadOnlyList<GedDocument>> GetAllFiles(CancellationToken ctk = default(CancellationToken));
        Task<IReadOnlyList<GedDocument>> GetAllFilesByPublicIds(IEnumerable<Guid> ids, CancellationToken ctk = default(CancellationToken));

        // Chargement unitaire
        Task<GedDocument> GetById(int id, CancellationToken ctk = default(CancellationToken));
        Task<GedDocument> GetByPublicId(Guid? publicId, CancellationToken ctk = default(CancellationToken));
        Task<GedDocument> GetByName(string fileName, CancellationToken ctk);
    }
}