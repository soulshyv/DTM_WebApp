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
                        Xp = Convert.ToInt16(reader["Xp"]),
                        Lvl = Convert.ToInt16(reader["Lvl"]),
                        Po = Convert.ToInt16(reader["Po"]),
                        Race = reader["Race"].ToString(),
                        TypePerso = reader["Type_Perso"].ToString()

                    });
                }
            }

            return characs;
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

                await reader.ReadAsync();
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

        public async Task<List<DonsPerso>> GetDonsPerso(string nomPerso)
        {
            const string elementPerso = @"SELECT
                                            `viewdonperso`.`Pseudo`,
                                            `viewdonperso`.`Competence`,
                                            `viewdonperso`.`Description`,
                                            `viewdonperso`.`Taux`
                                          FROM `jdr`.`viewdonperso`
                                          WHERE Pseudo = @NomPerso";
            var cmd = new MySqlCommand(elementPerso, Conn);
            cmd.Parameters.AddWithValue("@nomPerso", nomPerso);

            var dons = new List<DonsPerso>();
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
                    dons.Add(new DonsPerso
                    {
                        Libelle = reader["Libelle"].ToString(),
                        Description = reader["Description"].ToString(),
                        Taux = Convert.ToInt16(reader["Taux"])
                    });
                }
            }

            return dons;
        }

        public async Task<List<Don>> GetAllDons()
        {
            const string elementPerso = @"SELECT
                                            `don`.`Libelle`,
                                            `don`.`Description`
                                          FROM `jdr`.`don`";
            var cmd = new MySqlCommand(elementPerso, Conn);

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
            const string elementPerso = @"SELECT
                                            `viewpassifdemon`.`Passif`
                                          FROM `jdr`.`viewpassifdemon`
                                          WHERE Pseudo = @nomPerso";
            var cmd = new MySqlCommand(elementPerso, Conn);
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
            const string elementPerso = @"SELECT
                                            `viewpassifdemon`.`Passif`
                                          FROM `jdr`.`viewpassifdemon`
                                          WHERE Demon = @nomDemon";
            var cmd = new MySqlCommand(elementPerso, Conn);
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
            const string elementPerso = @"SELECT
                                            `passif`.`Libelle`,
                                            `passif`.`Description`
                                          FROM `jdr`.`passif`";
            var cmd = new MySqlCommand(elementPerso, Conn);

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
            const string elementPerso = @"SELECT
                                            `demon`.`Nom`
                                          FROM `jdr`.`demon`";
            var cmd = new MySqlCommand(elementPerso, Conn);

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
            const string elementPerso = @"SELECT
                                            `viewdemonperso`.`Demon`
                                          FROM `jdr`.`viewdemonperso`
                                          WHERE Pseudo = @NomPerso";
            var cmd = new MySqlCommand(elementPerso, Conn);
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
            const string elementPerso = @"SELECT
                                            `viewinventaire`.`Item`,
                                            `viewinventaire`.`Description`,
                                            `viewinventaire`.`Type d'item`,
                                            `viewinventaire`.`Prix`,
                                            `viewinventaire`.`Commentaire`,
                                            `viewinventaire`.`Quantite`
                                          FROM `jdr`.`viewinventaire`
                                          WHERE Pseudo = @NomPerso";
            var cmd = new MySqlCommand(elementPerso, Conn);
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
                    inventaire.Items.Add(new Item
                    {
                        Nom = reader["Item"].ToString(),
                        Description = reader["Description"].ToString(),
                        TypeItem = reader["Type d'item"].ToString(),
                        Prix = Convert.ToInt16(reader["Prix"]),
                        Commentaire = reader["Commentaire"].ToString(),
                        Quantite = Convert.ToInt16(reader["Quantite"])
                    });
                }
            }

            return inventaire;
        }

        public async Task<Item> GetItemByNom(string nomItem)
        {
            const string elementPerso = @"SELECT
                                            `item`.`Nom`,
                                            `item`.`Description`,
                                            `item`.`Type_Item`,
                                            `item`.`Prix`,
                                            `item`.`Commentaire`,
                                            `item`.`Quantite`
                                          FROM `jdr`.`item`
                                          WHERE Nom = @nomItem";
            var cmd = new MySqlCommand(elementPerso, Conn);
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
                    Prix = Convert.ToInt16(reader["Prix"]),
                    Commentaire = reader["Commentaire"].ToString(),
                    Quantite = Convert.ToInt16(reader["Quantite"])
                };
            }

            return item;
        }

        public async Task<Character> GetPersoByName(string nomPerso)
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
                    Xp = Convert.ToInt16(reader["Xp"]),
                    Lvl = Convert.ToInt16(reader["Lvl"]),
                    Po = Convert.ToInt16(reader["Po"]),
                    Race = reader["Race"].ToString(),
                    TypePerso = reader["Type_Perso"].ToString()

                };
            }

            return charac;
        }

        public async Task<List<Skill>> GetSkillsPerso(string nomPerso)
        {
            const string elementPerso = @"SELECT
                                            `viewskillperso`.`Skill`,
                                            `viewskillperso`.`Description`,
                                            `viewskillperso`.`Taux`,
                                            `viewskillperso`.`Degats`
                                          FROM `jdr`.`viewskillperso`
                                          WHERE Pseudo = @NomPerso";
            var cmd = new MySqlCommand(elementPerso, Conn);
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
                    skills.Add(new Skill
                    {
                        Libelle = reader["Skill"].ToString(),
                        Description = reader["Description"].ToString(),
                        Taux = Convert.ToInt16(reader["Taux"]),
                        Degats = reader["Description"].ToString()
                    });
                }
            }

            return skills;
        }

        public async Task<List<Skill>> GetAllSkills()
        {
            const string elementPerso = @"SELECT
                                            `skill`.`Libelle`,
                                            `skill`.`Description`,
                                            `skill`.`Taux`,
                                            `skill`.`Degats`
                                          FROM `jdr`.`skill`";
            var cmd = new MySqlCommand(elementPerso, Conn);

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
                    skills.Add(new Skill
                    {
                        Libelle = reader["Skill"].ToString(),
                        Description = reader["Description"].ToString(),
                        Taux = Convert.ToInt16(reader["Taux"]),
                        Degats = reader["Description"].ToString()
                    });
                }
            }

            return skills;
        }

        public async Task<List<Element>> GetAllEllements()
        {
            const string elementPerso = @"SELECT
                                            `element`.`Libelle`,
                                            `element`.`Description`
                                          FROM `jdr`.`element``";
            var cmd = new MySqlCommand(elementPerso, Conn);

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
            const string elementPerso = @"SELECT
                                              `viewelementperso`.`Libelle`,
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
    }
}