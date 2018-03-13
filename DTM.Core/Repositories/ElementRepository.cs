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
    public class ElementRepository : RepositoryBase<DtmDbContext, Element, int>
    {
        public ElementRepository(DtmDbContext co, Func<DtmDbContext, DbSet<Element>> tableDbSet, Expression<Func<Element, int>> tableKeySelector) : base(co, tableDbSet, tableKeySelector)
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
    }
}