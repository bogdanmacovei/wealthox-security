using Common.Interfaces;
using System;
using System.Collections.Generic;

namespace Wealthox.Entities
{
    public partial class ConstructionMaterial : IEntity
    {
        public ConstructionMaterial()
        {
            HouseConstructionMaterial = new HashSet<HouseConstructionMaterial>();
            HouseExteriorMaterialNavigation = new HashSet<House>();
            HouseFoundationMaterialNavigation = new HashSet<House>();
            HouseRoofMaterialNavigation = new HashSet<House>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<HouseConstructionMaterial> HouseConstructionMaterial { get; set; }
        public ICollection<House> HouseExteriorMaterialNavigation { get; set; }
        public ICollection<House> HouseFoundationMaterialNavigation { get; set; }
        public ICollection<House> HouseRoofMaterialNavigation { get; set; }
    }
}
