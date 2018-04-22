using DTM.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DTM.Core.Repositories
{
    public class InventaireRepository : RepositoryBase<JdrContext, Inventaire, int>
    {
        public InventaireRepository(JdrContext co) : base(co, _ => _.Inventaire, _ => _.Id)
        {
        }

        public override async Task<Inventaire> GetById(int id, bool noTracking = false, CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Inventaire.SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        public async Task<IEnumerable<Inventaire>> GetByPersoId(int id,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Inventaire.Where(_ => _.PersoId == id).ToArrayAsync(ctk);
        }

        public async Task<IEnumerable<Inventaire>> GetByItemId(int id,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Inventaire.Where(_ => _.ItemId == id).ToArrayAsync(ctk);
        }
    }
}