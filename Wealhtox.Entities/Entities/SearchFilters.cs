using Common.Interfaces;
using System;
using System.Collections.Generic;

namespace Wealthox.Entities
{
    public partial class SearchFilters : IEntity
    {
        public Guid SearchId { get; set; }
        public Guid FilterId { get; set; }
        public DateTime? SearchDate { get; set; }
    }
}
