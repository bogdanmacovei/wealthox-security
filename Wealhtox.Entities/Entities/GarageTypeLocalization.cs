using Common.Interfaces;
using System;
using System.Collections.Generic;

namespace Wealthox.Entities
{
    public partial class GarageTypeLocalization : IEntity
    {
        public GarageTypeLocalization()
        {
            House = new HashSet<House>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<House> House { get; set; }
    }
}
