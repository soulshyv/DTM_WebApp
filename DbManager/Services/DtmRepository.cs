using System;
using System.Collections.Generic;
using System.Linq;
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
            const string sql = @"SELECT
                                    perso.Nom,
                                    perso.Xp,
                                    perso.Lvl,
                                    perso.Po,
                                    perso.Race,
                                    perso.Type_Perso
                                 FROM jdr.perso";
            var cmd = new MySqlCommand(sql, Conn);

            var ret = new List<Character>();
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                if (reader == null)
                    throw new Exception("Une erreur est survenue");

                if (!reader.HasRows)
                {
                    reader.Close();
                    return null;
                }

                while (reader.Read())
                {
                    ret.Add(new Character
                    {
                        Nom = reader["Nom"].ToString(),
                        Xp = Convert.ToInt16(reader["Xp"]),
                        Lvl = Convert.ToInt16(reader["Lvl"]),
                        Po = Convert.ToInt16(reader["Po"]),
                        Race = reader["Race"].ToString(),
                        TypePerso = reader["Type_Perso"].ToString()

                    });
                }
            }

            return ret;
        }

        public async Task<CharacterFull> GetFullPersoByName(string nomPerso)
        {
            Character Perso;
            CaracsPerso Caracs;
            JaugesPerso Jauges;
            StatsPerso Stats;
            var Elements = new List<Element>();
            const string viewFullPerso = @"SELECT
                                    `viewpersofull`.`Pseudo`,
                                    `viewpersofull`.`Experience`,
                                    `viewpersofull`.`Niveau`,
                                    `viewpersofull`.`Piece d'or`,
                                    `viewpersofull`.`Race`,
                                    `viewpersofull`.`Type de perso`,
                                    `viewpersofull`.`Attaque`,
                                    `viewpersofull`.`Defense`,
                                    `viewpersofull`.`Rapidite`,
                                    `viewpersofull`.`Point de vie`,
                                    `viewpersofull`.`Point de vie max`,
                                    `viewpersofull`.`Point de psy`,
                                    `viewpersofull`.`Point de psy max`,
                                    `viewpersofull`.`Point de synchro`,
                                    `viewpersofull`.`Point de synchro max`,
                                    `viewpersofull`.`Physique`,
                                    `viewpersofull`.`Mental`,
                                    `viewpersofull`.`Social`
                                FROM `jdr`.`viewpersofull`
                                WHERE `Perso` = @nomPerso";
            var cmd = new MySqlCommand(viewFullPerso, Conn);
            cmd.Parameters.AddWithValue("@nomPerso", nomPerso);

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                if (reader == null)
                    throw new Exception("Une erreur est survenue");

                if (!reader.HasRows)
                {
                    reader.Close();
                    return null;
                }

                reader.Read();
                Perso = new Character
                {
                    Nom = reader["Pseudo"].ToString(),
                    Xp = Convert.ToInt16(reader["Experience"]),
                    Lvl = Convert.ToInt16(reader["Niveau"]),
                    Po = Convert.ToInt16(reader["Piece d'or"]),
                    Race = reader["Race"].ToString(),
                    TypePerso = reader["Type de perso"].ToString()

                };
                Caracs = new CaracsPerso
                {
                    NomPerso = reader["Pseudo"].ToString(),
                    Attaque = Convert.ToInt16(reader["Attaque"]),
                    Defense = Convert.ToInt16(reader["Defense"]),
                    Rapidite = Convert.ToInt16(reader["Rapidite"])
                };
                Jauges = new JaugesPerso
                {
                    NomPerso = reader["Pseudo"].ToString(),
                    Pv = Convert.ToInt16(reader["Point de vie"]),
                    PvMax = Convert.ToInt16(reader["Point de vie max"]),
                    Psy = Convert.ToInt16(reader["Point de psy"]),
                    PsyMax = Convert.ToInt16(reader["Point de psy max"]),
                    Synchro = Convert.ToInt16(reader["Point de synchro"]),
                    SynchroMax = Convert.ToInt16(reader["Point de synchro max"]),
                };
                Stats = new StatsPerso
                {
                    NomPerso = reader["Pseudo"].ToString(),
                    Physique = Convert.ToInt16(reader["Physique"]),
                    Mental = Convert.ToInt16(reader["Mental"]),
                    Social = Convert.ToInt16(reader["Social"]),
                };
            }

            Elements = await GetElementPerso(nomPerso);


            return ret;
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

        public async Task<List<Element>> GetElementPerso(string nomPerso)
        {
            const string elementPerso = @"SELECT `viewelementperso`.`Libelle`,
                                              `viewelementperso`.`Description`,
                                              `viewelementperso`.`Pseudo`
                                          FROM `jdr`.`viewelementperso`
                                          WHERE `Perso` =  @nomPerso";
            var cmd = new MySqlCommand(elementPerso, Conn);
            cmd.Parameters.AddWithValue("@nomPerso", nomPerso);

            var elements = new List<Element>();
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                if (reader == null)
                    throw new Exception("Une erreur est survenue");

                if (!reader.HasRows)
                {
                    reader.Close();
                    return null;
                }

                while (reader.Read())
                {
                    elements.Add(new Element
                    {
                        Libelle = reader["Libelle"].ToString(),
                        Description = reader["Description"].ToString()
                    });
                }
            }

            return elements;
        }
    }
}