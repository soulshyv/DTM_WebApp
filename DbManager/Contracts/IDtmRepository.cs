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
        Task<List<Demon>> GetDemonPerso(string nomPerso);
        Task<List<DonsPerso>> GetDonsPerso(string nomPerso);
        Task<List<Element>> GetElementPerso(string nomPerso);
        Task<Inventaire> GetInventairePerso(string nomPerso);
        Task<Item> GetItemByNom(string nomItem);
        Task<Character> GetPersoByName(string nomPerso);
        Task<List<Skill>> GetSkillsPerso(string nomPerso);
        Task<List<Passif>> PassifsPerso(string nomPerso);
        Task<List<Passif>> PassifsDemon(string nomDemon);
    }
}