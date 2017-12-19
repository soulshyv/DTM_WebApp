using DTM.Core.Contracts;
using DTM.DbManager.Contracts;
using DTM.DbManager.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DTM.DbManager.Services
{
    public sealed class DtmRepository : IDtmRepository
    {
        public DtmRepository(IDtmDbConnection dbConnection)
        {
            Conn = dbConnection.DbConnection;
        }

        private MySqlConnection Conn { get; }


        /**************** SELECT ****************/

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

            var characs = new List<Character>();
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                if (reader == null)
                    throw new Exception("Une erreur est survenue");

                if (!reader.HasRows)
                {
                    reader.Close();
                    return null;
                }

                while (await reader.ReadAsync())
                {
                    characs.Add(new Character
                    {
                        Nom = reader["Nom"].ToString(),
                        Xp = reader["Xp"] != DBNull.Value ? Convert.ToInt16(reader["Xp"]) : 0,
                        Lvl = reader["Lvl"] != DBNull.Value ? Convert.ToInt16(reader["Lvl"]) : 0,
                        Po = reader["Po"] != DBNull.Value ? Convert.ToInt16(reader["Po"]) : 0,
                        Race = reader["Race"].ToString(),
                        TypePerso = reader["Type_Perso"].ToString()

                    });
                }
            }

            return characs;
        }

        public async Task<CharacterFull> GetFullPersoByName(string nomPerso)
        {
            Character charac;
            Caracs caracs;
            Jauges jauges;
            Stats stats;
            Inventaire Inventaire;
            var elements = new List<Element>();
            var skills = new List<Skill>();
            var dons = new List<DonPerso>();
            var demons = new List<Demon>();

            const string sql = @"SELECT
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
                                          WHERE `viewpersofull`.`Pseudo` = @nomPerso";
            var cmd = new MySqlCommand(sql, Conn);
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

                await reader.ReadAsync();
                charac = new Character
                {
                    Nom = nomPerso,
                    Race = reader["Race"].ToString(),
                    TypePerso = reader["Type de perso"].ToString()

                };
                if (reader["Experience"] == DBNull.Value)
                    charac.Xp = null;
                else
                    charac.Xp = Convert.ToInt16(reader["Experience"]);

                if (reader["Niveau"] == DBNull.Value)
                    charac.Lvl = null;
                else
                    charac.Lvl = Convert.ToInt16(reader["Niveau"]);

                if (reader["Piece d'or"] == DBNull.Value)
                    charac.Po = null;
                else
                    charac.Po = Convert.ToInt16(reader["Piece d'or"]);

                caracs = new Caracs();
                if (reader["Attaque"] == DBNull.Value)
                    caracs.Attaque = null;
                else
                    caracs.Attaque = Convert.ToInt16(reader["Attaque"]);

                if (reader["Defense"] == DBNull.Value)
                    caracs.Defense = null;
                else
                    caracs.Defense = Convert.ToInt16(reader["Defense"]);

                if (reader["Rapidite"] == DBNull.Value)
                    caracs.Rapidite = null;
                else
                    caracs.Rapidite = Convert.ToInt16(reader["Rapidite"]);

                jauges = new Jauges();
                if (reader["Point de vie"] == DBNull.Value)
                    jauges.Pv = null;
                else
                    jauges.Pv = Convert.ToInt16(reader["Point de vie"]);

                if (reader["Point de vie max"] == DBNull.Value)
                    jauges.PvMax = null;
                else
                    jauges.PvMax = Convert.ToInt16(reader["Point de vie max"]);

                if (reader["Point de psy"] == DBNull.Value)
                    jauges.Psy = null;
                else
                    jauges.Psy = Convert.ToInt16(reader["Point de psy"]);

                if (reader["Point de psy max"] == DBNull.Value)
                    jauges.PsyMax = null;
                else
                    jauges.PsyMax = Convert.ToInt16(reader["Point de psy max"]);

                if (reader["Point de synchro"] == DBNull.Value)
                    jauges.Synchro = null;
                else
                    jauges.Synchro = Convert.ToInt16(reader["Point de synchro"]);

                if (reader["Point de synchro max"] == DBNull.Value)
                    jauges.SynchroMax = null;
                else
                    jauges.SynchroMax = Convert.ToInt16(reader["Point de synchro max"]);

                stats = new Stats();
                if (reader["Physique"] == DBNull.Value)
                    stats.Physique = null;
                else
                    stats.Physique = Convert.ToInt16(reader["Physique"]);

                if (reader["Mental"] == DBNull.Value)
                    stats.Mental = null;
                else
                    stats.Mental = Convert.ToInt16(reader["Mental"]);

                if (reader["Social"] == DBNull.Value)
                    stats.Social = null;
                else
                    stats.Social = Convert.ToInt16(reader["Social"]);
            }

            Inventaire = await GetInventairePerso(nomPerso);
            elements = await GetElementPerso(nomPerso);
            skills = await GetSkillsPerso(nomPerso);
            dons = await GetDonsPerso(nomPerso);
            demons = await GetDemonPerso(nomPerso);

            return new CharacterFull(charac, caracs, jauges, stats, elements, skills, dons, demons, Inventaire);
        }

        public Task<Caracs> GetCaracsPerso(string nomPerso)
        {
            throw new NotImplementedException();
        }

        public Task<Jauges> GetJaugesPerso(string nomPerso)
        {
            throw new NotImplementedException();
        }

        public Task<Stats> GetStatsPerso(string nomPerso)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DonPerso>> GetDonsPerso(string nomPerso)
        {
            const string sql = @"SELECT
                                            `viewdonperso`.`Pseudo`,
                                            `viewdonperso`.`Competence`,
                                            `viewdonperso`.`Description`,
                                            `viewdonperso`.`Taux`
                                          FROM `jdr`.`viewdonperso`
                                          WHERE Pseudo = @NomPerso";
            var cmd = new MySqlCommand(sql, Conn);
            cmd.Parameters.AddWithValue("@nomPerso", nomPerso);

            var dons = new List<DonPerso>();
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                if (reader == null)
                    throw new Exception("Une erreur est survenue");

                if (!reader.HasRows)
                {
                    reader.Close();
                    return null;
                }

                while (await reader.ReadAsync())
                {
                    var donPerso = new DonPerso
                    {
                        Libelle = reader["Competence"].ToString(),
                        Description = reader["Description"].ToString()
                    };

                    if (reader["Taux"] == DBNull.Value)
                        donPerso.Taux = null;
                    else
                        donPerso.Taux = Convert.ToInt16(reader["Taux"]);

                    dons.Add(donPerso);
                }
            }

            return dons;
        }

        public async Task<List<Don>> GetAllDons()
        {
            const string sql = @"SELECT
                                            `don`.`Libelle`,
                                            `don`.`Description`
                                          FROM `jdr`.`don`";
            var cmd = new MySqlCommand(sql, Conn);

            var demons = new List<Don>();
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                if (reader == null)
                    throw new Exception("Une erreur est survenue");

                if (!reader.HasRows)
                {
                    reader.Close();
                    return null;
                }

                while (await reader.ReadAsync())
                {
                    demons.Add(new Don
                    {
                        Libelle = reader["Libelle"].ToString(),
                        Description = reader["Description"].ToString()
                    });
                }
            }

            return demons;
        }

        public async Task<List<Passif>> PassifsPerso(string nomPerso)
        {
            const string sql = @"SELECT
                                            `viewpassifdemon`.`Passif`
                                          FROM `jdr`.`viewpassifdemon`
                                          WHERE Pseudo = @nomPerso";
            var cmd = new MySqlCommand(sql, Conn);
            cmd.Parameters.AddWithValue("@nomPerso", nomPerso);

            var passifs = new List<Passif>();
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                if (reader == null)
                    throw new Exception("Une erreur est survenue");

                if (!reader.HasRows)
                {
                    reader.Close();
                    return null;
                }

                while (await reader.ReadAsync())
                {
                    passifs.Add(new Passif
                    {
                        Libelle = reader["Libelle"].ToString(),
                        Description = reader["Description"].ToString()
                    });
                }
            }

            return passifs;
        }

        public async Task<List<Passif>> PassifsDemon(string nomDemon)
        {
            const string sql = @"SELECT
                                            `viewpassifdemon`.`Passif`
                                          FROM `jdr`.`viewpassifdemon`
                                          WHERE Demon = @nomDemon";
            var cmd = new MySqlCommand(sql, Conn);
            cmd.Parameters.AddWithValue("@nomDemon", nomDemon);

            var passifs = new List<Passif>();
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                if (reader == null)
                    throw new Exception("Une erreur est survenue");

                if (!reader.HasRows)
                {
                    reader.Close();
                    return null;
                }

                while (await reader.ReadAsync())
                {
                    passifs.Add(new Passif
                    {
                        Libelle = reader["Libelle"].ToString(),
                        Description = reader["Description"].ToString()
                    });
                }
            }

            return passifs;
        }

        public async Task<List<Passif>> GetAllPassifs()
        {
            const string sql = @"SELECT
                                            `passif`.`Libelle`,
                                            `passif`.`Description`
                                          FROM `jdr`.`passif`";
            var cmd = new MySqlCommand(sql, Conn);

            var passifs = new List<Passif>();
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                if (reader == null)
                    throw new Exception("Une erreur est survenue");

                if (!reader.HasRows)
                {
                    reader.Close();
                    return null;
                }

                while (await reader.ReadAsync())
                {
                    passifs.Add(new Passif
                    {
                        Libelle = reader["Libelle"].ToString(),
                        Description = reader["Description"].ToString()
                    });
                }
            }

            return passifs;
        }

        public async Task<List<Demon>> GetAllDemons()
        {
            const string sql = @"SELECT
                                            `demon`.`Nom`
                                          FROM `jdr`.`demon`";
            var cmd = new MySqlCommand(sql, Conn);

            var demons = new List<Demon>();
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                if (reader == null)
                    throw new Exception("Une erreur est survenue");

                if (!reader.HasRows)
                {
                    reader.Close();
                    return null;
                }

                while (await reader.ReadAsync())
                {
                    demons.Add(new Demon
                    {
                        Nom = reader["Nom"].ToString()
                    });
                }
            }

            return demons;
        }

        public async Task<List<Demon>> GetDemonPerso(string nomPerso)
        {
            const string sql = @"SELECT
                                            `viewdemonperso`.`Demon`
                                          FROM `jdr`.`viewdemonperso`
                                          WHERE Pseudo = @NomPerso";
            var cmd = new MySqlCommand(sql, Conn);
            cmd.Parameters.AddWithValue("@nomPerso", nomPerso);

            var demons = new List<Demon>();
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                if (reader == null)
                    throw new Exception("Une erreur est survenue");

                if (!reader.HasRows)
                {
                    reader.Close();
                    return null;
                }

                while (await reader.ReadAsync())
                {
                    demons.Add(new Demon
                    {
                        Nom = reader["Demon"].ToString()
                    });
                }
            }

            return demons;
        }

        public async Task<Inventaire> GetInventairePerso(string nomPerso)
        {
            const string sql = @"SELECT
                                            `viewinventaire`.`Item`,
                                            `viewinventaire`.`Description`,
                                            `viewinventaire`.`Type d'item`,
                                            `viewinventaire`.`Prix`,
                                            `viewinventaire`.`Commentaire`,
                                            `viewinventaire`.`Quantite`
                                          FROM `jdr`.`viewinventaire`
                                          WHERE Pseudo = @NomPerso";
            var cmd = new MySqlCommand(sql, Conn);
            cmd.Parameters.AddWithValue("@nomPerso", nomPerso);

            var inventaire = new Inventaire();
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                if (reader == null)
                    throw new Exception("Une erreur est survenue");

                if (!reader.HasRows)
                {
                    reader.Close();
                    return null;
                }

                while (await reader.ReadAsync())
                {
                    var item = new Item
                    {
                        Nom = reader["Item"].ToString(),
                        Description = reader["Description"].ToString(),
                        TypeItem = reader["Type d'item"].ToString(),
                        Commentaire = reader["Commentaire"].ToString()
                    };

                    if (reader["Prix"] == DBNull.Value)
                        item.Prix = null;
                    else
                        item.Prix = Convert.ToInt16(reader["Prix"]);

                    if (reader["Quantite"] == DBNull.Value)
                        item.Quantite = null;
                    else
                        item.Quantite = Convert.ToInt16(reader["Quantite"]);

                    inventaire.Items.Add(item);
                }
            }

            return inventaire;
        }

        public async Task<Item> GetItemByNom(string nomItem)
        {
            const string sql = @"SELECT
                                            `item`.`Nom`,
                                            `item`.`Description`,
                                            `item`.`Type_Item`,
                                            `item`.`Prix`,
                                            `item`.`Commentaire`,
                                            `item`.`Quantite`
                                          FROM `jdr`.`item`
                                          WHERE Nom = @nomItem";
            var cmd = new MySqlCommand(sql, Conn);
            cmd.Parameters.AddWithValue("@nomItem", nomItem);

            Item item;
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                if (reader == null)
                    throw new Exception("Une erreur est survenue");

                if (!reader.HasRows)
                {
                    reader.Close();
                    return null;
                }

                await reader.ReadAsync();
                item = new Item
                {
                    Nom = reader["Item"].ToString(),
                    Description = reader["Description"].ToString(),
                    TypeItem = reader["Type d'item"].ToString(),
                    Commentaire = reader["Commentaire"].ToString(),
                };

                if (reader["Prix"] == DBNull.Value)
                    item.Prix = null;
                else
                    item.Prix = Convert.ToInt16(reader["Prix"]);

                if (reader["Quantite"] == DBNull.Value)
                    item.Quantite = null;
                else
                    item.Quantite = Convert.ToInt16(reader["Quantite"]);
            }

            return item;
        }

        public async Task<Character> GetPersoByNom(string nomPerso)
        {
            const string sql = @"SELECT
                                    perso.Nom,
                                    perso.Xp,
                                    perso.Lvl,
                                    perso.Po,
                                    perso.Race,
                                    perso.Type_Perso
                                 FROM jdr.perso
                                 WHERE perso.Nom = @nomPerso";
            var cmd = new MySqlCommand(sql, Conn);
            cmd.Parameters.AddWithValue("@nomPerso", nomPerso);

            Character charac;
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                if (reader == null)
                    throw new Exception("Une erreur est survenue");

                if (!reader.HasRows)
                {
                    reader.Close();
                    return null;
                }

                await reader.ReadAsync();
                charac = new Character
                {
                    Nom = reader["Nom"].ToString(),
                    Race = reader["Race"].ToString(),
                    TypePerso = reader["Type_Perso"].ToString()

                };

                if (reader["Xp"] == DBNull.Value)
                    charac.Xp = null;
                else
                    charac.Xp = Convert.ToInt16(reader["Xp"]);

                if (reader["Lvl"] == DBNull.Value)
                    charac.Lvl = null;
                else
                    charac.Lvl = Convert.ToInt16(reader["Lvl"]);

                if (reader["Po"] == DBNull.Value)
                    charac.Po = null;
                else
                    charac.Po = Convert.ToInt16(reader["Po"]);
            }

            return charac;
        }

        public async Task<List<Skill>> GetSkillsPerso(string nomPerso)
        {
            const string sql = @"SELECT
                                            `viewskillperso`.`Skill`,
                                            `viewskillperso`.`Description`,
                                            `viewskillperso`.`Taux`,
                                            `viewskillperso`.`Degats`
                                          FROM `jdr`.`viewskillperso`
                                          WHERE Pseudo = @NomPerso";
            var cmd = new MySqlCommand(sql, Conn);
            cmd.Parameters.AddWithValue("@nomPerso", nomPerso);

            var skills = new List<Skill>();
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                if (reader == null)
                    throw new Exception("Une erreur est survenue");

                if (!reader.HasRows)
                {
                    reader.Close();
                    return null;
                }

                while (await reader.ReadAsync())
                {
                    var skill = new Skill
                    {
                        Libelle = reader["Skill"].ToString(),
                        Description = reader["Description"].ToString(),
                        Degats = reader["Description"].ToString()
                    };

                    if (reader["Taux"] == DBNull.Value)
                        skill.Taux = null;
                    else
                        skill.Taux = Convert.ToInt16(reader["Taux"]);

                    skills.Add(skill);
                }
            }

            return skills;
        }

        public async Task<List<Skill>> GetAllSkills()
        {
            const string sql = @"SELECT
                                            `skill`.`Libelle`,
                                            `skill`.`Description`,
                                            `skill`.`Taux`,
                                            `skill`.`Degats`
                                          FROM `jdr`.`skill`";
            var cmd = new MySqlCommand(sql, Conn);

            var skills = new List<Skill>();
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                if (reader == null)
                    throw new Exception("Une erreur est survenue");

                if (!reader.HasRows)
                {
                    reader.Close();
                    return null;
                }

                while (await reader.ReadAsync())
                {
                    var skill = new Skill
                    {
                        Libelle = reader["Skill"].ToString(),
                        Description = reader["Description"].ToString(),
                        Degats = reader["Degats"] == DBNull.Value ? null : reader["Degats"].ToString()
                    };

                    if (reader["Taux"] == DBNull.Value)
                        skill.Taux = null;
                    else
                        skill.Taux = Convert.ToInt16(reader["Taux"]);

                    skills.Add(skill);
                }
            }

            return skills;
        }

        public async Task<List<Element>> GetAllEllements()
        {
            const string sql = @"SELECT
                                            `element`.`Libelle`,
                                            `element`.`Description`
                                          FROM `jdr`.`element``";
            var cmd = new MySqlCommand(sql, Conn);

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

                while (await reader.ReadAsync())
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

        public async Task<List<Element>> GetElementPerso(string nomPerso)
        {
            const string sql = @"SELECT
                                              `viewelementperso`.`Libelle`,
                                              `viewelementperso`.`Description`,
                                              `viewelementperso`.`Pseudo`
                                          FROM `jdr`.`viewelementperso`
                                          WHERE `Pseudo` =  @nomPerso";
            var cmd = new MySqlCommand(sql, Conn);
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

                while (await reader.ReadAsync())
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

        public async Task UpdatePerso(Character charac)
        {
            const string sql = @"UPDATE carac
                                 SET
                                 Xp = @xp,
                                 Lvl = @lvl,
                                 Po = @po,
                                 Race = @race,
                                 Type_Perso = @type
                                 WHERE Perso_Nom = @nomPerso";
            var cmd = new MySqlCommand(sql, Conn);
            cmd.Parameters.AddWithValue("@xp", charac.Xp);
            cmd.Parameters.AddWithValue("@lvl", charac.Lvl);
            cmd.Parameters.AddWithValue("@po", charac.Po);
            cmd.Parameters.AddWithValue("@race", charac.Race);
            cmd.Parameters.AddWithValue("@type", charac.TypePerso);
            cmd.Parameters.AddWithValue("@nomPerso", charac.Nom);
            await cmd.ExecuteNonQueryAsync();
        }

        /**************** UPDATE ****************/

        public async Task UpdateStatsPerso(Caracs caracs, string nomPerso)
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

        public async Task UpdateDemon(List<Demon> demons)
        {
            const string sql = @"UPDATE demons
                                 SET
                                 Nom = @nom
                                 WHERE Nom = @nom";
            var cmd = new MySqlCommand(sql, Conn);
            foreach(var demon in demons)
            {
                cmd.Parameters.AddWithValue("@nom", demon.Nom);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateDemonPerso(List<Demon> demons, string nomPerso)
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

        public async Task UpdateDons(List<Don> dons)
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

        public async Task UpdateDonsPerso(List<Don> dons, string nomPerso)
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

        public async Task UpdateElement(List<Element> elements)
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

        public async Task UpdateElementPerso(List<Element> elements, string nomPerso)
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

        public async Task UpdateInventairePerso(Inventaire inventaire, string nomPerso)
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

        public async Task UpdateItem(Item item)
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

        public async Task UpdateJaugesPerso(Jauges jauge, string nomPerso)
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

        public async Task UpdatePassifs(List<Passif> passifs)
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

        public async Task UpdatePassifsPerso(List<Passif> passifs, string nomPerso)
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

        public async Task UpdateSkills(List<Skill> skills)
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

        public async Task UpdateSkillsPerso(List<Skill> skills, string nomPerso)
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

        /**************** DELETE ****************/

        /**************** INSERT ****************/
    }
}
 