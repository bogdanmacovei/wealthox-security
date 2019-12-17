using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wealthox.Web.Models
{
    public class AddOrEditHouseVm
    {
        public AddOrEditHouseVm()
        {
            DwellingTypeList = new List<SelectListItem>();
            ZoneTypeList = new List<SelectListItem>();
            UtilitiesTypeList = new List<SelectListItem>();
            BuildingTypeList = new List<SelectListItem>();
            HouseStyleTypeList = new List<SelectListItem>();
            RoofStyleTypeList = new List<SelectListItem>();
            GarageTypeList = new List<SelectListItem>();
            HeatingTypeList = new List<SelectListItem>();
            QualityList = new List<SelectListItem>();
            ConstructionMaterials = new List<SelectListItem>();
    }
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu!")]
        public string Specifications { get; set; }
        public int? CountyId { get; set; }
        public int? CityId { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu!")]
        public int? DwellingType { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu!")]
        public int? ZoneType { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu!")]
        public int? UtilitiesType { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu!")]
        public int? BuildingType { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu!")]
        public int? HouseStyleType { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu!")]
        public int? OverallQuality { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu!")]
        public int? OverallConditions { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu!")]
        public int? YearBuilt { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu!")]
        public int? YearRemodel { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu!")]
        public int? RoofStyleType { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu!")]
        public Guid? RoofMaterial { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu!")]
        public Guid? ExteriorMaterial { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu!")]
        public int? ExteriorQuality { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu!")]
        public int? ExteriorConditions { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu!")]
        public Guid? FoundationMaterial { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu!")]
        public int? TotalBasementArea { get; set; }
        public int? HeatingType { get; set; }
        public int? HeatingQuality { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu!")]
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

        public List<SelectListItem> DwellingTypeList { get; set; }

        public List<SelectListItem> ZoneTypeList { get; set; }

        public List<SelectListItem> UtilitiesTypeList { get; set; }

        public List<SelectListItem> BuildingTypeList { get; set; }

        public List<SelectListItem> HouseStyleTypeList { get; set; }

        public List<SelectListItem> RoofStyleTypeList { get; set; }

        public List<SelectListItem> GarageTypeList { get; set; }

        public List<SelectListItem> HeatingTypeList { get; set; }

        public List<SelectListItem> QualityList { get; set; }

        public List<SelectListItem> ConstructionMaterials { get; set; }
    }
}
