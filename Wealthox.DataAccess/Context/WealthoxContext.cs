using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Wealhtox.Entities;
using Wealthox.DataAccess.Logger;
using Wealthox.Entities;

namespace Wealthox.DataAccess.Data
{
    public partial class WealthoxContext : DbContext
    {
        public WealthoxContext()
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public WealthoxContext(DbContextOptions<WealthoxContext> options)
            : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Announcements> Announcements { get; set; }
        public virtual DbSet<BuildingTypeLocalization> BuildingTypeLocalization { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<ConstructionMaterial> ConstructionMaterial { get; set; }
        public virtual DbSet<Counties> Counties { get; set; }
        public virtual DbSet<DwellingTypeLocalization> DwellingTypeLocalization { get; set; }
        public virtual DbSet<Filters> Filters { get; set; }
        public virtual DbSet<GarageTypeLocalization> GarageTypeLocalization { get; set; }
        public virtual DbSet<HeatingTypeLocalization> HeatingTypeLocalization { get; set; }
        public virtual DbSet<House> House { get; set; }
        public virtual DbSet<HouseConstructionMaterial> HouseConstructionMaterial { get; set; }
        public virtual DbSet<HouseStyleLocalization> HouseStyleLocalization { get; set; }
        public virtual DbSet<QualityLocalization> QualityLocalization { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoofStyleLocalization> RoofStyleLocalization { get; set; }
        public virtual DbSet<SearchFilters> SearchFilters { get; set; }
        public virtual DbSet<SearchHistory> SearchHistory { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UtilitiesLocalization> UtilitiesLocalization { get; set; }
        public virtual DbSet<ZoneLocalization> ZoneLocalization { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(new WealthoxConsoleLoggerFactory());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Announcements>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.CreatedOn).HasColumnType("date");
                entity.Property(e => e.IsDeleted).ValueGeneratedNever();
                entity.Property(e => e.IsApproved).ValueGeneratedNever();
                entity.Property(e => e.IsSold).ValueGeneratedNever();
                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.House)
                    .WithMany(p => p.Announcements)
                    .HasForeignKey(d => d.HouseId)
                    .HasConstraintName("FK_AnnouncementHouse");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Announcements)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserAnnouncement");
            });

