﻿using DTM.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DTM.Core.Repositories
{
    public class ItemRepository : RepositoryBase<DtmDbContext, Item, int>
    {
        public ItemRepository(DtmDbContext co) : base(co, _ => _.Item, _ => _.Id)
        {
        }

        public override async Task<Item> GetById(int id, bool noTracking = false, CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Item.SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        public async Task<IEnumerable<Item>> GetByLibelle(string nom,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Item.Where(_ => _.Nom == nom).ToArrayAsync(ctk);
        }

        public async Task<IEnumerable<Item>> GetByType(int type,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Item.Where(_ => _.TypeItem == type).ToArrayAsync(ctk);
        }

        public async Task<IEnumerable<Item>> GetAll(CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Item.ToArrayAsync(ctk);
        }
    }
}