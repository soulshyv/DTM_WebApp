using DTM.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DTM.Core.Repositories
{
    public class PassifPersoRepository : RepositoryBase<JdrContext, PassifPerso, int>
    {
        public PassifPersoRepository(JdrContext co) : base(co, _ => _.PassifPerso, _ => _.Id)
        {
        }

        public override async Task<PassifPerso> GetById(int id, bool noTracking = false, CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.PassifPerso.SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        public async Task<IEnumerable<PassifPerso>> GetByPersoId(int id,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.PassifPerso.Where(_ => _.PersoId == id).ToArrayAsync(ctk);
        }

        public async Task<IEnumerable<PassifPerso>> GetByPassifId(int id,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.PassifPerso.Where(_ => _.PassifId == id).ToArrayAsync(ctk);
        }
    }
}