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
    public class SkillPersoRepository : RepositoryBase<DtmDbContext, SkillPerso, int>
    {
        public SkillPersoRepository(DtmDbContext co, Func<DtmDbContext, DbSet<SkillPerso>> tableDbSet, Expression<Func<SkillPerso, int>> tableKeySelector) : base(co, tableDbSet, tableKeySelector)
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