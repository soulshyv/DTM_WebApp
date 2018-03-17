using DTM.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DTM.Core.Repositories
{
    public class SkillPersoRepository : RepositoryBase<DtmDbContext, SkillPerso, int>
    {
        public SkillPersoRepository(DtmDbContext co) : base(co, _ => _.SkillPerso, _ => _.Id)
        {
        }

        public override async Task<SkillPerso> GetById(int id, bool noTracking = false, CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.SkillPerso.SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        public async Task<IEnumerable<SkillPerso>> GetByPersoId(int id,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.SkillPerso.Where(_ => _.PersoId == id).ToArrayAsync(ctk);
        }

        public async Task<IEnumerable<SkillPerso>> GetBySkillId(int id,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.SkillPerso.Where(_ => _.SkillId == id).ToArrayAsync(ctk);
        }
    }
}