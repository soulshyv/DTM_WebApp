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
    public class InventaireRepository : RepositoryBase<DtmDbContext, Inventaire, int>
    {
        public InventaireRepository(DtmDbContext co, Func<DtmDbContext, DbSet<Inventaire>> tableDbSet, Expression<Func<Inventaire, int>> tableKeySelector) : base(co, tableDbSet, tableKeySelector)
        {
        }

        public override async Task<Inventaire> GetById(int id, bool noTracking = false, CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Inventaire.SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        public async Task<IEnumerable<Inventaire>> GetByPersoId(int id,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Inventaire.Where(_ => _.PersoId == id).ToArrayAsync(ctk);
        }

        public async Task<IEnumerable<Inventaire>> GetByItemId(int id,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Inventaire.Where(_ => _.ItemId == id).ToArrayAsync(ctk);
        }
    }
}