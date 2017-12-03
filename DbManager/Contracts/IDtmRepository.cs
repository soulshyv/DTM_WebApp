using System.Threading.Tasks;

namespace DbManager.Contracts
{
    public interface IDtmRepository
    {
        Task GetAllDemons();
        Task GetAllDons();
        Task GetAllEllements();
        Task GetAllInventaires();
        Task GetAllItemsByPerso();
        Task GetAllPassifs();
        Task GetAllPerso(object perso);
        Task GetAllSkills();
        Task GetCaracPerso(object perso);
        Task GetDemonPerso(object perso);
        Task GetDonsPerso(object perso);
        Task GetElementPerso(object perso);
        Task GetInventairePerso(object perso);
        Task GetItemByNom(object perso);
        Task GetItemsPerso(object perso);
        Task GetJaugePerso(object perso);
        Task GetPersoByName(object perso);
        Task GetSkillsPerso(object perso);
        Task GetStatsPerso(object perso);
        Task PassifsPerso(object perso);
    }
}