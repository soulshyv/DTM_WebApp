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
    public class CaracsRepository : RepositoryBase<DtmDbContext, Carac, int>
    {
        public CaracsRepository(DtmDbContext co, Func<DtmDbContext, DbSet<Carac>> tableDbSet, Expression<Func<Carac, int>> tableKeySelector) : base(co, tableDbSet, tableKeySelector)
        {
        }

        public override async Task<Carac> GetById(int id, bool noTracking = false, CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Carac.SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        public async Task<Carac> GetByPersoId(int id,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Carac.SingleOrDefaultAsync(_ => _.PersoId == id, ctk);
        }
    }
}