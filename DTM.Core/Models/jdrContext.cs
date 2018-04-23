using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DTM.Core.Models
{
    public partial class JdrContext : DbContext
    {
        public virtual DbSet<Demon> Demon { get; set; }
        public virtual DbSet<DemonPerso> DemonPerso { get; set; }
        public virtual DbSet<Don> Don { get; set; }
        public virtual DbSet<DonPerso> DonPerso { get; set; }
        public virtual DbSet<Element> Element { get; set; }
        public virtual DbSet<ElementPerso> ElementPerso { get; set; }
        public virtual DbSet<Inventaire> Inventaire { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Metier> Metier { get; set; }
        public virtual DbSet<MetierPerso> MetierPerso { get; set; }
        public virtual DbSet<Passif> Passif { get; set; }
        public virtual DbSet<PassifDemon> PassifDemon { get; set; }
        public virtual DbSet<PassifPerso> PassifPerso { get; set; }
        public virtual DbSet<Perso> Perso { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<SkillPerso> SkillPerso { get; set; }
        public virtual DbSet<User> User { get; set; }

        public JdrContext() :
            base()
        {
            OnCreated();
        }

        public JdrContext(DbContextOptions<JdrContext> options) :
            base(options)
        {
            OnCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.Options.Extensions.OfType<RelationalOptionsExtension>().Any(ext => !string.IsNullOrEmpty(ext.ConnectionString) || ext.Connection != null))
            {
                optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=jdr;Uid=mj;Pwd=mj");
            }

            CustomizeConfiguration(ref optionsBuilder);
            base.OnConfiguring(optionsBuilder);
        }

        partial void CustomizeConfiguration(ref DbContextOptionsBuilder optionsBuilder);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Demon>(entity =>
            {
                entity.ToTable("demon");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DemonPerso>(entity =>
            {
                entity.ToTable("demon_perso");

                entity.HasIndex(e => e.DemonId)
                    .HasName("fk_demonPerso_demon");

                entity.HasIndex(e => e.PersoId)
                    .HasName("fk_demonPerso_perso");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DemonId)
                    .HasColumnName("Demon_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PersoId)
                    .HasColumnName("Perso_Id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Demon)
                    .WithMany(p => p.DemonPerso)
                    .HasForeignKey(d => d.DemonId)
                    .HasConstraintName("fk_demonPerso_demon");

                entity.HasOne(d => d.Perso)
                    .WithMany(p => p.DemonPerso)
                    .HasForeignKey(d => d.PersoId)
                    .HasConstraintName("fk_demonPerso_perso");
            });

            modelBuilder.Entity<Don>(entity =>
            {
                entity.ToTable("don");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Libelle)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<DonPerso>(entity =>
            {
                entity.ToTable("don_perso");

                entity.HasIndex(e => e.DonId)
                    .HasName("fk_donPerso_don");

                entity.HasIndex(e => e.PersoId)
                    .HasName("fk_donPerso_perso");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DonId)
                    .HasColumnName("Don_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PersoId)
                    .HasColumnName("Perso_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Taux).HasColumnType("int(11)");

                entity.HasOne(d => d.Don)
                    .WithMany(p => p.DonPerso)
                    .HasForeignKey(d => d.DonId)
                    .HasConstraintName("fk_donPerso_don");

                entity.HasOne(d => d.Perso)
                    .WithMany(p => p.DonPerso)
                    .HasForeignKey(d => d.PersoId)
                    .HasConstraintName("fk_donPerso_perso");
            });

            modelBuilder.Entity<Element>(entity =>
            {
                entity.ToTable("element");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Libelle)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ElementPerso>(entity =>
            {
                entity.ToTable("element_perso");

                entity.HasIndex(e => e.ElementId)
                    .HasName("fk_elementPerso_element");

                entity.HasIndex(e => e.PersoId)
                    .HasName("fk_elementPerso_perso");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ElementId)
                    .HasColumnName("Element_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PersoId)
                    .HasColumnName("Perso_Id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.ElementPerso)
                    .HasForeignKey(d => d.ElementId)
                    .HasConstraintName("fk_elementPerso_element");

                entity.HasOne(d => d.Perso)
                    .WithMany(p => p.ElementPerso)
                    .HasForeignKey(d => d.PersoId)
                    .HasConstraintName("fk_elementPerso_perso");
            });

            modelBuilder.Entity<Inventaire>(entity =>
            {
                entity.ToTable("inventaire");

                entity.HasIndex(e => e.ItemId)
                    .HasName("fk_inventaire_item");

                entity.HasIndex(e => e.PersoId)
                    .HasName("fk_inventaire_perso");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ItemId)
                    .HasColumnName("Item_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PersoId)
                    .HasColumnName("Perso_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Quantite).HasColumnType("int(11)");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Inventaire)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("fk_inventaire_item");

                entity.HasOne(d => d.Perso)
                    .WithMany(p => p.Inventaire)
                    .HasForeignKey(d => d.PersoId)
                    .HasConstraintName("fk_inventaire_perso");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("item");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Commentaire).HasMaxLength(1000);

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Prix).HasColumnType("int(11)");

                entity.Property(e => e.TypeItem)
                    .HasColumnName("Type_Item")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Metier>(entity =>
            {
                entity.ToTable("metier");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Libelle)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<MetierPerso>(entity =>
            {
                entity.ToTable("metier_perso");

                entity.HasIndex(e => e.MetierId)
                    .HasName("fk_metierPerso_metier");

                entity.HasIndex(e => e.PersoId)
                    .HasName("fk_metierPerso_perso");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Lvl).HasColumnType("int(11)");

                entity.Property(e => e.MetierId)
                    .HasColumnName("Metier_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PersoId)
                    .HasColumnName("Perso_Id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Metier)
                    .WithMany(p => p.MetierPerso)
                    .HasForeignKey(d => d.MetierId)
                    .HasConstraintName("fk_metierPerso_metier");

                entity.HasOne(d => d.Perso)
                    .WithMany(p => p.MetierPerso)
                    .HasForeignKey(d => d.PersoId)
                    .HasConstraintName("fk_metierPerso_perso");
            });

            modelBuilder.Entity<Passif>(entity =>
            {
                entity.ToTable("passif");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Libelle)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<PassifDemon>(entity =>
            {
                entity.ToTable("passif_demon");

                entity.HasIndex(e => e.DemonId)
                    .HasName("fk_passifDemon_demon");

                entity.HasIndex(e => e.PassifId)
                    .HasName("fk_passifDemon_passif");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DemonId)
                    .HasColumnName("Demon_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PassifId)
                    .HasColumnName("Passif_Id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Demon)
                    .WithMany(p => p.PassifDemon)
                    .HasForeignKey(d => d.DemonId)
                    .HasConstraintName("fk_passifDemon_demon");

                entity.HasOne(d => d.Passif)
                    .WithMany(p => p.PassifDemon)
                    .HasForeignKey(d => d.PassifId)
                    .HasConstraintName("fk_passifDemon_passif");
            });

            modelBuilder.Entity<PassifPerso>(entity =>
            {
                entity.ToTable("passif_perso");

                entity.HasIndex(e => e.PassifId)
                    .HasName("fk_passifPerso_passif");

                entity.HasIndex(e => e.PersoId)
                    .HasName("fk_passifPerso_perso");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.PassifId)
                    .HasColumnName("Passif_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PersoId)
                    .HasColumnName("Perso_Id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Passif)
                    .WithMany(p => p.PassifPerso)
                    .HasForeignKey(d => d.PassifId)
                    .HasConstraintName("fk_passifPerso_passif");

                entity.HasOne(d => d.Perso)
                    .WithMany(p => p.PassifPerso)
                    .HasForeignKey(d => d.PersoId)
                    .HasConstraintName("fk_passifPerso_perso");
            });

            modelBuilder.Entity<Perso>(entity =>
            {
                entity.ToTable("perso");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Caracs)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.Jauges)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.Lvl).HasColumnType("int(11)");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Po).HasColumnType("int(11)");

                entity.Property(e => e.Race)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Stats)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.TypePerso)
                    .HasColumnName("Type_Perso")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Xp).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("skill");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Degats).HasColumnType("char(6)");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Libelle)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Taux).HasColumnType("int(11)");
            });

            modelBuilder.Entity<SkillPerso>(entity =>
            {
                entity.ToTable("skill_perso");

                entity.HasIndex(e => e.PersoId)
                    .HasName("fk_skillPerso_perso");

                entity.HasIndex(e => e.SkillId)
                    .HasName("fk_skillPerso_skill");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.PersoId)
                    .HasColumnName("Perso_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SkillId)
                    .HasColumnName("Skill_Id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Perso)
                    .WithMany(p => p.SkillPerso)
                    .HasForeignKey(d => d.PersoId)
                    .HasConstraintName("fk_skillPerso_perso");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.SkillPerso)
                    .HasForeignKey(d => d.SkillId)
                    .HasConstraintName("fk_skillPerso_skill");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.PersoId)
                    .HasName("fk_users_perso");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.PersoId)
                    .HasColumnName("Perso_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Pwd)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Perso)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.PersoId)
                    .HasConstraintName("fk_users_perso");
            });
        }

        partial void OnCreated();
    }
}
