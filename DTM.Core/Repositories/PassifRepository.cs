using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using DTM.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DTM.Core.Repositories
{
    public class PassifRepository : RepositoryBase<DtmDbContext, Passif, int>
    {
        public PassifRepository(DtmDbContext co, Func<DtmDbContext, DbSet<Passif>> tableDbSet, Expression<Func<Passif, int>> tableKeySelector) : base(co, tableDbSet, tableKeySelector)
        {
        }

        public override async Task<Passif> GetById(int id, bool noTracking = false, CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Passif.SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        public async Task<IEnumerable<Passif>> GetByLibelle(string libelle,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Passif.Where(_ => _.Libelle == libelle).ToArrayAsync(ctk);
        }
    }
}