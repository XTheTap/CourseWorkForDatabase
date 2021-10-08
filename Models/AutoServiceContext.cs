using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AutoServiceGeniralsMotors.Models
{
    public partial class AutoServiceContext : DbContext
    {
        public AutoServiceContext()
        {
        }

        public AutoServiceContext(DbContextOptions<AutoServiceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<AutoMark> AutoMarks { get; set; }
        public virtual DbSet<Automobile> Automobiles { get; set; }
        public virtual DbSet<BodyType> BodyTypes { get; set; }
        public virtual DbSet<ImageOfCar> ImageOfCars { get; set; }
        public virtual DbSet<Promo> Promos { get; set; }
        public virtual DbSet<ServiceMerge> ServiceMerges { get; set; }
        public virtual DbSet<TypeService> TypeServices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=KOSHKA-O4KOVAYA\\SQLEXPRESS;Database=AutoService;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AutoMark>(entity =>
            {
                entity.ToTable("AutoMark");

                entity.HasIndex(e => e.MarkName, "UQ__AutoMark__2E78BFF894C090B8")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MarkName).HasMaxLength(20);
            });

            modelBuilder.Entity<Automobile>(entity =>
            {
                entity.ToTable("Automobile");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdentityUser).HasMaxLength(450);

                entity.Property(e => e.NumberAuto)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.BodyNavigation)
                    .WithMany(p => p.Automobiles)
                    .HasForeignKey(d => d.Body)
                    .HasConstraintName("FK__Automobile__Body__0F2D40CE");

                entity.HasOne(d => d.IdentityUserNavigation)
                    .WithMany(p => p.Automobiles)
                    .HasForeignKey(d => d.IdentityUser)
                    .HasConstraintName("FK__Automobil__Ident__10216507");

                entity.HasOne(d => d.MarkNavigation)
                    .WithMany(p => p.Automobiles)
                    .HasForeignKey(d => d.Mark)
                    .HasConstraintName("FK__Automobile__Mark__0E391C95");
            });

            modelBuilder.Entity<BodyType>(entity =>
            {
                entity.ToTable("BodyType");

                entity.HasIndex(e => e.BodyName, "UQ__BodyType__CF6A10ACBBDC8583")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BodyName).HasMaxLength(20);
            });

            modelBuilder.Entity<ImageOfCar>(entity =>
            {
                entity.ToTable("ImageOfCar");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AutoImage).HasColumnType("image");

                entity.HasOne(d => d.Auto)
                    .WithMany(p => p.ImageOfCars)
                    .HasForeignKey(d => d.AutoId)
                    .HasConstraintName("FK__ImageOfCa__AutoI__18B6AB08");
            });

            modelBuilder.Entity<Promo>(entity =>
            {
                entity.ToTable("Promo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PromoNumber)
                    .HasMaxLength(64)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ServiceMerge>(entity =>
            {
                entity.ToTable("ServiceMerge");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.AutomobileNavigation)
                    .WithMany(p => p.ServiceMerges)
                    .HasForeignKey(d => d.Automobile)
                    .HasConstraintName("FK__ServiceMe__Autom__14E61A24");

                entity.HasOne(d => d.TypeServiceNavigation)
                    .WithMany(p => p.ServiceMerges)
                    .HasForeignKey(d => d.TypeService)
                    .HasConstraintName("FK__ServiceMe__TypeS__15DA3E5D");
            });

            modelBuilder.Entity<TypeService>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
