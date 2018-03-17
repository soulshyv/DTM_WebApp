using DTM.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DTM.Core.Repositories
{
    public class SkillRepository : RepositoryBase<DtmDbContext, Skill, int>
    {
        public SkillRepository(DtmDbContext co) : base(co, _ => _.Skill, _ => _.Id)
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