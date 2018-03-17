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
    public class PersoRepository : RepositoryBase<DtmDbContext, Perso, int>
    {
        public PersoRepository(DtmDbContext co) : base(co, _ => _.Perso, _ => _.Id)
        {   
        }

        public override async Task<Perso> GetById(int id, bool noTracking = false, CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Perso.SingleOrDefaultAsync(_ => _.Id == id, ctk);
        }

        public async Task<IEnumerable<Perso>> GetAll(CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Perso.ToArrayAsync(ctk);
        }

        public async Task<Perso> GetByNom(string nom,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Perso.SingleOrDefaultAsync(_ => _.Nom == nom, ctk);
        }

        public async Task<IEnumerable<Perso>> GetByRace(string race,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Perso.Where(_ => _.Race == race).ToArrayAsync(ctk);
        }

        public async Task<IEnumerable<Perso>> GetByTypePerso(int type,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Perso.Where(_ => _.TypePerso == type).ToArrayAsync(ctk);
        }

        public async Task<Perso> GetFullPersoById(int id,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Perso
                .Where(_ => _.Id == id)
                .Include(_ => _.Carac)
                .Include(_ => _.Jauge)
                .Include(_ => _.Stat)
                .Include(_ => _.DemonPerso).ThenInclude(_ => _.Demon)
                .Include(_ => _.DonPerso).ThenInclude(_ => _.Don)
                .Include(_ => _.ElementPerso).ThenInclude(_ => _.Element)
                .Include(_ => _.Inventaire).ThenInclude(_ => _.Item)
                .Include(_ => _.MetierPerso).ThenInclude(_ => _.Metier)
                .Include(_ => _.PassifPerso).ThenInclude(_ => _.Passif)
                .Include(_ => _.SkillPerso).ThenInclude(_ => _.Skill)
                .FirstOrDefaultAsync(ctk);
        }

        public async Task<Perso> GetFullPersoByName(string nom,
            CancellationToken ctk = default(CancellationToken))
        {
            return await Connection.Perso.Include(_ => _.Carac).Include(_ => _.Jauge).Include(_ => _.Stat).Include(_ => _.DemonPerso).Include(_ => _.DonPerso).Include(_ => _.ElementPerso).Include(_ => _.Inventaire).Include(_ => _.MetierPerso).Include(_ => _.PassifPerso).Include(_ => _.SkillPerso).Where(_ => _.Nom == nom).FirstOrDefaultAsync(ctk);
        }
    }
}