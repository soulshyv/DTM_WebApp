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
    public class DonRepository : RepositoryBase<JdrContext, Don, int>
    {
        public DonRepository(JdrContext co) : base(co, _ => _.Don, _ => _.Id)
        {
        }

        public override async Task<Don> GetById(int id, bool noTracking = false, CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Don.SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        public async Task<Don> GetByLibelle(string libelle,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Don.SingleOrDefaultAsync(_ => _.Libelle == libelle, ctk);
        }

        public async Task<IEnumerable<Don>> GetAll(CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Don.ToArrayAsync(ctk);
        }
    }
}