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
    public class MetierRepository : RepositoryBase<DtmDbContext, Metier, int>
    {
        public MetierRepository(DtmDbContext co, Func<DtmDbContext, DbSet<Metier>> tableDbSet, Expression<Func<Metier, int>> tableKeySelector) : base(co, tableDbSet, tableKeySelector)
        {
        }

        public override async Task<Metier> GetById(int id, bool noTracking = false, CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Metier.SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        public async Task<IEnumerable<Metier>> GetByLibelle(string libelle,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Metier.Where(_ => _.Libelle == libelle).ToArrayAsync(ctk);
        }
    }
}