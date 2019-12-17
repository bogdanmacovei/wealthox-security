using Common.Interfaces;
using System;
using System.Collections.Generic;

namespace Wealthox.Entities
{
    public partial class Filters : IEntity
    {
        public Guid Id { get; set; }
        public int? Price { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public int? BedroomsNumber { get; set; }
        public int? BathroomsNumber { get; set; }
    }
}
