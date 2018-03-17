﻿using DTM.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DTM.Core.Repositories
{
    public class PassifDemonRepository : RepositoryBase<DtmDbContext, PassifDemon, int>
    {
        public PassifDemonRepository(DtmDbContext co) : base(co, _ => _.PassifDemon, _ => _.Id)
        {
        }

        public override async Task<PassifDemon> GetById(int id, bool noTracking = false, CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.PassifDemon.SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        public async Task<IEnumerable<PassifDemon>> GetByDemonId(int id,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.PassifDemon.Where(_ => _.DemonId == id).ToArrayAsync(ctk);
        }

        public async Task<IEnumerable<PassifDemon>> GetByPassifId(int id,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.PassifDemon.Where(_ => _.PassifId == id).ToArrayAsync(ctk);
        }
    }
}