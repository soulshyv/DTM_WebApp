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
    public class DonRepository : RepositoryBase<DtmDbContext, Don, int>
    {
        public DonRepository(DtmDbContext co) : base(co, _ => _.Don, _ => _.Id)
        {
        }

        public override async Task<Don> GetById(int id, bool noTracking = false, CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Don.SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        public async Task<IEnumerable<Don>> GetByLibelle(string libelle,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Don.Where(_ => _.Libelle == libelle).ToArrayAsync(ctk);
        }
    }
}