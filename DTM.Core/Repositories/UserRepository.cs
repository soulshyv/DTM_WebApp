using DTM.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DTM.Core.Repositories
{
    public class UserRepository : RepositoryBase<JdrContext, User, int>
    {
        public UserRepository(JdrContext co) : base(co, _ => _.User, _ => _.Id)
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