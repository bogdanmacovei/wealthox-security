using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wealthox.Entities;
using Wealthox.Services;

namespace Wealthox.Web.Models
{
    public class AnnouncementFilters
    {
        public int? GarageNumberOfCars { get; set; }
        public int? HeatingQuality { get; set; }
        public bool HasAirConditioning { get; set; }
        public int? BuildingType { get; set; }
        public int? HouseStyleType { get; set; }
        public int? OverallQuality { get; set; }
        public int? OverallConditions { get; set; }
        public int? ExteriorQuality { get; set; }
        public int? NumberOfBathrooms { get; set; }
        public int? NumberOfBedrooms { get; set; }
        public int? TotalNumberOfRooms { get; set; }

        public List<SelectListItem> ZoneTypeList { get; set; }

        public List<SelectListItem> BuildingTypeList { get; set; }

        public List<SelectListItem> HouseStyleTypeList { get; set; }

        public List<SelectListItem> QualityList { get; set; }

    }
}
