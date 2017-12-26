using System.Collections.Generic;
using System.Threading.Tasks;
using DTM.DbManager.Models;

namespace DTM.DbManager.Contracts
{
    public interface IDtmRepositoryUpdate
    {
        Task UpdateCaracsPerso(Caracs caracs, string nomPerso);
        Task UpdateDemon(IEnumerable<Demon> demons);
        Task UpdateDemonPerso(IEnumerable<Demon> demons, string nomPerso);
        Task UpdateDons(IEnumerable<Don> dons);
        Task UpdateDonsPerso(IEnumerable<Don> dons, string nomPerso);
        Task UpdateElement(IEnumerable<Element> elements);
        Task UpdateElementPerso(IEnumerable<Element> elements, string nomPerso);
        Task UpdateInventairePerso(Inventaire inventaire, string nomPerso);
        Task UpdateItem(Item item);
        Task UpdateJaugesPerso(Jauges jauge, string nomPerso);
        Task UpdatePassifs(IEnumerable<Passif> passifs);
        Task UpdatePassifsDemon(IEnumerable<Passif> passifs, string nomDemon);
        Task UpdatePassifsPerso(IEnumerable<Passif> passifs, string nomPerso);
        Task UpdatePerso(Character charac);
        Task UpdateSkills(IEnumerable<Skill> skills);
        Task UpdateSkillsPerso(IEnumerable<Skill> skills, string nomPerso);
        Task UpdateStatsPerso(Stats stats, string nomPerso);
    }
}