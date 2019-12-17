using Common.Interfaces;
using System;
using System.Collections.Generic;

namespace Wealthox.Entities
{
    public partial class Counties : IEntity
    {
        public Counties()
        {
            Cities = new HashSet<Cities>();
            House = new HashSet<House>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Cities> Cities { get; set; }
        public ICollection<House> House { get; set; }
    }
}
