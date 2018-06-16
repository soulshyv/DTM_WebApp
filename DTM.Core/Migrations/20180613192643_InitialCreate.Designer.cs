﻿// <auto-generated />
using System;
using DTM.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DTM.Core.Migrations
{
    [DbContext(typeof(JdrContext))]
    [Migration("20180613192643_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799");

            modelBuilder.Entity("DTM.Core.Models.Demon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("demon");
                });

            modelBuilder.Entity("DTM.Core.Models.DemonPerso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int>("DemonId")
                        .HasColumnName("Demon_Id")
                        .HasColumnType("int(11)");

                    b.Property<int>("PersoId")
                        .HasColumnName("Perso_Id")
                        .HasColumnType("int(11)");

                    b.HasKey("Id");

                    b.HasIndex("DemonId")
                        .HasName("fk_demonPerso_demon");

                    b.HasIndex("PersoId")
                        .HasName("fk_demonPerso_perso");

                    b.ToTable("demon_perso");
                });

            modelBuilder.Entity("DTM.Core.Models.Don", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Description")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("''")
                        .HasMaxLength(1000);

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("don");
                });

            modelBuilder.Entity("DTM.Core.Models.DonPerso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int>("DonId")
                        .HasColumnName("Don_Id")
                        .HasColumnType("int(11)");

                    b.Property<int>("PersoId")
                        .HasColumnName("Perso_Id")
                        .HasColumnType("int(11)");

                    b.Property<int>("Taux")
                        .HasColumnType("int(11)");

                    b.HasKey("Id");

                    b.HasIndex("DonId")
                        .HasName("fk_donPerso_don");

                    b.HasIndex("PersoId")
                        .HasName("fk_donPerso_perso");

                    b.ToTable("don_perso");
                });

            modelBuilder.Entity("DTM.Core.Models.Element", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Description")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("''")
                        .HasMaxLength(1000);

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("element");
                });

            modelBuilder.Entity("DTM.Core.Models.ElementPerso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int>("ElementId")
                        .HasColumnName("Element_Id")
                        .HasColumnType("int(11)");

                    b.Property<int>("PersoId")
                        .HasColumnName("Perso_Id")
                        .HasColumnType("int(11)");

                    b.HasKey("Id");

                    b.HasIndex("ElementId")
                        .HasName("fk_elementPerso_element");

                    b.HasIndex("PersoId")
                        .HasName("fk_elementPerso_perso");

                    b.ToTable("element_perso");
                });

            modelBuilder.Entity("DTM.Core.Models.Inventaire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int>("ItemId")
                        .HasColumnName("Item_Id")
                        .HasColumnType("int(11)");

                    b.Property<int>("PersoId")
                        .HasColumnName("Perso_Id")
                        .HasColumnType("int(11)");

                    b.Property<int>("Quantite")
                        .HasColumnType("int(11)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId")
                        .HasName("fk_inventaire_item");

                    b.HasIndex("PersoId")
                        .HasName("fk_inventaire_perso");

                    b.ToTable("inventaire");
                });

            modelBuilder.Entity("DTM.Core.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Commentaire")
                        .HasMaxLength(1000);

                    b.Property<string>("Description")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("''")
                        .HasMaxLength(1000);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("Prix")
                        .HasColumnType("int(11)");

                    b.Property<int>("TypeItem")
                        .HasColumnName("Type_Item")
                        .HasColumnType("int(11)");

                    b.HasKey("Id");

                    b.ToTable("item");
                });

            modelBuilder.Entity("DTM.Core.Models.Metier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Description")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("''")
                        .HasMaxLength(1000);

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("metier");
                });

            modelBuilder.Entity("DTM.Core.Models.MetierPerso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int?>("Lvl")
                        .HasColumnType("int(11)");

                    b.Property<int>("MetierId")
                        .HasColumnName("Metier_Id")
                        .HasColumnType("int(11)");

                    b.Property<int>("PersoId")
                        .HasColumnName("Perso_Id")
                        .HasColumnType("int(11)");

                    b.HasKey("Id");

                    b.HasIndex("MetierId")
                        .HasName("fk_metierPerso_metier");

                    b.HasIndex("PersoId")
                        .HasName("fk_metierPerso_perso");

                    b.ToTable("metier_perso");
                });

            modelBuilder.Entity("DTM.Core.Models.Passif", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Description")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("''")
                        .HasMaxLength(1000);

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("passif");
                });

            modelBuilder.Entity("DTM.Core.Models.PassifDemon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int>("DemonId")
                        .HasColumnName("Demon_Id")
                        .HasColumnType("int(11)");

                    b.Property<int>("PassifId")
                        .HasColumnName("Passif_Id")
                        .HasColumnType("int(11)");

                    b.HasKey("Id");

                    b.HasIndex("DemonId")
                        .HasName("fk_passifDemon_demon");

                    b.HasIndex("PassifId")
                        .HasName("fk_passifDemon_passif");

                    b.ToTable("passif_demon");
                });

            modelBuilder.Entity("DTM.Core.Models.PassifPerso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int>("PassifId")
                        .HasColumnName("Passif_Id")
                        .HasColumnType("int(11)");

                    b.Property<int>("PersoId")
                        .HasColumnName("Perso_Id")
                        .HasColumnType("int(11)");

                    b.HasKey("Id");

                    b.HasIndex("PassifId")
                        .HasName("fk_passifPerso_passif");

                    b.HasIndex("PersoId")
                        .HasName("fk_passifPerso_perso");

                    b.ToTable("passif_perso");
                });

            modelBuilder.Entity("DTM.Core.Models.Perso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Caracs")
                        .IsRequired()
                        .HasMaxLength(512);

                    b.Property<string>("Jauges")
                        .IsRequired()
                        .HasMaxLength(512);

                    b.Property<int>("Lvl")
                        .HasColumnType("int(11)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("Po")
                        .HasColumnType("int(11)");

                    b.Property<string>("Race")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Stats")
                        .IsRequired()
                        .HasMaxLength(512);

                    b.Property<int?>("TypePerso")
                        .HasColumnName("Type_Perso")
                        .HasColumnType("int(11)");

                    b.Property<int?>("Xp")
                        .HasColumnType("int(11)");

                    b.HasKey("Id");

                    b.ToTable("perso");
                });

            modelBuilder.Entity("DTM.Core.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Degats")
                        .HasColumnType("char(6)");

                    b.Property<string>("Description")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("''")
                        .HasMaxLength(1000);

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int?>("Taux")
                        .HasColumnType("int(11)");

                    b.HasKey("Id");

                    b.ToTable("skill");
                });

            modelBuilder.Entity("DTM.Core.Models.SkillPerso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int>("PersoId")
                        .HasColumnName("Perso_Id")
                        .HasColumnType("int(11)");

                    b.Property<int>("SkillId")
                        .HasColumnName("Skill_Id")
                        .HasColumnType("int(11)");

                    b.HasKey("Id");

                    b.HasIndex("PersoId")
                        .HasName("fk_skillPerso_perso");

                    b.HasIndex("SkillId")
                        .HasName("fk_skillPerso_skill");

                    b.ToTable("skill_perso");
                });

            modelBuilder.Entity("DTM.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int>("PersoId")
                        .HasColumnName("Perso_Id")
                        .HasColumnType("int(11)");

                    b.Property<string>("Pwd")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("PersoId")
                        .HasName("fk_users_perso");

                    b.ToTable("user");
                });

            modelBuilder.Entity("DTM.Core.Models.DemonPerso", b =>
                {
                    b.HasOne("DTM.Core.Models.Demon", "Demon")
                        .WithMany("DemonPerso")
                        .HasForeignKey("DemonId")
                        .HasConstraintName("fk_demonPerso_demon")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DTM.Core.Models.Perso", "Perso")
                        .WithMany("DemonPerso")
                        .HasForeignKey("PersoId")
                        .HasConstraintName("fk_demonPerso_perso")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DTM.Core.Models.DonPerso", b =>
                {
                    b.HasOne("DTM.Core.Models.Don", "Don")
                        .WithMany("DonPerso")
                        .HasForeignKey("DonId")
                        .HasConstraintName("fk_donPerso_don")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DTM.Core.Models.Perso", "Perso")
                        .WithMany("DonPerso")
                        .HasForeignKey("PersoId")
                        .HasConstraintName("fk_donPerso_perso")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DTM.Core.Models.ElementPerso", b =>
                {
                    b.HasOne("DTM.Core.Models.Element", "Element")
                        .WithMany("ElementPerso")
                        .HasForeignKey("ElementId")
                        .HasConstraintName("fk_elementPerso_element")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DTM.Core.Models.Perso", "Perso")
                        .WithMany("ElementPerso")
                        .HasForeignKey("PersoId")
                        .HasConstraintName("fk_elementPerso_perso")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DTM.Core.Models.Inventaire", b =>
                {
                    b.HasOne("DTM.Core.Models.Item", "Item")
                        .WithMany("Inventaire")
                        .HasForeignKey("ItemId")
                        .HasConstraintName("fk_inventaire_item")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DTM.Core.Models.Perso", "Perso")
                        .WithMany("Inventaire")
                        .HasForeignKey("PersoId")
                        .HasConstraintName("fk_inventaire_perso")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DTM.Core.Models.MetierPerso", b =>
                {
                    b.HasOne("DTM.Core.Models.Metier", "Metier")
                        .WithMany("MetierPerso")
                        .HasForeignKey("MetierId")
                        .HasConstraintName("fk_metierPerso_metier")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DTM.Core.Models.Perso", "Perso")
                        .WithMany("MetierPerso")
                        .HasForeignKey("PersoId")
                        .HasConstraintName("fk_metierPerso_perso")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DTM.Core.Models.PassifDemon", b =>
                {
                    b.HasOne("DTM.Core.Models.Demon", "Demon")
                        .WithMany("PassifDemon")
                        .HasForeignKey("DemonId")
                        .HasConstraintName("fk_passifDemon_demon")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DTM.Core.Models.Passif", "Passif")
                        .WithMany("PassifDemon")
                        .HasForeignKey("PassifId")
                        .HasConstraintName("fk_passifDemon_passif")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DTM.Core.Models.PassifPerso", b =>
                {
                    b.HasOne("DTM.Core.Models.Passif", "Passif")
                        .WithMany("PassifPerso")
                        .HasForeignKey("PassifId")
                        .HasConstraintName("fk_passifPerso_passif")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DTM.Core.Models.Perso", "Perso")
                        .WithMany("PassifPerso")
                        .HasForeignKey("PersoId")
                        .HasConstraintName("fk_passifPerso_perso")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DTM.Core.Models.SkillPerso", b =>
                {
                    b.HasOne("DTM.Core.Models.Perso", "Perso")
                        .WithMany("SkillPerso")
                        .HasForeignKey("PersoId")
                        .HasConstraintName("fk_skillPerso_perso")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DTM.Core.Models.Skill", "Skill")
                        .WithMany("SkillPerso")
                        .HasForeignKey("SkillId")
                        .HasConstraintName("fk_skillPerso_skill")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DTM.Core.Models.User", b =>
                {
                    b.HasOne("DTM.Core.Models.Perso", "Perso")
                        .WithMany("User")
                        .HasForeignKey("PersoId")
                        .HasConstraintName("fk_users_perso")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
