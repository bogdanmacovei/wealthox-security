using System;
using System.Collections.Generic;
using System.Text;

namespace Wealthox.Entities
{
    public class SearchHistoryDTO
    {
        public float? OverallQuality { get; set; }
        public float? OverallConditions { get; set; }
        public float? TotalNumberOfRooms { get; set; }
        public float? NumberOfBedrooms { get; set; }
        public float? NumberOfBathrooms { get; set; }
        public float? GarageNumberOfCars { get; set; }
        public float? HouseStyleType { get; set; }
        public float? BuildingType { get; set; }
        public float? ExteriorQuality { get; set; }
        public float? HeatingQuality { get; set; }
        public float? HasAirConditioning { get; set; }
    }
}
