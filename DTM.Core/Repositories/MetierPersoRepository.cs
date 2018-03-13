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
    public class MetierPersoRepository : RepositoryBase<DtmDbContext, MetierPerso, int>
    {
        public MetierPersoRepository(DtmDbContext co, Func<DtmDbContext, DbSet<MetierPerso>> tableDbSet, Expression<Func<MetierPerso, int>> tableKeySelector) : base(co, tableDbSet, tableKeySelector)
        {
        }

        public override async Task<MetierPerso> GetById(int id, bool noTracking = false, CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.MetierPerso.SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        public async Task<IEnumerable<MetierPerso>> GetByPersoId(int id,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.MetierPerso.Where(_ => _.PersoId == id).ToArrayAsync(ctk);
        }

        public async Task<IEnumerable<MetierPerso>> GetByMetierId(int id,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.MetierPerso.Where(_ => _.MetierId == id).ToArrayAsync(ctk);
        }
    }
}