using DTM.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DTM.Core.Repositories
{
    public class ElementPersoRepository : RepositoryBase<JdrContext, ElementPerso, int>
    {
        public ElementPersoRepository(JdrContext co) : base(co, _ => _.ElementPerso, _ => _.Id)
        {
        }

        public override async Task<ElementPerso> GetById(int id, bool noTracking = false, CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.ElementPerso.SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        public async Task<IEnumerable<ElementPerso>> GetByPersoId(int id,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.ElementPerso.Where(_ => _.PersoId == id).ToArrayAsync(ctk);
        }

        public async Task<IEnumerable<ElementPerso>> GetByElementId(int id,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.ElementPerso.Where(_ => _.ElementId == id).ToArrayAsync(ctk);
        }
    }
}