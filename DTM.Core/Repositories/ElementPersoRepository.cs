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
    public class ElementPersoRepository : RepositoryBase<DtmDbContext, ElementPerso, int>
    {
        public ElementPersoRepository(DtmDbContext co, Func<DtmDbContext, DbSet<ElementPerso>> tableDbSet, Expression<Func<ElementPerso, int>> tableKeySelector) : base(co, tableDbSet, tableKeySelector)
        {
        }

        public override async Task<ElementPerso> GetById(int id, bool noTracking = false, CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.ElementPerso.SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        public async Task<IEnumerable<ElementPerso>> GetByPersoId(int id,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.ElementPerso.Where(_ => _.PersoId == id).ToArrayAsync(ctk);
        }

        public async Task<IEnumerable<ElementPerso>> GetByElementId(int id,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.ElementPerso.Where(_ => _.ElementId == id).ToArrayAsync(ctk);
        }
    }
}