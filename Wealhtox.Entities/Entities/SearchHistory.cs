using Common.Interfaces;
using System;
using System.Collections.Generic;

namespace Wealthox.Entities
{
    public partial class SearchHistory : IEntity
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public DateTime? SearchDate { get; set; }

        public int? OverallQuality { get; set; }

        public int? OverallConditions { get; set; }
        public int? TotalNumberOfRooms { get; set; }
        public int? NumberOfBedrooms { get; set; }
        public int? NumberOfBathrooms { get; set; }
        public int? GarageNumberOfCars { get; set; }
        public int? HouseStyleType { get; set; }
        public int? BuildingType { get; set; }
        public int? ExteriorQuality { get; set; }
        public int? HeatingQuality { get; set; }
        public bool? HasAirConditioning { get; set; }

        public Users User { get; set; }
    }
}
