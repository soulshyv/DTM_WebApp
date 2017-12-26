using System.Collections.Generic;
using System.Threading.Tasks;
using DTM.Core.Contracts;
using DTM.DbManager.Contracts;
using DTM.DbManager.Models;
using MySql.Data.MySqlClient;

namespace DTM.DbManager.Services.Repository
{
    public class DtmRepositoryUpdate : IDtmRepositoryUpdate
    {
        public DtmRepositoryUpdate(IDtmDbConnection dbConnection)
        {
            Conn = dbConnection.DbConnection;
        }

        private MySqlConnection Conn { get; }

        /**************** UPDATE ****************/

        public async Task UpdatePerso(Character charac)
        {
            const string sql = @"UPDATE perso
                                 SET
                                 Nom = @nomPerso
                                 Xp = @xp,
                                 Lvl = @lvl,
                                 Po = @po,
                                 Race = @race,
                                 Type_Perso = @type
                                 WHERE Nom = @nomPerso";
            var cmd = new MySqlCommand(sql, Conn);
            cmd.Parameters.AddWithValue("@xp", charac.Xp);
            cmd.Parameters.AddWithValue("@lvl", charac.Lvl);
            cmd.Parameters.AddWithValue("@po", charac.Po);
            cmd.Parameters.AddWithValue("@race", charac.Race);
            cmd.Parameters.AddWithValue("@type", charac.TypePerso);
            cmd.Parameters.AddWithValue("@nomPerso", charac.Nom);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task UpdateCaracsPerso(Caracs caracs, string nomPerso)
        {
            const string sql = @"UPDATE carac
                                 SET
                                 Atk = @atk,
                                 Def = @def,
                                 Rap = @rapi
                                 WHERE Perso_Nom = @nomPerso";
            var cmd = new MySqlCommand(sql, Conn);
            cmd.Parameters.AddWithValue("@atk", caracs.Attaque);
            cmd.Parameters.AddWithValue("@def", caracs.Defense);
            cmd.Parameters.AddWithValue("@rapi", caracs.Rapidite);
            cmd.Parameters.AddWithValue("@nomPerso", nomPerso);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task UpdateStatsPerso(Stats stats, string nomPerso)
        {
            const string sql = @"UPDATE stat
                                 SET
                                 Phy = @physique,
                                 Mental = @mental,
                                 Social = @social
                                 WHERE Perso_Nom = @nomPerso";
            var cmd = new MySqlCommand(sql, Conn);
            cmd.Parameters.AddWithValue("@physique", stats.Physique);
            cmd.Parameters.AddWithValue("@mental", stats.Mental);
            cmd.Parameters.AddWithValue("@social", stats.Social);
            cmd.Parameters.AddWithValue("@nomPerso", nomPerso);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task UpdateJaugesPerso(Jauges jauge, string nomPerso)
        {
            const string sql = @"UPDATE jauge
                                 SET
                                 Vie = @vie,
                                 Vie_Max = @vieMax,
                                 Psy = @psy,
                                 Psy_Max = @psyMax,
                                 Sync = @sync,
                                 Sync_Max = @syncMax
                                 WHERE Perso_Nom = @nomPerso";
            var cmd = new MySqlCommand(sql, Conn);
            cmd.Parameters.AddWithValue("@vie", jauge.Pv);
            cmd.Parameters.AddWithValue("@vieMax", jauge.PvMax);
            cmd.Parameters.AddWithValue("@psy", jauge.Psy);
            cmd.Parameters.AddWithValue("@psyMax", jauge.PsyMax);
            cmd.Parameters.AddWithValue("@sync", jauge.Synchro);
            cmd.Parameters.AddWithValue("@syncMax", jauge.SynchroMax);
            cmd.Parameters.AddWithValue("@nomPerso", nomPerso);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task UpdateDemon(IEnumerable<Demon> demons)
        {
            const string sql = @"UPDATE demons
                                 SET
                                 Nom = @nom
                                 WHERE Nom = @nom";
            var cmd = new MySqlCommand(sql, Conn);
            foreach (var demon in demons)
            {
                cmd.Parameters.AddWithValue("@nom", demon.Nom);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateDemonPerso(IEnumerable<Demon> demons, string nomPerso)
        {
            const string sql = @"UPDATE demon_perso
                                 SET
                                 Demon_Nom = @nomDemon,
                                 WHERE Perso_Nom = @nomPerso";
            var cmd = new MySqlCommand(sql, Conn);
            foreach (var demon in demons)
            {
                cmd.Parameters.AddWithValue("@nomDemon", demon.Nom);
                cmd.Parameters.AddWithValue("@nomPerso", nomPerso);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateDons(IEnumerable<Don> dons)
        {
            const string sql = @"UPDATE don
                                 SET
                                 Libelle = @libelle,
                                 Description = @desc
                                 WHERE Libelle = @libelle";
            var cmd = new MySqlCommand(sql, Conn);

            foreach (var don in dons)
            {
                cmd.Parameters.AddWithValue("@libelle", don.Libelle);
                cmd.Parameters.AddWithValue("@desc", don.Description);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateDonsPerso(IEnumerable<Don> dons, string nomPerso)
        {
            const string sql = @"UPDATE don
                                 SET
                                 Libelle = @libelle,
                                 Description = @desc
                                 WHERE Libelle = @libelle";
            var cmd = new MySqlCommand(sql, Conn);

            foreach (var don in dons)
            {
                cmd.Parameters.AddWithValue("@libelle", don.Libelle);
                cmd.Parameters.AddWithValue("@desc", don.Description);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateElement(IEnumerable<Element> elements)
        {
            const string sql = @"UPDATE element`
                                 SET
                                 Libelle = @libelle,
                                 Description = @desc
                                 WHERE Libelle = @libelle";
            var cmd = new MySqlCommand(sql, Conn);

            foreach (var element in elements)
            {
                cmd.Parameters.AddWithValue("@libelle", element.Libelle);
                cmd.Parameters.AddWithValue("@desc", element.Description);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateElementPerso(IEnumerable<Element> elements, string nomPerso)
        {
            const string sql = @"UPDATE element_perso
                                 SET
                                 Element_Libelle = @element
                                 WHERE Perso_Nom = @nomPerso";
            var cmd = new MySqlCommand(sql, Conn);

            foreach (var element in elements)
            {
                cmd.Parameters.AddWithValue("@element", element.Libelle);
                cmd.Parameters.AddWithValue("@nomPerso", nomPerso);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateInventairePerso(Inventaire inventaire, string nomPerso)
        {
            const string sql = @"UPDATE inventaire
                                 SET
                                 Item_Nom = @itemNom,
                                 WHERE Perso_Nom = nomPerso";
            var cmd = new MySqlCommand(sql, Conn);

            foreach (var item in inventaire.Items)
            {
                cmd.Parameters.AddWithValue("@itemNom", item.Nom);
                cmd.Parameters.AddWithValue("@nomPerso", nomPerso);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateItem(Item item)
        {
            const string sql = @"UPDATE item
                                 SET
                                 Nom = @nom,
                                 Description = @desc,
                                 Type_Item = @type,
                                 Prix = @prix,
                                 Commentaire = @comm,
                                 Quantite = @qte
                                 WHERE `Nom` = @nom";
            var cmd = new MySqlCommand(sql, Conn);
            cmd.Parameters.AddWithValue("@nom", item.Nom);
            cmd.Parameters.AddWithValue("@desc", item.Description);
            cmd.Parameters.AddWithValue("@type", item.TypeItem);
            cmd.Parameters.AddWithValue("@prix", item.Prix);
            cmd.Parameters.AddWithValue("@comm", item.Commentaire);
            cmd.Parameters.AddWithValue("@qte", item.Quantite);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task UpdatePassifs(IEnumerable<Passif> passifs)
        {
            const string sql = @"UPDATE passif
                                 SET
                                 Libelle = @libelle,
                                 Description = @desc
                                 WHERE Libelle = @libelle";
            var cmd = new MySqlCommand(sql, Conn);

            foreach (var passif in passifs)
            {
                cmd.Parameters.AddWithValue("@libelle", passif.Libelle);
                cmd.Parameters.AddWithValue("@desc", passif.Description);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdatePassifsPerso(IEnumerable<Passif> passifs, string nomPerso)
        {
            const string sql = @"UPDATE passif_perso
                                 Passif_Libelle = @passif
                                 WHERE `Perso_Nom = @nomPerso";
            var cmd = new MySqlCommand(sql, Conn);

            foreach (var passif in passifs)
            {
                cmd.Parameters.AddWithValue("@passif", passif.Libelle);
                cmd.Parameters.AddWithValue("@nomPerso", nomPerso);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdatePassifsDemon(IEnumerable<Passif> passifs, string nomDemon)
        {
            const string sql = @"UPDATE passif_demon
                                 Passif_Libelle = @passif
                                 WHERE `Demon_Nom = @nomDemon";
            var cmd = new MySqlCommand(sql, Conn);

            foreach (var passif in passifs)
            {
                cmd.Parameters.AddWithValue("@passif", passif.Libelle);
                cmd.Parameters.AddWithValue("@nomDemon", nomDemon);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateSkills(IEnumerable<Skill> skills)
        {
            const string sql = @"UPDATE skill
                                 SET
                                 Libelle = @libelle,
                                 Description = @desc,
                                 Taux = @taux,
                                 Degats = @degats
                                 WHERE Libelle = @libelle";
            var cmd = new MySqlCommand(sql, Conn);

            foreach (var skill in skills)
            {
                cmd.Parameters.AddWithValue("@libelle", skill.Libelle);
                cmd.Parameters.AddWithValue("@desc", skill.Description);
                cmd.Parameters.AddWithValue("@taux", skill.Taux);
                cmd.Parameters.AddWithValue("@libelle", skill.Degats);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateSkillsPerso(IEnumerable<Skill> skills, string nomPerso)
        {
            const string sql = @"UPDATE skill_perso`
                                 SET
                                 Skill_Libelle = @skill
                                 WHERE Perso_Nom` = @nomPerso";
            var cmd = new MySqlCommand(sql, Conn);

            foreach (var skill in skills)
            {
                cmd.Parameters.AddWithValue("@skill", skill.Libelle);
                cmd.Parameters.AddWithValue("@nomPerso", nomPerso);
                await cmd.ExecuteNonQueryAsync();
            }
        }
    }
}