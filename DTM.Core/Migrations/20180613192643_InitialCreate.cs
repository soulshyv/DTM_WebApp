using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DTM.Core.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "demon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_demon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "don",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Libelle = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true, defaultValueSql: "''")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_don", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "element",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Libelle = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true, defaultValueSql: "''")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_element", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true, defaultValueSql: "''"),
                    Type_Item = table.Column<int>(type: "int(11)", nullable: false),
                    Prix = table.Column<int>(type: "int(11)", nullable: true),
                    Commentaire = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "metier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Libelle = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true, defaultValueSql: "''")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_metier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "passif",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Libelle = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true, defaultValueSql: "''")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passif", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "perso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(maxLength: 50, nullable: false),
                    Xp = table.Column<int>(type: "int(11)", nullable: true),
                    Lvl = table.Column<int>(type: "int(11)", nullable: false),
                    Po = table.Column<int>(type: "int(11)", nullable: true),
                    Race = table.Column<string>(maxLength: 50, nullable: false),
                    Type_Perso = table.Column<int>(type: "int(11)", nullable: true),
                    Caracs = table.Column<string>(maxLength: 512, nullable: false),
                    Jauges = table.Column<string>(maxLength: 512, nullable: false),
                    Stats = table.Column<string>(maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "skill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Libelle = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true, defaultValueSql: "''"),
                    Taux = table.Column<int>(type: "int(11)", nullable: true),
                    Degats = table.Column<string>(type: "char(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "passif_demon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Passif_Id = table.Column<int>(type: "int(11)", nullable: false),
                    Demon_Id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passif_demon", x => x.Id);
                    table.ForeignKey(
                        name: "fk_passifDemon_demon",
                        column: x => x.Demon_Id,
                        principalTable: "demon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_passifDemon_passif",
                        column: x => x.Passif_Id,
                        principalTable: "passif",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "demon_perso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Demon_Id = table.Column<int>(type: "int(11)", nullable: false),
                    Perso_Id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_demon_perso", x => x.Id);
                    table.ForeignKey(
                        name: "fk_demonPerso_demon",
                        column: x => x.Demon_Id,
                        principalTable: "demon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_demonPerso_perso",
                        column: x => x.Perso_Id,
                        principalTable: "perso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "don_perso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Don_Id = table.Column<int>(type: "int(11)", nullable: false),
                    Perso_Id = table.Column<int>(type: "int(11)", nullable: false),
                    Taux = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_don_perso", x => x.Id);
                    table.ForeignKey(
                        name: "fk_donPerso_don",
                        column: x => x.Don_Id,
                        principalTable: "don",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_donPerso_perso",
                        column: x => x.Perso_Id,
                        principalTable: "perso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "element_perso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Element_Id = table.Column<int>(type: "int(11)", nullable: false),
                    Perso_Id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_element_perso", x => x.Id);
                    table.ForeignKey(
                        name: "fk_elementPerso_element",
                        column: x => x.Element_Id,
                        principalTable: "element",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_elementPerso_perso",
                        column: x => x.Perso_Id,
                        principalTable: "perso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inventaire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Item_Id = table.Column<int>(type: "int(11)", nullable: false),
                    Perso_Id = table.Column<int>(type: "int(11)", nullable: false),
                    Quantite = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventaire", x => x.Id);
                    table.ForeignKey(
                        name: "fk_inventaire_item",
                        column: x => x.Item_Id,
                        principalTable: "item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_inventaire_perso",
                        column: x => x.Perso_Id,
                        principalTable: "perso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "metier_perso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Metier_Id = table.Column<int>(type: "int(11)", nullable: false),
                    Perso_Id = table.Column<int>(type: "int(11)", nullable: false),
                    Lvl = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_metier_perso", x => x.Id);
                    table.ForeignKey(
                        name: "fk_metierPerso_metier",
                        column: x => x.Metier_Id,
                        principalTable: "metier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_metierPerso_perso",
                        column: x => x.Perso_Id,
                        principalTable: "perso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "passif_perso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Passif_Id = table.Column<int>(type: "int(11)", nullable: false),
                    Perso_Id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passif_perso", x => x.Id);
                    table.ForeignKey(
                        name: "fk_passifPerso_passif",
                        column: x => x.Passif_Id,
                        principalTable: "passif",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_passifPerso_perso",
                        column: x => x.Perso_Id,
                        principalTable: "perso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    Pwd = table.Column<string>(maxLength: 50, nullable: false),
                    Perso_Id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                    table.ForeignKey(
                        name: "fk_users_perso",
                        column: x => x.Perso_Id,
                        principalTable: "perso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "skill_perso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Skill_Id = table.Column<int>(type: "int(11)", nullable: false),
                    Perso_Id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skill_perso", x => x.Id);
                    table.ForeignKey(
                        name: "fk_skillPerso_perso",
                        column: x => x.Perso_Id,
                        principalTable: "perso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_skillPerso_skill",
                        column: x => x.Skill_Id,
                        principalTable: "skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "fk_demonPerso_demon",
                table: "demon_perso",
                column: "Demon_Id");

            migrationBuilder.CreateIndex(
                name: "fk_demonPerso_perso",
                table: "demon_perso",
                column: "Perso_Id");

            migrationBuilder.CreateIndex(
                name: "fk_donPerso_don",
                table: "don_perso",
                column: "Don_Id");

            migrationBuilder.CreateIndex(
                name: "fk_donPerso_perso",
                table: "don_perso",
                column: "Perso_Id");

            migrationBuilder.CreateIndex(
                name: "fk_elementPerso_element",
                table: "element_perso",
                column: "Element_Id");

            migrationBuilder.CreateIndex(
                name: "fk_elementPerso_perso",
                table: "element_perso",
                column: "Perso_Id");

            migrationBuilder.CreateIndex(
                name: "fk_inventaire_item",
                table: "inventaire",
                column: "Item_Id");

            migrationBuilder.CreateIndex(
                name: "fk_inventaire_perso",
                table: "inventaire",
                column: "Perso_Id");

            migrationBuilder.CreateIndex(
                name: "fk_metierPerso_metier",
                table: "metier_perso",
                column: "Metier_Id");

            migrationBuilder.CreateIndex(
                name: "fk_metierPerso_perso",
                table: "metier_perso",
                column: "Perso_Id");

            migrationBuilder.CreateIndex(
                name: "fk_passifDemon_demon",
                table: "passif_demon",
                column: "Demon_Id");

            migrationBuilder.CreateIndex(
                name: "fk_passifDemon_passif",
                table: "passif_demon",
                column: "Passif_Id");

            migrationBuilder.CreateIndex(
                name: "fk_passifPerso_passif",
                table: "passif_perso",
                column: "Passif_Id");

            migrationBuilder.CreateIndex(
                name: "fk_passifPerso_perso",
                table: "passif_perso",
                column: "Perso_Id");

            migrationBuilder.CreateIndex(
                name: "fk_skillPerso_perso",
                table: "skill_perso",
                column: "Perso_Id");

            migrationBuilder.CreateIndex(
                name: "fk_skillPerso_skill",
                table: "skill_perso",
                column: "Skill_Id");

            migrationBuilder.CreateIndex(
                name: "fk_users_perso",
                table: "user",
                column: "Perso_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "demon_perso");

            migrationBuilder.DropTable(
                name: "don_perso");

            migrationBuilder.DropTable(
                name: "element_perso");

            migrationBuilder.DropTable(
                name: "inventaire");

            migrationBuilder.DropTable(
                name: "metier_perso");

            migrationBuilder.DropTable(
                name: "passif_demon");

            migrationBuilder.DropTable(
                name: "passif_perso");

            migrationBuilder.DropTable(
                name: "skill_perso");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "don");

            migrationBuilder.DropTable(
                name: "element");

            migrationBuilder.DropTable(
                name: "item");

            migrationBuilder.DropTable(
                name: "metier");

            migrationBuilder.DropTable(
                name: "demon");

            migrationBuilder.DropTable(
                name: "passif");

            migrationBuilder.DropTable(
                name: "skill");

            migrationBuilder.DropTable(
                name: "perso");
        }
    }
}