            modelBuilder.Entity<BuildingTypeLocalization>(entity =>
            {
                entity.ToTable("BuildingType_Localization");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cities>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.County)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountyId)
                    .HasConstraintName("FK_CityCounties");
            });

            modelBuilder.Entity<ConstructionMaterial>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Counties>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<DwellingTypeLocalization>(entity =>
            {
                entity.ToTable("DwellingType_Localization");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<Filters>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.County)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GarageTypeLocalization>(entity =>
            {
                entity.ToTable("GarageType_Localization");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HeatingTypeLocalization>(entity =>
            {
                entity.ToTable("HeatingType_Localization");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<House>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.IsApproved).ValueGeneratedNever();
                entity.Property(e => e.IsAvailable).ValueGeneratedNever();
                entity.Property(e => e.IsDeleted).ValueGeneratedNever();

                entity.Property(e => e.Specifications)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.Houses)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_User");

                entity.HasOne(d => d.BuildingTypeNavigation)
                    .WithMany(p => p.House)
                    .HasForeignKey(d => d.BuildingType)
                    .HasConstraintName("FK__House__BuildingT__4CA06362");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.House)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_HouseCity");

                entity.HasOne(d => d.County)
                    .WithMany(p => p.House)
                    .HasForeignKey(d => d.CountyId)
                    .HasConstraintName("FK_HouseCounty");

                entity.HasOne(d => d.DwellingTypeNavigation)
                    .WithMany(p => p.House)
                    .HasForeignKey(d => d.DwellingType)
                    .HasConstraintName("FK__House__DwellingT__4D94879B");

                entity.HasOne(d => d.ExteriorConditionsNavigation)
                    .WithMany(p => p.HouseExteriorConditionsNavigation)
                    .HasForeignKey(d => d.ExteriorConditions)
                    .HasConstraintName("FK__House__ExteriorC__4E88ABD4");

                entity.HasOne(d => d.ExteriorMaterialNavigation)
                    .WithMany(p => p.HouseExteriorMaterialNavigation)
                    .HasForeignKey(d => d.ExteriorMaterial)
                    .HasConstraintName("FK__House__ExteriorM__4F7CD00D");

                entity.HasOne(d => d.ExteriorQualityNavigation)
                    .WithMany(p => p.HouseExteriorQualityNavigation)
                    .HasForeignKey(d => d.ExteriorQuality)
                    .HasConstraintName("FK__House__ExteriorQ__5070F446");

                entity.HasOne(d => d.FenceQualityNavigation)
                    .WithMany(p => p.HouseFenceQualityNavigation)
                    .HasForeignKey(d => d.FenceQuality)
                    .HasConstraintName("FK__House__FenceQual__5165187F");

                entity.HasOne(d => d.FoundationMaterialNavigation)
                    .WithMany(p => p.HouseFoundationMaterialNavigation)
                    .HasForeignKey(d => d.FoundationMaterial)
                    .HasConstraintName("FK__House__Foundatio__52593CB8");

                entity.HasOne(d => d.GarageConditionNavigation)
                    .WithMany(p => p.HouseGarageConditionNavigation)
                    .HasForeignKey(d => d.GarageCondition)
                    .HasConstraintName("FK__House__GarageCon__534D60F1");

                entity.HasOne(d => d.GarageQualityNavigation)
                    .WithMany(p => p.HouseGarageQualityNavigation)
                    .HasForeignKey(d => d.GarageQuality)
                    .HasConstraintName("FK__House__GarageQua__5441852A");

                entity.HasOne(d => d.GarageTypeNavigation)
                    .WithMany(p => p.House)
                    .HasForeignKey(d => d.GarageType)
                    .HasConstraintName("FK__House__GarageTyp__5535A963");

                entity.HasOne(d => d.HeatingQualityNavigation)
                    .WithMany(p => p.HouseHeatingQualityNavigation)
                    .HasForeignKey(d => d.HeatingQuality)
                    .HasConstraintName("FK__House__HeatingQu__5629CD9C");

                entity.HasOne(d => d.HeatingTypeNavigation)
                    .WithMany(p => p.House)
                    .HasForeignKey(d => d.HeatingType)
                    .HasConstraintName("FK__House__HeatingTy__571DF1D5");

                entity.HasOne(d => d.HouseStyleTypeNavigation)
                    .WithMany(p => p.House)
                    .HasForeignKey(d => d.HouseStyleType)
                    .HasConstraintName("FK__House__HouseStyl__5812160E");

                entity.HasOne(d => d.KitchenQualityNavigation)
                    .WithMany(p => p.HouseKitchenQualityNavigation)
                    .HasForeignKey(d => d.KitchenQuality)
                    .HasConstraintName("FK__House__KitchenQu__59063A47");

                entity.HasOne(d => d.OverallConditionsNavigation)
                    .WithMany(p => p.HouseOverallConditionsNavigation)
                    .HasForeignKey(d => d.OverallConditions)
                    .HasConstraintName("FK__House__OverallCo__59FA5E80");

                entity.HasOne(d => d.OverallQualityNavigation)
                    .WithMany(p => p.HouseOverallQualityNavigation)
                    .HasForeignKey(d => d.OverallQuality)
                    .HasConstraintName("FK__House__OverallQu__5AEE82B9");

                entity.HasOne(d => d.PoolQualityNavigation)
                    .WithMany(p => p.HousePoolQualityNavigation)
                    .HasForeignKey(d => d.PoolQuality)
                    .HasConstraintName("FK__House__PoolQuali__5BE2A6F2");

                entity.HasOne(d => d.RoofMaterialNavigation)
                    .WithMany(p => p.HouseRoofMaterialNavigation)
                    .HasForeignKey(d => d.RoofMaterial)
                    .HasConstraintName("FK__House__RoofMater__5CD6CB2B");

                entity.HasOne(d => d.RoofStyleTypeNavigation)
                    .WithMany(p => p.House)
                    .HasForeignKey(d => d.RoofStyleType)
                    .HasConstraintName("FK__House__RoofStyle__5DCAEF64");

                entity.HasOne(d => d.UtilitiesTypeNavigation)
                    .WithMany(p => p.House)
                    .HasForeignKey(d => d.UtilitiesType)
                    .HasConstraintName("FK__House__Utilities__5EBF139D");

                entity.HasOne(d => d.ZoneTypeNavigation)
                    .WithMany(p => p.House)
                    .HasForeignKey(d => d.ZoneType)
                    .HasConstraintName("FK__House__ZoneType__5FB337D6");
            });

            modelBuilder.Entity<HouseConstructionMaterial>(entity =>
            {
                entity.HasKey(e => new { e.HouseId, e.ConstructionMaterialId });

                entity.ToTable("House_ConstructionMaterial");

                entity.HasOne(d => d.ConstructionMaterial)
                    .WithMany(p => p.HouseConstructionMaterial)
                    .HasForeignKey(d => d.ConstructionMaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConstructionHouse");

                entity.HasOne(d => d.House)
                    .WithMany(p => p.HouseConstructionMaterial)
                    .HasForeignKey(d => d.HouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HouseConstruction");
            });

            modelBuilder.Entity<HouseStyleLocalization>(entity =>
            {
                entity.ToTable("HouseStyle_Localization");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<QualityLocalization>(entity =>
            {
                entity.ToTable("Quality_Localization");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RoofStyleLocalization>(entity =>
            {
                entity.ToTable("RoofStyle_Localization");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SearchFilters>(entity =>
            {
                entity.HasKey(e => new { e.SearchId, e.FilterId });

                entity.ToTable("Search_Filters");

                entity.Property(e => e.SearchDate).HasColumnType("date");
            });

            modelBuilder.Entity<SearchHistory>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.SearchDate).HasColumnType("date");

                entity.Property(e => e.OverallQuality).ValueGeneratedNever();
                entity.Property(e => e.OverallConditions).ValueGeneratedNever();
                entity.Property(e => e.TotalNumberOfRooms).ValueGeneratedNever();
                entity.Property(e => e.NumberOfBedrooms).ValueGeneratedNever();
                entity.Property(e => e.NumberOfBathrooms).ValueGeneratedNever();
                entity.Property(e => e.GarageNumberOfCars).ValueGeneratedNever();
                entity.Property(e => e.HouseStyleType).ValueGeneratedNever();
                entity.Property(e => e.BuildingType).ValueGeneratedNever();
                entity.Property(e => e.ExteriorQuality).ValueGeneratedNever();
                entity.Property(e => e.HeatingQuality).ValueGeneratedNever();
                entity.Property(e => e.HasAirConditioning).ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SearchHistory)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserSearch");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RegisterDate).HasColumnType("date");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole");
            });

            modelBuilder.Entity<UtilitiesLocalization>(entity =>
            {
                entity.ToTable("Utilities_Localization");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ZoneLocalization>(entity =>
            {
                entity.ToTable("Zone_Localization");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
