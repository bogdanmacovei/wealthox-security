using Common.Interfaces;
using System;
using System.Collections.Generic;

namespace Wealthox.Entities
{
    public partial class HouseConstructionMaterial : IEntity
    {
        public Guid HouseId { get; set; }
        public Guid ConstructionMaterialId { get; set; }

        public ConstructionMaterial ConstructionMaterial { get; set; }
        public House House { get; set; }
    }
}
