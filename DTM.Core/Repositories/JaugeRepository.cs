using DTM.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DTM.Core.Repositories
{
    public class JaugeRepository : RepositoryBase<DtmDbContext, Jauge, int>
    {
        public JaugeRepository(DtmDbContext co) : base(co, _ => _.Jauge, _ => _.Id)
        {
        }

        public override async Task<Jauge> GetById(int id, bool noTracking = false, CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Jauge.SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        public async Task<Jauge> GetByPersoId(int id,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Jauge.SingleOrDefaultAsync(_ => _.PersoId == id, ctk);
        }
    }
}