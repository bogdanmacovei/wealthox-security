using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Wealthox.Web.Models.Admin
{
    public class FiltersPredictionVm
    {
        [DisplayName("Overall quality")]
        public int? OverallQuality { get; set; }
        public List<SelectListItem> OverallQualityList { get; set; }

        [DisplayName("Overall conditions")]
        public int? OverallConditions { get; set; }
        public List<SelectListItem> OverallConditionsList { get; set; }

        [DisplayName("Year built")]
        public int? YearBuilt { get; set; }

        [DisplayName("Year remodel")]
        public int? YearRemodel { get; set; }

        [DisplayName("Exterior quality")]
        public int? ExteriorQuality { get; set; }
        public List<SelectListItem> ExteriorQualityList { get; set; }

        [DisplayName("Exterior conditions")]
        public int? ExteriorConditions { get; set; }
        public List<SelectListItem> ExteriorConditionsList { get; set; }

        [DisplayName("Total basement area")]
        public int? TotalBasementArea { get; set; }

        [DisplayName("Heating quality")]
        public int? HeatingQuality { get; set; }
        public List<SelectListItem> HeatingQualityList { get; set; }

        [DisplayName("Has air conditioning")]
        public int? HasAirConditioning { get; set; }
        public List<SelectListItem> HasAirConditioningList { get; set; }

        [DisplayName("First floor area")]
        public int? FirstFloorArea { get; set; }

        [DisplayName("Second floor area")]
        public int? SecondFloorArea { get; set; }

        [DisplayName("Number of bathrooms")]
        public int? NumberOfBathrooms { get; set; }

        [DisplayName("Number of bedrooms")]
        public int? NumberOfBedrooms { get; set; }

        [DisplayName("Number of kitchens")]
        public int? NumberOfKitchens { get; set; }

        [DisplayName("Kitchen quality")]
        public int? KitchenQuality { get; set; }
        public List<SelectListItem> KitchenQualityList { get; set; }

        [DisplayName("Total number of rooms")]
        public int? TotalNumberOfRooms { get; set; }

        [DisplayName("Garage year built")]
        public int? GarageYearBuilt { get; set; }

        [DisplayName("Garage number of cars")]
        public int? GarageNumberOfCars { get; set; }

        [DisplayName("Garage area")]
        public int? GarageArea { get; set; }

        [DisplayName("Garage quality")]
        public int? GarageQuality { get; set; }
        public List<SelectListItem> GarageQualityList { get; set; }

        [DisplayName("Garage condition")]
        public int? GarageCondition { get; set; }
        public List<SelectListItem> GarageConditionList { get; set; }

        [DisplayName("Pool area")]
        public int? PoolArea { get; set; }

        [DisplayName("Pool quality")]
        public int? PoolQuality { get; set; }
        public List<SelectListItem> PoolQualityList { get; set; }

        [DisplayName("Fence quality")]
        public int? FenceQuality { get; set; }
        public List<SelectListItem> FenceQualityList { get; set; }
    }
}
