using System;
using System.Collections.Generic;
using System.Text;

namespace Wealthox.Entities
{
    public class HouseInfo
    {

        public HouseInfo()
        {
            DwellingTypes = new List<DwellingTypeLocalization>();
            Zone = new List<ZoneLocalization>();
            Utilities = new List<UtilitiesLocalization>();
            BuildingTypes = new List<BuildingTypeLocalization>();
            HouseStyles = new List<HouseStyleLocalization>();
            RoofStyles = new List<RoofStyleLocalization>();
            GarageTypes = new List<GarageTypeLocalization>();
            HeatingTypes = new List<HeatingTypeLocalization>();
            Qualities = new List<QualityLocalization>();
            ConstructionMaterials = new List<ConstructionMaterial>();
        }

        public List<DwellingTypeLocalization> DwellingTypes { get; set; }

        public List<ZoneLocalization> Zone { get; set;}

        public List<UtilitiesLocalization> Utilities { get; set; }

        public List<BuildingTypeLocalization> BuildingTypes { get; set; }

        public List<HouseStyleLocalization> HouseStyles { get; set; }

        public List<RoofStyleLocalization> RoofStyles { get; set; }

        public List<GarageTypeLocalization> GarageTypes { get; set; }

        public List<HeatingTypeLocalization> HeatingTypes { get; set; }

        public List<QualityLocalization> Qualities { get; set; }

        public List<ConstructionMaterial> ConstructionMaterials { get; set; }

    }
}
