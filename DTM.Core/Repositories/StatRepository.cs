using DTM.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DTM.Core.Repositories
{
    public class StatRepository : RepositoryBase<DtmDbContext, Stat, int>
    {
        public StatRepository(DtmDbContext co) : base(co, _ => _.Stat, _ => _.Id)
        {
        }

        public override async Task<Stat> GetById(int id, bool noTracking = false, CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Stat.SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        public async Task<Stat> GetByPersoId(int id,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Stat.SingleOrDefaultAsync(_ => _.PersoId == id, ctk);
        }
    }
}