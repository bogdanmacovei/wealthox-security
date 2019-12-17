using Common.Interfaces;
using System;
using System.Collections.Generic;

namespace Wealthox.Entities
{
    public partial class House : IEntity
    {
        public House()
        {
            Announcements = new HashSet<Announcements>();
            HouseConstructionMaterial = new HashSet<HouseConstructionMaterial>();
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public bool? IsDeleted { get; set; }
        public bool? IsApproved { get; set; }
        public bool? IsAvailable { get; set; }
        public string Specifications { get; set; }
        public int? CountyId { get; set; }
        public int? CityId { get; set; }
        public int? DwellingType { get; set; }
        public int? ZoneType { get; set; }
        public int? UtilitiesType { get; set; }
        public int? BuildingType { get; set; }
        public int? HouseStyleType { get; set; }
        public int? OverallQuality { get; set; }
        public int? OverallConditions { get; set; }
        public int? YearBuilt { get; set; }
        public int? YearRemodel { get; set; }
        public int? RoofStyleType { get; set; }
        public Guid? RoofMaterial { get; set; }
        public Guid? ExteriorMaterial { get; set; }
        public int? ExteriorQuality { get; set; }
        public int? ExteriorConditions { get; set; }
        public Guid? FoundationMaterial { get; set; }
        public int? TotalBasementArea { get; set; }
        public int? HeatingType { get; set; }
        public int? HeatingQuality { get; set; }
        public bool? HasAirConditioning { get; set; }
        public int? FirstFloorArea { get; set; }
        public int? SecondFloorArea { get; set; }
        public int? NumberOfBathrooms { get; set; }
        public int? NumberOfBedrooms { get; set; }
        public int? NumberOfKitchen { get; set; }
        public int? KitchenQuality { get; set; }
        public int? TotalNumberOfRooms { get; set; }
        public int? GarageType { get; set; }
        public int? GarageYearBuilt { get; set; }
        public int? GarageNumberOfCars { get; set; }
        public int? GarageArea { get; set; }
        public int? GarageQuality { get; set; }
        public int? GarageCondition { get; set; }
        public int? PoolArea { get; set; }
        public int? PoolQuality { get; set; }
        public int? FenceQuality { get; set; }
        public int? TempIdentif { get; set; }

        public BuildingTypeLocalization BuildingTypeNavigation { get; set; }
        public Cities City { get; set; }
        public Counties County { get; set; }
        public DwellingTypeLocalization DwellingTypeNavigation { get; set; }
        public QualityLocalization ExteriorConditionsNavigation { get; set; }
        public ConstructionMaterial ExteriorMaterialNavigation { get; set; }
        public QualityLocalization ExteriorQualityNavigation { get; set; }
        public QualityLocalization FenceQualityNavigation { get; set; }
        public ConstructionMaterial FoundationMaterialNavigation { get; set; }
        public QualityLocalization GarageConditionNavigation { get; set; }
        public QualityLocalization GarageQualityNavigation { get; set; }
        public GarageTypeLocalization GarageTypeNavigation { get; set; }
        public QualityLocalization HeatingQualityNavigation { get; set; }
        public HeatingTypeLocalization HeatingTypeNavigation { get; set; }
        public HouseStyleLocalization HouseStyleTypeNavigation { get; set; }
        public QualityLocalization KitchenQualityNavigation { get; set; }
        public QualityLocalization OverallConditionsNavigation { get; set; }
        public QualityLocalization OverallQualityNavigation { get; set; }
        public QualityLocalization PoolQualityNavigation { get; set; }
        public ConstructionMaterial RoofMaterialNavigation { get; set; }
        public RoofStyleLocalization RoofStyleTypeNavigation { get; set; }
        public UtilitiesLocalization UtilitiesTypeNavigation { get; set; }
        public ZoneLocalization ZoneTypeNavigation { get; set; }
        public ICollection<Announcements> Announcements { get; set; }
        public ICollection<HouseConstructionMaterial> HouseConstructionMaterial { get; set; }

        public Users UserNavigation { get; set; }
    }
}
