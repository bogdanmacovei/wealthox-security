using Common.Interfaces;
using System;
using System.Collections.Generic;

namespace Wealthox.Entities
{
    public partial class Cities : IEntity
    {
        public Cities()
        {
            House = new HashSet<House>();
        }

        public int Id { get; set; }
        public int? CountyId { get; set; }
        public string Name { get; set; }

        public Counties County { get; set; }
        public ICollection<House> House { get; set; }
    }
}
