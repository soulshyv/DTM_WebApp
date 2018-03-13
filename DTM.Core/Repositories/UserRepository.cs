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
    public class UserRepository : RepositoryBase<DtmDbContext, User, int>
    {
        public UserRepository(DtmDbContext co, Func<DtmDbContext, DbSet<User>> tableDbSet, Expression<Func<User, int>> tableKeySelector) : base(co, tableDbSet, tableKeySelector)
        {
        }

        public override async Task<User> GetById(int id, bool noTracking = false, CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.User.SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        public async Task<IEnumerable<User>> GetByUserName(string userName,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.User.Where(_ => _.UserName == userName).ToArrayAsync(ctk);
        }

        public async Task<IEnumerable<User>> GetByPersoId(int id,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.User.Where(_ => _.PersoId == id).ToArrayAsync(ctk);
        }
    }
}