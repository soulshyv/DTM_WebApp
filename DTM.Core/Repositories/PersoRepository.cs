using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DTM.Core.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DTM.Core.Repositories
{
    public class PersoRepository : RepositoryBase<JdrContext, Perso, int>
    {
        public PersoRepository(JdrContext co) : base(co, _ => _.Perso, _ => _.Id)
        {
        }

        public override async Task<Perso> GetById(int id, bool noTracking = false,
            CancellationToken ctk = default(CancellationToken))
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

        public async Task<PersoDto> GetFullPersoById(int id,
            CancellationToken ctk = default(CancellationToken))
        {
            var res = await (
                from perso in Connection.Perso
                join ep in Connection.ElementPerso on perso.Id equals ep.PersoId into eps
                join dp in Connection.DonPerso on perso.Id equals dp.PersoId into dps
                join demon in Connection.DemonPerso on perso.Id equals demon.PersoId into demons
                join inv in Connection.Inventaire on perso.Id equals inv.PersoId into invs
                join mp in Connection.MetierPerso on perso.Id equals mp.PersoId into mps
                join pp in Connection.PassifPerso on perso.Id equals pp.PersoId into pps
                join sp in Connection.SkillPerso on perso.Id equals sp.PersoId into sps
                where perso.Id == id
                select new PersoDto(
                                new Charac(perso),
                                perso.Caracs,
                                perso.Jauges,
                                perso.Stats,
                                eps.ToList(),
                                sps.ToList(),
                                dps.ToList(),
                                demons.ToList(),
                                invs.ToList(),
                                mps.ToList(),
                                pps.ToList())
                ).FirstOrDefaultAsync(ctk);

            return res;
        }

        public async Task<PersoDto> GetFullPersoByName(string nom,
            CancellationToken ctk = default(CancellationToken))
        {
            var res = await (
                from perso in Connection.Perso
                join ep in Connection.ElementPerso on perso.Id equals ep.PersoId into eps
                join dp in Connection.DonPerso on perso.Id equals dp.PersoId into dps
                join demon in Connection.DemonPerso on perso.Id equals demon.PersoId into demons
                join inv in Connection.Inventaire on perso.Id equals inv.PersoId into invs
                join mp in Connection.MetierPerso on perso.Id equals mp.PersoId into mps
                join pp in Connection.PassifPerso on perso.Id equals pp.PersoId into pps
                join sp in Connection.SkillPerso on perso.Id equals sp.PersoId into sps
                where perso.Nom == nom
                select new PersoDto(
                    new Charac(perso),
                    perso.Caracs,
                    perso.Jauges,
                    perso.Stats,
                    eps.ToList(),
                    sps.ToList(),
                    dps.ToList(),
                    demons.ToList(),
                    invs.ToList(),
                    mps.ToList(),
                    pps.ToList())
            ).FirstOrDefaultAsync(ctk);

            return res;
        }
    }
}