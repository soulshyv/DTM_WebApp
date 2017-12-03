using System;
using System.Threading.Tasks;
using DbManager.Contracts;
using MySql.Data.MySqlClient;

namespace DbManager.Services
{
    public sealed class DtmRepository : IDtmRepository
    {
        private const string ConnectionString = @"Server=localhost;Port=3306;Database=jdr;Uid=root;Pwd=root";

        public DtmRepository()
        {
            try
            {
                Conn = new MySqlConnection(ConnectionString);
                Conn.Open();
            }
            catch (Exception)
            {
                Conn.Close();
                throw new Exception("Une erreur est survenue pendant la connexion à la base de données");
            }
        }

        private MySqlConnection Conn { get; }
        public async Task GetAllPerso(object perso)
        {
            await Task.CompletedTask;
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