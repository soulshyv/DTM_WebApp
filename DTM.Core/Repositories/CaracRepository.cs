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
    public class CaracRepository : RepositoryBase<DtmDbContext, Carac, int>
    {
        public CaracRepository(DtmDbContext co) : base(co, _ => _.Carac, _ => _.Id)
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