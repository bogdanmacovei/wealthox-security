using Common.Interfaces;
using System;
using System.Collections.Generic;

namespace Wealthox.Entities
{
    public partial class HouseStyleLocalization : IEntity
    {
        public HouseStyleLocalization()
        {
            House = new HashSet<House>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<House> House { get; set; }
    }
}
