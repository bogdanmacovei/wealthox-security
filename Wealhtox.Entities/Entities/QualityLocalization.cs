using Common.Interfaces;
using System;
using System.Collections.Generic;

namespace Wealthox.Entities
{
    public partial class QualityLocalization : IEntity
    {
        public QualityLocalization()
        {
            HouseExteriorConditionsNavigation = new HashSet<House>();
            HouseExteriorQualityNavigation = new HashSet<House>();
            HouseFenceQualityNavigation = new HashSet<House>();
            HouseGarageConditionNavigation = new HashSet<House>();
            HouseGarageQualityNavigation = new HashSet<House>();
            HouseHeatingQualityNavigation = new HashSet<House>();
            HouseKitchenQualityNavigation = new HashSet<House>();
            HouseOverallConditionsNavigation = new HashSet<House>();
            HouseOverallQualityNavigation = new HashSet<House>();
            HousePoolQualityNavigation = new HashSet<House>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<House> HouseExteriorConditionsNavigation { get; set; }
        public ICollection<House> HouseExteriorQualityNavigation { get; set; }
        public ICollection<House> HouseFenceQualityNavigation { get; set; }
        public ICollection<House> HouseGarageConditionNavigation { get; set; }
        public ICollection<House> HouseGarageQualityNavigation { get; set; }
        public ICollection<House> HouseHeatingQualityNavigation { get; set; }
        public ICollection<House> HouseKitchenQualityNavigation { get; set; }
        public ICollection<House> HouseOverallConditionsNavigation { get; set; }
        public ICollection<House> HouseOverallQualityNavigation { get; set; }
        public ICollection<House> HousePoolQualityNavigation { get; set; }
    }
}
