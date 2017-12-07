using System.Collections.Generic;
using System.Threading.Tasks;
using DTM.DbManager.Models;

namespace DTM.DbManager.Contracts
{
    public interface IDtmRepository
    {
        Task<List<Demon>> GetAllDemons();
        Task<List<Don>> GetAllDons();
        Task<List<Element>> GetAllEllements();
        Task<List<Passif>> GetAllPassifs();
        Task<List<Character>> GetAllPerso();
        Task<List<Skill>> GetAllSkills();
        Task<Caracs> GetCaracsPerso(string nomPerso);
        Task<Jauges> GetJaugesPerso(string nomPerso);
        Task<Stats> GetStatsPerso(string nomPerso);
        Task<List<Demon>> GetDemonPerso(string nomPerso);
        Task<List<DonPerso>> GetDonsPerso(string nomPerso);
        Task<List<Element>> GetElementPerso(string nomPerso);
        Task<Inventaire> GetInventairePerso(string nomPerso);
        Task<Item> GetItemByNom(string nomItem);
        Task<Character> GetPersoByNom(string nomPerso);
        Task<List<Skill>> GetSkillsPerso(string nomPerso);
        Task<List<Passif>> PassifsPerso(string nomPerso);
        Task<List<Passif>> PassifsDemon(string nomDemon);
    }
}