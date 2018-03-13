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
    public class SkillRepository : RepositoryBase<DtmDbContext, Skill, int>
    {
        public SkillRepository(DtmDbContext co, Func<DtmDbContext, DbSet<Skill>> tableDbSet, Expression<Func<Skill, int>> tableKeySelector) : base(co, tableDbSet, tableKeySelector)
        {
        }

        public override async Task<Skill> GetById(int id, bool noTracking = false, CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Skill.SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        public async Task<IEnumerable<Skill>> GetByLibelle(string libelle,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Skill.Where(_ => _.Libelle == libelle).ToArrayAsync(ctk);
        }
    }
}