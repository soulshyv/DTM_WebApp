using DTM.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DTM.Core.Repositories
{
    public class MetierRepository : RepositoryBase<DtmDbContext, Metier, int>
    {
        public MetierRepository(DtmDbContext co) : base(co, _ => _.Metier, _ => _.Id)
        {
        }

        public override async Task<Metier> GetById(int id, bool noTracking = false, CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Metier.SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        public async Task<IEnumerable<Metier>> GetByLibelle(string libelle,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Metier.Where(_ => _.Libelle == libelle).ToArrayAsync(ctk);
        }
    }
}