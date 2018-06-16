﻿using DTM.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DTM.Core.Repositories
{
    public class SkillRepository : RepositoryBase<JdrContext, Skill, int>
    {
        public SkillRepository(JdrContext co) : base(co, _ => _.Skill, _ => _.Id)
        {
        }

        public override async Task<Skill> GetById(int id, bool noTracking = false, CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Skill.SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        public async Task<Skill> GetByLibelle(string libelle,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Skill.SingleOrDefaultAsync(_ => _.Libelle == libelle, ctk);
        }

        public async Task<IEnumerable<Skill>> GetAll(CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Skill.ToArrayAsync(ctk);
        }
    }
}