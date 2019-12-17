using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Wealhtox.Entities;
using Wealthox.DataAccess.Base;
using Wealthox.DataAccess.Data;
using Wealthox.Entities;

namespace Wealthox.DataAccess.UnitOfWork
{
    public class WealthoxUnitOfWork : BaseUnitOfWork
    {
        public WealthoxUnitOfWork(WealthoxContext context)
            : base(context)
        {

        }

        private IRepository<Announcements> announcements;
        private IRepository<Cities> cities;
        private IRepository<ConstructionMaterial> constructionMaterials;
        private IRepository<Counties> counties;
        private IRepository<Filters> filters;
        private IRepository<House> houses;
        private IRepository<HouseConstructionMaterial> houseConstructionMaterials;
        private IRepository<Role> roles;
        private IRepository<SearchFilters> searchFilters;
        private IRepository<SearchHistory> searchHistories;
        private IRepository<Users> users;
        private IRepository<BuildingTypeLocalization> buildingtypes;
        private IRepository<DwellingTypeLocalization> dwellingtypes;
        private IRepository<GarageTypeLocalization> garagetypes;
        private IRepository<HeatingTypeLocalization> heatingtypes;
        private IRepository<HouseStyleLocalization> housestyles;
        private IRepository<QualityLocalization> quality;
        private IRepository<RoofStyleLocalization> roofstyles;
        private IRepository<UtilitiesLocalization> utilities;
        private IRepository<ZoneLocalization> zone;

        public IRepository<Announcements> Announcements => announcements ?? (announcements = new BaseRepository<Announcements>(DbContext));
        public IRepository<Cities> Cities => cities ?? (cities = new BaseRepository<Cities>(DbContext));
        public IRepository<ConstructionMaterial> ConstructionMaterials => constructionMaterials ?? (constructionMaterials = new BaseRepository<ConstructionMaterial>(DbContext));
        public IRepository<Counties> Counties => counties ?? (counties = new BaseRepository<Counties>(DbContext));
        public IRepository<Filters> Filters => filters ?? (filters = new BaseRepository<Filters>(DbContext));
        public IRepository<House> House => houses ?? (houses = new BaseRepository<House>(DbContext));
        public IRepository<HouseConstructionMaterial> HouseConstructionMaterials => houseConstructionMaterials ?? (houseConstructionMaterials = new BaseRepository<HouseConstructionMaterial>(DbContext));
        public IRepository<Role> Roles => roles ?? (roles = new BaseRepository<Role>(DbContext));
        public IRepository<SearchFilters> SearchFilters => searchFilters ?? (searchFilters = new BaseRepository<SearchFilters>(DbContext));
        public IRepository<SearchHistory> SearchHistories => searchHistories ?? (searchHistories = new BaseRepository<SearchHistory>(DbContext));
        public IRepository<Users> Users => users ?? (users = new BaseRepository<Users>(DbContext));
        public IRepository<BuildingTypeLocalization> BuildingTypeLocalization => buildingtypes ?? (buildingtypes = new BaseRepository<BuildingTypeLocalization>(DbContext));
        public IRepository<DwellingTypeLocalization> DwellingTypeLocalization => dwellingtypes ?? (dwellingtypes = new BaseRepository<DwellingTypeLocalization>(DbContext));
        public IRepository<GarageTypeLocalization> GarageTypeLocalization => garagetypes ?? (garagetypes = new BaseRepository<GarageTypeLocalization>(DbContext));
        public IRepository<HeatingTypeLocalization> HeatingTypeLocalization => heatingtypes ?? (heatingtypes = new BaseRepository<HeatingTypeLocalization>(DbContext));
        public IRepository<HouseStyleLocalization> HouseStyleLocalization => housestyles ?? (housestyles = new BaseRepository<HouseStyleLocalization>(DbContext));
        public IRepository<QualityLocalization> QualityLocalization => quality ?? (quality = new BaseRepository<QualityLocalization>(DbContext));
        public IRepository<RoofStyleLocalization> RoofStyleLocalization => roofstyles ?? (roofstyles = new BaseRepository<RoofStyleLocalization>(DbContext));
        public IRepository<UtilitiesLocalization> UtilitiesLocalization => utilities ?? (utilities = new BaseRepository<UtilitiesLocalization>(DbContext));
        public IRepository<ZoneLocalization> ZoneLocalization => zone ?? (zone = new BaseRepository<ZoneLocalization>(DbContext));

    }
}
