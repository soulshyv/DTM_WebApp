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
    public class PassifPersoRepository : RepositoryBase<DtmDbContext, PassifPerso, int>
    {
        public PassifPersoRepository(DtmDbContext co, Func<DtmDbContext, DbSet<PassifPerso>> tableDbSet, Expression<Func<PassifPerso, int>> tableKeySelector) : base(co, tableDbSet, tableKeySelector)
        {
        }

        public override async Task<PassifPerso> GetById(int id, bool noTracking = false, CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.PassifPerso.SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        public async Task<IEnumerable<PassifPerso>> GetByPersoId(int id,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.PassifPerso.Where(_ => _.PersoId == id).ToArrayAsync(ctk);
        }

        public async Task<IEnumerable<PassifPerso>> GetByPassifId(int id,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.PassifPerso.Where(_ => _.PassifId == id).ToArrayAsync(ctk);
        }
    }
}