using System.Collections.Generic;
using System.Threading.Tasks;
using DTM.DbManager.Models;

namespace DTM.DbManager.Contracts
{
    public interface IDtmRepository
    {
        /* SELECT */
        Task<List<Demon>> GetAllDemons();
        Task<List<Don>> GetAllDons();
        Task<List<Element>> GetAllEllements();
        Task<List<Passif>> GetAllPassifs();
        Task<List<Character>> GetAllPerso();
        Task<List<Skill>> GetAllSkills();
        Task<CharacterFull> GetFullPersoByName(string nomPerso);
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

        /* UPDATE */
        Task UpdateCaracsPerso(Caracs caracs, string nomPerso);
        Task UpdatePerso(Character charac);
        Task UpdateDemon(List<Demon> demons);
        Task UpdateDemonPerso(List<Demon> demons, string nomPerso);
        Task UpdateDons(List<Don> dons);
        Task UpdateDonsPerso(List<Don> dons, string nomPerso);
        Task UpdateElement(List<Element> elements);
        Task UpdateElementPerso(List<Element> elements, string nomPerso);
        Task UpdateInventairePerso(Inventaire inventaire, string nomPerso);
        Task UpdateItem(Item item);
        Task UpdateJaugesPerso(Jauges jauge, string nomPerso);
        Task UpdatePassifs(List<Passif> passifs);
        Task UpdatePassifsPerso(List<Passif> passifs, string nomPerso);
        Task UpdateSkills(List<Skill> skills);
        Task UpdateSkillsPerso(List<Skill> skills, string nomPerso);
        Task UpdateStatsPerso(Caracs caracs, string nomPerso);

        /* DELETE */


        /* INSERT */
    }
}