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
    public class JaugeRepository : RepositoryBase<DtmDbContext, Jauge, int>
    {
        public JaugeRepository(DtmDbContext co, Func<DtmDbContext, DbSet<Jauge>> tableDbSet, Expression<Func<Jauge, int>> tableKeySelector) : base(co, tableDbSet, tableKeySelector)
        {
        }

        public override async Task<Jauge> GetById(int id, bool noTracking = false, CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Jauge.SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        public async Task<Jauge> GetByPersoId(int id,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Jauge.SingleOrDefaultAsync(_ => _.PersoId == id, ctk);
        }
    }
}