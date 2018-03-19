using DTM.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DTM.Core.Repositories
{
    public class ElementRepository : RepositoryBase<DtmDbContext, Element, int>
    {
        public ElementRepository(DtmDbContext co) : base(co, _ => _.Element, _ => _.Id)
        {
        }

        public override async Task<Element> GetById(int id, bool noTracking = false, CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Element.SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        public async Task<IEnumerable<Element>> GetByLibelle(string libelle,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Element.Where(_ => _.Libelle == libelle).ToArrayAsync(ctk);
        }

        public async Task<IEnumerable<Element>> GetAll(CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Element.ToArrayAsync(ctk);
        }
    }
}