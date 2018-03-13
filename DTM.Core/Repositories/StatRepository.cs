using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using DTM.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DTM.Core.Repositories
{
    public class StatRepository : RepositoryBase<DtmDbContext, Stat, int>
    {
        public StatRepository(DtmDbContext co, Func<DtmDbContext, DbSet<Stat>> tableDbSet, Expression<Func<Stat, int>> tableKeySelector) : base(co, tableDbSet, tableKeySelector)
        {
        }

        public override async Task<Stat> GetById(int id, bool noTracking = false, CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Stat.SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        public async Task<Stat> GetByPersoId(int id,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Stat.SingleOrDefaultAsync(_ => _.PersoId == id, ctk);
        }
    }
}