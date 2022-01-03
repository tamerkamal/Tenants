using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Master.Entity.Models;

namespace Master.Entity.DbContexts
{
    public partial class MasterDbContext : DbContext
    {
        public MasterDbContext()
        {
        }

        public MasterDbContext(DbContextOptions<MasterDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Subscription> Subscription { get; set; }
        public virtual DbSet<Tenant> Tenant { get; set; }
        public virtual DbSet<Tier> Tier { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=MasterDbConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ExpiresOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.HasIndex(e => e.SubDomain)
                    .HasName("UQ__Tenant__7499EE1050149404")
                    .IsUnique();

                entity.Property(e => e.CognitoApiresourceIds)
                    .IsRequired()
                    .HasColumnName("CognitoAPIResourceIds")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CognitoClientId)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CognitoDomain)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CognitoPoolArn)
                    .IsRequired()
                    .HasColumnName("CognitoPoolARN")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CognitoPoolId)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SubDomain)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tier>(entity =>
            {
                entity.Property(e => e.TierId).ValueGeneratedNever();

                entity.Property(e => e.TierDesc)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TierName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
