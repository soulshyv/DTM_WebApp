using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using RpgManager.Ged.Contracts;
using RpgManager.Ged.Models;

namespace RpgManager.Ged.Repositories
{
    public class MySqlGedDocumentRepository : IGedDocumentRepository
    {
        private const string BaseSelectQuery = @"
                                           SELECT
                                            g.ID,
                                            g.Public_Id AS PublicId,
                                            g.File_Name AS FileName,
                                            g.File_Path AS FilePath,
                                            g.File_Size AS FileSize,
                                            g.Created
                                           FROM Ged g ";

        public MySqlGedDocumentRepository(IDbConnection sql)
        {
            DbConnection = sql;
        }

        private IDbConnection DbConnection { get; }

        public async Task<GedDocument> Create(GedDocument file,
            CancellationToken ctk = default(CancellationToken))
        {
            var dp = new DynamicParameters(new
            {
                publicId = file.PublicId,
                filename = file.FileName,
                filepath = file.FilePath,
                fileSize = file.FileSize,
                created = file.Created
            });

            var cd = new CommandDefinition(@"
                            INSERT INTO Ged
                            (
                              Public_Id,
                              File_Name,
                              File_Path,
                              File_Size,
                              Created
                            )
                            VALUES
                            (
                              @publicId,
                              @filename,
                              @filepath,
                              @fileSize,
                              @created
                            )", dp, cancellationToken: ctk);

            await DbConnection.ExecuteAsync(cd);

            return file;
        }

        public async Task Delete(GedDocument file, CancellationToken ctk = default(CancellationToken))
        {
            var cd = new CommandDefinition(@"
                            DELETE FROM Ged
                            WHERE Id = @id",
                new
                {
                    id = file.Id
                }, cancellationToken: ctk);

            await DbConnection.ExecuteAsync(cd).ConfigureAwait(false);
        }

        public async Task<GedDocument> Update(GedDocument file,
            CancellationToken ctk = default(CancellationToken))
        {
            await DbConnection.ExecuteAsync(@"
                            UPDATE Ged
                            SET
                             Public_Id = @publicId,
                             File_Name = @fileName,
                             File_Path = @filePath,
                             File_Size = @fileSize,
                             Created = :created
                            WHERE
                             Id = @id",
                new
                {
                    id = file.Id,
                    publicId = file.PublicId,
                    fileName = file.FileName,
                    filePath = file.FilePath,
                    fileSize = file.FileSize,
                    created = file.Created
                });
            return file;
        }

        public async Task<IReadOnlyList<GedDocument>> GetAllFiles(
            CancellationToken ctk = default(CancellationToken))
        {
            return (await DbConnection.QueryAsync<GedDocument>(
                BaseSelectQuery
            )).ToArray();
        }

        public async Task<IReadOnlyList<GedDocument>> GetAllFilesByPublicIds(IEnumerable<Guid> ids, CancellationToken ctk = default(CancellationToken))
        {
            return (await DbConnection.QueryAsync<GedDocument>(
                BaseSelectQuery +
                @"WHERE g.Public_Id in @Ids",
                new
                {
                    Ids = ids.ToArray()
                }
            )).ToArray();
        }

        public async Task<GedDocument> GetById(int id,
            CancellationToken ctk = default(CancellationToken))
        {
            return (await DbConnection.QueryAsync<GedDocument>(
                BaseSelectQuery +
                @"WHERE g.Id = @Id",
                new
                {
                    Id = id
                })).FirstOrDefault();
        }

        public async Task<GedDocument> GetByPublicId(Guid? publicId,
            CancellationToken ctk = default(CancellationToken))
        {
            return (await DbConnection.QueryAsync<GedDocument>(
                new CommandDefinition(BaseSelectQuery + @"WHERE g.Public_Id = @PublicId", new
                {
                    PublicId = publicId
                }))).FirstOrDefault();
        }

        public async Task<GedDocument> GetByName(string fileName, CancellationToken ctk)
        {
            return (await DbConnection.QueryAsync<GedDocument>(
                new CommandDefinition(BaseSelectQuery + @"WHERE g.FileName LIKE @fileName%", new
                {
                    FileName = fileName
                }))).FirstOrDefault();
        }
    }
}