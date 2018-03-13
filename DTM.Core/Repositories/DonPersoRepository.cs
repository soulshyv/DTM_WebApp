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
    public class DonPersoRepository : RepositoryBase<DtmDbContext, DonPerso, int>
    {
        public DonPersoRepository(DtmDbContext co, Func<DtmDbContext, DbSet<DonPerso>> tableDbSet, Expression<Func<DonPerso, int>> tableKeySelector) : base(co, tableDbSet, tableKeySelector)
        {
        }

        public override async Task<DonPerso> GetById(int id, bool noTracking = false, CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.DonPerso.SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        public async Task<IEnumerable<DonPerso>> GetByPersoId(int id,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.DonPerso.Where(_ => _.PersoId == id).ToArrayAsync(ctk);
        }

        public async Task<IEnumerable<DonPerso>> GetByDonId(int id,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.DonPerso.Where(_ => _.DonId == id).ToArrayAsync(ctk);
        }
    }
}