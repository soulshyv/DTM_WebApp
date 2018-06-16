using DTM.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DTM.Core.Repositories
{
    public class DonPersoRepository : RepositoryBase<JdrContext, DonPerso, int>
    {
        public DonPersoRepository(JdrContext co) : base(co, _ => _.DonPerso, _ => _.Id)
        {
        }

        public override async Task<DonPerso> GetById(int id, bool noTracking = false, CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.DonPerso.SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        public async Task<IEnumerable<DonPerso>> GetByPersoId(int id,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.DonPerso.Where(_ => _.PersoId == id).ToArrayAsync(ctk);
        }

        public async Task<IEnumerable<DonPerso>> GetByDonId(int id,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.DonPerso.Where(_ => _.DonId == id).ToArrayAsync(ctk);
        }
    }
}