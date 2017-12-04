using System.Collections.Generic;
using System.Threading.Tasks;
using DTM.Core.Contracts;
using DTM.DbManager.Contracts;
using MySql.Data.MySqlClient;
using Dapper;
using DTM.DbManager.Models;

namespace DTM.DbManager.Services
{
    public sealed class DtmRepository : IDtmRepository
    {
        public DtmRepository(IDtmDbConnection dbConnection)
        {
            Conn = dbConnection.DbConnection;
        }

        private MySqlConnection Conn { get; }

        public async Task<List<Character>> GetAllPerso()
        {
            return (await Conn.ExecuteAsync(@"SELECT
                                             perso.Nom,
                                             perso.Xp,
                                             perso.Lvl,
                                             perso.Po,
                                             perso.Race,
                                             perso.Type_Perso
                                            FROM jdr.perso")).Tolist();
        }

        public async Task GetPersoByName(object perso)
        {
            await Task.CompletedTask;
        }

        public async Task GetStatsPerso(object perso)
        {
            await Task.CompletedTask;
        }

        public async Task GetCaracPerso(object perso)
        {
            await Task.CompletedTask;
        }

        public async Task GetJaugePerso(object perso)
        {
            await Task.CompletedTask;
        }

        public async Task GetDonsPerso(object perso)
        {
            await Task.CompletedTask;
        }

        public async Task GetAllDons()
        {
            await Task.CompletedTask;
        }

        public async Task PassifsPerso(object perso)
        {
            await Task.CompletedTask;
        }

        public async Task GetAllPassifs()
        {
            await Task.CompletedTask;
        }

        public async Task GetAllDemons()
        {
            await Task.CompletedTask;
        }

        public async Task GetDemonPerso(object perso)
        {
            await Task.CompletedTask;
        }

        public async Task GetInventairePerso(object perso)
        {
            await Task.CompletedTask;
        }

        public async Task GetAllInventaires()
        {
            await Task.CompletedTask;
        }

        public async Task GetItemByNom(object perso)
        {
            await Task.CompletedTask;
        }

        public async Task GetItemsPerso(object perso)
        {
            await Task.CompletedTask;
        }

        public async Task GetAllItemsByPerso()
        {
            await Task.CompletedTask;
        }

        public async Task GetSkillsPerso(object perso)
        {
            await Task.CompletedTask;
        }

        public async Task GetAllSkills()
        {
            await Task.CompletedTask;
        }

        public async Task GetAllEllements()
        {
            await Task.CompletedTask;
        }

        public async Task GetElementPerso(object perso)
        {
            await Task.CompletedTask;
        }

        //public static DbManager GetInstance()
        //{
        //    return Instance;
        //}
    }
}