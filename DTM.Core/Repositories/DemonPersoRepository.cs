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
    public class DemonPersoRepository : RepositoryBase<DtmDbContext, DemonPerso, int>
    {
        public DemonPersoRepository(DtmDbContext co) : base(co, _ => _.DemonPerso, _ => _.Id)
        {
        }

        public override async Task<DemonPerso> GetById(int id, bool noTracking = false, CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.DemonPerso.SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        public async Task<IEnumerable<DemonPerso>> GetByPersoId(int id,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.DemonPerso.Where(_ => _.PersoId == id).ToArrayAsync(ctk);
        }

        public async Task<IEnumerable<DemonPerso>> GetByDemonId(int id,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.DemonPerso.Where(_ => _.DemonId == id).ToArrayAsync(ctk);
        }
    }
}