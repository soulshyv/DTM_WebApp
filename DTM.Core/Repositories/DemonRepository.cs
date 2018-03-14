﻿using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using DTM.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DTM.Core.Repositories
{
    public class DemonRepository : RepositoryBase<DtmDbContext, Demon, int>
    {
        public DemonRepository(DtmDbContext co, Func<DtmDbContext, DbSet<Demon>> tableDbSet, Expression<Func<Demon, int>> tableKeySelector) : base(co, tableDbSet, tableKeySelector)
        {
        }

        public override async Task<Demon> GetById(int id, bool noTracking = false, CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Demon.SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        public async Task<Demon> GetByNom(string nom,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Demon.SingleOrDefaultAsync(_ => _.Nom == nom, ctk);
        }
    }
}