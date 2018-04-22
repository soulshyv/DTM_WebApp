using DTM.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DTM.Core.Repositories
{
    public class MetierPersoRepository : RepositoryBase<JdrContext, MetierPerso, int>
    {
        public MetierPersoRepository(JdrContext co) : base(co, _ => _.MetierPerso, _ => _.Id)
        {
        }

        public override async Task<MetierPerso> GetById(int id, bool noTracking = false, CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.MetierPerso.SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        public async Task<IEnumerable<MetierPerso>> GetByPersoId(int id,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.MetierPerso.Where(_ => _.PersoId == id).ToArrayAsync(ctk);
        }

        public async Task<IEnumerable<MetierPerso>> GetByMetierId(int id,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.MetierPerso.Where(_ => _.MetierId == id).ToArrayAsync(ctk);
        }
    }
}